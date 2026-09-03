using System;
using System.Collections.Generic;
using System.Text;

namespace MediaDevices;

// Explicit Interface Implementation

partial class MediaDevice : ISonyMediaDevice
{
    IEnumerable<OpCodesSony> ISonyMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.VendorOpcodes().Select(o => (OpCodesSony)o));
    }

    SonyCompression? ISonyMediaDevice.Compression
    {
        get => (SonyCompression?)GetDevicePropertyUInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, (uint?)value);
    }
}
