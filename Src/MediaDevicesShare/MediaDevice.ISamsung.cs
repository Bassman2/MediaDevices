namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : ISamsungMediaDevice
{
    IEnumerable<OpCodesSamsung> ISamsungMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => WpdDevice.VendorOpcodes<OpCodesSamsung>(this.device!));
    }
}
