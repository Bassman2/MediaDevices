using System.Data;

namespace MediaDevices.WindowsPortableDevices;

partial class WpdDevice
{
    #region MediaDevice: path based

    public IEnumerable<string> EnumerateDirectories(string path, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
        return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFiles(string path, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
        return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFileSystemEntries(string path, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
        return item.GetChildren().Select(i => i.FullName);
    }

    public IEnumerable<string> EnumerateFileSystemEntries(string path, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
        return item.GetChildren(searchPattern, searchOption).Select(i => i.FullName);
    }

    public bool DirectoryExists(string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return Item.FindFolder(mediaDevice, path) != null;
    }

    public void CreateDirectory(string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        
        var now = DateTime.Now;
        Item.GetRoot(mediaDevice).CreateSubdirectory(path, now, now, now);
    }

    public void DeleteDirectory(string path, bool recursive = false)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Directory {path} not found.");
        item.Delete(recursive);
    }

    public bool FileExists(string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return Item.FindFile(mediaDevice, path) != null;
    }

    public void DeleteFile(string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        // File.Delete throws DirectoryNotFoundException if path was not found; never FileNotFoundException
        Item item = Item.FindFile(mediaDevice, path) ?? throw new DirectoryNotFoundException($"File {path} not found.");
        item.Delete();
    }

    public void Rename(string path, string newName)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindItem(mediaDevice, path) ?? throw new FileNotFoundException($"Path {path} not found.", path);
        item.Rename(newName);
    }

    #endregion

    #region Download and Upload path based

