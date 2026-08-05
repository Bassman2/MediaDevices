namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Philips")]
public class PhilipsUFDUnitTest : WritableUnitTest
{
    public PhilipsUFDUnitTest() : base("\\F:")
    {
        #region Device Tests

        // Device Properties Test
        deviceDescription = "PHILIPS USB     ";
        deviceFriendlyName = "PHILIPS UFD";
        deviceManufacture = "        ";
        deviceFirmwareVersion = "    ";
        deviceModel = "PHILIPS USB     ";
        deviceSerialNumber = "0000000005\u0006\u0018";
        deviceDateTimeHasValue = false;
        devicePowerSource = PowerSource.External;
        deviceProtocol = "MSC:";
        deviceSupportsNonConsumable = null;
        deviceSupportedFormatsAreOrdered = null;
        deviceTransport = null;

        // Capability Test
        deviceSupportedEvents = [Events.ObjectAdded, Events.ObjectRemoved, Events.ObjectUpdated];
        deviceSupportedCommands = [
            Commands.ObjectEnumerationStartFind,
            Commands.ObjectEnumerationFindNext,
            Commands.ObjectEnumerationEndFind, 
            Commands.ObjectManagementDeleteObjects,
            Commands.ObjectManagementCreateObjectWithPropertiesOnly, 
            Commands.ObjectManagementCreateObjectWithPropertiesAndData, 
            Commands.ObjectManagementWriteObjectData, 
            Commands.ObjectManagementCommitObject,
            Commands.ObjectManagementRevertObject,
            Commands.ObjectPropertiesGetSupported,
            Commands.ObjectPropertiesGet, 
            Commands.ObjectPropertiesGetAll, 
            Commands.ObjectPropertiesSet, 
            Commands.ObjectPropertiesGetAttribute,
            Commands.ObjectPropertiesDelete, 
            Commands.ObjectResourcesGetSupported,
            Commands.ObjectResourcesGetAttributes, 
            Commands.ObjectResourcesOpen, 
            Commands.ObjectResourcesRead, 
            Commands.ObjectResourcesWrite,
            Commands.ObjectResourcesClose, 
            Commands.ObjectResourcesDelete, 
            Commands.CapabilitiesGetSupportedCommands, 
            Commands.CapabilitiesGetCommandOptions, 
            Commands.CapabilitiesGetSupportedFunctionalCategories,
            Commands.CapabilitiesGetSupportedEvents,
            Commands.CapabilitiesGetEventOptions, 
            Commands.CapabilitiesGetFunctionalObjects,
            Commands.CapabilitiesGetSupportedContentTypes,
            Commands.CapabilitiesGetSupportedFormats,
            Commands.CapabilitiesGetSupportedFormatProperties,
            Commands.CapabilitiesGetFixedPropertyAttributes];
        deviceSupportedContents = [ContentType.Unspecified, ContentType.Folder, ContentType.Audio, ContentType.Video, ContentType.Image, ContentType.Contact];
        deviceFunctionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test

        // Drive Test
        deviceDrives = [""];


        // Device File Dates Test
        deviceCreationTimeMode = DateMode.Now;
        deviceLastWriteTimeMode = DateMode.Now;
        deviceDateAuthoredMode = DateMode.NotSupported;


        // Vendor Test
        deviceVendorOpcodes = [];
        deviceVendorExtentionDescription = null;

        #endregion

        #region Readonly Tests

        readonlyFileDownloadIcon = false;

        // file
        readonlyFilePath = @"\F:\Test_ReadonlyFile\Pictures\Sundown.jpg";
        readonlyFileLength = 3675020ul;
        readonlyFileCreationTime = DateTime.Parse("2026-08-04T18:17:35");
        readonlyFileLastWriteTime = DateTime.Parse("2026-07-23T17:20:34");
        readonlyFileAuthoredTime = DateTime.Parse("2024-06-25T18:53:17");
        readonlyFileAttributes = MediaFileAttributes.Normal | MediaFileAttributes.CanDelete;

        readonlyFileParentPath = @"\F:\Test_ReadonlyFile\Pictures";
        readonlyFileParentCreationTime = DateTime.Parse("2026-08-04T18:17:35");
        readonlyFileParentLastWriteTime = DateTime.Parse("2026-08-03T13:22:34");
        readonlyFileParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // folder 
        readonlyFolderPath = @"\F:\Test_ReadonlyFile\Pictures";
        readonlyFolderCreationTime = DateTime.Parse("2026-08-04T18:17:35");
        readonlyFolderLastWriteTime = DateTime.Parse("2026-08-03T13:22:34");
        readonlyFolderAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFolderParentPath = @"\F:\Test_ReadonlyFile";
        readonlyFolderParentCreationTime = DateTime.Parse("2026-08-04T18:17:35");
        readonlyFolderParentLastWriteTime = DateTime.Parse("2026-08-03T13:22:34");
        readonlyFolderParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // Enumerable & List tests
        readonlyFileDownloadIcon = false;
        readonlyFileDownloadThumbnail = true;

        #endregion
    }
}
