namespace MediaDevicesUnitTest;

partial class ReadonlyUnitTest
{
    #region ArgumentException

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceCreateDirectoryArgumentExceptionTest()
    {
        string path = Path.Combine(readonlyFolderPath!, "aaa|xx");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<ArgumentException>(() => device.CreateDirectory(path));
        device.Disconnect();
    }

    #endregion

    #region ArgumentNullException

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceCreateDirectoryArgumentNullExceptionTest()
    {
        string path = "";

        var device = GetDevice();
        device.Connect();
        Assert.Throws<ArgumentNullException>(() => device.CreateDirectory(path));
        device.Disconnect();
    }

    #endregion

    #region PathTooLongException

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceCreateDirectoryPathTooLongExceptionTest()
    {
        string path = Path.Combine(readonlyFolderPath!, Path.Combine([..Enumerable.Repeat("aaaaaaaaaa", 25)])); 

        var device = GetDevice();
        device.Connect();
        Assert.Throws<PathTooLongException>(() => device.CreateDirectory(path));
        device.Disconnect();
    }

    #endregion

    #region DirectoryNotFoundException

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceDeleteFileDirectoryNotFoundExceptionTest()
    {
        string path = Path.Combine(readonlyFolderPath!, "DummyX", "file.xy");

        var device = GetDevice();
        device.Connect();
        // File.Delete throws DirectoryNotFoundException if path was not found; never FileNotFoundException
        Assert.Throws<DirectoryNotFoundException>(() => device.DeleteFile(path));
        device.Disconnect();
    }

    #endregion

    #region FileNotFoundException

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceRenameFileNotFoundExceptionTest()
    {
        string path = Path.Combine(readonlyFolderPath!, "DummyX", "file.xy");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<FileNotFoundException>(() => device.Rename(path, "rrr.uzx"));
        device.Disconnect();
    }

    #endregion

    #region IOException

    

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceDeleteFileIOExceptionTest()
    {
        string path = @"\A300\DCIM\100NIKON\DSCN0006.JPG";

        var device = GetDevice();
        device.Connect();
        Assert.Throws<IOException>(() => device.DeleteFile(path));
        device.Disconnect();
    }

    #endregion

    #region DirectoryNotFoundException Tests

    /*
    [TestMethod]
    [Description("Readonly Enumerate Directories Exception Test")]
    public void ExceptionReadonlyMediaDeviceDirectoryEnumerateTest()
    {
        string folder = Path.Combine(readonlyFolderPath!, "Dummy1");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<DirectoryNotFoundException>(() => device.EnumerateDirectories(folder).ToList());
        device.Disconnect();
    }

    [TestMethod]
    [Description("Readonly Create Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceCreateFolderTest()
    {
        string folder = Path.Combine(readonlyFolderPath!, "Dummy2");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<DirectoryNotFoundException>(() => device.CreateDirectory(folder));
        device.Disconnect();
    }

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceDeleteDirectoriesTest()
    {
        string folder = Path.Combine(readonlyFolderPath!, "Dummy3");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<DirectoryNotFoundException>(() => device.DeleteDirectory(folder));
        device.Disconnect();
    }

    [TestMethod]
    [Description("Readonly Enumerate Directories Exception Test")]
    public void ExceptionReadonlyMediaDeviceEnumerateFilesTest()
    {
        string folder = Path.Combine(readonlyFolderPath!, "Dummy4");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<DirectoryNotFoundException>(() => device.EnumerateFiles(folder).ToList());
        device.Disconnect();
    }

    [TestMethod]
    [Description("Readonly Create Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceCreateFileTest()
    {
        string folder = Path.Combine(readonlyFolderPath!, "Dummy5");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<DirectoryNotFoundException>(() => device.CreateDirectory(@"\" + Guid.NewGuid().ToString()));
        device.Disconnect();
    }

    [TestMethod]
    [Description("Readonly Delete Directory Exception Test")]
    public void ExceptionReadonlyMediaDeviceDeleteFileTest()
    {
        string folder = Path.Combine(readonlyFolderPath!, "Dummy6");

        var device = GetDevice();
        device.Connect();
        Assert.Throws<DirectoryNotFoundException>(() => device.DeleteFile(folder));
        device.Disconnect();
    }
    */

    #endregion

    //[TestMethod]
    //[Description("Readonly Delete Directory Exception Test")]
    //public void ExceptionReadonlyMediaDeviceDeleteReadonlyFileTest()
    //{
    //    string folder = "\\SD1\\DCIM\\100EOSR6\\0K8A0173.JPG";

    //    var device = GetDevice();
    //    device.Connect();
    //    Assert.Throws<UnauthorizedAccessException>(() => device.DeleteFile(folder));
    //    device.Disconnect();
    //}
}
