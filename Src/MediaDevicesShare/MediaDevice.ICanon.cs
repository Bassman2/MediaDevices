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

        mainWorker.Invoke(() => ProtocolHandler.Capture(this.device!));
    }

    //Guid wpdDevicePropertiesGuid = new Guid("1f6b2299-9e76-43c8-a2ec-eeef43358afc");

    //// Canon PTP/MTP Extension Property Code for OwnerName is typically 0xD501 (or 54529)
    //int canonOwnerNameId = 0xD501;

    internal string? ownerName = null;
    string? ICanonMediaDevice.OwnerName
    {
        get => ownerName; 
        set { }
    }


    // 0xD502 (Artist/Author)
    internal string? artistAuthor = null;
    string? ICanonMediaDevice.ArtistAuthor
    {
        get => artistAuthor;
        set { }
    }

    //0xD503 (Copyright)
    private string? copyright = null;
    string? ICanonMediaDevice.Copyright
    {
        get => copyright; 
        set { }
    }

   
        
       
}
