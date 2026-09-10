using System.Collections.Concurrent;
using System.Diagnostics.Tracing;

namespace MediaDevices.ProtocolStack;

internal partial class TransportLayerLinux : ITransportLayer, IDisposable
{

    private const int O_RDWR = 2;

    // Instanzvariablen
    private int deviceFd = -1;
    private readonly uint endpointIn;
    private readonly uint endpointOut;
    private readonly uint interfaceNumber;

    private readonly ConcurrentDictionary<uint, (MtpTransactionResult Result, TaskCompletionSource<MtpTransactionResult> Tcs)> pendingTransactions = new();

    private uint globalTransactionId = 0;  

    private Thread? _receiveThread;
    private bool isRunning;
    private readonly object lockObject = new();

    public event Action<MtpContainerHeader, byte[]>? PacketReceived;
    public event Action<Exception>? ErrorOccurred;

    public event Action<Events, uint[]>? EventReceived;

    public TransportLayerLinux(string devicePath, uint interfaceNumber, uint epIn, uint epOut)
    {
        this.interfaceNumber = interfaceNumber;
        endpointIn = epIn;
        endpointOut = epOut;

        // 1. USB-Gerätedatei öffnen (String wird dank StringMarshalling.Utf8 sauber übergeben)
        deviceFd = Open(devicePath, O_RDWR);
        if (deviceFd < 0)
        {
            int errno = Marshal.GetLastPInvokeError(); // Nutze GetLastPInvokeError für LibraryImport
            throw new IOException($"Fehler beim Öffnen von {devicePath}. Errno: {errno}.");
        }

        // 2. Interface beanspruchen
        uint intf = this.interfaceNumber;
        if (Ioctl(deviceFd, USBDEVFS_CLAIMINTERFACE, ref intf) < 0)
        {
            int errno = Marshal.GetLastPInvokeError();
            Close(deviceFd);
            throw new IOException($"Konnte USB-Interface nicht beanspruchen. Errno: {errno}.");
        }
    }

    public void Dispose()
    {
        Disconnect();
        if (deviceFd >= 0)
        {
            uint intf = interfaceNumber;
            Ioctl(deviceFd, USBDEVFS_RELEASEINTERFACE, ref intf);
            Close(deviceFd);
            deviceFd = -1;
        }
    }

    public void Connect()
    {
        lock (lockObject)
        {
            if (isRunning) return;
            isRunning = true;
            _receiveThread = new Thread(ReceiveLoop)
            {
                IsBackground = true,
                Name = "MTP_Linux_Native_Receive"
            };
            _receiveThread.Start();
        }
    }

    public void Disconnect()
    {
        lock (lockObject)
        {
            if (!isRunning) return;
            isRunning = false;
        }
        _receiveThread?.Join(1000);
    }

