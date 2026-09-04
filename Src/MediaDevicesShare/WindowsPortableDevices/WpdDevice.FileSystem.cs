using System.Data;

namespace MediaDevices.WindowsPortableDevices;

partial class WpdDevice
{
    #region MediaDevice: path based

    /*
    public IEnumerable<string> EnumerateDirectories(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateDirectories(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFiles(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFiles(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFileSystemEntries(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren().Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFileSystemEntries(ObjectId objectId, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren(searchPattern, searchOption).Select(i => i.FullName);
    }
    */

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => i.ToDirectoryInfo());
    }

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => i.ToDirectoryInfo());
    }

    public IEnumerable<MediaFileInfo> EnumerateFiles(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => i.ToFileInfo());
    }

    public IEnumerable<MediaFileInfo> EnumerateFiles(ObjectId objectId, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => i.ToFileInfo());
    }

    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemEntries(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren().Select(i => i.ToFileSystemInfo());
    }

    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemEntries(ObjectId objectId, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        return item.GetChildren(searchPattern, searchOption).Select(i => i.ToFileSystemInfo());
    }

    public bool DirectoryExists(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return WpdItem.Create(this, objectId) != null;
    }

    //public void CreateDirectory(string path, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();
        
    //    var now = DateTime.Now;
    //    WpdItem.GetRoot(this).CreateSubdirectory(path, now, now, now);
    //}

    public MediaDirectoryInfo CreateDirectory(ObjectId objectId, string path, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var now = DateTime.Now;
        return WpdItem.Create(this, objectId).CreateSubdirectory(path, now, now, now)?.ToDirectoryInfo() ?? throw new Exception(); 
    }

    public void DeleteDirectory(ObjectId objectId, bool recursive = false, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId); 
        item.Delete(recursive);
    }

    public bool FileExists(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return WpdItem.Create(this, objectId) != null;
    }

    public void DeleteFile(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        // File.Delete throws DirectoryNotFoundException if path was not found; never FileNotFoundException
        WpdItem item = WpdItem.Create(this, objectId);
        item.Delete();
    }

    public void Rename(ObjectId objectId, string newName, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        item.Rename(newName);
    }

    #endregion

    #region Download and Upload path based

    public void DownloadFile(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.Create(this, objectId);
        using var sourceStream = item.OpenRead();
        sourceStream.CopyTo(stream);
    }

    public void DownloadFile(ObjectId objectId, string destination, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.FindFile(this, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using var sourceStream = item.OpenRead();
        using var destinationStream = File.Create(destination);
        sourceStream.CopyTo(destinationStream);
    }

    public void DownloadIcon(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.FindFile(this, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using var sourceStream = item.OpenReadIcon();
        sourceStream.CopyTo(stream);
    }

    public void DownloadIcon(ObjectId objectId, string destination, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.FindFile(this, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using var sourceStream = item.OpenReadIcon();
        using var destinationStream = File.Create(destination);
        sourceStream.CopyTo(destinationStream);
    }

    public void DownloadThumbnail(ObjectId objectId, Stream stream, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.FindFile(this, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using Stream sourceStream = item.OpenReadThumbnail();
        sourceStream.CopyTo(stream);
    }

    public void DownloadThumbnail(ObjectId objectId, string destination, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.FindFile(this, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using Stream sourceStream = item.OpenReadThumbnail();
        using var destinationStream = File.Create(destination);
        sourceStream.CopyTo(destinationStream);
    }

    public void DownloadFolder(ObjectId objectId, string destination, bool recursive, bool ignoreExceptions, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        //Directory.CreateDirectory(destination);
        //WpdItem dir = WpdItem.Create(this, objectId);
        //if (recursive)
        //{
        //    foreach (var item in dir.GetChildren("*", SearchOption.AllDirectories))
        //    {
        //        string path = Path.Combine(destination, GetLocalPath(source, item.FullName));
        //        if (item.IsFile)
        //        {
        //            DownloadFileIntern(item, path, ignoreExceptions);
        //        }
        //        else
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //    }
        //}
        //else
        //{
        //    foreach (var item in dir.GetChildren())
        //    {
        //        string path = Path.Combine(destination, GetLocalPath(source, item.FullName));
        //        DownloadFileIntern(item, path, ignoreExceptions);
        //    }
        //}
    }

    private void DownloadFileIntern(WpdItem item, string path, bool ignoreExceptions, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        try
        {
            using var sourceStream = item.OpenRead();
            using var destinationStream = File.Create(path);
            sourceStream.CopyTo(destinationStream);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{ex.Message} for {item.GetPath()}");
            if (!ignoreExceptions)
            {
                throw;
            }
        }
    }

    public void UploadFile(Stream stream, string destination, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        string? folder = Path.GetDirectoryName(destination);
        string fileName = Path.GetFileName(destination);
        WpdItem item = WpdItem.FindFolder(this, folder!) ?? throw new DirectoryNotFoundException($"Directory {folder} not found.");

        if (item.GetChildren().Any(i => EqualsName(i.Name, fileName, this.IsCaseSensitive)))
        {
            throw new IOException($"File {destination} already exists");
        }

        item.UploadFile(fileName, stream, DateTime.Now, DateTime.Now, DateTime.Now);
    }

    public void UploadFile(string source, string destination, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        string? folder = Path.GetDirectoryName(destination);
        string fileName = Path.GetFileName(destination);
        WpdItem item = WpdItem.FindFolder(this, folder!) ?? throw new DirectoryNotFoundException($"Directory {folder} not found.");

        if (item.GetChildren().Any(i => EqualsName(i.Name, fileName, this.IsCaseSensitive)))
        {
            throw new IOException($"File {destination} already exists");
        }

        using var stream = File.OpenRead(source);

        //// for testing 
        //item.UploadFile(fileName, stream, 
        //    new DateTime(2001, 1, 1),  // created
        //    new DateTime(2002, 2, 2),  // modified 
        //    new DateTime(2003, 3, 3)); // authored

        item.UploadFile(fileName, stream,
            DateTime.Now,                   // created: set date of upload
            File.GetLastWriteTime(source),  // modified: set date the file was last written
            File.GetLastWriteTime(source)); // authored: set date the file was last written
    }

    public void UploadFolder(string source, string destination, bool recursive, bool ignoreExceptions, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var now = DateTime.Now;
        WpdItem.GetRoot(this).CreateSubdirectory(destination, now, now, now);
        if (recursive)
        {
            var list = new DirectoryInfo(source).EnumerateFileSystemInfos("*", SearchOption.AllDirectories);
            foreach (var fsi in list)
            {
                var relSource = fsi.FullName.Substring(source.Length);
                var absDestination = Path.Combine(destination, relSource);

                if (fsi is FileInfo)
                {
                    try
                    {
                        // call the instance overload UploadFile(source, destination)
                        UploadFile(fsi.FullName, absDestination);
                    } 
                    catch 
                    {
                        if (!ignoreExceptions) throw;
                    }
                }
                else
                {
                    WpdItem.GetRoot(this).CreateSubdirectory(absDestination, now, now, now);
                }
            }
        }
        else
        {
            foreach (var file in Directory.EnumerateFiles(source))
            {
                try
                {
                    UploadFile(mediaDevice, file, Path.Combine(destination, Path.GetFileName(file)));
                }
                catch
                {
                    if (!ignoreExceptions) throw;
                }
            }
        }

    }

    //private static void UploadFileIntern(MediaDevice mediaDevice, FileInfo fi, string source, string destination, bool ignoreExceptions)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();
    //    try
    //    {
    //        WpdItem item = WpdItem.FindFolder(mediaDevice, fi.DirectoryName!) ?? throw new DirectoryNotFoundException($"Directory {fi.DirectoryName} not found.");
    //        string path = Path.Combine(destination, GetLocalPath(source, fi.FullName));
    //        using FileStream stream = fi.OpenRead();
    //        item.UploadFile(path, stream,
    //            DateTime.Now,                   // created: set date of upload
    //            File.GetLastWriteTime(source),  // modified: set date the file was last written
    //            File.GetLastWriteTime(source)); // authored: set date the file was last written);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"{ex.Message} for {fi.DirectoryName}");
    //        if (!ignoreExceptions)
    //        {
    //            throw;
    //        }
    //    }
    //}

    private void UploadFileIntern(FileInfo fi, string source, string destination, bool ignoreExceptions)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        try
        {
            WpdItem item = WpdItem.FindFolder(this, fi.DirectoryName!) ?? throw new DirectoryNotFoundException($"Directory {fi.DirectoryName} not found.");
            string path = Path.Combine(destination, GetLocalPath(source, fi.FullName));
            using FileStream stream = fi.OpenRead();
            item.UploadFile(path, stream,
                DateTime.Now,                   // created: set date of upload
                File.GetLastWriteTime(source),  // modified: set date the file was last written
                File.GetLastWriteTime(source)); // authored: set date the file was last written);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{ex.Message} for {fi.DirectoryName}");
            if (!ignoreExceptions)
            {
                throw;
            }
        }
    }

    #endregion

    #region MediaDevice: MediaFileInfo, MediaDirectoryInfo, MediaDriveInfo and MediaFileSystemInfo based 


    public MediaFileInfo GetFileInfo(string path, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = WpdItem.FindItem(this, path) ?? throw new FileNotFoundException($"{path} not found.", path);
        return new MediaFileInfo(this, item.ObjectId);
    }

    public MediaDirectoryInfo GetDirectoryInfo(string path, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = WpdItem.FindFolder(this, path) ?? throw new DirectoryNotFoundException($"{path} not found.");
        return new MediaDirectoryInfo(this, item.ObjectId);
    }

    
    public IEnumerable<MediaDriveInfo> GetDrives(CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Guid storage = FunctionalCategory.Storage.ToGuid();

        int err = this.deviceCapabilities!.GetFunctionalObjects(ref storage, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalObjects));

        yield break;
        //return collection.Enumerate<MediaDriveInfo>(i => i.ToMediaDriveInfo()));
    }

    public MediaDirectoryInfo GetRootDirectory(CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem wpdItem = WpdItem.GetRoot(this);
        return wpdItem.ToDirectoryInfo();
    }

    public void DownloadFileFromPersistentUniqueId(string persistentUniqueId, Stream stream, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem? item = WpdItem.GetFromPersistentUniqueId(this, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        using Stream sourceStream = item.OpenRead();
        sourceStream.CopyTo(stream);
    }

    #endregion

    #region MediDevice: PersistentUniqueId

    public string GetPathFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.GetFromPersistentUniqueId(this, persistentUniqueId) ?? throw new FileNotFoundException($"{persistentUniqueId} not found.");
        return item.GetPath();
    }

    public MediaFileSystemInfo GetFileSystemInfoFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem item = WpdItem.GetFromPersistentUniqueId(t, persistentUniqueId) ?? throw new FileNotFoundException($"{persistentUniqueId} not found.");
        return (MediaFileSystemInfo)(item.IsFile ? new MediaFileInfo(this, item.ObjectId) : new MediaDirectoryInfo(this, item.ObjectId));
    }

    public void DownloadFileFromPersistentUniqueId(string persistentUniqueId, string destination, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem? item = WpdItem.GetFromPersistentUniqueId(this, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        using var reader = item.OpenRead();
        using var writer = File.Create(destination);
        reader.CopyTo(writer);
    }

    public Stream OpenReadFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem? item = WpdItem.GetFromPersistentUniqueId(this, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        return item.OpenRead();
    }

    public StreamReader OpenTextFromPersistentUniqueId(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem? item = WpdItem.GetFromPersistentUniqueId(this, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        return new StreamReader(item.OpenRead());
    }



    #endregion

    #region MediaFileSystemInfo

    public void Refresh(WpdItem item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.Refresh();
    }

    public MediaDirectoryInfo? GetParent(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem? parent = WpdItem.Create(this, objectId).Parent;
        return parent?.ToDirectoryInfo();
    }

    public void SetCreationTime(WpdItem item, DateTime? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.SetDateCreated(value.GetValueOrDefault(DateTime.Now));
    }

    public void SetLastWriteTime(WpdItem item, DateTime? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.SetDateModified(value.GetValueOrDefault(DateTime.Now));
    }

    public void SetDateAuthored(WpdItem item, DateTime? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.SetDateAuthored(value.GetValueOrDefault(DateTime.Now));
    }

    //public void Rename(WpdItem item, string newName, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    item.Rename(newName);
    //}

    #endregion

    #region MediaDirectoryInfo

    //public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(WpdItem item, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => new MediaDirectoryInfo(this, i));

    //}

    //public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(WpdItem item, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    return item.GetChildren(searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => new MediaDirectoryInfo(this, i));
    //}

    //public IEnumerable<MediaFileInfo> EnumerateFiles(WpdItem item, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => new MediaFileInfo(this, i));
    //}
    //public IEnumerable<MediaFileInfo> EnumerateFiles(WpdItem item, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    return item.GetChildren(searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => new MediaFileInfo(this, i));
    //}

    //public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfos(WpdItem item, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    return item.GetChildren().Select(i => i.Type == ItemType.File ?
    //        (MediaFileSystemInfo)new MediaFileInfo(this, i) :
    //        (MediaFileSystemInfo)new MediaDirectoryInfo(this, i));
    //}
    //public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfos(WpdItem item, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    return item.GetChildren(searchPattern, searchOption).Select(i => i.Type == ItemType.File ?
    //        (MediaFileSystemInfo)new MediaFileInfo(this, i) :
    //        (MediaFileSystemInfo)new MediaDirectoryInfo(this, i));
    //}

    //public MediaDirectoryInfo CreateSubdirectory(WpdItem item, string path)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    var now = DateTime.Now;

    //    WpdItem? dirItem = item.CreateSubdirectory(path, now, now, now);
    //    return new MediaDirectoryInfo(this, dirItem!);
    //}

    #endregion

    #region MediaFileInfo

    public void CopyTo(ObjectId objectId, string destFileName, bool overwrite, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
        using Stream sourceStream = WpdItem.Create(this, objectId).OpenRead();
        sourceStream.CopyTo(file);
    }

    public void CopyIconTo(ObjectId objectId, string destFileName, bool overwrite, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
        using Stream sourceStream = WpdItem.Create(this, objectId).OpenReadIcon();
        sourceStream.CopyTo(file);
    }

    public void CopyThumbnailTo(ObjectId objectId, string destFileName, bool overwrite, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();   

        using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
        using Stream sourceStream = WpdItem.Create(this, objectId).OpenReadThumbnail();
        sourceStream.CopyTo(file);
    }

    public Stream OpenRead(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return WpdItem.Create(this, objectId).OpenRead();
    }

    public StreamReader OpenText(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return new StreamReader(WpdItem.Create(this, objectId).OpenRead());
    }

    public Stream OpenIcon(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return WpdItem.Create(this, objectId).OpenReadIcon();
    }

    public Stream OpenThumbnail(ObjectId objectId, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return WpdItem.Create(this, objectId).OpenReadThumbnail();
    }

    #endregion

    #region Internal

    private string GetLocalPath(string basePath, string fullPath)
    {
        if (!fullPath.StartsWith(basePath))
        {
            throw new ArgumentException($"{basePath} is not the base path of {fullPath}!");
        }
        return fullPath[basePath.Length..].TrimStart('\\', '/');
        //return fullPath.Remove(0, basePath.Length).TrimStart('\\', '/');

    }

    internal static bool EqualsName(string a, string b, bool isCaseSensitive)
    {
        return isCaseSensitive ? a == b : string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }

    private static string? FilterToRegex(string? filter)
    {
        if (filter == null || filter == "*" || filter == "*.*")
        {
            return null;
        }

        StringBuilder s = new(filter);
        s.Replace(".", @"\.");
        s.Replace("+", @"\+");
        s.Replace("$", @"\$");
        s.Replace("(", @"\(");
        s.Replace(")", @"\)");
        s.Replace("[", @"\[");
        s.Replace("]", @"\]");
        s.Replace("?", ".?");
        s.Replace("*", ".*");
        return s.ToString();
    }

    #endregion
}
