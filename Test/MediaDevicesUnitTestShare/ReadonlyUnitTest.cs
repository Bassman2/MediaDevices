namespace MediaDevicesUnitTest;

public abstract class ReadonlyUnitTest : UnitTest
{
    protected enum EnumerableMode
    {
        Sequence,
        Subset
    }

    // file tests
    protected string readonlyFilePath;
    protected ulong readonlyFileLength;
    protected DateTime? readonlyFileCreationTime;
    protected DateTime? readonlyFileLastWriteTime;
    protected DateTime? readonlyFileAuthoredTime;
    protected MediaFileAttributes? readonlyFileAttributes = MediaFileAttributes.Normal;

    protected string? readonlyFileParentPath;
    protected DateTime? readonlyFileParentCreationTime = null;
    protected DateTime? readonlyFileParentLastWriteTime = null;
    protected DateTime? readonlyFileParentAuthoredTime = null;
    protected MediaFileAttributes? readonlyFileParentAttributes = MediaFileAttributes.Directory;

    // folder tests
    protected string? readonlyFolderPath;
    protected DateTime? readonlyFolderCreationTime = null;
    protected DateTime? readonlyFolderLastWriteTime = null;
    protected DateTime? readonlyFolderAuthoredTime = null; 
    protected MediaFileAttributes? readonlyFolderAttributes = MediaFileAttributes.Directory;

    protected string? readonlyFolderParentPath;
    protected bool readonlyFolderParentTimes = true;
    protected DateTime? readonlyFolderParentCreationTime = null;
    protected DateTime? readonlyFolderParentLastWriteTime = null;
    protected DateTime? readonlyFolderParentAuthoredTime = null;
    protected MediaFileAttributes? readonlyFolderParentAttributes = MediaFileAttributes.Directory;

    // Enumerable & List tests
    protected bool readonlyFileDownloadIcon = false;
    protected bool readonlyFileDownloadThumbnail = false;

    protected string readonlyEnumPath = "";
    protected string readonlyEnumSearchPatternFiles = "";
    protected string readonlyEnumSearchPatternFolders = "";
    protected string readonlyEnumSearchPatternItems = "";

    protected EnumerableMode readonlyEnumFilesMode = EnumerableMode.Sequence;
    protected List<string> readonlyEnumFiles = [];
    protected List<string> readonlyEnumFilesRecursive = [];
    protected List<string> readonlyEnumFilesSearchPattern = [];
    protected List<string> readonlyEnumFilesSearchPatternRecursive = [];

    protected EnumerableMode readonlyEnumFoldersMode = EnumerableMode.Sequence;
    protected List<string> readonlyEnumFolders = [];
    protected List<string> readonlyEnumFoldersRecursive = [];
    protected List<string> readonlyEnumFoldersSearchPattern = [];
    protected List<string> readonlyEnumFoldersSearchPatternRecursive = [];

    protected EnumerableMode readonlyEnumItemsMode = EnumerableMode.Sequence;
    protected List<string> readonlyEnumItems = [];
    protected List<string> readonlyEnumItemsRecursive = [];
    protected List<string> readonlyEnumItemsSearchPattern = [];
    protected List<string> readonlyEnumItemsSearchPatternRecursive = [];

