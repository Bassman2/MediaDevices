namespace MediaDevices.ProtocolStack;

internal partial class TransportLayerLinux : ITransportLayer
{
    private IntPtr libUsbContext = IntPtr.Zero;
    private IntPtr deviceHandle = IntPtr.Zero;


    public byte BulkInPipe { get; set; }
    public byte BulkOutPipe { get; set; }

    public bool ConnectToHardware(object deviceIdentifier)
    {
        var (vid, pid) = ((ushort, ushort))deviceIdentifier;
        if (LibUsbInit(out libUsbContext) < 0) return false;

        deviceHandle = LibUsbOpenDeviceWithVidPid(libUsbContext, vid, pid);
        if (deviceHandle == IntPtr.Zero) { LibUsbExit(libUsbContext); return false; }

        LibUsbClaimInterface(deviceHandle, 0);
        BulkOutPipe = 0x01;
        BulkInPipe = 0x82;
        return true;
    }

    public bool WriteRawBytes(byte[] data) => LibUsbBulkTransfer(deviceHandle, BulkOutPipe, data, data.Length, out _, 1000) == 0;

    public byte[] ReadRawBytes(int expectedSize)
    {
        byte[] buffer = new byte[expectedSize];
        if (LibUsbBulkTransfer(deviceHandle, BulkInPipe, buffer, buffer.Length, out int transferred, 1000) == 0)
        {
            byte[] clean = new byte[transferred]; Array.Copy(buffer, clean, transferred); return clean;
        }
        return Array.Empty<byte>();
    }

    public void Dispose()
    {
        if (deviceHandle != IntPtr.Zero) LibUsbClose(deviceHandle);
        if (libUsbContext != IntPtr.Zero) LibUsbExit(libUsbContext);
    }


    #region LibraryImport

    [LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_init")]
    private static partial int LibUsbInit(out IntPtr context);

    [LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_open_device_with_vid_pid")]
    private static partial IntPtr LibUsbOpenDeviceWithVidPid(IntPtr context, ushort vendorId, ushort productId);

    [LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_claim_interface")]
    private static partial int LibUsbClaimInterface(IntPtr devHandle, int interfaceNumber);

    [LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_bulk_transfer")]
    private static partial int LibUsbBulkTransfer(IntPtr devHandle, byte endpoint, byte[] data, int length, out int transferred, uint timeout);

    [LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_close")]
    private static partial void LibUsbClose(IntPtr devHandle);

    [LibraryImport("libusb-1.0.so.0", EntryPoint = "libusb_exit")]
    private static partial void LibUsbExit(IntPtr context);

    #endregion

}
