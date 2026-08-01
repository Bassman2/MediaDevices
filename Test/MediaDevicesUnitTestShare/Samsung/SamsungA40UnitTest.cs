namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Samsung")]
public class SamsungA40UnitTest : WritableUnitTest
{
    public SamsungA40UnitTest()
    {
        // Device Select
        this.deviceSelect = device => device.Description == this.deviceDescription;

        // Ignore tests
        //this.ignoreTests = Ignore.DownloadIcon;

        #region Device Tests

        // Device Properties Test
        this.deviceDescription = "SM-A405FN";
        this.deviceFriendlyName = "Samsung A40";
        this.deviceManufacture = "Samsung Electronics Co., Ltd.";
        this.deviceSyncPartner = "Longhorn Sync Engine";
        this.deviceFirmwareVersion = "A405FNXXU4CWC3";
        this.deviceModel = "SM-A405FN";
        this.deviceSerialNumber = "R58M81NACKB";
        this.deviceDeviceType = DeviceType.MediaPlayer;
        this.deviceDateTimeHasValue = false;
        
        //  Device Capability Test
        this.functionalCategories = [FunctionalCategory.Storage, FunctionalCategory.RenderingInformation];

        // Device Content Location Test

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
        readonlyFileParentAuthoredTime = new DateTime(0001, 01, 01, 00, 00, 00);
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
        this.readonlyEnumItems = [
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
        this.readonlyEnumItemsRecursive = [
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
        this.readonlyEnumItemsSearchPattern = [
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        this.readonlyEnumItemsSearchPatternRecursive = [
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


        // FileSystem PersistentUniqueId
        //this.FolderPersistentUniqueId = "{052BDC9B-08B6-A6AB-5591-E52A8B782B74}"; // "{ CF527675-97D8-3DEF-0000-000000000000}";
        //this.FolderPersistentUniqueIdPath = @"\Phone\Music";
        //this.FilePersistentUniqueId = "{25606D91-C12C-CF74-93A6-34E88717AD11}"; // "{FDFF71F3-E0BD-D98E-0000-000000000000}";
        //this.FilePersistentUniqueIdPath = @"\Phone\Samsung\Music\Over_the_Horizon.mp3"; // @"\Phone\Videos\desktop.ini"; Directory = "\\Phone\\Samsung\\Music"

        #endregion

        #region Writeable Tests

        this.workingFolder = @"\Card\Test";

        this.drives = ["Phone", "Card"];

        #endregion

        // Exists Test
            
    }
}
