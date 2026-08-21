namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : ICanonMediaDevice
{
    IEnumerable<OpCodesCanon> ICanonMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesCanon>(this.device!));
    }
}
