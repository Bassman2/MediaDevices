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

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesSony>(this.device!));
    }

    SonyCompression? ISonyMediaDevice.Compression
    {
        get => (SonyCompression?)GetDevicePropertyUInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, (uint?)value);
    }
}
