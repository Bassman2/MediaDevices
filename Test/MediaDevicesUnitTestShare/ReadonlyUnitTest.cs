namespace MediaDevicesUnitTest;

public abstract class ReadonlyUnitTest : UnitTest
{
    // mediaDeviceFile
    protected string? readonlyTestFilePath;
    protected ulong readonlyTestFileLength;
    protected DateTime? readonlyTestFileCreationTime;
    protected DateTime? readonlyTestFileLastWriteTime;
    protected DateTime? readonlyTestFileAuthoredTime;
    protected MediaFileAttributes? readonlyTestFileAttributes = MediaFileAttributes.Normal;

    // folder of mediaDeviceFile
    protected string? readonlyTestFolderPath;
    protected DateTime? readonlyTestFolderCreationTime;
    protected DateTime? readonlyTestFolderLastWriteTime;
    protected DateTime? readonlyTestFolderAuthoredTime = DateTime.MinValue; 
    protected MediaFileAttributes? readonlyTestFolderAttributes = MediaFileAttributes.Directory;

    // mediaDeviceParent of folder
    protected string? readonlyTestParentPath;
    protected DateTime? readonlyTestParentCreationTime;
    protected DateTime? readonlyTestParentLastWriteTime;
    protected DateTime? readonlyTestParentAuthoredTime = DateTime.MinValue;
    protected MediaFileAttributes? readonlyTestParentAttributes = MediaFileAttributes.Directory;

    // Enum
    protected string? readonlyTestEnumPath;
    protected string? readonlyTestEnumFolderSearchPattern;
    protected string? readonlyTestEnumFileSearchPattern;
    protected string? readonlyTestEnumItemSearchPattern;

    protected List<string>? readonlyTestEnumFoldersAll;
    protected List<string>? readonlyTestEnumFoldersAllRecursive;
    protected List<string>? readonlyTestEnumFoldersSearchPattern;
    protected List<string>? readonlyTestEnumFoldersSearchPatternRecursive;

    protected List<string>? readonlyTestEnumFilesAll;
    protected List<string>? readonlyTestEnumFilesAllRecursive;
    protected List<string>? readonlyTestEnumFilesSearchPattern;
    protected List<string>? readonlyTestEnumFilesSearchPatternRecursive;

    protected List<string>? readonlyTestEnumItemsAll;
    protected List<string>? readonlyTestEnumItemsAllRecursive;
    protected List<string>? readonlyTestEnumItemsSearchPattern;
    protected List<string>? readonlyTestEnumItemsSearchPatternRecursive;

    [TestMethod]
    [Description("Check if files and folders exists.")]
    public void ReadonlyMediaDeviceExistsTest()
    {
        string existingFile = this.readonlyTestFilePath!;
        string existingDirectory = Path.GetDirectoryName(existingFile)!;
        string nonexistingFile = Path.Combine(existingDirectory, "NonexistingFile.txt")!;
        string nonexistingDirectory = Path.Combine(existingDirectory, "NotExistingFolder");

        var device = GetDevice();
        device.Connect();

        var exists1 = device.DirectoryExists(existingDirectory);
        var exists2 = device.DirectoryExists(nonexistingDirectory);
        var exists3 = device.FileExists(existingFile!);
        var exists4 = device.FileExists(nonexistingFile);

        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsFalse(exists2, "exists2");
        Assert.IsTrue(exists3, "exists3");
        Assert.IsFalse(exists4, "exists4");
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
        Assert.AreEqual(null, root.CreationTime, "root CreationTime");
        Assert.AreEqual(null, root.LastWriteTime, "root LastWriteTime");
        Assert.AreEqual(null, root.DateAuthored, "root DateAuthored");
        Assert.AreEqual(MediaFileAttributes.Object, root.Attributes, "root Attributes");
    }
        
    [TestMethod]
    [Description("Download a mediaDeviceFile from the target.")]
    public void ReadonlyMediaDeviceDownloadTest()
    {
        long position;
        var device = GetDevice();
        device.Connect();

        bool exists = device.FileExists(this.readonlyTestFilePath!);
        Assert.IsTrue(exists, "exists");

        string tempFile = Path.Combine(Path.GetTempPath(), Path.GetFileName(this.readonlyTestFilePath!));
        using (var stream = new MemoryStream())
        {
            device.DownloadFile(this.readonlyTestFilePath!, stream);
            position = stream.Length;

            using var file = File.Create(tempFile);
            stream.Position = 0;
            stream.CopyTo(file);
        }

        device.Disconnect();

        Assert.IsGreaterThan(0, position, "Position");
        Assert.IsTrue(File.Exists(tempFile), "Exists");
    }

