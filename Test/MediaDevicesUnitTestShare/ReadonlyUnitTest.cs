namespace MediaDevicesUnitTest;

public abstract class ReadonlyUnitTest : UnitTest
{
    // file
    protected string? readonlyFilePath;
    protected ulong readonlyFileLength;
    protected DateTime? readonlyFileCreationTime;
    protected DateTime? readonlyFileLastWriteTime;
    protected DateTime? readonlyFileAuthoredTime;
    protected MediaFileAttributes? readonlyFileAttributes = MediaFileAttributes.Normal;

    protected string? readonlyFileParentPath;
    protected DateTime? readonlyFileParentCreationTime;
    protected DateTime? readonlyFileParentLastWriteTime;
    protected DateTime? readonlyFileParentAuthoredTime = DateTime.MinValue;
    protected MediaFileAttributes? readonlyFileParentAttributes = MediaFileAttributes.Directory;

    // folderParent 
    protected string? readonlyFolderPath;
    protected DateTime? readonlyFolderCreationTime;
    protected DateTime? readonlyFolderLastWriteTime;
    protected DateTime? readonlyFolderAuthoredTime = DateTime.MinValue; 
    protected MediaFileAttributes? readonlyFolderAttributes = MediaFileAttributes.Directory;

    protected string? readonlyFolderParentPath;
    protected DateTime? readonlyFolderParentCreationTime;
    protected DateTime? readonlyFolderParentLastWriteTime;
    protected DateTime? readonlyFolderParentAuthoredTime = DateTime.MinValue;
    protected MediaFileAttributes? readonlyFolderParentAttributes = MediaFileAttributes.Directory;

    // Enumerable & List tests
    protected string? readonlyEnumPath;
    protected string? readonlyEnumFolderSearchPattern;
    protected string? readonlyEnumFileSearchPattern;
    protected string? readonlyEnumItemSearchPattern;

    protected List<string>? readonlyEnumFoldersAll;
    protected List<string>? readonlyEnumFoldersAllRecursive;
    protected List<string>? readonlyEnumFoldersSearchPattern;
    protected List<string>? readonlyEnumFoldersSearchPatternRecursive;

    protected List<string>? readonlyEnumFilesAll;
    protected List<string>? readonlyEnumFilesAllRecursive;
    protected List<string>? readonlyEnumFilesSearchPattern;
    protected List<string>? readonlyEnumFilesSearchPatternRecursive;

    protected List<string>? readonlyEnumItemsAll;
    protected List<string>? readonlyEnumItemsAllRecursive;
    protected List<string>? readonlyEnumItemsSearchPattern;
    protected List<string>? readonlyEnumItemsSearchPatternRecursive;

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
        Assert.AreEqual(Path.GetFileName(readonlyFilePath), file.Name, "File Name");
        Assert.AreEqual(readonlyFilePath, file.FullName, "File FullName");
        Assert.AreEqual(readonlyFileLength, file.Length, "File Length");
        Assert.AreEqual(readonlyFileCreationTime, file.CreationTime, "File CreationTime");
        Assert.AreEqual(readonlyFileLastWriteTime, file.LastWriteTime, "File LastWriteTime");
        Assert.AreEqual(readonlyFileAuthoredTime, file.DateAuthored, "File DateAuthored");
        Assert.AreEqual(readonlyFileAttributes, file.Attributes, "File Attributes");

