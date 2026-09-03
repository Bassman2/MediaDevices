namespace MediaDevices;

public interface ICanonMediaDevice
{
    IEnumerable<OpCodesCanon> VendorOpcodes();

    void Capture();

    int? ShootingMode { get; set; }


    string? OwnerName { get; set; }

    string? ArtistAuthor { get; set; }

    string? Copyright { get; set; }

    string? Serial { get; set; }

    //void TakePicture();

    //Task TakePictureAsync(CancellationToken cancellationToken = default);

    //void TakePictureAndDownload(string destination);
    
    //Task TakePictureAndDownloadAsync(string destination, CancellationToken cancellationToken = default);
}