    [TestMethod]
    [Description("Check mediaDeviceFile infos.")]
    public void ReadonlyFileInfoTest()
    {
        var device = GetDevice();
        device.Connect();

        var file = device.GetFileInfo(this.readonlyTestFilePath!);
        var folder = file.Directory;

        // file asserts
        Assert.AreEqual(Path.GetFileName(readonlyTestFilePath), file.Name, "File Name");
        Assert.AreEqual(readonlyTestFilePath, file.FullName, "File FullName");
        Assert.AreEqual(readonlyTestFileLength, file.Length, "File Length");
        Assert.AreEqual(readonlyTestFileCreationTime, file.CreationTime, "File CreationTime");
        Assert.AreEqual(readonlyTestFileLastWriteTime, file.LastWriteTime, "File LastWriteTime");
        Assert.AreEqual(readonlyTestFileAuthoredTime, file.DateAuthored, "File DateAuthored");
        Assert.AreEqual(readonlyTestFileAttributes, file.Attributes, "File Attributes");
        
        // folder asserts
        Assert.AreEqual(Path.GetFileName(readonlyTestFolderPath), folder!.Name, "Folder Name");
        Assert.AreEqual(readonlyTestFolderPath, folder.FullName, "Folder FullName");
        Assert.AreEqual(0ul, folder.Length, "Folder Length");
        Assert.AreEqual(readonlyTestFolderCreationTime, folder.CreationTime, "Folder CreationTime");
        Assert.AreEqual(readonlyTestFolderLastWriteTime, folder.LastWriteTime, "Folder LastWriteTime");
        Assert.AreEqual(readonlyTestFolderAuthoredTime, folder.DateAuthored, "Folder DateAuthored");
        Assert.AreEqual(readonlyTestFolderAttributes, folder.Attributes, "Folder Attributes");

        using (var mem = new MemoryStream())
        {
            using (var stream = file.OpenRead())
            {
                stream.CopyTo(mem);
            }
            Assert.AreEqual(this.readonlyTestFileLength, (ulong)mem.Position, "mediaDeviceFile read size");
        }

        device.Disconnect();

    }

