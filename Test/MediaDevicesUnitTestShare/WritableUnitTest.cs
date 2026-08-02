namespace MediaDevicesUnitTest;

public abstract class WritableUnitTest : ReadonlyUnitTest 
{
    protected readonly string testDataFolder = Path.GetFullPath(@".\..\..\..\..\TestData");
    protected string writeableWorkingFolder = string.Empty;

    protected List<string> treeList =
    [
        "\\UploadTree\\Aaa",
        "\\UploadTree\\Aaa\\A.txt",
        "\\UploadTree\\Aaa\\Abb",
        "\\UploadTree\\Aaa\\Abb\\Acc",
        "\\UploadTree\\Aaa\\Abb\\Acc\\Ctest.txt",
        "\\UploadTree\\Aaa\\Abb\\Add",
        "\\UploadTree\\Aaa\\Abb\\Aee.txt",
        "\\UploadTree\\Aaa\\Abb\\Aff.txt",
        "\\UploadTree\\Aaa\\Abb\\Agg.txt",
        "\\UploadTree\\Aaa\\Abb\\B.txt",
        "\\UploadTree\\Aaa\\Acc",
        "\\UploadTree\\Baa",
        "\\UploadTree\\Baa\\Bxx.txt",
        "\\UploadTree\\Bbb",
        "\\UploadTree\\Caa",
        "\\UploadTree\\Caa\\Cxx.txt",
        "\\UploadTree\\Ccc",
        "\\UploadTree\\Root.txt"
    ];
    protected List<string>? treeListFull;

    private string GetTempFile(string extention = ".txt")
    {
        return Path.Combine(writeableWorkingFolder, Path.ChangeExtension(Path.GetFileName(Path.GetTempFileName()), extention));
    }

