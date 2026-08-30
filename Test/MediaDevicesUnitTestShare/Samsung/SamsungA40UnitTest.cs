namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Samsung")]
public class SamsungA40UnitTest : SamsungUnitTest
{
    public SamsungA40UnitTest() : base("\\Card")
    {
        #region Device Tests

        // Device Properties Test
        deviceManufacturerId = ManufacturerId.Samsung;
        deviceDeviceId = 0x6860;
        deviceDescription = "SM-A405FN";
        deviceFriendlyName = "Samsung A40";
        deviceManufacture = "Samsung Electronics Co., Ltd.";

        deviceName = "SM-A405FN";

        deviceSyncPartner = "Longhorn Sync Engine";
        deviceFirmwareVersion = "A405FNXXU4CWC3";
        deviceModel = "SM-A405FN";
        deviceSerialNumber = "R58M81NACKB";
        deviceDeviceType = DeviceType.MediaPlayer;
        deviceSupportsNonConsumable = true;
        deviceSupportedFormatsAreOrdered = true;
        deviceIsFriendlyNameEditable = true;
        
        // Capability Test
        deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded];
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
            Commands.ObjectPropertiesBulkGetValuesByObjectListStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectListNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectListEnd,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatEnd,
            Commands.ObjectPropertiesBulkSetValuesByObjectListStart,
            Commands.ObjectPropertiesBulkSetValuesByObjectListNext,
            Commands.ObjectPropertiesBulkSetValuesByObjectListEnd];
        deviceSupportedContents = [ContentType.Audio, ContentType.Playlist, ContentType.Video, ContentType.Document, ContentType.Unspecified, ContentType.Folder, ContentType.Image];
        deviceFunctionalCategories = [FunctionalCategory.Storage, FunctionalCategory.RenderingInformation];

        // ContentLocation Test

        // Device File Dates Test
        deviceCreationTimeMode = DateMode.Now;
        deviceLastWriteTimeMode = DateMode.FileTime;

        // Drive Test
        deviceDrives = ["Phone", "Card"];

        // Vendor Test
        deviceVendorOpcodes = [
            OpCodesSamsung.Unknown1,
            OpCodesSamsung.Unknown2,
            OpCodesSamsung.Unknown3,
            OpCodesSamsung.Unknown4,
            OpCodesSamsung.Unknown5,
            OpCodesSamsung.Unknown6];
        deviceVendorExtentionDescription = @"^microsoft\.com: 1\.0; samsung\.com\/kies: 5\.0; samsung\.com\/devicestatus: \d; $";
                                        //   "microsoft.com: 1.0; samsung.com/kies: 5.0; samsung.com/devicestatus: 0; ";

        #endregion

        #region Readonly Tests

        // file
        readonlyFilePath = @"\Phone\Pictures\My_Test_Pictures\Sundown.jpg";
        readonlyFileLength = 3675020ul;
        readonlyFileCreationTime = new DateTime(2026, 07, 23, 17, 20, 41);
        readonlyFileLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFileAuthoredTime = new DateTime(2024, 06, 25, 21, 53, 17);
        readonlyFileAttributes = MediaFileAttributes.Normal | MediaFileAttributes.CanDelete;

        readonlyFileParentPath = @"\Phone\Pictures\My_Test_Pictures";
        readonlyFileParentCreationTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFileParentLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFileParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // folder 
        readonlyFolderPath = @"\Phone\Pictures\My_Test_Pictures";
        readonlyFolderCreationTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFolderLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFolderAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFolderParentPath = @"\Phone\Pictures";
        readonlyFolderParentCreationTime = new DateTime(2026, 07, 23, 19, 06, 10);
        readonlyFolderParentLastWriteTime = new DateTime(2026, 07, 23, 19, 06, 10);
        readonlyFolderParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // Enumerable & List tests
        readonlyFileDownloadIcon = false;
        readonlyFileDownloadThumbnail = true;

        #endregion
    }
}