    protected ReadonlyUnitTest(string testPath)
    {
        // for writeable device or readonly devices with SD card, copy MediaDevices\TestData to the device nad use this settings
        readonlyFilePath = Path.Combine(testPath, "Test_ReadonlyFile");
        readonlyEnumPath = Path.Combine(testPath, "Test_ReadonlyEnum");

        readonlyEnumSearchPatternFolders = "*data*";
        readonlyEnumSearchPatternFiles = "*data*";
        readonlyEnumSearchPatternItems = "*data*";

        readonlyEnumFiles = [
            readonlyEnumPath + "\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002.txt",
            readonlyEnumPath + "\\test_file_0001.txt",
            readonlyEnumPath + "\\test_file_0002.txt"];
        readonlyEnumFilesRecursive = [
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0002.txt",
            readonlyEnumPath + "\\test_file_0001.txt",
            readonlyEnumPath + "\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_file_0002.txt"];
        readonlyEnumFilesSearchPattern = [
            readonlyEnumPath + "\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002.txt"];
        readonlyEnumFilesSearchPatternRecursive = [
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0002.txt"];

        // ReadonlyDirectoryInfoEnumDirectoriesTest
        readonlyEnumFolders = [
            readonlyEnumPath + "\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0002", 
            readonlyEnumPath + "\\test_folder_0001", 
            readonlyEnumPath + "\\test_folder_0002"];
        readonlyEnumFoldersRecursive = [
            readonlyEnumPath + "\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0001\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001", 
            readonlyEnumPath + "\\test_data_0002",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001", 
            readonlyEnumPath + "\\test_folder_0001", 
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001", 
            readonlyEnumPath + "\\test_folder_0002", 
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001", 
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001"];
        readonlyEnumFoldersSearchPattern = [
            readonlyEnumPath + "\\test_data_0001",
            readonlyEnumPath + "\\test_data_0002"];

        readonlyEnumFoldersSearchPatternRecursive = [
            readonlyEnumPath + "\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0001\\test_data_0001",
            readonlyEnumPath + "\\test_data_0002", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0001",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001"];

        readonlyEnumItems = [
            readonlyEnumPath + "\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0002", 
            readonlyEnumPath + "\\test_data_0002.txt",
            readonlyEnumPath + "\\test_file_0001.txt",
            readonlyEnumPath + "\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0001",
            readonlyEnumPath + "\\test_folder_0002"];
        readonlyEnumItemsRecursive = [
            readonlyEnumPath + "\\test_data_0001",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0002", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_file_0001.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_file_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_file_0001.txt", 
            readonlyEnumPath + "\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_folder_0001",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001", 
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_file_0001.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_file_0001.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_folder_0002", 
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001", 
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_file_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_file_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_folder_0002\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_file_0001.txt", 
            readonlyEnumPath + "\\test_folder_0002\\test_file_0002.txt", 
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_file_0001.txt", 
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_file_0002.txt"];
        readonlyEnumItemsSearchPattern = [
            readonlyEnumPath + "\\test_data_0001",
            readonlyEnumPath + "\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002", 
            readonlyEnumPath + "\\test_data_0002.txt"];
        readonlyEnumItemsSearchPatternRecursive = [
            readonlyEnumPath + "\\test_data_0001",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_data_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_data_0001\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0001\\test_sub_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0002", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0001", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_data_0001.txt", 
            readonlyEnumPath + "\\test_data_0002\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_data_0002\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001", 
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_data_0002.txt", 
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0001\\test_sub_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001", 
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_data_0002.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0001.txt",
            readonlyEnumPath + "\\test_folder_0002\\test_sub_0001\\test_data_0002.txt"];
    }

    [TestMethod]
    [Description("Readonly Root test.")]
    public void ReadonlyRootTest()
    {
        var device = GetDevice();
        device.Connect();
        var root = device.GetRootDirectory();
        device.Disconnect();

        Assert.AreEqual("\\", root.Name, "root Name");
        Assert.AreEqual("\\", root.FullName, "root FullName");
        Assert.AreEqual(0ul, root.Length, "root Length");
        Assert.IsNull(root.CreationTime, "root CreationTime");
        Assert.IsNull(root.LastWriteTime, "root LastWriteTime");
        Assert.IsNull(root.DateAuthored, "root DateAuthored");
        Assert.AreEqual(MediaFileAttributes.Object, root.Attributes, "root Attributes");
    }

    #region MediaDevice file tests

    [TestMethod]
    [Description("Check if file exists.")]
    public void ReadonlyMediaDeviceFileExistsTest()
    {
        string existingFile = this.readonlyFilePath!;
        string nonexistingFile = Path.Combine(readonlyFolderPath!, "NonexistingFile.txt")!;

        var device = GetDevice();
        device.Connect();
        var exists1 = device.FileExists(existingFile!);
        var exists2 = device.FileExists(nonexistingFile);
        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsFalse(exists2, "exists2");
        
    }

    [TestMethod]
    [Description("Check mediaDeviceFile infos.")]
    public void ReadonlyFileInfoTest()
    {
        var device = GetDevice();
        device.Connect();

        var file = device.GetFileInfo(this.readonlyFilePath!);
        var parent = file.Directory;

        // file asserts
        Assert.AreEqual(Path.GetFileName(readonlyFilePath), file.Name, "readonlyFileName");
        Assert.AreEqual(readonlyFilePath, file.FullName, nameof(readonlyFilePath));
        Assert.AreEqual(readonlyFileLength, file.Length, nameof(readonlyFileLength));
        Assert.AreEqual(readonlyFileCreationTime, file.CreationTime, nameof(readonlyFileCreationTime));
        Assert.AreEqual(readonlyFileLastWriteTime, file.LastWriteTime, nameof(readonlyFileLastWriteTime));
        Assert.AreEqual(readonlyFileAuthoredTime, file.DateAuthored, nameof(readonlyFileAuthoredTime));
        Assert.AreEqual(readonlyFileAttributes, file.Attributes, nameof(readonlyFileAttributes));

        // folderParent folderParent asserts
        Assert.AreEqual(Path.GetFileName(readonlyFileParentPath), parent!.Name, "readonlyFileParentName");
        Assert.AreEqual(readonlyFileParentPath, parent.FullName, nameof(readonlyFileParentPath));
        Assert.AreEqual(0ul, parent.Length, "Folder 0 length");
        Assert.AreEqual(readonlyFileParentCreationTime, parent.CreationTime, nameof(readonlyFileParentCreationTime));
        Assert.AreEqual(readonlyFileParentLastWriteTime, parent.LastWriteTime, nameof(readonlyFileParentLastWriteTime));
        Assert.AreEqual(readonlyFileParentAuthoredTime, parent.DateAuthored, nameof(readonlyFileParentAuthoredTime));
        Assert.AreEqual(readonlyFileParentAttributes, parent.Attributes, nameof(readonlyFileParentAttributes));

        device.Disconnect();
    }

    [TestMethod]
    [Description("Download a mediaDeviceFile to the target.")]
    public void ReadonlyMediaDeviceFileDownloadPathTest()
    {
        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.readonlyFilePath!));

        var device = GetDevice();
        device.Connect();

        bool exists = device.FileExists(this.readonlyFilePath!);
        Assert.IsTrue(exists, "exists");
        
        device.DownloadFile(this.readonlyFilePath!, tempFile);
        device.Disconnect();

        Assert.IsTrue(File.Exists(tempFile), "Exists");
        Assert.AreEqual(readonlyFileLength, (ulong)new FileInfo(tempFile).Length, "Length");
    }

    [TestMethod]
    [Description("Download a mediaDeviceFile to the target.")]
    [Ignore("Test takes too long")]
    public void ReadonlyMediaDeviceFileDownloadPathBigSizeTest()
    {
        string sourcePath = @"\Card\BigSize.zip";
        string destinationPath = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(".zip"));
        ulong destinationFileSize = 2359730001ul;

        var device = GetDevice();
        device.Connect();

        bool exists = device.FileExists(sourcePath);
        Assert.IsTrue(exists, "exists");

        device.DownloadFile(sourcePath, destinationPath);
        device.Disconnect();

        Assert.IsTrue(File.Exists(destinationPath), "Exists");
        Assert.AreEqual(destinationFileSize, (ulong)new FileInfo(destinationPath).Length, nameof(destinationFileSize));
    }



