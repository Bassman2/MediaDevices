namespace MediaDevicesUnitTest;

public abstract class WritableUnitTest : ReadonlyUnitTest 
{
    protected readonly string testDataFolder = Path.GetFullPath(@".\..\..\..\..\TestData");

    protected string? workingFolder;
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

    protected void UploadTestTree(MediaDevice device)
    {
        this.treeListFull = [.. treeList.Select(p => workingFolder + p)];

        string sourceFolder = Path.Combine(testDataFolder, "UploadTree");

        // create empty folders not checked in
        Directory.CreateDirectory(Path.Combine(sourceFolder, @"Aaa\Abb\Add"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, @"Aaa\Acc"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "Bbb"));
        Directory.CreateDirectory(Path.Combine(sourceFolder, "Ccc"));

        var l = Directory.EnumerateFileSystemEntries(sourceFolder, "*", SearchOption.AllDirectories).OrderBy(s => s).ToList();
        var x = Directory.GetFileSystemEntries(sourceFolder, "*", SearchOption.AllDirectories).OrderBy(s => s).ToList();

        string destFolder = Path.Combine(this.workingFolder!, "UploadTree");
        
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
        
        string newFolder = Path.Combine(this.workingFolder!, "Test");
        var exists1 = device.DirectoryExists(this.workingFolder!);
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

        string filePath = Path.Combine(this.workingFolder!, "Test.txt");
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
        var exists2 = device.FileExists(@"\Phone\Downloads\Test.txt");

        device.Disconnect();

        Assert.IsTrue(exists1, "exists1");
        Assert.IsFalse(exists2, "exists2");
    }

    [TestMethod]
    [Description("Upload a file to the target.")]
    [Ignore("BUG")]
    public void WritableUploadFilePathTest()
    {
        var device = GetDevice();
        device.Connect();

        string sourceFile = Path.Combine(testDataFolder, "TestFile.txt");
        string destFile = Path.Combine(this.workingFolder!, "TestFile.txt");

        var exists1 = device.FileExists(destFile);
        if (exists1)
        {
            device.DeleteFile(destFile);
        }

        device.UploadFile(sourceFile, destFile);

        var exists = device.FileExists(destFile);

        device.DeleteFile(destFile);

        device.Disconnect();

        Assert.IsTrue(exists, "exists");

    }

    [TestMethod]
    [Description("Upload a tree to the target.")]
    public void WritableUploadTreeTest()
    {
        var device = GetDevice();
        device.Connect();

        UploadTestTree(device);
        
        string destFolder = Path.Combine(this.workingFolder!, "UploadTree");
        int _ = this.workingFolder!.Length;                      
        
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

        string filePath = Path.Combine(this.workingFolder!, "RenameTest.txt");
        string newName = "NewName.txt";
        string newPath = Path.Combine(this.workingFolder!, newName);


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

        string filePath = Path.Combine(this.workingFolder!, "RenameFolder");
        string newName = "NewFolder";
        string newPath = Path.Combine(this.workingFolder!, newName);


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
        string newFolder1 = Path.Combine(this.workingFolder!, Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
        string newFolder2 = Path.Combine(this.workingFolder!, Path.GetFileNameWithoutExtension(Path.GetTempFileName()));

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
    public void WritableEventTest()
    {
        //if (!this.supEvent) return;

        AutoResetEvent fired = new(false);

        var mediaDevice = GetDevice();
        mediaDevice.ObjectRemoved += (s, a) => fired.Set();
        mediaDevice.Connect();

        string filePath = Path.Combine(this.workingFolder!, "Test.txt");
        if (mediaDevice.FileExists(filePath))
        {
            mediaDevice.DeleteFile(filePath);
        }

        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes("This is a test.")))
        {
            mediaDevice.UploadFile(stream, filePath);
        }

        mediaDevice.DeleteFile(filePath);

        bool isFired = fired.WaitOne(new TimeSpan(0, 2, 0));
        mediaDevice.Disconnect();

        Assert.IsTrue(isFired);
    }


    [TestMethod]
    [Description("Upload a unix file name to the target.")]
    public void WritableUploadUnixFileNameTest()
    {
        string workingUnixFolder = Path.Combine(this.workingFolder!, "UnixTest");

        var device = GetDevice();
        device.Connect();

        string sourceFile = Path.Combine(testDataFolder, "TestFile.txt");
        string destFile = Path.Combine(workingUnixFolder, @"Test:File.txt");

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
