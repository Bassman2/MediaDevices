namespace MediaDevices.ProtocolStack;

internal class ApplicationLayer : ProtocolLayer, IDevice
{
    private bool isConnected;

    private readonly ITransportLayer transportLayer;

    public bool IsConnected => isConnected;

    public bool IsCaseSensitive => MediaDevice?.IsCaseSensitive ?? false;

    // Backing property - allow internal assignment by factory/creator
    public MediaDevice MediaDevice { get; }

    private uint transactionId = 0;

    public ApplicationLayer(ITransportLayer transportLayer, string usbPath, ushort manufacturerId, ushort deviceId)
        : base(transportLayer)
    {
        this.transportLayer = transportLayer;
        this.MediaDevice = new MediaDevice(this)
        {
            UsbPath = usbPath,
            ManufacturerId = (ManufacturerId)manufacturerId,
            DeviceId = deviceId
        };
        transportLayer.ConnectToHardware(usbPath);
    }

    public void GetDeviceInfo()
    {
        byte[] commandPacket = ProtocolLayer.PackageCommand(
            OperationCodes.GetDeviceInfo,
            transactionId,
            parameters: null
        );

        SendRawBytes(commandPacket);

        // 2. Data-Paket empfangen (Enthält die Geräteinformationen)
        byte[] dataBuffer = ReceiveRawBytes();
        MtpContainerHeader dataHeader = ProtocolLayer.UnpackageHeader(dataBuffer);

        if (dataHeader.Type == MtpHeaderType.Data)
        {
            // Extrahiere den Payload (die eigentlichen DeviceInfo-Bytes)
            // Die ersten 12 Bytes sind der Header, der Rest sind die Daten
            byte[] devInfoPayload = new byte[dataBuffer.Length - 12];
            Array.Copy(dataBuffer, 12, devInfoPayload, 0, devInfoPayload.Length);

            // TODO: devInfoPayload parsen (Hersteller, Modell, Seriennummer etc.)
            Console.WriteLine($"MTP-Datenpaket mit Länge {dataHeader.Length} empfangen.");
        }

        // 3. Response-Paket empfangen (Schließt die Transaktion ab)
        byte[] responseBuffer = ReceiveRawBytes();
        MtpContainerHeader responseHeader = ProtocolLayer.UnpackageHeader(responseBuffer);

        if (responseHeader.Code == MtpResponseCode.OK)
        {
            Console.WriteLine("GetDeviceInfo erfolgreich abgeschlossen!");
        }
        else
        {
            Console.WriteLine($"Fehler beim Ausführen des Befehls. Code: {responseHeader.Code}");
        }
    }

    public void Connect(MediaDeviceAccess access, MediaDeviceShare share, bool enableCache)
    {
        // Minimal connect behaviour: mark connected. Real protocol-specific logic not implemented.
        isConnected = true;
    }

    public void Disconnect()
    {
        isConnected = false;
    }

    public void Cancel()
    {
        // No-op in this default implementation.
    }

    #region Events

    public event EventHandler<MediaDeviceEventArgs>? Event;

    //public event EventHandler<ObjectAddedEventArgs>? ObjectAdded;
    //public event EventHandler<MediaDeviceEventArgs>? ObjectRemoved;
    //public event EventHandler<MediaDeviceEventArgs>? ObjectUpdated;
    //public event EventHandler<MediaDeviceEventArgs>? DeviceReset;
    //public event EventHandler<MediaDeviceEventArgs>? DeviceCapabilitiesUpdated;
    //public event EventHandler<MediaDeviceEventArgs>? StorageFormat;
    //public event EventHandler<MediaDeviceEventArgs>? ObjectTransferRequest;
    //public event EventHandler<MediaDeviceEventArgs>? DeviceRemoved;
    //public event EventHandler<MediaDeviceEventArgs>? ServiceMethodComplete;

    #endregion

    #region Capabilities

