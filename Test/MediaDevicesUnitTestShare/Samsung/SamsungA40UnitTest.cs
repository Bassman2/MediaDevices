namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Samsung")]
public class SamsungA40UnitTest : WritableUnitTest
{
    public SamsungA40UnitTest()
    {
        // Device Select
        deviceSelect = device => device.Description == this.deviceDescription;

        // Ignore tests
        //this.ignoreTests = Ignore.DownloadIcon;

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
        deviceVendorExtentionDescription = "microsoft.com: 1.0; samsung.com/kies: 5.0; samsung.com/devicestatus: 2; ";

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

        readonlyEnumPath = @"Phone\Pictures\My_EnumTest";
        readonlyEnumSearchPatternFolders = "S*";
        readonlyEnumSearchPatternFiles = "desc*";
        readonlyEnumSearchPatternItems = "*es*";

        readonlyEnumFiles = ["\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt"];
        readonlyEnumFilesRecursive = ["\\Phone\\Pictures\\My_EnumTest\\A0002\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0003.txt", "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0003.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0003.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt"]; 
        readonlyEnumFilesSearchPattern = ["\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt"];
        readonlyEnumFilesSearchPatternRecursive = ["\\Phone\\Pictures\\My_EnumTest\\A0002\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0003.txt", "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0003.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0003.txt", "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt", "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt", "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt"];

        // ReadonlyDirectoryInfoEnumDirectoriesTest
       readonlyEnumFolders = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0001",
            "\\Phone\\Pictures\\My_EnumTest\\A0002",
            "\\Phone\\Pictures\\My_EnumTest\\_S1002",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        readonlyEnumFoldersRecursive = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        readonlyEnumFoldersSearchPattern = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        readonlyEnumFoldersSearchPatternRecursive = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];

        

        // ReadonlyDirectoryInfoEnumItemsTest
        readonlyEnumItems = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000",
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        readonlyEnumItemsRecursive = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001",
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0003.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\_desc_0004.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0001.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\A0001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002",
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\_desc_0004.txt",
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0001.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_S1002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0003.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\_desc_0004.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0001.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        readonlyEnumItemsSearchPattern = [
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        readonlyEnumItemsSearchPatternRecursive = [
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0002.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\_desc_0004.txt",
            "\\Phone\\Pictures\\My_EnumTest\\S1001\\desc_0001.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0003.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\_desc_0004.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\A0002\\desc_0002.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0003.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\_desc_0004.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001\\desc_0001.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
       
        #endregion

        #region Writeable Tests

        writeableWorkingFolder = @"\Card\Test";
               

        #endregion

        // Exists Test
            
    }
}
