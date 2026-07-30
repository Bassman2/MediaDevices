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
        this.ignoreTests = Ignore.DownloadIcon;

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
        this.readonlyTestFilePath = @"\Phone\Pictures\My_Test_Pictures\Sundown.jpg";
        this.readonlyTestFileLength = 3675020ul;
        this.readonlyTestFileCreationTime = new DateTime(2026, 07, 23, 17, 20, 41);
        this.readonlyTestFileLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        this.readonlyTestFileAuthoredTime = new DateTime(2024, 06, 25, 21, 53, 17);
        this.readonlyTestFileAttributes = MediaFileAttributes.Normal | MediaFileAttributes.CanDelete;

        // folder of file
        this.readonlyTestFolderPath = @"\Phone\Pictures\My_Test_Pictures";
        this.readonlyTestFolderCreationTime = new DateTime(2026, 07, 23, 17, 20, 33);
        this.readonlyTestFolderLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        this.readonlyTestFolderAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // parent of folder
        this.readonlyTestParentPath = @"\Phone\Pictures";
        this.readonlyTestParentCreationTime = new DateTime(2026, 07, 23, 19, 06, 10);
        this.readonlyTestParentLastWriteTime = new DateTime(2026, 07, 23, 19, 06, 10);
        this.readonlyTestParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;
        
        // Enum
        this.readonlyTestEnumPath = @"Phone\Pictures\My_EnumTest";
        this.readonlyTestEnumFolderSearchPattern = "S*";
        this.readonlyTestEnumFileSearchPattern = "desc*";
        this.readonlyTestEnumItemSearchPattern = "*es*";

        // ReadonlyDirectoryInfoEnumDirectoriesTest
        this.readonlyTestEnumFoldersAll = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0001",
            "\\Phone\\Pictures\\My_EnumTest\\A0002",
            "\\Phone\\Pictures\\My_EnumTest\\_S1002",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        this.readonlyTestEnumFoldersAllRecursive = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0001", 
            "\\Phone\\Pictures\\My_EnumTest\\A0002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        this.readonlyTestEnumFoldersSearchPattern = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        this.readonlyTestEnumFoldersSearchPatternRecursive = [
            "\\Phone\\Pictures\\My_EnumTest\\S1000", 
            "\\Phone\\Pictures\\My_EnumTest\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002", 
            "\\Phone\\Pictures\\My_EnumTest\\_S1002\\S1001", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];

        // ReadonlyDirectoryInfoEnumFilesTest
        this.readonlyTestEnumFilesAll = [
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt"];
        this.readonlyTestEnumFilesAllRecursive = [
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
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt"];
        this.readonlyTestEnumFilesSearchPattern = [
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt", 
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt"];
        this.readonlyTestEnumFilesSearchPatternRecursive = [
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
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt"];

        // ReadonlyDirectoryInfoEnumItemsTest
        this.readonlyTestEnumItemsAll = [
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
        this.readonlyTestEnumItemsAllRecursive = [
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
        this.readonlyTestEnumItemsSearchPattern = [
            "\\Phone\\Pictures\\My_EnumTest\\desc_0001.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0002.txt",
            "\\Phone\\Pictures\\My_EnumTest\\desc_0003.txt",
            "\\Phone\\Pictures\\My_EnumTest\\_desc_0004.txt",
            "\\Phone\\Pictures\\My_EnumTest\\X0000es0", 
            "\\Phone\\Pictures\\My_EnumTest\\X0000es1"];
        this.readonlyTestEnumItemsSearchPatternRecursive = [
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
        this.FolderPersistentUniqueId = "{052BDC9B-08B6-A6AB-5591-E52A8B782B74}"; // "{ CF527675-97D8-3DEF-0000-000000000000}";
        this.FolderPersistentUniqueIdPath = @"\Phone\Music";
        this.FilePersistentUniqueId = "{25606D91-C12C-CF74-93A6-34E88717AD11}"; // "{FDFF71F3-E0BD-D98E-0000-000000000000}";
        this.FilePersistentUniqueIdPath = @"\Phone\Samsung\Music\Over_the_Horizon.mp3"; // @"\Phone\Videos\desktop.ini"; Directory = "\\Phone\\Samsung\\Music"

        #endregion

        #region Writeable Tests

        this.workingFolder = @"\Card\Test";

        this.drives = ["Phone", "Card"];

        #endregion

        // Exists Test
            
    }
}
