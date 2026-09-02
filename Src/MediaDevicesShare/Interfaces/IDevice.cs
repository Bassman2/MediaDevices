namespace MediaDevices.Interfaces;

internal interface IDevice : IDisposable
{
    bool IsConnected { get; }

    bool IsCaseSensitive { get; }

    void Connect(MediaDeviceAccess access, MediaDeviceShare share, bool enableCache);

    void Disconnect();

    void Cancel();

    #region Capabilities

    IEnumerable<Commands> SupportedCommands(CancellationToken cancellationToken = default);

    IEnumerable<MediaProperty> CommandOptions(Commands command, CancellationToken cancellationToken = default);

    IEnumerable<FunctionalCategory> FunctionalCategories(CancellationToken cancellationToken = default);

    IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default);

    IEnumerable<ContentType> SupportedContentTypes(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default);

    IEnumerable<Formats> SupportedFormats(ContentType functionalCategory, CancellationToken cancellationToken = default);

    IEnumerable<string> SupportedFormatProperties(Formats format, CancellationToken cancellationToken = default);


    IEnumerable<Events> SupportedEvents(CancellationToken cancellationToken = default);

    IEnumerable<(string, string)> EventOptions(Events ev);

    #endregion

    #region Commands

    void ResetDevice();

    IEnumerable<string>? GetContentLocations(ContentType contentType);

    bool Eject(string path);

    void Format(string path);
    bool SendTextSMS(string functionalObject, string recipient, string text);

    bool StillImageCaptureInitiate(string functionalObject);

    MediaStorageInfo? GetStorageInfo(string storageObjectId);

    #endregion

    #region FileSystem

    IEnumerable<string> EnumerateDirectories(string path, CancellationToken cancellationToken = default);
    IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);
    IEnumerable<string> EnumerateFiles(string path, CancellationToken cancellationToken = default);
    IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);
    IEnumerable<string> EnumerateFileSystemEntries(string path, CancellationToken cancellationToken = default);
    IEnumerable<string> EnumerateFileSystemEntries(string path, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);

    bool DirectoryExists(string path, CancellationToken cancellationToken = default);

    void CreateDirectory(string path, CancellationToken cancellationToken = default);
    void CreateDirectory(string objectId, string path, CancellationToken cancellationToken = default);

    void DeleteDirectory(string path, bool recursive = false, CancellationToken cancellationToken = default);
    void DeleteDirectoryByObjectId(string objectId, bool recursive = false, CancellationToken cancellationToken = default);

    bool FileExists(string path, CancellationToken cancellationToken = default);

    void DeleteFile(string path, CancellationToken cancellationToken = default);

    void Rename(string path, string newName, CancellationToken cancellationToken = default);

    void DownloadFile(string source, Stream stream, CancellationToken cancellationToken = default);

    void DownloadFile(string source, string destination, CancellationToken cancellationToken = default);

    void DownloadIcon(string source, Stream stream, CancellationToken cancellationToken = default);

    void DownloadIcon(string source, string destination, CancellationToken cancellationToken = default);

    void DownloadThumbnail(string source, Stream stream, CancellationToken cancellationToken = default);

    void DownloadThumbnail(string source, string destination, CancellationToken cancellationToken = default);

    void DownloadFolder(string source, string destination, bool recursive, bool ignoreExceptions, CancellationToken cancellationToken = default);


    void UploadFile(Stream stream, string destination, CancellationToken cancellationToken = default);

    void UploadFile(string source, string destination, CancellationToken cancellationToken = default);

    void UploadFolder(string source, string destination, bool recursive, bool ignoreExceptions, CancellationToken cancellationToken = default);

    MediaFileInfo GetFileInfo(string path, CancellationToken cancellationToken = default);

    MediaDirectoryInfo GetDirectoryInfo(string path, CancellationToken cancellationToken = default);

    IEnumerable<MediaDriveInfo> GetDrives(CancellationToken cancellationToken = default);

    MediaDirectoryInfo GetRootDirectory(CancellationToken cancellationToken = default);

    string GetPathFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default);

    MediaFileSystemInfo GetFileSystemInfoFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default);

    void DownloadFileFromPersistentUniqueId(string persistentUniqueId, string destination, CancellationToken cancellationToken = default);

    Stream OpenReadFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default);

    StreamReader? OpenTextFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default);

    #endregion

    #region Vendor

    IEnumerable<OpCodes> VendorOpcodes();

    IEnumerable<int> VendorExcecute(OpCodes opCode, IEnumerable<int> inputParams, out int respCode);

    IEnumerable<int> VendorExcecuteRead(OpCodes opCode, IEnumerable<int> inputParams);

    IEnumerable<int> VendorExcecuteWrite(OpCodes opCode, IEnumerable<int> inputParams);

    IEnumerable<int> VendorEndTransfer(string context, out int respCode);

    string VendorExtentionDescription();

    #endregion

    #region MediaDriveInfo

    void EjectObjectId(string objectId);
    void FormatObjectId(string objectId);
    MediaDirectoryInfo? GetParent(string objectId);

    void CopyTo(string objectId, string destFileName, bool overwrite = true);

    void CopyIconTo(string objectId, string destFileName, bool overwrite = true);

    void CopyThumbnailTo(string objectId, string destFileName, bool overwrite = true);

    Stream OpenRead(string objectId);

    Stream OpenIcon(string objectId);

    Stream OpenThumbnail(string objectId);

    StreamReader OpenText(string objectId);

    #endregion

    #region Extentions

    string? GetPropertyString(PropertyKey propertyKey);

    int? GetPropertyInt(PropertyKey propertyKey);

    uint? GetPropertyUInt(PropertyKey propertyKey);

    DateTime? GetPropertyDateTime(PropertyKey propertyKey);

    bool SetProperty(PropertyKey propertyKey, string? value);

    bool SetProperty(PropertyKey propertyKey, int? value);

    bool SetProperty(PropertyKey propertyKey, uint? value);

    bool SetProperty(PropertyKey propertyKey, DateTime? value);

    #endregion

    #region Services

    IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceType);

    void ServiceClose();

    #endregion


}