    public void DownloadFile(string source, Stream stream)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using var sourceStream = item.OpenRead();
        sourceStream.CopyTo(stream);
    }

    public void DownloadFile(string source, string destination)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using var sourceStream = item.OpenRead();
        using var destinationStream = File.Create(destination);
        sourceStream.CopyTo(destinationStream);
    }

    public void DownloadIcon(string source, Stream stream)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using var sourceStream = item.OpenReadIcon();
        sourceStream.CopyTo(stream);
    }

    public void DownloadIcon(string source, string destination)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using var sourceStream = item.OpenReadIcon();
        using var destinationStream = File.Create(destination);
        sourceStream.CopyTo(destinationStream);
    }

    public void DownloadThumbnail(string source, Stream stream)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using Stream sourceStream = item.OpenReadThumbnail();
        sourceStream.CopyTo(stream);
    }

    public void DownloadThumbnail(string source, string destination)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
        using Stream sourceStream = item.OpenReadThumbnail();
        using var destinationStream = File.Create(destination);
        sourceStream.CopyTo(destinationStream);
    }

    public void DownloadFolder(string source, string destination, bool recursive, bool ignoreExceptions)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Directory.CreateDirectory(destination);
        Item dir = Item.FindFolder(mediaDevice, source) ?? throw new DirectoryNotFoundException($"{source} not found.");
        if (recursive)
        {
            foreach (var item in dir.GetChildren("*", SearchOption.AllDirectories))
            {
                string path = Path.Combine(destination, GetLocalPath(source, item.FullName));
                if (item.IsFile)
                {
                    DownloadFileIntern(item, path, ignoreExceptions);
                }
                else
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
        else
        {
            foreach (var item in dir.GetChildren())
            {
                string path = Path.Combine(destination, GetLocalPath(source, item.FullName));
                DownloadFileIntern(item, path, ignoreExceptions);
            }
        }
    }

    private void DownloadFileIntern(Item item, string path, bool ignoreExceptions)
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

    public void UploadFile(Stream stream, string destination)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        string? folder = Path.GetDirectoryName(destination);
        string fileName = Path.GetFileName(destination);
        Item item = Item.FindFolder(mediaDevice, folder!) ?? throw new DirectoryNotFoundException($"Directory {folder} not found.");

        if (item.GetChildren().Any(i => EqualsName(i.Name, fileName, mediaDevice.IsCaseSensitive)))
        {
            throw new IOException($"File {destination} already exists");
        }

        item.UploadFile(fileName, stream, DateTime.Now, DateTime.Now, DateTime.Now);
    }

    public void UploadFile(string source, string destination)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        string? folder = Path.GetDirectoryName(destination);
        string fileName = Path.GetFileName(destination);
        Item item = Item.FindFolder(mediaDevice, folder!) ?? throw new DirectoryNotFoundException($"Directory {folder} not found.");

        if (item.GetChildren().Any(i => EqualsName(i.Name, fileName, mediaDevice.IsCaseSensitive)))
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

    public void UploadFolder(string source, string destination, bool recursive, bool ignoreExceptions)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var now = DateTime.Now;
        Item.GetRoot(mediaDevice).CreateSubdirectory(destination, now, now, now);
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
                        UploadFile(mediaDevice, fsi.FullName, absDestination);
                    } 
                    catch 
                    {
                        if (!ignoreExceptions) throw;
                    }
                }
                else
                {
                    Item.GetRoot(mediaDevice).CreateSubdirectory(absDestination, now, now, now);
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
    //        Item item = Item.FindFolder(mediaDevice, fi.DirectoryName!) ?? throw new DirectoryNotFoundException($"Directory {fi.DirectoryName} not found.");
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
            Item item = Item.FindFolder(mediaDevice, fi.DirectoryName!) ?? throw new DirectoryNotFoundException($"Directory {fi.DirectoryName} not found.");
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


    public MediaFileInfo GetFileInfo(string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = Item.FindItem(mediaDevice, path) ?? throw new FileNotFoundException($"{path} not found.", path);
        return new MediaFileInfo(mediaDevice, item);
    }

    public MediaDirectoryInfo GetDirectoryInfo(string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"{path} not found.");
        return new MediaDirectoryInfo(mediaDevice, item);
    }

    
    internal IEnumerable<MediaDriveInfo> GetDrives()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Guid storage = FunctionalCategory.Storage.ToGuid();

        int err = mediaDevice.deviceCapabilities!.GetFunctionalObjects(ref storage, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalObjects));

        return collection.Enumerate<MediaDriveInfo>(i => new MediaDriveInfo(mediaDevice, i.ToString()));
    }

    public MediaDirectoryInfo GetRootDirectory()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return new MediaDirectoryInfo(mediaDevice, Item.GetRoot(mediaDevice));
    }

    public void DownloadFileFromPersistentUniqueId(string persistentUniqueId, Stream stream)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        using Stream sourceStream = item.OpenRead();
        sourceStream.CopyTo(stream);
    }

    #endregion

    #region MediDevice: PersistentUniqueId

    public string GetPathFromPersistentUniqueId(string persistentUniqueId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId) ?? throw new FileNotFoundException($"{persistentUniqueId} not found.");
        return item.GetPath();
    }

    public MediaFileSystemInfo GetFileSystemInfoFromPersistentUniqueId(string persistentUniqueId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId) ?? throw new FileNotFoundException($"{persistentUniqueId} not found.");
        return (MediaFileSystemInfo)(item.IsFile ? new MediaFileInfo(mediaDevice, item) : new MediaDirectoryInfo(mediaDevice, item));
    }

    public void DownloadFileFromPersistentUniqueId(string persistentUniqueId, string destination)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        using var reader = item.OpenRead();
        using var writer = File.Create(destination);
        reader.CopyTo(writer);
    }

    public Stream OpenReadFromPersistentUniqueId(string persistentUniqueId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        return item.OpenRead();
    }

    public StreamReader OpenTextFromPersistentUniqueId(string persistentUniqueId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
        if (item == null || !item.IsFile)
        {
            throw new FileNotFoundException($"{persistentUniqueId} not found.");
        }
        return new StreamReader(item.OpenRead());
    }



    #endregion

    #region MediaFileSystemInfo

    public void Refresh(Item item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.Refresh();
    }

    public MediaDirectoryInfo? GetParent(Item item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? parent = item.Parent;
        return parent == null ? null : new MediaDirectoryInfo(mediaDevice, parent);
    }

    public void SetCreationTime(Item item, DateTime? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.SetDateCreated(value.GetValueOrDefault(DateTime.Now));
    }

    public void SetLastWriteTime(Item item, DateTime? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.SetDateModified(value.GetValueOrDefault(DateTime.Now));
    }

    public void SetDateAuthored(Item item, DateTime? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.SetDateAuthored(value.GetValueOrDefault(DateTime.Now));
    }

    public void Rename(Item item, string newName)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        item.Rename(newName);
    }

    #endregion

    #region MediaDirectoryInfo

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(Item item, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => new MediaDirectoryInfo(mediaDevice, i));

    }

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(Item item, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => new MediaDirectoryInfo(mediaDevice, i));
    }

    public IEnumerable<MediaFileInfo> EnumerateFiles(Item item, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => new MediaFileInfo(mediaDevice, i));
    }
    public IEnumerable<MediaFileInfo> EnumerateFiles(Item item, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.GetChildren(searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => new MediaFileInfo(mediaDevice, i));
    }

    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfos(Item item, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.GetChildren().Select(i => i.Type == ItemType.File ?
            (MediaFileSystemInfo)new MediaFileInfo(mediaDevice, i) :
            (MediaFileSystemInfo)new MediaDirectoryInfo(mediaDevice, i));
    }
    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfos(Item item, string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.GetChildren(searchPattern, searchOption).Select(i => i.Type == ItemType.File ?
            (MediaFileSystemInfo)new MediaFileInfo(mediaDevice, i) :
            (MediaFileSystemInfo)new MediaDirectoryInfo(mediaDevice, i));
    }

    public MediaDirectoryInfo CreateSubdirectory(Item item, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var now = DateTime.Now;

        Item? dirItem = item.CreateSubdirectory(path, now, now, now);
        return new MediaDirectoryInfo(mediaDevice, dirItem!);
    }

    #endregion

    #region MediaFileInfo

    public void CopyTo(Item item, string destFileName, bool overwrite)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
        using Stream sourceStream = item.OpenRead();
        sourceStream.CopyTo(file);
    }

    public void CopyIconTo(Item item, string destFileName, bool overwrite)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
        using Stream sourceStream = item.OpenReadIcon();
        sourceStream.CopyTo(file);
    }

    public void CopyThumbnailTo(Item item, string destFileName, bool overwrite)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();   

        using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
        using Stream sourceStream = item.OpenReadThumbnail();
        sourceStream.CopyTo(file);
    }

    public Stream OpenRead(Item item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.OpenRead();
    }

    public StreamReader OpenText(Item item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return new StreamReader(item.OpenRead());
    }

    public Stream OpenIcon(Item item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.OpenReadIcon();
    }

    public Stream OpenThumbnail(Item item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return item.OpenReadThumbnail();
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
