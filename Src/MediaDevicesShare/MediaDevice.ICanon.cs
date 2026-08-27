namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : ICanonMediaDevice
{
    IEnumerable<OpCodesCanon> ICanonMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesCanon>(this.device!));
    }

    void ICanonMediaDevice.Capture()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        //mainWorker.Invoke(() => ProtocolHandler.Capture(this.device!));
    }

    int? ICanonMediaDevice.ShootingMode
    {
        get => GetDevicePropertyInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, value);
    }


    string? ICanonMediaDevice.OwnerName
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertyOwnerName); 
        set => SetDeviceProperty(WPD.CanonDevicePropertyOwnerName, value);
    }
    
    string? ICanonMediaDevice.ArtistAuthor
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertyArtistAuthor);
        set => SetDeviceProperty(WPD.CanonDevicePropertyArtistAuthor, value);
    }

   
    string? ICanonMediaDevice.Copyright
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertyCopyright);
        set => SetDeviceProperty(WPD.CanonDevicePropertyCopyright, value);
    }

    string? ICanonMediaDevice.Serial
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertySerial);
        set => SetDeviceProperty(WPD.CanonDevicePropertySerial, value);
    }




}
