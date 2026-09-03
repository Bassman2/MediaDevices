namespace MediaDevices.Interfaces;

internal interface IDevice : IDisposable
{
    bool IsConnected { get; }

    bool IsCaseSensitive { get; }

    void Connect(MediaDeviceAccess access, MediaDeviceShare share, bool enableCache);

    void Disconnect();

    void Cancel();

    ObjectId PathToObjectId(string path, CancellationToken cancellationToken = default);

    #region Capabilities

    IEnumerable<Commands> SupportedCommands(CancellationToken cancellationToken = default);

    IEnumerable<MediaProperty> CommandOptions(Commands command, CancellationToken cancellationToken = default);

    IEnumerable<FunctionalCategory> FunctionalCategories(CancellationToken cancellationToken = default);

    IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default);

    IEnumerable<ContentType> SupportedContentTypes(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default);

    IEnumerable<Formats> SupportedFormats(ContentType functionalCategory, CancellationToken cancellationToken = default);

    IEnumerable<string> SupportedFormatProperties(Formats format, CancellationToken cancellationToken = default);


    IEnumerable<Events> SupportedEvents(CancellationToken cancellationToken = default);

    IEnumerable<(string, string)> EventOptions(Events ev, CancellationToken cancellationToken = default);

    #endregion

    #region Commands

    void ResetDevice();

    IEnumerable<string>? GetContentLocations(ContentType contentType);

    
    bool SendTextSMS(string functionalObject, string recipient, string text);

    bool StillImageCaptureInitiate(string functionalObject);

    MediaStorageInfo? GetStorageInfo(ObjectId storageObjectId);

    #endregion

    #region FileSystem

    //IEnumerable<string> EnumerateDirectories(ObjectId objectId, CancellationToken cancellationToken = default);
    //IEnumerable<string> EnumerateDirectories(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);
    //IEnumerable<string> EnumerateFiles(ObjectId objectId, CancellationToken cancellationToken = default);
    //IEnumerable<string> EnumerateFiles(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);
    //IEnumerable<string> EnumerateFileSystemEntries(ObjectId objectId, CancellationToken cancellationToken = default);
    //IEnumerable<string> EnumerateFileSystemEntries(ObjectId objectId, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);

    IEnumerable<MediaDirectoryInfo> EnumerateDirectories(ObjectId objectId, CancellationToken cancellationToken = default);
    IEnumerable<MediaDirectoryInfo> EnumerateDirectories(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);
    IEnumerable<MediaFileInfo> EnumerateFiles(ObjectId objectId, CancellationToken cancellationToken = default);
    IEnumerable<MediaFileInfo> EnumerateFiles(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);
    IEnumerable<MediaFileSystemInfo> EnumerateFileSystemEntries(ObjectId objectId, CancellationToken cancellationToken = default);
    IEnumerable<MediaFileSystemInfo> EnumerateFileSystemEntries(ObjectId objectId, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default);


    bool DirectoryExists(ObjectId objectId, CancellationToken cancellationToken = default);

    MediaDirectoryInfo CreateDirectory(ObjectId objectId, string path, CancellationToken cancellationToken = default);

    void DeleteDirectory(ObjectId objectId, bool recursive = false, CancellationToken cancellationToken = default);
   

    bool FileExists(ObjectId objectId, CancellationToken cancellationToken = default);

    void DeleteFile(ObjectId objectId, CancellationToken cancellationToken = default);

    void Rename(ObjectId objectId, string newName, CancellationToken cancellationToken = default);

    void DownloadFile(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default);

    void DownloadFile(ObjectId objectId, string destination, CancellationToken cancellationToken = default);

    void DownloadIcon(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default);

    void DownloadIcon(ObjectId objectId, string destination, CancellationToken cancellationToken = default);

    void DownloadThumbnail(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default);

    void DownloadThumbnail(ObjectId objectId, string destination, CancellationToken cancellationToken = default);

    void DownloadFolder(ObjectId objectId, string destination, bool recursive, bool ignoreExceptions, CancellationToken cancellationToken = default);


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

    IEnumerable<ushort> VendorOpcodes(CancellationToken cancellationToken = default);

    IEnumerable<int> VendorExcecute(OpCodes opCode, IEnumerable<int> inputParams, out int respCode);

    IEnumerable<int> VendorExcecuteRead(OpCodes opCode, IEnumerable<int> inputParams);

    IEnumerable<int> VendorExcecuteWrite(OpCodes opCode, IEnumerable<int> inputParams);

    IEnumerable<int> VendorEndTransfer(string context, out int respCode);

    string VendorExtentionDescription();

    #endregion

    #region MediaDriveInfo

    bool Eject(ObjectId objectId, CancellationToken cancellationToken = default);

    bool Format(ObjectId objectId, CancellationToken cancellationToken = default);

    MediaDirectoryInfo? GetParent(ObjectId objectId, CancellationToken cancellationToken = default);

    void CopyTo(ObjectId objectId, string destFileName, bool overwrite = true, CancellationToken cancellationToken = default);

    void CopyIconTo(ObjectId objectId, string destFileName, bool overwrite = true, CancellationToken cancellationToken = default);

    void CopyThumbnailTo(ObjectId objectId, string destFileName, bool overwrite = true, CancellationToken cancellationToken = default);

    Stream OpenRead(ObjectId objectId, CancellationToken cancellationToken = default);

    Stream OpenIcon(ObjectId objectId, CancellationToken cancellationToken = default);

    Stream OpenThumbnail(ObjectId objectId, CancellationToken cancellationToken = default);

    StreamReader OpenText(ObjectId objectId, CancellationToken cancellationToken = default);

    #endregion

    #region Extentions

    string? GetPropertyString(ObjectId objectId, PropertyKey propertyKey);

    int? GetPropertyInt(ObjectId objectId, PropertyKey propertyKey);

    uint? GetPropertyUInt(ObjectId objectId, PropertyKey propertyKey);

    DateTime? GetPropertyDateTime(ObjectId objectId, PropertyKey propertyKey);

    bool SetProperty(ObjectId objectId, PropertyKey propertyKey, string? value);

    bool SetProperty(ObjectId objectId, PropertyKey propertyKey, int? value);

    bool SetProperty(ObjectId objectId, PropertyKey propertyKey, uint? value);

    bool SetProperty(ObjectId objectId, PropertyKey propertyKey, DateTime? value);

    #endregion

    #region Services

    IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceType);

   // void ServiceClose();

    #endregion


}