    public async Task<MtpTransactionResult> SendCommandAsync(OperationCodes opCode, uint[]? parameters = null, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // Generate a unique transaction ID.
        uint transactionId = Interlocked.Increment(ref globalTransactionId);

        var tcs = new TaskCompletionSource<MtpTransactionResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        var resultPlaceholder = new MtpTransactionResult();

        // Transaktion registrieren
        pendingTransactions[transactionId] = (resultPlaceholder, tcs);

        using var registration = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken));

        try
        {
            // 2. Command-Paket bauen und absenden
            byte[] cmdPacket = PackageCommand(opCode, transactionId, parameters);
            Write(cmdPacket);
            return await tcs.Task;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        finally
        {
            // Clean up to prevent memory leaks.
            pendingTransactions.TryRemove(transactionId, out _);
        }
    }

    public abstract void ReceiveEvent(Events mtpEvent, uint[] eventData);

    private void ProcessIncomingPacket(MtpContainerHeader header, byte[] payload)
    {
        if (header.Type == MtpHeaderType.Event)
        {
            // Bei Events steht der Event-Code im Feld 'Code' des Headers
            Events eventCode = (Events)header.Code;

            // Events können bis zu 3 optionale Parameter enthalten (jeweils 4 Bytes im Payload)
            uint[] eventParameters = new uint[payload.Length / 4];
            for (int i = 0; i < eventParameters.Length; i++)
            {
                eventParameters[i] = BitConverter.ToUInt32(payload, i * 4);
            }

            // Event an die Anwendung feuern (wichtig: auf einem separaten Thread-Pool-Thread ausführen)
            Task.Run(() => EventReceived?.Invoke(eventCode, eventParameters));
            return;
        }

        // Prüfen, ob eine Transaktion auf diese ID wartet
        if (!pendingTransactions.TryGetValue(header.TransactionId, out var tx))
        {
            // Optional: Unaufgeforderte Event-Pakete abfangen (z.B. Device-Events)
            return;
        }

        if (header.Type == MtpHeaderType.Data)
        {
            // Zwischenphase: Wir haben die Daten erhalten. Wir speichern sie im Result-Objekt
            // und warten auf das finale Response-Paket.
            tx.Result.Data = payload;
        }
        else if (header.Type == MtpHeaderType.Response)
        {
            // Endphase: Die Antwort ist da. Transaktion erfolgreich abschließen.
            tx.Result.ResponseCode = header.Code;

            // Setzt das Ergebnis frei -> Der wartende 'ExecuteCommandAsync'-Task wacht auf
            tx.Tcs.TrySetResult(tx.Result);
        }
    }


    private void Write(byte[] buffer)
    {
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        try
        {
            UsbdevfsBulktransfer transfer = new()
            {
                Ep = endpointOut,
                Len = (uint)buffer.Length,
                Timeout = 5000,
                Data = handle.AddrOfPinnedObject()
            };

            int result = IoctlBulk(deviceFd, USBDEVFS_BULK, ref transfer);
            if (result < 0)
            {
                int errno = Marshal.GetLastPInvokeError();
                throw new IOException($"Nativer USB-Schreibfehler (Bulk Out). Errno: {errno}");
            }
        }
        finally
        {
            handle.Free();
        }
    }

    private void ReceiveLoop()
    {
        while (isRunning)
        {
            try
            {
                // 1. Erstes Längenfeld (4 Bytes) lesen
                byte[]? lengthBytes = ReadExact(4);
                if (lengthBytes == null) break;

                uint packetLength = BitConverter.ToUInt32(lengthBytes, 0);
                if (packetLength < 12) continue;

                // 2. Gesamtes Paket aufbauen
                byte[] fullPacket = new byte[packetLength];
                Buffer.BlockCopy(lengthBytes, 0, fullPacket, 0, 4);

                byte[]? remainingBytes = ReadExact((int)packetLength - 4);
                if (remainingBytes == null) break;
                Buffer.BlockCopy(remainingBytes, 0, fullPacket, 4, remainingBytes.Length);

                // 3. Header auswerten und an App weiterleiten
                MtpContainerHeader header = UnpackageHeader(fullPacket);
                byte[] payload = new byte[packetLength - 12];
                if (payload.Length > 0)
                {
                    Buffer.BlockCopy(fullPacket, 12, payload, 0, payload.Length);
                }

                ProcessIncomingPacket(header, payload);
            }
            catch (Exception ex)
            {
                if (isRunning) ErrorOccurred?.Invoke(ex);
                break;
            }
        }
    }

    private byte[]? ReadExact(int totalRequested)
    {
        byte[] resultBuffer = new byte[totalRequested];
        int bytesReadTotal = 0;

        while (bytesReadTotal < totalRequested && isRunning)
        {
            int chunkToRead = totalRequested - bytesReadTotal;
            byte[] tempChunk = new byte[chunkToRead];
            GCHandle handle = GCHandle.Alloc(tempChunk, GCHandleType.Pinned);

            try
            {
                UsbdevfsBulktransfer transfer = new()
                {
                    Ep = endpointIn,
                    Len = (uint)chunkToRead,
                    Timeout = 1000, // Timeout für Interruption-Checks
                    Data = handle.AddrOfPinnedObject()
                };

                int result = IoctlBulk(deviceFd, USBDEVFS_BULK, ref transfer);

                if (result < 0)
                {
                    int errno = Marshal.GetLastPInvokeError();
                    if (errno == 110) continue; // ETIMEDOUT -> Schleife wiederholen

                    return null; // Schwerer Fehler (z.B. Device disconnected)
                }

                if (result > 0)
                {
                    Buffer.BlockCopy(tempChunk, 0, resultBuffer, bytesReadTotal, result);
                    bytesReadTotal += result;
                }
            }
            finally
            {
                handle.Free();
            }
        }

        return resultBuffer;
    }

    public static MtpContainerHeader UnpackageHeader(byte[] rawData)
    {
        MtpContainerHeader header = new() { Length = 0, Type = 0, Code = 0, TransactionId = 0 };
        if (rawData == null || rawData.Length < 12) return header;

        using MemoryStream ms = new(rawData);
        using BinaryReader reader = new(ms);

        header.Length = reader.ReadUInt32();
        header.Type = (MtpHeaderType)reader.ReadUInt16();
        header.Code = (MtpResponseCode)reader.ReadUInt16();
        header.TransactionId = reader.ReadUInt32();

        return header;
    }

    public static byte[] PackageCommand(OperationCodes opCode, uint transactionId, uint[]? parameters = null)
    {
        parameters ??= Array.Empty<uint>();
        uint packetLength = 12 + ((uint)parameters.Length * 4);

        using MemoryStream ms = new();
        using BinaryWriter writer = new(ms);

        writer.Write(packetLength);
        writer.Write((ushort)MtpHeaderType.Command);
        writer.Write((ushort)opCode);
        writer.Write(transactionId);

        foreach (uint param in parameters) { writer.Write(param); }
        return ms.ToArray();
    }

    #region LibraryImport

    private const uint USBDEVFS_CLAIMINTERFACE = 0x8004550F;
    private const uint USBDEVFS_RELEASEINTERFACE = 0x80045510;
    private const uint USBDEVFS_BULK = 0xC0185502;

    [StructLayout(LayoutKind.Sequential)]
    private struct UsbdevfsBulktransfer
    {
        public uint Ep;          // Endpoint ID (z.B. 0x01 für Out, 0x81 für In)
        public uint Len;         // Länge der Daten
        public uint Timeout;     // Timeout in Millisekunden
        public IntPtr Data;      // Zeiger auf den Datenpuffer
    }

    [LibraryImport("libc", EntryPoint = "open", SetLastError = true, StringMarshalling = StringMarshalling.Utf8)]
    private static partial int Open(string pathname, int flags);

    [LibraryImport("libc", EntryPoint = "close", SetLastError = true)]
    private static partial int Close(int fd);

    [LibraryImport("libc", EntryPoint = "ioctl", SetLastError = true)]
    private static partial int Ioctl(int fd, uint request, ref uint arg);

    [LibraryImport("libc", EntryPoint = "ioctl", SetLastError = true)]
    private static partial int IoctlBulk(int fd, uint request, ref UsbdevfsBulktransfer transfer);

    #endregion


    //private IntPtr libUsbContext = IntPtr.Zero;
    //private IntPtr deviceHandle = IntPtr.Zero;


    //public byte BulkInPipe { get; set; }
    //public byte BulkOutPipe { get; set; }

    //public bool ConnectToHardware(object deviceIdentifier)
    //{
    //    var (vid, pid) = ((ushort, ushort))deviceIdentifier;
    //    if (LibUsbInit(out libUsbContext) < 0) return false;

    //    deviceHandle = LibUsbOpenDeviceWithVidPid(libUsbContext, vid, pid);
    //    if (deviceHandle == IntPtr.Zero) { LibUsbExit(libUsbContext); return false; }

    //    LibUsbClaimInterface(deviceHandle, 0);
    //    BulkOutPipe = 0x01;
    //    BulkInPipe = 0x82;
    //    return true;
    //}

    //public bool WriteRawBytes(byte[] data) => LibUsbBulkTransfer(deviceHandle, BulkOutPipe, data, data.Length, out _, 1000) == 0;

    //public byte[] ReadRawBytes(int expectedSize)
    //{
    //    byte[] buffer = new byte[expectedSize];
    //    if (LibUsbBulkTransfer(deviceHandle, BulkInPipe, buffer, buffer.Length, out int transferred, 1000) == 0)
    //    {
    //        byte[] clean = new byte[transferred]; Array.Copy(buffer, clean, transferred); return clean;
    //    }
    //    return Array.Empty<byte>();
    //}

    //public void Dispose()
    //{
    //    if (deviceHandle != IntPtr.Zero) LibUsbClose(deviceHandle);
    //    if (libUsbContext != IntPtr.Zero) LibUsbExit(libUsbContext);
    //}


    //#region LibraryImport

    //[LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_init")]
    //private static partial int LibUsbInit(out IntPtr context);

    //[LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_open_device_with_vid_pid")]
    //private static partial IntPtr LibUsbOpenDeviceWithVidPid(IntPtr context, ushort vendorId, ushort productId);

    //[LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_claim_interface")]
    //private static partial int LibUsbClaimInterface(IntPtr devHandle, int interfaceNumber);

    //[LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_bulk_transfer")]
    //private static partial int LibUsbBulkTransfer(IntPtr devHandle, byte endpoint, byte[] data, int length, out int transferred, uint timeout);

    //[LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_close")]
    //private static partial void LibUsbClose(IntPtr devHandle);

    //[LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_exit")]
    //private static partial void LibUsbExit(IntPtr context);

    //#endregion

}
