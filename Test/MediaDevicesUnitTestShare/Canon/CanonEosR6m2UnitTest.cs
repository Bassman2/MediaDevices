namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Canon")]
public class CanonEosR6m2UnitTest : ReadonlyUnitTest
{
    public CanonEosR6m2UnitTest()
        : base("")
    {
        #region Device Tests

        // Device Test
        deviceDescription = "Canon EOS R6m2";
        deviceFriendlyName = "Canon EOS R6m2";
        deviceManufacture = "Canon.Inc";

        deviceName = "Canon EOS R6m2";
        
        deviceFirmwareVersion = "3-1.7.0";
        deviceModel = "Canon EOS R6m2";
        deviceSerialNumber = "7bb7e995a3455324bc9ac49dc9b0af43";
        deviceDeviceType = DeviceType.Camera;
        
        // Capability Test
        deviceSupportedEvents = [Events.DeviceReset, Events.Unknown, Events.StorageFormat, Events.Unknown, Events.Unknown, Events.ObjectRemoved, Events.Unknown, Events.Unknown, Events.Unknown, Events.Unknown, Events.Unknown, Events.ObjectTransferRequest, Events.Unknown, Events.Unknown, Events.ObjectUpdated, Events.Unknown, Events.Unknown, Events.Unknown, Events.Unknown, Events.Unknown, Events.Unknown, Events.Unknown, Events.ObjectAdded, Events.Unknown];

        deviceSupportedCommands = [
            Commands.ObjectEnumerationStartFind,
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
            Commands.ObjectManagementDeleteObjects,
            Commands.ObjectManagementCreateObjectWithPropertiesOnly,
            Commands.ObjectManagementCreateObjectWithPropertiesAndData,
            Commands.ObjectManagementWriteObjectData,
            Commands.ObjectManagementCommitObject,
            Commands.ObjectManagementRevertObject,
            Commands.StorageFormat];
        deviceSupportedContents = [ContentType.Image, ContentType.Audio, ContentType.Video, ContentType.Document, ContentType.Unspecified, ContentType.Folder, ContentType.Certificate];

        // ContentLocation Test
        deviceContentLocationsImages = [];

        // DriveTest
        deviceDrives = ["SD1", "SD2"];

        // Vendor Test
        deviceVendorOpcodes = [];
        deviceVendorExtentionDescription = "";

        #endregion

        #region Readonly Tests

        // Exists Test
        this.readonlyFilePath = @"\SD\DCIM\100CANON\IMG_2568.JPG";


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

        #endregion
    }
}
