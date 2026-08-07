using static System.Net.Mime.MediaTypeNames;

namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Canon")]
public class CanonEosR6m2UnitTest : ReadonlyUnitTest
{
    public CanonEosR6m2UnitTest()
        : base("")
    {
        ignoreTests = Ignore.FriendlyName;

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
        deviceVendorOpcodes = [37164, 37331, 37168, 37332, 37169, 37333, 37170, 37171, 37172, 37336, 37173, 37337, 37174, 37338, 37175, 37339, 37176, 37340, 37177, 37341, 37178, 37342, 37179, 37180, 37181, 37345, 37182, 37183, 37347, 37184, 37185, 37187, 37351, 37188, 37352, 37189, 37353, 37190, 37192, 37356, 37193, 37194, 37195, 37360, 37197, 37361, 37199, 37200, 37203, 37204, 37205, 37207, 37208, 37209, 37210, 37211, 37212, 37213, 37214, 37215, 37216, 37217, 37218, 37219, 37222, 37227, 37228, 37230, 37231, 37232, 37233, 37234, 37235, 37236, 36911, 37239, 37240, 37241, 36915, 37248, 37249, 37250, 37251, 37252, 37253, 37254, 37255, 37256, 37257, 37258, 36944, 36945, 36956, 36957, 37121, 37122, 36960, 37123, 37124, 37125, 37126, 37127, 37128, 37292, 37129, 37293, 37130, 37294, 37295, 37132, 36970, 36971, 37135, 37136, 36973, 37140, 37141, 37305, 37142, 37306, 37143, 37144, 36983, 37146, 36984, 37147, 36985, 37148, 37149, 37150, 37151, 37159, 37160, 37161, 36999, 37000];
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