    [TestMethod]
    [Description("Download a mediaDeviceFile from the target.")]
    public void ReadonlyMediaDeviceFileDownloadStreamTest()
    {
        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.readonlyFilePath!));

        var device = GetDevice();
        device.Connect();

        bool exists = device.FileExists(this.readonlyFilePath!);
        Assert.IsTrue(exists, "exists");

        using (var stream = File.Create(tempFile))
        {
            device.DownloadFile(this.readonlyFilePath!, stream);
        }

        device.Disconnect();

        Assert.IsTrue(File.Exists(tempFile), "Exists");
        Assert.AreEqual(readonlyFileLength, (ulong)new FileInfo(tempFile).Length, "Length");
    }

    [TestMethod]
    [Description("Download a mediaDeviceFile to the target.")]
    [Ignore("Test takes too long")]
    public void ReadonlyMediaDeviceFileDownloadStreamBigSizeTest()
    {
        string sourcePath = @"\Card\BigSize.zip";
        string destinationPath = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(".zip"));
        ulong destinationFileSize = 2359730001ul;

        var device = GetDevice();
        device.Connect();

        bool exists = device.FileExists(sourcePath);
        Assert.IsTrue(exists, "exists");

        using (var stream = File.Create(destinationPath))
        {
            device.DownloadFile(sourcePath, stream);
        }
        device.Disconnect();

        Assert.IsTrue(File.Exists(destinationPath), "Exists");
        Assert.AreEqual(destinationFileSize, (ulong)new FileInfo(destinationPath).Length, nameof(destinationFileSize));
    }

    [TestMethod]
    [Description("Download a icon from the target.")]
    public void ReadonlyMediaDeviceDownloadIconTest()
    {
        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.readonlyFilePath!));
        

        var device = GetDevice();
        device.Connect();

        var exists = device.FileExists(readonlyFilePath!);
        Assert.IsTrue(exists, "exists");

        if (readonlyFileDownloadIcon)
        {
            device.DownloadIcon(readonlyFilePath!, tempFile);
            Assert.IsTrue(File.Exists(tempFile), "Exists");
            Assert.IsGreaterThan(100, new FileInfo(tempFile).Length, "Length");
        }
        else
        {
            Assert.ThrowsExactly<NotSupportedException>(() => device.DownloadIcon(readonlyFilePath!, tempFile));
        }
        device.Disconnect();
    }

    [TestMethod]
    [Description("Download a thumbnail from the target.")]
    public void ReadonlyMediaDeviceDownloadThumbnailTest()
    {
        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.readonlyFilePath!));

        var device = GetDevice();
        device.Connect();

        var exists = device.FileExists(readonlyFilePath!);
        Assert.IsTrue(exists, "exists");

        if (readonlyFileDownloadThumbnail)
        {
            device.DownloadThumbnail(readonlyFilePath!, tempFile);
            Assert.IsTrue(File.Exists(tempFile), "Exists");
            Assert.IsGreaterThan(100, new FileInfo(tempFile).Length, "Length");
        }
        else
        {
            Assert.ThrowsExactly<NotSupportedException>(() => device.DownloadThumbnail(readonlyFilePath!, tempFile)); 
        }   
        device.Disconnect();
    }

    //[TestMethod]
    //[Description("Download a folder tree from the target.")]
    //public void ReadonlyMediaDeviceDownloadTreeTest()
    //{
    //    var device = GetDevice();
    //    device.Connect();

    //    string sourceFolder = Path.Combine(testDataFolder, "UploadTree");
    //    string destFolder = Path.Combine(this.writeableWorkingFolder!, "UploadTree");

    //    var exists1 = device.DirectoryExists(destFolder);
    //    if (exists1)
    //    {
    //        device.DeleteDirectory(destFolder, true);
    //    }


    //    device.UploadFolder(sourceFolder, destFolder);

    //    string downloadFolder = Path.Combine(testDataFolder, "DownloadTree");

    //    if (Directory.Exists(downloadFolder))
    //    {
    //        Directory.Delete(downloadFolder, true);
    //    }

    //    device.DownloadFolder(destFolder, downloadFolder);

    //    device.Disconnect();

    //    //Assert.IsTrue(File.Exists(tempFile), "Exists");

    //}



    #endregion

    #region MediaDevice folder tests

    [TestMethod]
    [Description("Check if folderParent exists.")]
    public void ReadonlyMediaDeviceFolderExistsTest()
    {
        string existingDirectory = Path.GetDirectoryName(readonlyFolderPath)!;
        string nonexistingDirectory = Path.Combine(readonlyFolderPath!, "NotExistingFolder");

        var device = GetDevice();
        device.Connect();
        var exists1 = device.DirectoryExists(existingDirectory);
        var exists2 = device.DirectoryExists(nonexistingDirectory);
        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsFalse(exists2, "exists2");
    }

    [TestMethod]
    [Description("Check directory infos.")]
    public void ReadonlyDirectoryInfoTest()
    {
        var device = GetDevice();
        device.Connect();

        var folder = device.GetDirectoryInfo(readonlyFolderPath!);
        var folderParent = folder.Parent!;
        
        // folderParent
        Assert.AreEqual(Path.GetFileName(readonlyFolderPath), folder.Name, "readonlyFolderName");
        Assert.AreEqual(readonlyFolderPath, folder.FullName, "readonlyFolderFullName");
        Assert.AreEqual(0ul, folder.Length, "readonlyFolderLength");
        Assert.AreEqual(readonlyFolderCreationTime, folder.CreationTime, "readonlyFolderCreationTime");
        Assert.AreEqual(readonlyFolderLastWriteTime, folder.LastWriteTime, "readonlyFolderLastWriteTime");
        Assert.AreEqual(readonlyFolderAuthoredTime, folder.DateAuthored, "readonlyFolderAuthoredTime");
        Assert.AreEqual(readonlyFolderAttributes, folder.Attributes, "readonlyFolderAttributes");

        // folderParent
        Assert.AreEqual(Path.GetFileName(readonlyFolderParentPath), folderParent.Name, "readonlyFolderParentName");
        Assert.AreEqual(readonlyFolderParentPath, folderParent.FullName, nameof(readonlyFolderParentPath));
        Assert.AreEqual(0ul, folderParent.Length, "readonlyFolderParentLength");
        if (readonlyFolderParentTimes)
        {
            Assert.AreEqual(readonlyFolderParentCreationTime, folderParent.CreationTime, nameof(readonlyFolderParentCreationTime));
            Assert.AreEqual(readonlyFolderParentLastWriteTime, folderParent.LastWriteTime, nameof(readonlyFolderParentLastWriteTime));
            Assert.AreEqual(readonlyFolderParentAuthoredTime, folderParent.DateAuthored, "readonlyFolderParentDateAuthored");
        }
        Assert.AreEqual(readonlyFolderParentAttributes, folderParent.Attributes, nameof(readonlyFolderParentAttributes));

        device.Disconnect();
    }

    #endregion

    #region Enum files test

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumFilesTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateFiles(readonlyEnumPath).ToList();
        var enum2 = device.EnumerateFiles(readonlyEnumPath, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateFiles(readonlyEnumPath, readonlyEnumSearchPatternFiles).ToList();
        var enum4 = device.EnumerateFiles(readonlyEnumPath, readonlyEnumSearchPatternFiles, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        if (this.readonlyEnumFilesMode == EnumerableMode.Sequence)
        {
            Assert.AreSequenceEqual(readonlyEnumFiles, enum1, SequenceOrder.InAnyOrder, nameof(readonlyEnumFiles));
            Assert.AreSequenceEqual(readonlyEnumFilesRecursive, enum2, SequenceOrder.InAnyOrder, nameof(readonlyEnumFilesRecursive));
            Assert.AreSequenceEqual(readonlyEnumFilesSearchPattern, enum3, SequenceOrder.InAnyOrder, nameof(readonlyEnumFilesSearchPattern));
            Assert.AreSequenceEqual(readonlyEnumFilesSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, nameof(readonlyEnumFilesSearchPatternRecursive));
        }
        else
        {
            CollectionAssert.IsSubsetOf(readonlyEnumFiles, enum1, nameof(readonlyEnumFiles));
            CollectionAssert.IsSubsetOf(readonlyEnumFilesRecursive, enum2, nameof(readonlyEnumFilesRecursive));
            CollectionAssert.IsSubsetOf(readonlyEnumFilesSearchPattern, enum3, nameof(readonlyEnumFilesSearchPattern));
            CollectionAssert.IsSubsetOf(readonlyEnumFilesSearchPatternRecursive, enum4, nameof(readonlyEnumFilesSearchPatternRecursive));
        }
    }

    [TestMethod]
    [Description("Check directory infos enum.")]
    public void ReadonlyDirectoryInfoEnumFilesTest()
    {
        var device = GetDevice();
        device.Connect();

        var dir = device.GetDirectoryInfo(this.readonlyEnumPath!);

        var enum1 = dir.EnumerateFiles().Select(e => e.FullName).ToList();
        var enum2 = dir.EnumerateFiles("", SearchOption.AllDirectories).Select(e => e.FullName).ToList();
        var enum3 = dir.EnumerateFiles(readonlyEnumSearchPatternFiles).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateFiles(readonlyEnumSearchPatternFiles, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        if(this.readonlyEnumFilesMode == EnumerableMode.Sequence)
        {
            Assert.AreSequenceEqual(readonlyEnumFiles, enum1, SequenceOrder.InAnyOrder, nameof(readonlyEnumFiles));
            Assert.AreSequenceEqual(readonlyEnumFilesRecursive, enum2, SequenceOrder.InAnyOrder, nameof(readonlyEnumFilesRecursive));
            Assert.AreSequenceEqual(readonlyEnumFilesSearchPattern, enum3, SequenceOrder.InAnyOrder, nameof(readonlyEnumFilesSearchPattern));
            Assert.AreSequenceEqual(readonlyEnumFilesSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, nameof(readonlyEnumFilesSearchPatternRecursive));
        }
        else
        {
            CollectionAssert.IsSubsetOf(readonlyEnumFiles, enum1, nameof(readonlyEnumFiles));
            CollectionAssert.IsSubsetOf(readonlyEnumFilesRecursive, enum2, nameof(readonlyEnumFilesRecursive));
            CollectionAssert.IsSubsetOf(readonlyEnumFilesSearchPattern, enum3, nameof(readonlyEnumFilesSearchPattern));
            CollectionAssert.IsSubsetOf(readonlyEnumFilesSearchPatternRecursive, enum4, nameof(readonlyEnumFilesSearchPatternRecursive));
        }
    }

    #endregion

    #region Enum folders test

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumDirectoriesTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateDirectories(readonlyEnumPath).ToList();
        var enum2 = device.EnumerateDirectories(readonlyEnumPath, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateDirectories(readonlyEnumPath, readonlyEnumSearchPatternFolders).ToList();
        var enum4 = device.EnumerateDirectories(readonlyEnumPath, readonlyEnumSearchPatternFolders, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        if (this.readonlyEnumFoldersMode == EnumerableMode.Sequence)
        {
            Assert.AreSequenceEqual(readonlyEnumFolders, enum1, SequenceOrder.InAnyOrder, nameof(readonlyEnumFolders));
            Assert.AreSequenceEqual(readonlyEnumFoldersRecursive, enum2, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersRecursive));
            Assert.AreSequenceEqual(readonlyEnumFoldersSearchPattern, enum3, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersSearchPattern));
            Assert.AreSequenceEqual(readonlyEnumFoldersSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersSearchPatternRecursive));
        }
        else
        {
            CollectionAssert.IsSubsetOf(readonlyEnumFolders, enum1, nameof(readonlyEnumFolders));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersRecursive, enum2, nameof(readonlyEnumFoldersRecursive));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersSearchPattern, enum3, nameof(readonlyEnumFoldersSearchPattern));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersSearchPatternRecursive, enum4, nameof(readonlyEnumFoldersSearchPatternRecursive));
        }
    }

    [TestMethod]
    [Description("Check directory infos enum.")]
    public void ReadonlyDirectoryInfoEnumDirectoriesTest()
    {
        var device = GetDevice();
        device.Connect();

        var dir = device.GetDirectoryInfo(this.readonlyEnumPath!);

        var enum1 = dir.EnumerateDirectories().Select(e => e.FullName).ToList();
        var enum2 = dir.EnumerateDirectories("", SearchOption.AllDirectories).Select(e => e.FullName).ToList();
        var enum3 = dir.EnumerateDirectories(readonlyEnumSearchPatternFolders).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateDirectories(readonlyEnumSearchPatternFolders, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        if (this.readonlyEnumFoldersMode == EnumerableMode.Sequence)
        {
            Assert.AreSequenceEqual(readonlyEnumFolders, enum1, SequenceOrder.InAnyOrder, nameof(readonlyEnumFolders));
            Assert.AreSequenceEqual(readonlyEnumFoldersRecursive, enum2, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersRecursive));
            Assert.AreSequenceEqual(readonlyEnumFoldersSearchPattern, enum3, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersSearchPattern));
            Assert.AreSequenceEqual(readonlyEnumFoldersSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersSearchPatternRecursive));
        }
        else
        {
            CollectionAssert.IsSubsetOf(readonlyEnumFolders, enum1, nameof(readonlyEnumFolders));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersRecursive, enum2, nameof(readonlyEnumFoldersRecursive));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersSearchPattern, enum3, nameof(readonlyEnumFoldersSearchPattern));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersSearchPatternRecursive, enum4, nameof(readonlyEnumFoldersSearchPatternRecursive));
        }
    }

    #endregion

    #region Enum items test

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumItemsTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateFileSystemEntries(readonlyEnumPath).ToList();
        var enum2 = device.EnumerateFileSystemEntries(readonlyEnumPath, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateFileSystemEntries(readonlyEnumPath, readonlyEnumSearchPatternItems).ToList();
        var enum4 = device.EnumerateFileSystemEntries(readonlyEnumPath, readonlyEnumSearchPatternItems, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        if (this.readonlyEnumFoldersMode == EnumerableMode.Sequence)
        {
            Assert.AreSequenceEqual(readonlyEnumItems, enum1, SequenceOrder.InAnyOrder, nameof(readonlyEnumItems));
            Assert.AreSequenceEqual(readonlyEnumItemsRecursive, enum2, SequenceOrder.InAnyOrder, nameof(readonlyEnumItemsRecursive));
            Assert.AreSequenceEqual(readonlyEnumItemsSearchPattern, enum3, SequenceOrder.InAnyOrder, nameof(readonlyEnumItemsSearchPattern));
            Assert.AreSequenceEqual(readonlyEnumItemsSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, nameof(readonlyEnumItemsSearchPatternRecursive));
        }
        else
        {
            CollectionAssert.IsSubsetOf(readonlyEnumItems, enum1, nameof(readonlyEnumItems));
            CollectionAssert.IsSubsetOf(readonlyEnumItemsRecursive, enum2, nameof(readonlyEnumItemsRecursive));
            CollectionAssert.IsSubsetOf(readonlyEnumItemsSearchPattern, enum3, nameof(readonlyEnumItemsSearchPattern));
            CollectionAssert.IsSubsetOf(readonlyEnumItemsSearchPatternRecursive, enum4, nameof(readonlyEnumItemsSearchPatternRecursive));
        }
    }

    [TestMethod]
    [Description("Check directory infos enum.")]
    public void ReadonlyDirectoryInfoEnumItemsTest()
    {
        var device = GetDevice();
        device.Connect();

        var dir = device.GetDirectoryInfo(this.readonlyEnumPath!);

        var enum1 = dir.EnumerateFileSystemInfos().Select(e => e.FullName).ToList();
        var enum2 = dir.EnumerateFileSystemInfos("", SearchOption.AllDirectories).Select(e => e.FullName).ToList();
        var enum3 = dir.EnumerateFileSystemInfos(readonlyEnumSearchPatternItems).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateFileSystemInfos(readonlyEnumSearchPatternItems, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        if (this.readonlyEnumFoldersMode == EnumerableMode.Sequence)
        {
            Assert.AreSequenceEqual(readonlyEnumItems, enum1, SequenceOrder.InAnyOrder, nameof(readonlyEnumItems));
            Assert.AreSequenceEqual(readonlyEnumItemsRecursive, enum2, SequenceOrder.InAnyOrder, nameof(readonlyEnumItemsRecursive));
            Assert.AreSequenceEqual(readonlyEnumItemsSearchPattern, enum3, SequenceOrder.InAnyOrder, nameof(readonlyEnumItemsSearchPattern));
            Assert.AreSequenceEqual(readonlyEnumItemsSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, nameof(readonlyEnumItemsSearchPatternRecursive));
        }
        else
        {
            CollectionAssert.IsSubsetOf(readonlyEnumItems, enum1, nameof(readonlyEnumItems));
            CollectionAssert.IsSubsetOf(readonlyEnumItemsRecursive, enum2, nameof(readonlyEnumItemsRecursive));
            CollectionAssert.IsSubsetOf(readonlyEnumItemsSearchPattern, enum3, nameof(readonlyEnumItemsSearchPattern));
            CollectionAssert.IsSubsetOf(readonlyEnumItemsSearchPatternRecursive, enum4, nameof(readonlyEnumItemsSearchPatternRecursive));
        }
    }

    #endregion

    #region PersistentUniqueId

    [TestMethod]
    [Description("Check persistent unique id functionality.")]
    public void ReadonlyPersistentUniqueIdFileTest()
    {
        var device = GetDevice();
        device.Connect();

        MediaFileInfo mfi = device.GetFileInfo(readonlyFilePath!);
        Assert.IsNotNull(mfi);
        Assert.IsNotNull(mfi.PersistentUniqueId);
        
        var path = device.GetPathFromPersistentUniqueId(mfi.PersistentUniqueId)!;
        var file = device.GetFileSystemInfoFromPersistentUniqueId(mfi.PersistentUniqueId!) as MediaFileInfo;

        Assert.AreEqual(readonlyFilePath, path, "readonlyFilePath");

        Assert.AreEqual(Path.GetFileName(readonlyFilePath), file?.Name, "readonlyFileName");
        Assert.AreEqual(readonlyFilePath, file?.FullName, "readonlyFilePath");
        Assert.AreEqual(mfi.PersistentUniqueId, file?.PersistentUniqueId, "PersistentUniqueId");

        device.Disconnect();
    }


    [TestMethod]
    [Description("Readonly PersistentUniqueId Test")]
    public void ReadonlyPersistentUniqueIdFolderTest()
    {
        var device = GetDevice();
        device.Connect();

        MediaDirectoryInfo mfi = device.GetDirectoryInfo(readonlyFolderPath!);
        Assert.IsNotNull(mfi);
        Assert.IsNotNull(mfi.PersistentUniqueId);

        var path = device.GetPathFromPersistentUniqueId(mfi.PersistentUniqueId)!;
        var file = device.GetFileSystemInfoFromPersistentUniqueId(mfi.PersistentUniqueId!) as MediaDirectoryInfo;

        Assert.AreEqual(readonlyFolderPath, path, "readonlyFolderPath");

        Assert.AreEqual(Path.GetFileName(readonlyFolderPath), file?.Name, "readonlyFolderName");
        Assert.AreEqual(readonlyFolderPath, file?.FullName, "readonlyFolderPath");
        Assert.AreEqual(mfi.PersistentUniqueId, file?.PersistentUniqueId, "PersistentUniqueId");

        device.Disconnect();
    }

    #endregion
}
