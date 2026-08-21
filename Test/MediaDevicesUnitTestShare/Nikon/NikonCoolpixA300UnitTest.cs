namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Nikon")]
public class NikonCoolpixA300 : NikonUnitTest
{
    public NikonCoolpixA300()
        : base("\\A300")
    {
        #region Device Tests

        // Device Properties Test
        deviceDescription = "A300";
        deviceFriendlyName = "A300";
        deviceManufacture = "NIKON";

        deviceName = "A300";
                
        deviceFirmwareVersion = "COOLPIX A300 V1.4";
        deviceModel = "A300";
        deviceSerialNumber = "";
        deviceDateTimeHasValue = true;
        deviceDeviceType = DeviceType.Camera;
        deviceUseDeviceStage = DeviceTransport.USB;

        // Device Capability Test
        deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.DeviceCapabilitiesUpdated, Events.Unknown, Events.StorageFormat, Events.Unknown, Events.Unknown, Events.ObjectTransferRequest, Events.Unknown, Events.ObjectAdded];
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
            Commands.StorageFormat,
            Commands.StillImageCaptureInitiate,
            Commands.ObjectPropertiesBulkGetValuesByObjectListStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectListNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectListEnd,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatEnd];
        deviceSupportedContents = [ ContentType.Image, ContentType.Video, ContentType.Document, ContentType.Unspecified, ContentType.Folder];
        deviceFunctionalCategories = [ FunctionalCategory.Storage, FunctionalCategory.StillImageCapture ];

        // Device ContentLocation Test
        deviceContentLocationsImages = [];

        // Device Drive Test
        deviceDrives = ["A300"];

        // Device Vendor Test
        deviceVendorOpcodes = [
            OpCodesNikon.GetDevicePropertyCaps,
            OpCodesNikon.Placeholder,
            OpCodesNikon.GetDevicePropertyValue,
            OpCodesNikon.GetDevicePropDesc,
            OpCodesNikon.GetProfileAllData];
        deviceVendorExtentionDescription = "microsoft.com/deviceservices: 1.0;";

        #endregion

        #region  Readonly Tests

        // file tests
        readonlyFilePath = @"\A300\DCIM\100NIKON\DSCN0005.JPG";
        readonlyFileLength = 4784013ul;
        readonlyFileCreationTime = new DateTime(2017, 11, 15, 20, 55, 54);
        readonlyFileLastWriteTime = new DateTime(2017, 11, 15, 20, 55, 54);
        readonlyFileAuthoredTime = null;
        readonlyFileAttributes = MediaFileAttributes.Normal | MediaFileAttributes.CanDelete;

        readonlyFileParentPath = @"\A300\DCIM\100NIKON";
        readonlyFileParentCreationTime = null;
        readonlyFileParentLastWriteTime = null;
        readonlyFileParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // folder tests
        readonlyFolderPath = @"\A300\DCIM\100NIKON";
        readonlyFolderAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFolderParentPath = @"\A300\DCIM";
        readonlyFolderParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFileDownloadThumbnail = true;

        // Enumerable
        readonlyEnumPath = "\\A300\\DCIM";
        readonlyEnumSearchPatternFiles = "*003*";
        readonlyEnumSearchPatternFolders = "*003*";
        readonlyEnumSearchPatternItems = "*003*";

        //readonlyEnumFilesMode = EnumerableMode.Subset;
        readonlyEnumFiles = [];
        readonlyEnumFilesRecursive = ["\\A300\\DCIM\\100NIKON\\DSCN0005.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0006.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0007.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0008.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0009.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0010.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0011.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0012.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0013.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0014.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0015.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0016.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0017.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0018.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0019.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0020.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0021.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0022.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0023.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0024.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0025.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0026.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0027.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0028.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0029.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0030.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0031.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0032.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0033.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0034.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0035.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0036.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0037.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0038.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0039.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0040.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0041.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0042.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0043.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0044.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0045.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0046.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0047.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0048.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0049.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0050.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0051.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0052.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0053.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0054.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0055.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0056.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0057.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0058.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0059.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0060.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0061.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0062.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0063.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0064.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0065.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0066.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0067.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0068.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0069.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0070.JPG"];
        readonlyEnumFilesSearchPattern = [];
        readonlyEnumFilesSearchPatternRecursive = ["\\A300\\DCIM\\100NIKON\\DSCN0030.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0031.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0032.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0033.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0034.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0035.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0036.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0037.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0038.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0039.JPG"];


        //readonlyEnumFoldersMode = EnumerableMode.Subset;
        readonlyEnumFolders = ["\\A300\\DCIM\\100NIKON"];
        readonlyEnumFoldersRecursive = ["\\A300\\DCIM\\100NIKON"];
        readonlyEnumFoldersSearchPattern = [];
        readonlyEnumFoldersSearchPatternRecursive = [];

        readonlyEnumItems = ["\\A300\\DCIM\\100NIKON"];
        readonlyEnumItemsRecursive = ["\\A300\\DCIM\\100NIKON", "\\A300\\DCIM\\100NIKON\\DSCN0005.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0006.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0007.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0008.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0009.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0010.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0011.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0012.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0013.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0014.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0015.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0016.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0017.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0018.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0019.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0020.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0021.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0022.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0023.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0024.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0025.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0026.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0027.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0028.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0029.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0030.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0031.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0032.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0033.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0034.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0035.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0036.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0037.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0038.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0039.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0040.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0041.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0042.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0043.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0044.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0045.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0046.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0047.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0048.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0049.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0050.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0051.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0052.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0053.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0054.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0055.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0056.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0057.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0058.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0059.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0060.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0061.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0062.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0063.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0064.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0065.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0066.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0067.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0068.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0069.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0070.JPG"];
        readonlyEnumItemsSearchPattern = [];
        readonlyEnumItemsSearchPatternRecursive = ["\\A300\\DCIM\\100NIKON\\DSCN0030.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0031.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0032.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0033.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0034.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0035.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0036.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0037.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0038.JPG", "\\A300\\DCIM\\100NIKON\\DSCN0039.JPG"];

        #endregion
    }
}
