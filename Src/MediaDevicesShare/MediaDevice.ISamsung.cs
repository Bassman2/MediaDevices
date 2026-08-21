namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : ISamsungMediaDevice
{
    IEnumerable<OpCodesSamsung> ISamsungMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesSamsung>(this.device!));
    }
}
