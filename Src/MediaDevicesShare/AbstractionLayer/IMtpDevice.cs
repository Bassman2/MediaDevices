namespace MediaDevices.AbstractionLayer;

internal interface IMtpDevice : IDisposable
{
    string DeviceId { get; }
    string FriendlyName { get; }
    string Manufacturer { get; }

    void Connect();
    void Disconnect();

    List<string> GetStorageIds();
    List<MtpObject> GetChildren(string parentObjectId);

    void DownloadFile(string objectId, Stream destinationStream);
    void UploadFile(string parentObjectId, string fileName, Stream sourceStream);
    void DeleteObject(string objectId);
}
