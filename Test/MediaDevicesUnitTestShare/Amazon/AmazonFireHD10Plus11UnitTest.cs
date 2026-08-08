namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Amazon")]
public class AmazonFireHD10Plus11UnitTest : WritableUnitTest
{
    public AmazonFireHD10Plus11UnitTest()
        : base("\\Speichergerät")
    {
        #region Device Tests

        // Device Properties Test

        deviceDescription = "Fire";
        deviceFriendlyName = "FireHD10Plus11";
        deviceManufacture = "Amazon";

        deviceName = "Fire";
        
        deviceSyncPartner = "";
        deviceFirmwareVersion = "1.0";
        deviceModel = "Fire";
        deviceSerialNumber = "G001MG0613460HLU";

        // Capability Test
        this.deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded];
        this.deviceSupportedCommands = [
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
            Commands.ObjectManagementMoveObjects, 
            Commands.ObjectManagementCopyObjects, 
            Commands.ObjectPropertiesSet, 
            Commands.ObjectPropertiesBulkGetValuesByObjectListStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectListNext, 
            Commands.ObjectPropertiesBulkGetValuesByObjectListEnd, 
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatNext, 
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatEnd];
        this.deviceSupportedContents = [
            ContentType.Image,
            ContentType.Audio,
            ContentType.Playlist,
            ContentType.Video,
            ContentType.Document,
            ContentType.Unspecified,
            ContentType.Folder];
        //this.deviceFunctionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test
        this.deviceContentLocationsImages = []; // new List<string> { @"\Phone\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" };

        // DriveTest
        this.deviceDrives = ["Speichergerät"];

        // Device File Dates Test
        deviceCreationTimeMode = DateMode.NotSupported;
        deviceLastWriteTimeMode = DateMode.FileTime;
        deviceDateAuthoredMode = DateMode.NotSupported;

        // Vendor Test
        deviceVendorOpcodes = [38337, 38338, 38339, 38340, 38341];
        deviceVendorExtentionDescription = "microsoft.com: 1.0; android.com: 1.0;";


        #endregion

        #region Readonly Tests

        // file
        readonlyFilePath = @"\Speichergerät\Test_ReadonlyFile\Pictures\Sundown.jpg";
        readonlyFileLength = 3675020ul;
        readonlyFileLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFileAttributes = MediaFileAttributes.Normal | MediaFileAttributes.CanDelete;

        readonlyFileParentPath = @"\Speichergerät\Test_ReadonlyFile\Pictures";
        readonlyFileParentLastWriteTime = new DateTime(2026, 08, 03, 19, 24, 13);
        readonlyFileParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // folder 
        readonlyFolderPath = @"\Speichergerät\Test_ReadonlyFile\Pictures";
        readonlyFolderLastWriteTime = new DateTime(2026, 08, 03, 19, 24, 13);
        readonlyFolderAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFolderParentPath = @"\Speichergerät\Test_ReadonlyFile";
        readonlyFolderParentLastWriteTime = new DateTime(2026, 08, 03, 19, 24, 13);
        readonlyFolderParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFileDownloadIcon = false;
        readonlyFileDownloadThumbnail = true;

        #endregion
    }
}