    public IEnumerable<Commands> SupportedCommands(CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: SupportedCommands not implemented.");

    public IEnumerable<MediaProperty> CommandOptions(Commands command, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: CommandOptions not implemented.");

    public IEnumerable<FunctionalCategory> FunctionalCategories(CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: FunctionalCategories not implemented.");

    public IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: FunctionalObjects not implemented.");

    public IEnumerable<ContentType> SupportedContentTypes(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: SupportedContentTypes not implemented.");

    public IEnumerable<Formats> SupportedFormats(ContentType functionalCategory, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: SupportedFormats not implemented.");

    public IEnumerable<string> SupportedFormatProperties(Formats format, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: SupportedFormatProperties not implemented.");

    public IEnumerable<Events> SupportedEvents(CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: SupportedEvents not implemented.");

    public IEnumerable<(string, string)> EventOptions(Events ev, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: EventOptions not implemented.");

    #endregion

    #region Commands

    public void ResetDevice() => throw new NotSupportedException("ApplicationLayer: ResetDevice not implemented.");

    public IEnumerable<string>? GetContentLocations(ContentType contentType) => throw new NotSupportedException("ApplicationLayer: GetContentLocations not implemented.");

    public bool SendTextSMS(string functionalObject, string recipient, string text) => throw new NotSupportedException("ApplicationLayer: SendTextSMS not implemented.");

    public bool StillImageCaptureInitiate(string functionalObject) => throw new NotSupportedException("ApplicationLayer: StillImageCaptureInitiate not implemented.");

    public MediaStorageInfo? GetStorageInfo(ObjectId storageObjectId) => throw new NotSupportedException("ApplicationLayer: GetStorageInfo not implemented.");

    #endregion

    #region FileSystem

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: EnumerateDirectories not implemented.");

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(ObjectId objectId, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: EnumerateDirectories (with pattern) not implemented.");

    public IEnumerable<MediaFileInfo> EnumerateFiles(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: EnumerateFiles not implemented.");

    public IEnumerable<MediaFileInfo> EnumerateFiles(ObjectId objectId, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: EnumerateFiles (with pattern) not implemented.");

    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemEntries(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: EnumerateFileSystemEntries not implemented.");

    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemEntries(ObjectId objectId, string? searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: EnumerateFileSystemEntries (with pattern) not implemented.");

    public bool DirectoryExists(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DirectoryExists not implemented.");

    public MediaDirectoryInfo CreateDirectory(ObjectId objectId, string path, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: CreateDirectory not implemented.");

    public void DeleteDirectory(ObjectId objectId, bool recursive = false, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DeleteDirectory not implemented.");

    public bool FileExists(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: FileExists not implemented.");

    public void DeleteFile(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DeleteFile not implemented.");

    public void Rename(ObjectId objectId, string newName, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: Rename not implemented.");

    public void DownloadFile(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadFile not implemented.");

    public void DownloadFile(ObjectId objectId, string destination, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadFile (to path) not implemented.");

    public void DownloadIcon(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadIcon not implemented.");

    public void DownloadIcon(ObjectId objectId, string destination, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadIcon (to path) not implemented.");

    public void DownloadThumbnail(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadThumbnail not implemented.");

    public void DownloadThumbnail(ObjectId objectId, string destination, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadThumbnail (to path) not implemented.");

    public void DownloadFolder(ObjectId objectId, string destination, bool recursive, bool ignoreExceptions, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadFolder not implemented.");

    public void UploadFile(Stream stream, string destination, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: UploadFile (stream) not implemented.");

    public void UploadFile(string source, string destination, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: UploadFile (path) not implemented.");

    public void UploadFolder(string source, string destination, bool recursive, bool ignoreExceptions, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: UploadFolder not implemented.");

    public MediaFileInfo GetFileInfo(string path, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetFileInfo not implemented.");

    public MediaDirectoryInfo GetDirectoryInfo(string path, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetDirectoryInfo not implemented.");

    public IEnumerable<MediaDriveInfo> GetDrives(CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetDrives not implemented.");

    public MediaDirectoryInfo GetRootDirectory(CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetRootDirectory not implemented.");

    public string GetPathFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetPathFromPersistentUniqueId not implemented.");

    public MediaFileSystemInfo GetFileSystemInfoFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetFileSystemInfoFromPersistentUniqueId not implemented.");

    public void DownloadFileFromPersistentUniqueId(string persistentUniqueId, string destination, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: DownloadFileFromPersistentUniqueId not implemented.");

    public Stream OpenReadFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: OpenReadFromPersistentUniqueId not implemented.");

    public StreamReader? OpenTextFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: OpenTextFromPersistentUniqueId not implemented.");

    #endregion

    #region Vendor

    public IEnumerable<ushort> VendorOpcodes(CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: VendorOpcodes not implemented.");

    public IEnumerable<int> VendorExcecute(OpCodes opCode, IEnumerable<int> inputParams, out int respCode) => throw new NotSupportedException("ApplicationLayer: VendorExcecute not implemented.");

    public IEnumerable<int> VendorExcecuteRead(OpCodes opCode, IEnumerable<int> inputParams) => throw new NotSupportedException("ApplicationLayer: VendorExcecuteRead not implemented.");

    public IEnumerable<int> VendorExcecuteWrite(OpCodes opCode, IEnumerable<int> inputParams) => throw new NotSupportedException("ApplicationLayer: VendorExcecuteWrite not implemented.");

    public IEnumerable<int> VendorEndTransfer(string context, out int respCode) => throw new NotSupportedException("ApplicationLayer: VendorEndTransfer not implemented.");

    public string VendorExtentionDescription() => throw new NotSupportedException("ApplicationLayer: VendorExtentionDescription not implemented.");

    #endregion

    #region MediaDriveInfo

    public bool Eject(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: Eject not implemented.");

    public bool Format(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: Format not implemented.");

    public MediaDirectoryInfo? GetParent(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetParent not implemented.");

    public void CopyTo(ObjectId objectId, string destFileName, bool overwrite = true, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: CopyTo not implemented.");

    public void CopyIconTo(ObjectId objectId, string destFileName, bool overwrite = true, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: CopyIconTo not implemented.");

    public void CopyThumbnailTo(ObjectId objectId, string destFileName, bool overwrite = true, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: CopyThumbnailTo not implemented.");

    public Stream OpenRead(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: OpenRead not implemented.");

    public Stream OpenIcon(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: OpenIcon not implemented.");

    public Stream OpenThumbnail(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: OpenThumbnail not implemented.");

    public StreamReader OpenText(ObjectId objectId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: OpenText not implemented.");

    #endregion

    #region Extentions

    public string? GetPropertyString(ObjectId objectId, PropertyKey propertyKey) => throw new NotSupportedException("ApplicationLayer: GetPropertyString not implemented.");

    public int? GetPropertyInt(ObjectId objectId, PropertyKey propertyKey) => throw new NotSupportedException("ApplicationLayer: GetPropertyInt not implemented.");

    public uint? GetPropertyUInt(ObjectId objectId, PropertyKey propertyKey) => throw new NotSupportedException("ApplicationLayer: GetPropertyUInt not implemented.");

    public DateTime? GetPropertyDateTime(ObjectId objectId, PropertyKey propertyKey) => throw new NotSupportedException("ApplicationLayer: GetPropertyDateTime not implemented.");

    public bool SetProperty(ObjectId objectId, PropertyKey propertyKey, string? value) => throw new NotSupportedException("ApplicationLayer: SetProperty (string) not implemented.");

    public bool SetProperty(ObjectId objectId, PropertyKey propertyKey, int? value) => throw new NotSupportedException("ApplicationLayer: SetProperty (int) not implemented.");

    public bool SetProperty(ObjectId objectId, PropertyKey propertyKey, uint? value) => throw new NotSupportedException("ApplicationLayer: SetProperty (uint) not implemented.");

    public bool SetProperty(ObjectId objectId, PropertyKey propertyKey, DateTime? value) => throw new NotSupportedException("ApplicationLayer: SetProperty (DateTime) not implemented.");

    #endregion

    #region Services

    public IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceType) => throw new NotSupportedException("ApplicationLayer: GetServices not implemented.");

    #endregion

    #region Path/ObjectId

    public ObjectId PathToObjectId(string path, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: PathToObjectId not implemented.");

    #endregion

    #region FileSystem - Persistent Id helpers

    public MediaFileInfo GetFileInfoFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default) => throw new NotSupportedException("ApplicationLayer: GetFileInfoFromPersistentUniqueId not implemented.");

    #endregion

    #region IDisposable

    public void Dispose()
    {
        // release any native/protocol resources here in a full implementation
        isConnected = false;
        // Events: clear subscribers
        Event = null;
        //ObjectAdded = null;
        //ObjectRemoved = null;
        //ObjectUpdated = null;
        //DeviceReset = null;
        //DeviceCapabilitiesUpdated = null;
        //StorageFormat = null;
        //ObjectTransferRequest = null;
        //DeviceRemoved = null;
        //ServiceMethodComplete = null;
    }

    #endregion
}
