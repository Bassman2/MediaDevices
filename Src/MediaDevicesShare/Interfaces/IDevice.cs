namespace MediaDevices.Interfaces;

internal interface IDevice : IDisposable
{
    void Connect(MediaDeviceAccess access, MediaDeviceShare share, bool enableCache);

    void Disconnect();

    void Cancel();

    #region Capabilities

    IEnumerable<Commands> SupportedCommands();

    IEnumerable<MediaProperty> CommandOptions(Commands command);

    IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory);

    IEnumerable<ContentType> SupportedContentTypes(FunctionalCategory functionalCategory);

    IEnumerable<Formats> SupportedFormats(ContentType functionalCategory);

    IEnumerable<string> SupportedFormatProperties(Formats format);


    IEnumerable<Events> SupportedEvents();

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

    IEnumerable<string> EnumerateDirectories(string path);
    IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly);
    IEnumerable<string> EnumerateFiles(string path);
    IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly);
    IEnumerable<string> EnumerateFileSystemEntries(string path);
    IEnumerable<string> EnumerateFileSystemEntries(string path, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly);

    bool DirectoryExists(string path);

    void CreateDirectory(string path);

    void DeleteDirectory(string path, bool recursive = false);

    bool FileExists(string path);

    void DeleteFile(string path);

    void Rename(string path, string newName);

    #endregion


}
