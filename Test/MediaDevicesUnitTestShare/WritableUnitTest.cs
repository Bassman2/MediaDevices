namespace MediaDevicesUnitTest;

public abstract class WritableUnitTest(string testPath) : ReadonlyUnitTest(testPath)
{
    protected readonly string testDataFolder = Path.GetFullPath(@".\..\..\..\..\TestData");
    
    protected string writeableWorkingFolder = @"\Card\Test";

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

    private string GetDeviceTempFile(string extention = ".txt")
    {
        return Path.Combine(writeableWorkingFolder, Path.ChangeExtension(Path.GetFileName(Path.GetTempFileName()), extention));
    }

    private string GetDeviceTempFolder()
    {
        return Path.Combine(writeableWorkingFolder, Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
    }

    private static string GetLocalTempFolder()
    {
        return Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
    }

    [TestMethod]
    [Description("Creating a new sourceFolder.")]
    public void WritableCreateFolderTest()
    {
        var device = GetDevice();
        device.Connect();
        
        string newFolder = GetDeviceTempFolder();
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

        string filePath = GetDeviceTempFile(".txt");
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
        string destFile = GetDeviceTempFile();

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

        if (deviceFileProperties.HasFlag(FileProperties.CreationTime))
        {
            Assert.IsNotNull(fileInfo.CreationTime, nameof(fileInfo.CreationTime));
            Assert.IsGreaterThan(now - new TimeSpan(0, 0, 1), fileInfo.CreationTime.Value, "> " + nameof(fileInfo.CreationTime));
            Assert.IsLessThan(now + new TimeSpan(0, 0, 1), fileInfo.CreationTime.Value, "< " + nameof(fileInfo.CreationTime));
        }
        else
        {
            Assert.IsNull(fileInfo.CreationTime, nameof(fileInfo.CreationTime));
        }

        if (deviceFileProperties.HasFlag(FileProperties.LastWriteTime))
        {
            Assert.AreEqual(lastWrite, fileInfo.LastWriteTime, nameof(fileInfo.LastWriteTime));
        }
        else
        {
            Assert.IsNull(fileInfo.LastWriteTime, nameof(fileInfo.LastWriteTime));
        }

        if (deviceFileProperties.HasFlag(FileProperties.DateAuthored))
        {
            Assert.AreEqual(lastWrite, fileInfo.DateAuthored, nameof(fileInfo.DateAuthored));
        }
        else
        {
            Assert.IsNull(fileInfo.DateAuthored, nameof(fileInfo.DateAuthored));
        }

        device.Disconnect();
    }

    private static void CreateTextFile(string filePath, string content)
    {
        using var writer = File.CreateText(filePath);
        writer.WriteLine(content);
        writer.Close();
    }

    [TestMethod]
    [Description("Upload a tree to the target.")]
    public void WritableUploadTreeDirectoryTest()
    {
        string sourceFolder = GetLocalTempFolder();

        Directory.CreateDirectory(sourceFolder);
        CreateTextFile(Path.Combine(sourceFolder, "testA.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testB.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testC.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testD.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testE.txt"), "Dies ist ein Test.");
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderA"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderB"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderC"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderC\\subA"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderC\\subB"));
        CreateTextFile(Path.Combine(sourceFolder, "folderA\\testF.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderB\\testG.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderC\\testH.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderC\\subA\\testI.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderC\\subB\\testJ.txt"), "Dies ist ein Test.");

        string destinationFolder = GetDeviceTempFolder();
        int destinationFolderPathLength = destinationFolder.Length + 1;

        Trace.WriteLine($"sourceFolder: {sourceFolder}");
        Trace.WriteLine($"destinationFolder: {destinationFolder}");

        var device = GetDevice();
        device.Connect();
        device.UploadFolder(sourceFolder, destinationFolder, false); 
        
        var files = device.EnumerateFiles(destinationFolder).Select(f => f.Substring(destinationFolderPathLength)).ToList();
        var folders = device.EnumerateDirectories(destinationFolder).Select(f => f.Substring(destinationFolderPathLength)).ToList();
        
        device.Disconnect();

        Assert.AreSequenceEqual(["testA.txt", "testB.txt", "testC.txt", "testD.txt", "testE.txt"], files, nameof(files));
        Assert.AreSequenceEqual([], folders, nameof(folders));


    }

    [TestMethod]
    [Description("Upload a tree to the target.")]
    public void WritableUploadTreeRecursiveTest()
    {
        string sourceFolder = Path.ChangeExtension(Path.GetTempFileName(), "");

        Directory.CreateDirectory(sourceFolder);
        CreateTextFile(Path.Combine(sourceFolder, "testA.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testB.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testC.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testD.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "testE.txt"), "Dies ist ein Test.");
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderA"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderB"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderC"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderC\\subA"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "folderC\\subB"));
        CreateTextFile(Path.Combine(sourceFolder, "folderA\\testF.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderB\\testG.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderC\\testH.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderC\\subA\\testI.txt"), "Dies ist ein Test.");
        CreateTextFile(Path.Combine(sourceFolder, "folderC\\subB\\testJ.txt"), "Dies ist ein Test.");

        string destinationFolder = GetDeviceTempFolder();
        int destinationFolderPathLength = destinationFolder.Length + 1;

        Trace.WriteLine($"sourceFolder: {sourceFolder}");
        Trace.WriteLine($"destinationFolder: {destinationFolder}");

        var device = GetDevice();
        device.Connect();
        device.UploadFolder(sourceFolder, destinationFolder, true);

        var files = device.EnumerateFiles(destinationFolder, "*", SearchOption.AllDirectories).Select(f => f.Substring(destinationFolderPathLength)).ToList();
        var folders = device.EnumerateDirectories(destinationFolder, "*", SearchOption.AllDirectories).Select(f => f.Substring(destinationFolderPathLength)).ToList();
        device.Disconnect();

        Assert.AreSequenceEqual(["folderA\\testF.txt", "folderB\\testG.txt", "folderC\\subA\\testI.txt", "folderC\\subB\\testJ.txt", "folderC\\testH.txt", "testA.txt", "testB.txt", "testC.txt", "testD.txt", "testE.txt"], files, nameof(files));
        Assert.AreSequenceEqual(["folderA", "folderB", "folderC", "folderC\\subA", "folderC\\subB"], folders, nameof(folders));
    }


    [TestMethod]
    [Description("Rename a file.")]
    public void WritableRenameFileTest()
    {
        var device = GetDevice();
        device.Connect();

        string filePath = GetDeviceTempFile(".txt");
        string newPath = GetDeviceTempFile(".txt");
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
    [Description("Rename a sourceFolder.")]
    public void WritableRenameFolderTest()
    {
        var device = GetDevice();
        device.Connect();

        string filePath = GetDeviceTempFolder();
        string newPath = GetDeviceTempFolder();
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
    [Description("Creating a new sourceFolder.")]
    public void WritableConnectGenericReadTest()
    {
        string newFolder1 = GetDeviceTempFolder();
        string newFolder2 = GetDeviceTempFolder();

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

        string filePath = GetDeviceTempFile();
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

        string folder = GetDeviceTempFolder();

        AutoResetEvent addEvent = new(false);
        AutoResetEvent delEvent = new(false);

        var mediaDevice = GetDevice();
        mediaDevice.Connect(); 
                
        mediaDevice.ObjectAdded += (s, a) =>
        {
            addEvent.Set();
        };
        mediaDevice.ObjectRemoved += (s, a) => 
        {
            delEvent.Set();
        };

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
    [Ignore("Currently not supported.")]
    public void WritableUploadUnixFileNameTest()
    {
        string workingUnixFolder = GetDeviceTempFolder();

        var device = GetDevice();
        device.Connect();

        string sourceFile = GetDeviceTempFile();
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