        // folderParent folderParent asserts
        Assert.AreEqual(Path.GetFileName(readonlyFileParentPath), parent!.Name, "File Parent Name");
        Assert.AreEqual(readonlyFileParentPath, parent.FullName, "File Parent FullName");
        Assert.AreEqual(0ul, parent.Length, "File Parent Length");
        Assert.AreEqual(readonlyFileParentCreationTime, parent.CreationTime, "File Parent CreationTime");
        Assert.AreEqual(readonlyFileParentLastWriteTime, parent.LastWriteTime, "File Parent LastWriteTime");
        Assert.AreEqual(readonlyFileParentAuthoredTime, parent.DateAuthored, "File Parent DateAuthored");
        Assert.AreEqual(readonlyFileParentAttributes, parent.Attributes, "File Parent Attributes");

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
    [Description("Download a icon from the target.")]
    public void ReadonlyMediaDeviceDownloadIconTest()
    {
        CheckIgnoreTest(Ignore.DownloadIcon);

        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.readonlyFilePath!));
        

        var device = GetDevice();
        device.Connect();

        var exists1 = device.FileExists(readonlyFilePath!);

        device.DownloadIcon(readonlyFilePath!, tempFile);

        device.Disconnect();

        Assert.IsTrue(exists1);
        Assert.IsTrue(File.Exists(tempFile), "Exists");
        Assert.IsGreaterThan(100, new FileInfo(tempFile).Length, "Length");

    }

    [TestMethod]
    [Description("Download a thumbnail from the target.")]
    public void ReadonlyMediaDeviceDownloadThumbnailTest()
    {
        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.readonlyFilePath!));

        var device = GetDevice();
        device.Connect();

        var exists1 = device.FileExists(readonlyFilePath!);

        device.DownloadThumbnail(readonlyFilePath!, tempFile);

        device.Disconnect();

        Assert.IsTrue(exists1);
        Assert.IsTrue(File.Exists(tempFile), "Exists");
        Assert.IsGreaterThan(100, new FileInfo(tempFile).Length, "Length");

    }

    //[TestMethod]
    //[Description("Download a folder tree from the target.")]
    //public void ReadonlyMediaDeviceDownloadTreeTest()
    //{
    //    var device = GetDevice();
    //    device.Connect();

    //    string sourceFolder = Path.Combine(testDataFolder, "UploadTree");
    //    string destFolder = Path.Combine(this.workingFolder!, "UploadTree");

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
        Assert.AreEqual(Path.GetFileName(readonlyFolderPath), folder.Name, "Folder Name");
        Assert.AreEqual(readonlyFolderPath, folder.FullName, "Folder FullName");
        Assert.AreEqual(0ul, folder.Length, "Folder Length");
        Assert.AreEqual(readonlyFolderCreationTime, folder.CreationTime, "Folder CreationTime");
        Assert.AreEqual(readonlyFolderLastWriteTime, folder.LastWriteTime, "Folder LastWriteTime");
        Assert.AreEqual(readonlyFolderAuthoredTime, folder.DateAuthored, "Folder DateAuthored");
        Assert.AreEqual(readonlyFolderAttributes, folder.Attributes, "Folder Attributes");

        // folderParent
        Assert.AreEqual(Path.GetFileName(readonlyFolderParentPath), folderParent.Name, "Folder Parent Name");
        Assert.AreEqual(readonlyFolderParentPath, folderParent.FullName, "Folder Parent FullName");
        Assert.AreEqual(0ul, folderParent.Length, "Folder Parent Length");
        Assert.AreEqual(readonlyFolderParentCreationTime, folderParent.CreationTime, "Folder Parent CreationTime");
        Assert.AreEqual(readonlyFolderParentLastWriteTime, folderParent.LastWriteTime, "Folder Parent LastWriteTime");
        Assert.AreEqual(readonlyFolderParentAuthoredTime, folderParent.DateAuthored, "Folder Parent DateAuthored");
        Assert.AreEqual(readonlyFolderParentAttributes, folderParent.Attributes, "Folder Parent Attributes");

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

        var enum1 = device.EnumerateFiles(this.readonlyEnumPath!).ToList();
        var enum2 = device.EnumerateFiles(this.readonlyEnumPath!, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateFiles(this.readonlyEnumPath!, this.readonlyEnumFileSearchPattern!).ToList();
        var enum4 = device.EnumerateFiles(this.readonlyEnumPath!, this.readonlyEnumFileSearchPattern!, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyEnumFilesAll, enum1, SequenceOrder.InAnyOrder, "EnumFilesAll");
        Assert.AreSequenceEqual(this.readonlyEnumFilesAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumFilesAllRecursive");
        Assert.AreSequenceEqual(this.readonlyEnumFilesSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumFilesSearchPattern");
        Assert.AreSequenceEqual(this.readonlyEnumFilesSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumFilesSearchPatternRecursive");
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
        var enum3 = dir.EnumerateFiles(this.readonlyEnumFileSearchPattern!).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateFiles(this.readonlyEnumFileSearchPattern!, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyEnumFilesAll, enum1, SequenceOrder.InAnyOrder, "readonlyEnumFilesAll");
        Assert.AreSequenceEqual(this.readonlyEnumFilesAllRecursive, enum2, SequenceOrder.InAnyOrder, "readonlyEnumFilesAllRecursive");
        Assert.AreSequenceEqual(this.readonlyEnumFilesSearchPattern, enum3, SequenceOrder.InAnyOrder, "readonlyEnumFilesSearchPattern");
        Assert.AreSequenceEqual(this.readonlyEnumFilesSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "readonlyEnumFilesSearchPatternRecursive");
    }

    #endregion

    #region Enum folders test

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumDirectoriesTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateDirectories(this.readonlyEnumPath!).ToList();
        var enum2 = device.EnumerateDirectories(this.readonlyEnumPath!, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateDirectories(this.readonlyEnumPath!, this.readonlyEnumFolderSearchPattern!).ToList();
        var enum4 = device.EnumerateDirectories(this.readonlyEnumPath!, this.readonlyEnumFolderSearchPattern!, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyEnumFoldersAll, enum1, SequenceOrder.InAnyOrder, "EnumFoldersAll");
        Assert.AreSequenceEqual(this.readonlyEnumFoldersAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumFoldersAllRecursive");
        Assert.AreSequenceEqual(this.readonlyEnumFoldersSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumFoldersSearchPattern");
        Assert.AreSequenceEqual(this.readonlyEnumFoldersSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumFoldersSearchPatternRecursive");
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
        var enum3 = dir.EnumerateDirectories(this.readonlyEnumFolderSearchPattern!).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateDirectories(this.readonlyEnumFolderSearchPattern!, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyEnumFoldersAll, enum1, SequenceOrder.InAnyOrder, "EnumFoldersAll");
        Assert.AreSequenceEqual(this.readonlyEnumFoldersAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumFoldersAllRecursive");
        Assert.AreSequenceEqual(this.readonlyEnumFoldersSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumFoldersSearchPattern");
        Assert.AreSequenceEqual(this.readonlyEnumFoldersSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumFoldersSearchPatternRecursive");
    }

    #endregion

    #region Enum items test

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumItemsTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateFileSystemEntries(this.readonlyEnumPath!).ToList();
        var enum2 = device.EnumerateFileSystemEntries(this.readonlyEnumPath!, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateFileSystemEntries(this.readonlyEnumPath!, this.readonlyEnumItemSearchPattern!).ToList();
        var enum4 = device.EnumerateFileSystemEntries(this.readonlyEnumPath!, this.readonlyEnumItemSearchPattern!, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyEnumItemsAll, enum1, SequenceOrder.InAnyOrder, "EnumItemsAll");
        Assert.AreSequenceEqual(this.readonlyEnumItemsAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumItemsAllRecursive");
        Assert.AreSequenceEqual(this.readonlyEnumItemsSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumItemsSearchPattern");
        Assert.AreSequenceEqual(this.readonlyEnumItemsSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumItemsSearchPatternRecursive");
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
        var enum3 = dir.EnumerateFileSystemInfos(this.readonlyEnumItemSearchPattern!).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateFileSystemInfos(this.readonlyEnumItemSearchPattern!, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyEnumItemsAll, enum1, SequenceOrder.InAnyOrder, "EnumItemsAll");
        Assert.AreSequenceEqual(this.readonlyEnumItemsAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumItemsAllRecursive");
        Assert.AreSequenceEqual(this.readonlyEnumItemsSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumItemsSearchPattern");
        Assert.AreSequenceEqual(this.readonlyEnumItemsSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumItemsSearchPatternRecursive");
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
