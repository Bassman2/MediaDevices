using System.Collections.Concurrent;

namespace MediaDevices.ProtocolStack;

internal partial class TransportLayerLinux : ITransportLayer, IDisposable
{

    private const int O_RDWR = 2;

    // Instanzvariablen
    private int deviceFd = -1;
    private readonly uint endpointIn;
    private readonly uint endpointOut;
    private readonly uint endpointInterruptIn;
    private readonly uint interfaceNumber;

    private readonly ConcurrentDictionary<uint, (MtpTransactionResult Result, TaskCompletionSource<MtpTransactionResult> Tcs)> pendingTransactions = new();

    private uint globalTransactionId = 0;  

    private Thread? receiveThread;
    private Thread? eventReceiveThread; //  separater Thread für MTP-Events

    private bool isRunning;
    private readonly object lockObject = new();

    //public event Action<MtpContainerHeader, byte[]>? PacketReceived;
    public event Action<Exception>? ErrorOccurred;

    public event Action<Events, uint[]>? EventReceived;

    public TransportLayerLinux(string devicePath, uint interfaceNumber, uint epIn, uint epOut, uint epInterruptIn)
    {
        this.interfaceNumber = interfaceNumber;
        endpointIn = epIn;
        endpointOut = epOut;
        endpointInterruptIn = epInterruptIn;

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

            receiveThread = new Thread(ReceiveLoop) { IsBackground = true, Name = "MTP_Bulk_Receive_Thread" };
            receiveThread.Start();

            eventReceiveThread = new Thread(EventReceiveLoop) { IsBackground = true, Name = "MTP_Interrupt_Event_Thread" };
            eventReceiveThread.Start();
        }
    }

    public void Disconnect()
    {
        lock (lockObject)
        {
            if (!isRunning) return;
            isRunning = false;
        }
        receiveThread?.Join(1000);
        eventReceiveThread?.Join(1000);
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

    #region Download

    /// <summary>
    /// Lädt eine Datei anhand ihres ObjectHandles vom Gerät direkt in einen beschreibbaren Stream herunter.
    /// </summary>
    public async Task DownloadAsync(uint objectHandle, Stream destinationStream, CancellationToken cancellationToken = default)
    {
        if (destinationStream == null) throw new ArgumentNullException(nameof(destinationStream));
        if (!destinationStream.CanWrite) throw new ArgumentException("Der Zielstream muss beschreibbar sein.", nameof(destinationStream));

        uint txId = Interlocked.Increment(ref globalTransactionId);
        var tcs = new TaskCompletionSource<MtpTransactionResult>(TaskCreationOptions.RunContinuationsAsynchronously);

        var resultPlaceholder = new MtpTransactionResult
        {
            TargetDownloadStream = destinationStream // Hier dem ReceiveThread den Stream übergeben
        };

        pendingTransactions[txId] = (resultPlaceholder, tcs);

        using var registration = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken));

        try
        {
            // Sende den GetObject-Befehl mit dem ObjectHandle als Parameter
            byte[] cmdPacket = PackageCommand(OperationCodes.GetObject, txId, [objectHandle]);
            WriteBulk(cmdPacket);

            // Der ReceiveThread übernimmt jetzt das automatische Schreiben in den destinationStream.
            // Wir warten hier einfach, bis die Response-Phase abgeschlossen ist.
            MtpTransactionResult response = await tcs.Task;

            if (response.ResponseCode != MtpResponseCode.OK)
            {
                throw new IOException($"MTP GetObject fehlgeschlagen mit Code: {response.ResponseCode}");
            }
        }
        finally
        {
            pendingTransactions.TryRemove(txId, out _);
        }
    }



    #endregion

    #region Upload

    public async Task UploadAsync(Stream sourceStream, uint streamSize, string remoteFileName, uint targetFolderHandle = 0xFFFFFFFF, CancellationToken cancellationToken = default)
    {
        // --- SCHRITT 1: SendObjectInfo (Metadaten übermitteln wie bisher) ---
        uint txId = Interlocked.Increment(ref globalTransactionId);
        var tcs = new TaskCompletionSource<MtpTransactionResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        pendingTransactions[txId] = (new MtpTransactionResult(), tcs);

        try
        {
            uint[] infoParams = [0x00000000, targetFolderHandle];
            byte[] objectInfoDataset = CreateObjectInfoDataset(targetFolderHandle, streamSize, MtpObjectFormat.Undefined, remoteFileName);

            WriteBulk(PackageCommand(OperationCodes.SendObjectInfo, txId, infoParams));
            WriteBulk(PackageData(OperationCodes.SendObjectInfo, txId, objectInfoDataset));

            MtpTransactionResult infoResponse = await tcs.Task;
            if (infoResponse.ResponseCode != MtpResponseCode.OK)
                throw new IOException($"SendObjectInfo fehlgeschlagen: {infoResponse.ResponseCode}");

            // --- SCHRITT 2: SendObject (Nutzdaten per Transport-Streamer senden) ---
            txId = Interlocked.Increment(ref globalTransactionId);
            tcs = new TaskCompletionSource<MtpTransactionResult>(TaskCreationOptions.RunContinuationsAsynchronously);
            pendingTransactions[txId] = (new MtpTransactionResult(), tcs);

            // Command senden
            WriteBulk(PackageCommand(OperationCodes.SendObject, txId, null));

            // NEU: Rufe die Streaming-Methode der Transportschicht auf
            await StreamBulkOutAsync(sourceStream, streamSize, OperationCodes.SendObject, txId, cancellationToken);

            // Auf Bestätigung des Geräts warten
            MtpTransactionResult finalResponse = await tcs.Task;
            if (finalResponse.ResponseCode != MtpResponseCode.OK)
            {
                throw new IOException($"Streaming fehlgeschlagen bei SendObject: {finalResponse.ResponseCode}");
            }

            Console.WriteLine($"Stream erfolgreich als '{remoteFileName}' hochgeladen.");
        }
        finally
        {
            pendingTransactions.TryRemove(txId, out _);
        }
    }

    #endregion

    private static byte[] CreateObjectInfoDataset(uint parentHandle, uint fileSize, MtpObjectFormat format, string fileName)
    {
        using MemoryStream ms = new();
        using BinaryWriter writer = new(ms);

        writer.Write((uint)0x00000000); // StorageID (0x00000000 = Standard-Speicher)
        writer.Write((ushort)format);    // Object Format
        writer.Write((ushort)0x0000);   // Protection Status (0 = None)
        writer.Write(fileSize);         // Object Size (4 Bytes)

        // Thumbing/Format-Spezifische Felder (für normale Dateien mit 0 füllen)
        writer.Write((ushort)0); writer.Write((uint)0); writer.Write((uint)0);
        writer.Write((uint)0); writer.Write((uint)0); writer.Write((uint)0);
        writer.Write((uint)0);

        // Dateiname als MTP-String (Länge in Zeichen inkl. Null-Terminator + UTF-16 Bytes)
        if (string.IsNullOrEmpty(fileName))
        {
            writer.Write((byte)0);
        }
        else
        {
            writer.Write((byte)(fileName.Length + 1)); // Anzahl Zeichen inkl. \0
            byte[] stringBytes = System.Text.Encoding.Unicode.GetBytes(fileName);
            writer.Write(stringBytes);
            writer.Write((ushort)0); // Null-Terminator (\0)
        }

        // Datumsfelder (können leer gelassen werden: nur ein 0-Byte jeweils)
        writer.Write((byte)0); // Date Created
        writer.Write((byte)0); // Date Modified
        writer.Write((byte)0); // Keywords

        return ms.ToArray();
    }

    private byte[] PackageData(OperationCodes opCode, uint transactionId, byte[] payload)
    {
        uint totalLength = (uint)(12 + payload.Length);
        using MemoryStream ms = new();
        using BinaryWriter writer = new(ms);

        writer.Write(totalLength);
        writer.Write((ushort)MtpHeaderType.Data);
        writer.Write((ushort)opCode);
        writer.Write(transactionId);
        writer.Write(payload);

        return ms.ToArray();
    }

    public async Task StreamBulkOutAsync(Stream dataStream, uint contentSize, OperationCodes opCode, uint transactionId, CancellationToken cancellationToken = default)
    {
        if (dataStream == null) throw new ArgumentNullException(nameof(dataStream));

        // 1. MTP-Daten-Header bauen (12 Bytes)
        // Gesamtlänge = 12 Bytes Header + Inhaltsgröße
        uint totalDataLength = 12 + contentSize;

        using (MemoryStream headerMs = new())
        using (BinaryWriter headerWriter = new(headerMs))
        {
            headerWriter.Write(totalDataLength);
            headerWriter.Write((ushort)MtpHeaderType.Data);
            headerWriter.Write((ushort)opCode);
            headerWriter.Write(transactionId);

            // Header an das USB-Gerät senden
            Write(headerMs.ToArray());
        }

        // 2. Stream blockweise lesen und direkt an USB übergeben (64 KB Chunks)
        byte[] buffer = new byte[65536];
        uint totalBytesSent = 0;

        while (totalBytesSent < contentSize)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Berechne, wie viel maximal noch gelesen werden darf
            int bytesToRead = (int)Math.Min(buffer.Length, contentSize - totalBytesSent);

            int bytesRead = await dataStream.ReadAsync(buffer, 0, bytesToRead, cancellationToken);
            if (bytesRead <= 0)
            {
                throw new EndOfStreamException($"Der Datenstrom endete unerwartet bei {totalBytesSent} von {contentSize} Bytes.");
            }

            // Wir erstellen ein exakt passendes "Sichtfenster" auf die gelesenen Bytes,
            // ohne ein neues Array im RAM zu allozieren.
            ReadOnlySpan<byte> chunkSlice = new ReadOnlySpan<byte>(buffer, 0, bytesRead);

            // Aufruf der neuen WriteBulk-Methode
            WriteBulk(chunkSlice);

            // Direktes Schreiben des Chunks über ioctl auf das USB-Gerät
            // Write(buffer, 0, bytesRead);

            totalBytesSent += (uint)bytesRead;
        }
    }

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

    public unsafe void WriteBulk(ReadOnlySpan<byte> buffer)
    {
        if (buffer.IsEmpty) return;

        // Pinne den Span fixiert im Speicher, damit der GC ihn während des Systemaufrufs nicht verschiebt
        fixed (byte* ptr = &MemoryMarshal.GetReference(buffer))
        {
            UsbdevfsBulktransfer transfer = new() { Ep = endpointOut, Len = (uint)buffer.Length, Timeout = 5000, Data = (IntPtr)ptr };

            // Direkter nativer Aufruf in den Linux-Kernel via ioctl
            int result = IoctlBulk(deviceFd, USBDEVFS_BULK, ref transfer);
            if (result < 0)
            {
                int errno = Marshal.GetLastPInvokeError();
                throw new IOException($"Nativer USB-Schreibfehler (Bulk Out). Errno: {errno}");
            }
        }
    }

    private void ReceiveLoop()
    {
        while (isRunning)
        {
            try
            {
                // 1. Hole die ersten 4 Bytes (Länge)
                byte[]? lengthBytes = ReadExact(4);
                if (lengthBytes == null) break;

                uint packetLength = BitConverter.ToUInt32(lengthBytes, 0);
                if (packetLength < 12) continue;

                // 2. Hole die restlichen 8 Bytes des MTP-Headers (Typ, Code/OpCode, TxID)
                byte[]? headerRest = ReadExact(8);
                if (headerRest == null) break;

                // Header manuell zusammenbauen, da wir ihn stückweise gelesen haben
                byte[] fullHeaderBytes = new byte[12];
                Buffer.BlockCopy(lengthBytes, 0, fullHeaderBytes, 0, 4);
                Buffer.BlockCopy(headerRest, 0, fullHeaderBytes, 4, 8);
                MtpContainerHeader header = UnpackageHeader(fullHeaderBytes);

                uint payloadLength = packetLength - 12;

                // Prüfen, ob eine Transaktion auf diese ID wartet
                if (pendingTransactions.TryGetValue(header.TransactionId, out var tx))
                {
                    if (header.Type == MtpHeaderType.Data)
                    {
                        // --- FALL A: Es ist ein Download-Stream hinterlegt ---
                        if (tx.Result.TargetDownloadStream != null)
                        {
                            uint bytesRemaining = payloadLength;
                            byte[] buffer = new byte[65536]; // 64 KB temporärer Lese-Puffer

                            while (bytesRemaining > 0 && isRunning)
                            {
                                int toRead = (int)Math.Min(buffer.Length, bytesRemaining);
                                byte[]? chunk = ReadExact(toRead);
                                if (chunk == null) throw new IOException("USB-Verbindung während des Downloads abgebrochen.");

                                // Direkt in den Zielstream (z.B. die Festplatte) schreiben
                                tx.Result.TargetDownloadStream.Write(chunk, 0, chunk.Length);
                                bytesRemaining -= (uint)chunk.Length;
                            }

                            // Wichtig: Wir springen direkt zum nächsten Paket (warten auf Response)
                            continue;
                        }

                        // --- FALL B: Normaler kleiner Daten-Payload (wie GetDeviceInfo) ---
                        byte[]? payload = ReadExact((int)payloadLength);
                        if (payload == null) break;
                        tx.Result.Data = payload;
                        continue;
                    }
                    else if (header.Type == MtpHeaderType.Response)
                    {
                        tx.Result.ResponseCode = header.Code;
                        tx.Tcs.TrySetResult(tx.Result);
                        continue;
                    }
                }

                // Falls das Paket zu keiner aktiven Transaktion gehört (z.B. Events oder unbenutzt)
                if (payloadLength > 0)
                {
                    ReadExact((int)payloadLength); // Daten verwerfen
                }
            }
            catch (Exception ex)
            {
                if (isRunning) ErrorOccurred?.Invoke(ex);
                break;
            }
        }
        /*
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
        */
    }

    private void EventReceiveLoop()
    {
        // Puffergröße für MTP-Events ist klein. Standard-Event-Container hat 12 Bytes Header 
        // + maximal 3 Parameter à 4 Bytes = 24 Bytes maximale Puffergröße.
        byte[] eventBuffer = new byte[64];

        while (isRunning)
        {
            GCHandle handle = GCHandle.Alloc(eventBuffer, GCHandleType.Pinned);
            try
            {
                UsbdevfsBulktransfer transfer = new()
                {
                    Ep = endpointInterruptIn, // Liest vom Interrupt-Endpoint!
                    Len = (uint)eventBuffer.Length,
                    Timeout = 1000, // Prüft jede Sekunde, ob der Thread gestoppt werden soll
                    Data = handle.AddrOfPinnedObject()
                };

                // Linux nutzt intern USBDEVFS_BULK auch für Interrupt-Abfragen
                int result = IoctlBulk(deviceFd, USBDEVFS_BULK, ref transfer);

                if (result < 0)
                {
                    int errno = Marshal.GetLastPInvokeError();
                    if (errno == 110) continue; // ETIMEDOUT (Kein Event registriert, Schleife läuft weiter)

                    break; // Schwerwiegender Fehler oder USB-Kabel gezogen
                }

                if (result >= 12) // Ein gültiger MTP-Header muss mindestens 12 Bytes haben
                {
                    // Erstelle ein exaktes Array für das empfangene Event-Paket
                    byte[] rawPacket = new byte[result];
                    Buffer.BlockCopy(eventBuffer, 0, rawPacket, 0, result);

                    // Paket auspacken
                    MtpContainerHeader header = UnpackageHeader(rawPacket);

                    if (header.Type == MtpHeaderType.Event)
                    {
                        Events eventCode = (Events)header.Code;

                        // Parameter extrahieren (Nutzdaten nach den ersten 12 Bytes des Headers)
                        int payloadLen = result - 12;
                        uint[] eventParameters = new uint[payloadLen / 4];
                        for (int i = 0; i < eventParameters.Length; i++)
                        {
                            eventParameters[i] = BitConverter.ToUInt32(rawPacket, 12 + (i * 4));
                        }

                        // Event asynchron an die Anwendung weitergeben
                        Task.Run(() => EventReceived?.Invoke(eventCode, eventParameters));
                    }
                }
            }
            catch (Exception ex)
            {
                if (isRunning) ErrorOccurred?.Invoke(ex);
                break;
            }
            finally
            {
                handle.Free();
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
