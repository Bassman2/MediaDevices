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


}
