namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Samsung")]
public class SamsungA40UnitTest : WritableUnitTest
{
    public SamsungA40UnitTest() : base("\\Card")
    {
        // Device Select
        //deviceSelect = device => device.Description == this.deviceDescription;

        // Ignore tests
        //this.ignoreTests = Ignore.DownloadIcon;

        //string readonlyBasePath     Test_ReadonlyFile


        #region Device Tests

        // Device Properties Test
        deviceDescription = "SM-A405FN";
        deviceFriendlyName = "Samsung A40";
        deviceManufacture = "Samsung Electronics Co., Ltd.";
        deviceSyncPartner = "Longhorn Sync Engine";
        deviceFirmwareVersion = "A405FNXXU4CWC3";
        deviceModel = "SM-A405FN";
        deviceSerialNumber = "R58M81NACKB";
        deviceDeviceType = DeviceType.MediaPlayer;
        deviceDateTimeHasValue = false;

        // Capability Test
        deviceFunctionalCategories = [FunctionalCategory.Storage, FunctionalCategory.RenderingInformation];

        // ContentLocation Test

        // Drive Test
        deviceDrives = ["Phone", "Card"];
        
        // Vendor Test
        deviceVendorOpcodes = [38148, 37377, 37378, 38145, 38146, 38147];
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