    [TestMethod]
    [Description("Check directory infos.")]
    public void ReadonlyDirectoryInfoTest()
    {
        var device = GetDevice();
        device.Connect();

        var folder = device.GetDirectoryInfo(readonlyTestFolderPath!);
        var parent = folder.Parent;
        var root = parent!.Parent;
        while (root!.Parent != null)
        {
            root = root!.Parent;
        }
        var empty = root!.Parent;

        // folder
        Assert.AreEqual(Path.GetFileName(readonlyTestFolderPath), folder.Name, "Folder Name");
        Assert.AreEqual(readonlyTestFolderPath, folder.FullName, "Folder FullName");
        Assert.AreEqual(0ul, folder.Length, "Folder Length");
        Assert.AreEqual(readonlyTestFolderCreationTime, folder.CreationTime, "Folder CreationTime");
        Assert.AreEqual(readonlyTestFolderLastWriteTime, folder.LastWriteTime, "Folder LastWriteTime");
        Assert.AreEqual(readonlyTestFolderAuthoredTime, folder.DateAuthored, "Folder DateAuthored");
        Assert.AreEqual(readonlyTestFolderAttributes, folder.Attributes, "Folder Attributes");
        
        // parent
        Assert.AreEqual(Path.GetFileName(readonlyTestParentPath), parent.Name, "Parent Name");
        Assert.AreEqual(readonlyTestParentPath, parent.FullName, "Parent FullName");
        Assert.AreEqual(0ul, parent.Length, "Parent Length");
        Assert.AreEqual(readonlyTestParentCreationTime, parent.CreationTime, "Parent CreationTime");
        Assert.AreEqual(readonlyTestParentLastWriteTime, parent.LastWriteTime, "Parent LastWriteTime");
        Assert.AreEqual(readonlyTestParentAuthoredTime, parent.DateAuthored, "Parent DateAuthored");
        Assert.AreEqual(readonlyTestParentAttributes, parent.Attributes, "Parent Attributes");
             
        // root
        Assert.AreEqual(@"\", root.Name, "root Name");
        Assert.AreEqual(@"\", root.FullName, "root FullName");
        Assert.AreEqual(0ul, root.Length, "root Length");
        Assert.IsNull(root.CreationTime, "root CreationTime");
        Assert.IsNull(root.LastWriteTime, "root LastWriteTime");
        Assert.IsNull(root.DateAuthored, "root DateAuthored");
        Assert.AreEqual(MediaFileAttributes.Object, root.Attributes, "root Attributes");
        
        Assert.IsNull(empty, "empty");

        device.Disconnect();
    }

    [TestMethod]
    [Description("Check directory infos enum.")]
    public void ReadonlyDirectoryInfoEnumDirectoriesTest()
    {
        var device = GetDevice();
        device.Connect();

        var dir = device.GetDirectoryInfo(this.readonlyTestEnumPath!);

        var enum1 = dir.EnumerateDirectories().Select(e => e.FullName).ToList();
        var enum2 = dir.EnumerateDirectories("", SearchOption.AllDirectories).Select(e => e.FullName).ToList();
        var enum3 = dir.EnumerateDirectories(this.readonlyTestEnumFolderSearchPattern!).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateDirectories(this.readonlyTestEnumFolderSearchPattern!, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersAll, enum1, SequenceOrder.InAnyOrder, "EnumFoldersAll");
        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumFoldersAllRecursive");
        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumFoldersSearchPattern");
        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumFoldersSearchPatternRecursive");
    }

    [TestMethod]
    [Description("Check directory infos enum.")]
    public void ReadonlyDirectoryInfoEnumFilesTest()
    {
        var device = GetDevice();
        device.Connect();

        var dir = device.GetDirectoryInfo(this.readonlyTestEnumPath!);
         
        var enum1 = dir.EnumerateFiles().Select(e => e.FullName).ToList();
        var enum2 = dir.EnumerateFiles("", SearchOption.AllDirectories).Select(e => e.FullName).ToList();
        var enum3 = dir.EnumerateFiles(this.readonlyTestEnumFileSearchPattern!).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateFiles(this.readonlyTestEnumFileSearchPattern!, SearchOption.AllDirectories).Select(e => e.FullName).ToList();
         
        device.Disconnect();
                
        Assert.AreSequenceEqual(this.readonlyTestEnumFilesAll, enum1, SequenceOrder.InAnyOrder, "EnumFilesAll");
        Assert.AreSequenceEqual(this.readonlyTestEnumFilesAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumFilesAllRecursive");
        Assert.AreSequenceEqual(this.readonlyTestEnumFilesSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumFilesSearchPattern");
        Assert.AreSequenceEqual(this.readonlyTestEnumFilesSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumFilesSearchPatternRecursive");
    }

    [TestMethod]
    [Description("Check directory infos enum.")]
    public void ReadonlyDirectoryInfoEnumItemsTest()
    {
        var device = GetDevice();
        device.Connect();

        var dir = device.GetDirectoryInfo(this.readonlyTestEnumPath!);
                
        var enum1 = dir.EnumerateFileSystemInfos().Select(e => e.FullName).ToList();
        var enum2 = dir.EnumerateFileSystemInfos("", SearchOption.AllDirectories).Select(e => e.FullName).ToList();
        var enum3 = dir.EnumerateFileSystemInfos(this.readonlyTestEnumItemSearchPattern!).Select(e => e.FullName).ToList();
        var enum4 = dir.EnumerateFileSystemInfos(this.readonlyTestEnumItemSearchPattern!, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyTestEnumItemsAll, enum1, SequenceOrder.InAnyOrder, "EnumItemsAll");
        Assert.AreSequenceEqual(this.readonlyTestEnumItemsAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumItemsAllRecursive");
        Assert.AreSequenceEqual(this.readonlyTestEnumItemsSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumItemsSearchPattern");
        Assert.AreSequenceEqual(this.readonlyTestEnumItemsSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumItemsSearchPatternRecursive");
    }

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumDirectoriesTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateDirectories(this.readonlyTestEnumPath!).ToList();
        var enum2 = device.EnumerateDirectories(this.readonlyTestEnumPath!, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateDirectories(this.readonlyTestEnumPath!, this.readonlyTestEnumFolderSearchPattern!).ToList();
        var enum4 = device.EnumerateDirectories(this.readonlyTestEnumPath!, this.readonlyTestEnumFolderSearchPattern!, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersAll, enum1, SequenceOrder.InAnyOrder, "EnumFoldersAll");
        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumFoldersAllRecursive");
        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumFoldersSearchPattern");
        Assert.AreSequenceEqual(this.readonlyTestEnumFoldersSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumFoldersSearchPatternRecursive");
    }

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumFilesTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateFiles(this.readonlyTestEnumPath!).ToList();
        var enum2 = device.EnumerateFiles(this.readonlyTestEnumPath!, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateFiles(this.readonlyTestEnumPath!, this.readonlyTestEnumFileSearchPattern!).ToList();
        var enum4 = device.EnumerateFiles(this.readonlyTestEnumPath!, this.readonlyTestEnumFileSearchPattern!, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyTestEnumFilesAll, enum1, SequenceOrder.InAnyOrder, "EnumFilesAll");
        Assert.AreSequenceEqual(this.readonlyTestEnumFilesAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumFilesAllRecursive");
        Assert.AreSequenceEqual(this.readonlyTestEnumFilesSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumFilesSearchPattern");
        Assert.AreSequenceEqual(this.readonlyTestEnumFilesSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumFilesSearchPatternRecursive");
    }

    [TestMethod]
    [Description("Check directory enum.")]
    public void ReadonlyMediaDeviceEnumItemsTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = device.EnumerateFileSystemEntries(this.readonlyTestEnumPath!).ToList();
        var enum2 = device.EnumerateFileSystemEntries(this.readonlyTestEnumPath!, "", SearchOption.AllDirectories).ToList();
        var enum3 = device.EnumerateFileSystemEntries(this.readonlyTestEnumPath!, this.readonlyTestEnumItemSearchPattern!).ToList();
        var enum4 = device.EnumerateFileSystemEntries(this.readonlyTestEnumPath!, this.readonlyTestEnumItemSearchPattern!, SearchOption.AllDirectories).ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.readonlyTestEnumItemsAll, enum1, SequenceOrder.InAnyOrder, "EnumItemsAll");
        Assert.AreSequenceEqual(this.readonlyTestEnumItemsAllRecursive, enum2, SequenceOrder.InAnyOrder, "EnumItemsAllRecursive");
        Assert.AreSequenceEqual(this.readonlyTestEnumItemsSearchPattern, enum3, SequenceOrder.InAnyOrder, "EnumItemsSearchPattern");
        Assert.AreSequenceEqual(this.readonlyTestEnumItemsSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, "EnumItemsSearchPatternRecursive");
    }

    [TestMethod]
    [Description("Download a mediaDeviceFile to the target.")]
    public void ReadonlyMediaDeviceDownloadFileTest()
    {
        var device = GetDevice();
        device.Connect();

        bool exists = device.FileExists(this.readonlyTestFilePath!);
        Assert.IsTrue(exists, "exists");

        string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.readonlyTestFilePath!));

        device.DownloadFile(this.readonlyTestFilePath!, tempFile);

        device.Disconnect();

        Assert.IsTrue(File.Exists(tempFile), "Exists");

    }

    [TestMethod]
    [Description("Check persistent unique id functionality.")]
    public void ReadonlyMediaDeviceSystemPersistentUniqueIdTest()
    {
        var device = GetDevice();
        device.Connect();

        MediaDirectoryInfo? dir = device.GetFileSystemInfoFromPersistentUniqueId(this.FolderPersistentUniqueId!) as MediaDirectoryInfo;

        MediaFileInfo? file = device.GetFileSystemInfoFromPersistentUniqueId(this.FilePersistentUniqueId!) as MediaFileInfo;
        device.Disconnect();

        Assert.IsNotNull(dir, "Dir");
        Assert.IsTrue(dir.Attributes.HasFlag(MediaFileAttributes.Directory), "folder.IsDirectory");
        Assert.AreEqual(this.FolderPersistentUniqueIdPath, dir.FullName, "folder.FullName");

        Assert.IsNotNull(file, "File");
        Assert.IsTrue(file.Attributes.HasFlag(MediaFileAttributes.Normal), "mediaDeviceFile.IsFile");
        Assert.AreEqual(this.FilePersistentUniqueIdPath, file.FullName, "mediaDeviceFile.FullName");
    }
}