    private string GetTempFolder()
    {
        return Path.Combine(writeableWorkingFolder, Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
    }   

    protected void UploadTestTree(MediaDevice device)
    {
        string folder = GetTempFolder();
        this.treeListFull = [.. treeList.Select(p => folder + p)];

        string sourceFolder = Path.Combine(testDataFolder, "UploadTree");

        // create empty folders not checked in
        Directory.CreateDirectory(Path.Combine(sourceFolder, @"Aaa\Abb\Add"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, @"Aaa\Acc"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "Bbb"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "Ccc"));

        var l = Directory.EnumerateFileSystemEntries(sourceFolder, "*", SearchOption.AllDirectories).OrderBy(s => s).ToList();
        var x = Directory.GetFileSystemEntries(sourceFolder, "*", SearchOption.AllDirectories).OrderBy(s => s).ToList();

        string destFolder = Path.Combine(folder, "UploadTree");
        
        var exists = device.DirectoryExists(destFolder);
        if (exists)
        {
            device.DeleteDirectory(destFolder, true);
        }

        device.UploadFolder(sourceFolder, destFolder);
    }

   

    [TestMethod]
    [Description("Creating a new folder.")]
    public void WritableCreateFolderTest()
    {
        var device = GetDevice();
        device.Connect();
        
        string newFolder = GetTempFolder();
        var exists1 = device.DirectoryExists(Path.GetDirectoryName(newFolder)!);
        device.CreateDirectory(newFolder);
        var exists2 = device.DirectoryExists(newFolder);
        device.DeleteDirectory(newFolder, true);
        var exists3 = device.DirectoryExists(newFolder);

        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsTrue(exists2, "exists2");
        Assert.IsFalse(exists3, "exists3");
    }

    [TestMethod]
    [Description("Upload a file to the target.")]
    public void WritableUploadFileStreamTest()
    {
        var device = GetDevice();
        device.Connect();

        string filePath = GetTempFile(".txt");
        if (device.FileExists(filePath))
        {
            device.DeleteFile(filePath);
        }

        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes("This is a test.")))
        {
            device.UploadFile(stream, filePath);
        }
        var exists1 = device.FileExists(filePath);
        device.DeleteFile(filePath);
        var exists2 = device.FileExists($@"\Phone\Downloads\{Path.GetFileName(filePath)}");

        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsFalse(exists2, "exists2");
    }

    [TestMethod]
    [Description("Upload a file to the target.")]
    public void WritableUploadFilePathTest()
    {
        var device = GetDevice();
        device.Connect();

        string sourceFile = Path.ChangeExtension(Path.GetTempFileName(), ".txt");
        string destFile = GetTempFile();

        Trace.WriteLine($"sourceFile: {sourceFile}");
        Trace.WriteLine($"destFile: {destFile}");

        using (var writer = File.CreateText(sourceFile))
        {
            writer.WriteLine("This is a test.");
            writer.Close();
        }
        File.SetCreationTime(sourceFile, new DateTime(2001, 1, 1));        
        File.SetLastWriteTime(sourceFile, new DateTime(2002, 2, 2));       
        File.SetLastAccessTime(sourceFile, new DateTime(2003, 3, 3));      

        var creation = File.GetCreationTime(sourceFile);
        var lastAccess = File.GetLastAccessTime(sourceFile);
        var lastWrite = File.GetLastWriteTime(sourceFile);

        device.UploadFile(sourceFile, destFile);

        var fileInfo = device.GetFileInfo(destFile);

        var now = DateTime.Now;
        Assert.IsNotNull(fileInfo, nameof(fileInfo));
        Assert.AreEqual(17ul, fileInfo.Length, "length");
        
        Assert.IsNotNull(fileInfo.CreationTime, nameof(fileInfo.CreationTime));
        Assert.IsGreaterThan(now - new TimeSpan(0,0,1), fileInfo.CreationTime.Value, "> " + nameof(fileInfo.CreationTime));
        Assert.IsLessThan(now + new TimeSpan(0, 0, 1), fileInfo.CreationTime.Value, "< " + nameof(fileInfo.CreationTime));

        Assert.AreEqual(lastWrite, fileInfo.LastWriteTime, nameof(lastWrite));

        Assert.AreEqual(null, fileInfo.DateAuthored, nameof(lastAccess));

        device.Disconnect();
    }

    [TestMethod]
    [Description("Upload a tree to the target.")]
    public void WritableUploadTreeTest()
    {
        var device = GetDevice();
        device.Connect();

        UploadTestTree(device);
        
        string destFolder = GetTempFolder();
        
        
        var list = device.EnumerateFileSystemEntries(destFolder, null, SearchOption.AllDirectories).ToList();
        
        device.Disconnect();


        Assert.AreSequenceEqual(this.treeListFull, list, SequenceOrder.InAnyOrder, "EnumerateFileSystemEntries");
        //CollectionAssert.AreEquivalent(pathes, list, "EnumerateFileSystemEntries");
    }


    [TestMethod]
    [Description("Rename a file.")]
    public void WritableRenameFileTest()
    {
        var device = GetDevice();
        device.Connect();

        string filePath = GetTempFile(".txt");
        string newPath = GetTempFile(".txt");
        string newName = Path.GetFileName(newPath);


        if (device.FileExists(filePath))
        {
            device.DeleteFile(filePath);
        }
        if (device.FileExists(newPath))
        {
            device.DeleteFile(newPath);
        }

        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes("This is a test.")))
        {
            device.UploadFile(stream, filePath);
        }
        var exists1 = device.FileExists(filePath);

        device.Rename(filePath, newName);
        
        var exists2 = device.FileExists(newPath);

        device.DeleteFile(newPath);
        var exists3 = device.FileExists(newPath);

        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsTrue(exists2, "exists2");
        Assert.IsFalse(exists3, "exists3");
    }

    [TestMethod]
    [Description("Rename a folder.")]
    public void WritableRenameFolderTest()
    {
        var device = GetDevice();
        device.Connect();

        string filePath = GetTempFolder();
        string newPath = GetTempFolder();
        string newName = Path.GetFileName(newPath);


        if (device.DirectoryExists(filePath))
        {
            device.DeleteDirectory(filePath);
        }

        if (device.DirectoryExists(newPath))
        {
            device.DeleteDirectory(newPath);
        }

        device.CreateDirectory(filePath);

        var exists1 = device.DirectoryExists(filePath);

        device.Rename(filePath, newName);


        var exists2 = device.DirectoryExists(newPath);

        device.DeleteDirectory(newPath);
        var exists3 = device.DirectoryExists(newPath);

        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsTrue(exists2, "exists2");
        Assert.IsFalse(exists3, "exists3");
    }
    
    [TestMethod]
    [Description("Creating a new folder.")]
    public void WritableConnectGenericReadTest()
    {
        string newFolder1 = GetTempFolder();
        string newFolder2 = GetTempFolder();

        var device = GetDevice();

        device.Connect();
        device.CreateDirectory(newFolder1);
        var exists = device.DirectoryExists(newFolder1);
        device.Disconnect();

        device.Connect(MediaDeviceAccess.GenericRead);
        Assert.ThrowsExactly<NotSupportedException>(() => device.CreateDirectory(newFolder2));
        device.Disconnect();

        Assert.IsTrue(exists, nameof(exists));
    }


    [TestMethod]
    [Description("Test event handling.")]
    public void WritableEventFileTest()
    {
        AutoResetEvent fired = new(false);

        var mediaDevice = GetDevice();
        mediaDevice.ObjectRemoved += (s, a) => fired.Set();
        mediaDevice.Connect();

        string filePath = GetTempFile();
        if (mediaDevice.FileExists(filePath))
        {
            mediaDevice.DeleteFile(filePath);
        }

        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes("This is a test.")))
        {
            mediaDevice.UploadFile(stream, filePath);
        }

        mediaDevice.DeleteFile(filePath);

        bool isFired = fired.WaitOne(new TimeSpan(0, 0, 10));
        mediaDevice.Disconnect();

        Assert.IsTrue(isFired);
    }

    [TestMethod]
    [Description("Test event handling.")]
    public void WritableEventFolderTest()
    {

        string folder = GetTempFolder();

        AutoResetEvent addEvent = new(false);
        AutoResetEvent delEvent = new(false);

        var mediaDevice = GetDevice();
        mediaDevice.Connect(); 
                
        mediaDevice.ObjectAdded += (s, a) => addEvent.Set();
        mediaDevice.ObjectRemoved += (s, a) => delEvent.Set();

        mediaDevice.CreateDirectory(folder);
        mediaDevice.DeleteDirectory(folder);

        bool isAddFired = addEvent.WaitOne(new TimeSpan(0, 0, 10));
        bool isDelFired = delEvent.WaitOne(new TimeSpan(0, 0, 10));

        mediaDevice.Disconnect();

        Assert.IsTrue(isAddFired);
        Assert.IsTrue(isDelFired);
    }


    [TestMethod]
    [Description("Upload a unix file name to the target.")]
    public void WritableUploadUnixFileNameTest()
    {
        string workingUnixFolder = GetTempFolder();

        var device = GetDevice();
        device.Connect();

        string sourceFile = GetTempFile();
        string destFile = Path.Combine(Path.GetDirectoryName(sourceFile)!, @"Test:File.txt"); 

        var exists1 = device.FileExists(destFile);
        if (exists1)
        {
            device.DeleteFile(destFile);
        }

        device.UploadFile(sourceFile, destFile);

        var exists = device.FileExists(destFile);


        var _ = device.GetFiles(workingUnixFolder);

        device.DeleteFile(destFile);

        device.Disconnect();

        Assert.IsTrue(exists, "exists");
    }
}
