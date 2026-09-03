namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : ISamsungMediaDevice
{
    IEnumerable<OpCodesSamsung> ISamsungMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.VendorOpcodes().Select(o => (OpCodesSamsung)o));
    }
}
