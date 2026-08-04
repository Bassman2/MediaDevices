using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Philips")]
public class PhilipsUFD : WritableUnitTest
{
    public PhilipsUFD() : base("\\Card")
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

        // Vendor Test
        deviceVendorOpcodes = [];
        deviceVendorExtentionDescription = null;

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
