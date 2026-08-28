namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : INikonMediaDevice
{
    IEnumerable<OpCodesNikon> INikonMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesNikon>(this.device!));
    }

    int? INikonMediaDevice.ShootingMode
    {
        get => GetDevicePropertyInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, value);
    }

    string? INikonMediaDevice.ShootingBankNameA
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameA);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameA, value);
    }

    string? INikonMediaDevice.ShootingBankNameB
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameB);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameB, value);
    }

    string? INikonMediaDevice.ShootingBankNameC
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameC);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameC, value);
    }

    string? INikonMediaDevice.ShootingBankNameD
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameD);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameD, value);
    }

    void INikonMediaDevice.ResetCurrentBank() 
        => SetDeviceProperty(WPD.NikonDevicePropertyResetBank, 0);

    NikonRawCompression? INikonMediaDevice.RawCompression
    {
        get => (NikonRawCompression?)GetDevicePropertyUInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, (uint?)value);
    }
    
}
