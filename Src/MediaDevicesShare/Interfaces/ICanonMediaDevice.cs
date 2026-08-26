namespace MediaDevices;

public interface ICanonMediaDevice
{
    IEnumerable<OpCodesCanon> VendorOpcodes();

    void Capture();
    
    string? OwnerName {  get; set; }

    string? ArtistAuthor { get; set; }

    string? Copyright { get; set; }



}
