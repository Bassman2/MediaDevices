namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Canon")]
public class CanonEos60DUnitTest : ReadonlyUnitTest
{
    public CanonEos60DUnitTest()
        : base("")
    {
        ignoreTests = Ignore.FriendlyName;

        // Device Test
        deviceDescription = "Canon EOS 60D";
        deviceFriendlyName = "Canon EOS 60D";
        deviceManufacture = "Canon Inc.";

        deviceName = "Canon EOS 60D";

        deviceFirmwareVersion = "3-1.1.2";
        deviceProtocol = "MTP: 2.00";
        deviceModel = "Canon EOS 60D";
        deviceSerialNumber = "ff76057ad3e84a228e406f41cdd778a6";
        deviceDeviceType = DeviceType.Camera;
        deviceUseDeviceStage = DeviceTransport.USB;

        // Capability Test
        deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.StorageFormat, Events.Unknown, Events.ObjectTransferRequest, Events.ObjectAdded];
        deviceSupportedCommands = [
            Commands.ObjectEnumerationStartFind,
            Commands.ObjectManagementDeleteObjects,
            Commands.ObjectEnumerationFindNext,
            Commands.ObjectEnumerationEndFind,
            Commands.ObjectPropertiesGetSupported,
            Commands.ObjectPropertiesGet,
            Commands.ObjectPropertiesGetAll,
            Commands.ObjectPropertiesGetAttribute,
            Commands.ObjectResourcesGetSupported,
            Commands.ObjectResourcesGetAttributes,
            Commands.ObjectResourcesOpen,
            Commands.ObjectResourcesRead,
            Commands.ObjectResourcesClose,
            Commands.CapabilitiesGetSupportedCommands,
            Commands.CapabilitiesGetCommandOptions,
            Commands.CapabilitiesGetSupportedFunctionalCategories,
            Commands.CapabilitiesGetFunctionalObjects,
            Commands.CapabilitiesGetSupportedContentTypes,
            Commands.CapabilitiesGetSupportedFormats,
            Commands.CapabilitiesGetSupportedFormatProperties,
            Commands.CapabilitiesGetFixedPropertyAttributes,
            Commands.CapabilitiesGetSupportedEvents,
            Commands.CapabilitiesGetEventOptions,
            Commands.MtpExtVendorGetSupportedVendorOpcodes,
            Commands.MtpExtVendorGetVendorExtensionDescription,
            Commands.MtpExtVendorExecuteCommandWithoutDataPhase,
            Commands.MtpExtVendorExecuteCommandWithDataToRead,
            Commands.MtpExtVendorExecuteCommandWithDataToWrite,
            Commands.MtpExtVendorReadData,
            Commands.MtpExtVendorWriteData,
            Commands.MtpExtVendorEndDataTransfer,
            Commands.Unknown,
            Commands.Unknown,
            Commands.ObjectManagementCreateObjectWithPropertiesOnly,
            Commands.ObjectManagementCreateObjectWithPropertiesAndData,
            Commands.ObjectManagementWriteObjectData,
            Commands.ObjectManagementCommitObject,
            Commands.ObjectManagementRevertObject,
            Commands.ObjectPropertiesSet,
            Commands.StorageFormat,
            Commands.ObjectPropertiesBulkGetValuesByObjectListStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectListNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectListEnd,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatEnd,
            Commands.GenerateKeypair,
            Commands.CommitKeypair];
        deviceSupportedContents = [ContentType.Image, ContentType.Audio, ContentType.Video, ContentType.Document, ContentType.Unspecified, ContentType.Folder, ContentType.Certificate, ContentType.WirelessProfile];

        // ContentLocation Test
        deviceContentLocationsImages = [];


        // Exists Test
        this.readonlyFilePath = @"\SD\DCIM\100CANON\IMG_2568.JPG";


        //this.infoDirectoryName = "DCIM";
        //this.infoDirectoryPath = @"\Internal Storage\DCIM";
        //this.infoDirectoryCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        //this.infoDirectoryLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoDirectoryParentName = "Internal Storage";
        //this.infoDirectoryParentPath = @"\Internal Storage";
        //this.infoDirectoryParentCreationTime = null;
        //this.infoDirectoryParentLastWriteTime = null;

        //this.infoFilePath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";
        this.readonlyFileLength = 467430ul;
        this.readonlyFileCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyFileLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoFileParentName = "800AAAAA";
        //this.infoFileParentPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyFolderCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyFolderLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        this.readonlyEnumPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyEnumSearchPatternFolders = "*";
        this.readonlyEnumSearchPatternFiles = "*_0002*";
        this.readonlyEnumSearchPatternItems = "*_0003*";

        this.readonlyEnumFolders = [];
        this.readonlyEnumFoldersSearchPattern = [];

        this.readonlyEnumFiles = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumFilesSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];
        this.readonlyEnumFilesSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];

        this.readonlyEnumItems = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];

        deviceVendorOpcodes = [
            (OpCodes)37153,
            (OpCodes)37207,
            (OpCodes)37208,
            (OpCodes)37209,
            (OpCodes)37210,
            (OpCodes)36946,
            (OpCodes)36947,
            (OpCodes)37159,
            (OpCodes)37160,
            (OpCodes)37161,
            (OpCodes)37374,
            (OpCodes)36951, 
            (OpCodes)37163, 
            (OpCodes)37375, 
            (OpCodes)37216, 
            (OpCodes)36952,
            (OpCodes)37164,
            (OpCodes)36953,
            (OpCodes)37165, 
            (OpCodes)36954,
            (OpCodes)37166, 
            (OpCodes)37167,
            (OpCodes)37168, 
            (OpCodes)37169,
            (OpCodes)37170, 
            (OpCodes)36959, 
            (OpCodes)37171, 
            (OpCodes)37172,
            (OpCodes)37173, 
            (OpCodes)37174, 
            OpCodes.Canon_EOSGetStorageIDs,
            (OpCodes)37175,
            OpCodes.Panasonic_OpenSession,
            OpCodes.Panasonic_CloseSession,
            OpCodes.Canon_EOSGetObject,
            (OpCodes)37125,
            (OpCodes)37126,
            (OpCodes)37127,
            OpCodes.Canon_EOSGetDeviceInfoEx,
            (OpCodes)37129,
            (OpCodes)37130,
            (OpCodes)37131,
            (OpCodes)37132,
            (OpCodes)37134,
            OpCodes.Canon_EOSRemoteRelease,
            (OpCodes)37136,
            (OpCodes)37139,
            OpCodes.Canon_EOSSetRemoteMode,
            (OpCodes)37141,
            OpCodes.Canon_EOSGetEvent,
            (OpCodes)37143,
            (OpCodes)37144,
            (OpCodes)37146,
            (OpCodes)37147,
            (OpCodes)37360,
            (OpCodes)37148,
            (OpCodes)37361,
            (OpCodes)37149,
            OpCodes.Canon_EOSGetViewFinderImage,
            (OpCodes)37150,
            (OpCodes)37151,
            OpCodes.Canon_EOSDoAf,
            OpCodes.Canon_EOSDriveLens,
            (OpCodes)37152];
        deviceVendorExtentionDescription = "";
    }
}
