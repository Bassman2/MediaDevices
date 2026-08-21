namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : INikonMediaDevice
{
    IEnumerable<OpCodesNikon> INikonMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesNikon>(this.device!));
    }
}
