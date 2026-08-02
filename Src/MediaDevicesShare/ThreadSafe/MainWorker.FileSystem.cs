namespace MediaDevices;

partial class MainWorker
{
    #region MediaDevice: path based

    public IEnumerable<string> EnumerateDirectories(MediaDevice mediaDevice, string path)
    {
        return InvokeEnumerable(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
            return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => i.FullName);
        });
    }

    public IEnumerable<string> EnumerateDirectories(MediaDevice mediaDevice, string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        return InvokeEnumerable(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
            return item.GetChildren(searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => i.FullName);
        });
    }

    public IEnumerable<string> EnumerateFiles(MediaDevice mediaDevice, string path)
    {
        return InvokeEnumerable(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
            return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => i.FullName);
        });
    }

    public IEnumerable<string> EnumerateFiles(MediaDevice mediaDevice, string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        return InvokeEnumerable(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
            return item.GetChildren(searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => i.FullName);
        });
    }

    public IEnumerable<string> EnumerateFileSystemEntries(MediaDevice mediaDevice, string path)
    {
        return InvokeEnumerable(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
            return item.GetChildren().Select(i => i.FullName);
        });
    }

    public IEnumerable<string> EnumerateFileSystemEntries(MediaDevice mediaDevice, string path, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        return InvokeEnumerable(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Director {path} not found.");
            return item.GetChildren(searchPattern, searchOption).Select(i => i.FullName);
        });
    }

    public bool DirectoryExists(MediaDevice mediaDevice, string path)
    {
        return Invoke(() => Item.FindFolder(mediaDevice, path) != null);
    }

    public void CreateDirectory(MediaDevice mediaDevice, string path)
    {
        Invoke(() => Item.GetRoot(mediaDevice).CreateSubdirectory(path));
    }

    public void DeleteDirectory(MediaDevice mediaDevice, string path, bool recursive = false)
    {
        Invoke(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Directory {path} not found.");
            item.Delete(recursive);
        });
    }
    
    public bool FileExists(MediaDevice mediaDevice, string path)
    {
        return Invoke(() => Item.FindFile(mediaDevice, path) != null);
    }

    public void DeleteFile(MediaDevice mediaDevice, string path)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, path) ?? throw new FileNotFoundException($"File {path} not found.");
            item.Delete();
        });
    }

    public void Rename(MediaDevice mediaDevice, string path, string newName)
    {
        Invoke(() =>
        {
            Item item = Item.FindItem(mediaDevice, path) ?? throw new FileNotFoundException($"Path {path} not found.", path);
            item.Rename(newName);
        });
    }

    #endregion

    #region Download and Upload path based

    public void DownloadFile(MediaDevice mediaDevice, string source, Stream stream)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
            using var sourceStream = item.OpenRead();
            sourceStream.CopyTo(stream);
        });
    }

    public void DownloadFile(MediaDevice mediaDevice, string source, string destination)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
            using var sourceStream = item.OpenRead();
            using var destinationStream = File.Create(destination);
            sourceStream.CopyTo(destinationStream);
        });
    }

    public void DownloadIcon(MediaDevice mediaDevice, string source, Stream stream)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
            using var sourceStream = item.OpenReadIcon();
            sourceStream.CopyTo(stream);
        });
    }

    public void DownloadIcon(MediaDevice mediaDevice, string source, string destination)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
            using var sourceStream = item.OpenReadIcon();
            using var destinationStream = File.Create(destination);
            sourceStream.CopyTo(destinationStream);
        });
    }

    public void DownloadThumbnail(MediaDevice mediaDevice, string source, Stream stream)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
            using Stream sourceStream = item.OpenReadThumbnail();
            sourceStream.CopyTo(stream);
        });
    }

    public void DownloadThumbnail(MediaDevice mediaDevice, string source, string destination)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, source) ?? throw new FileNotFoundException($"File {source} not found.");
            using Stream sourceStream = item.OpenReadThumbnail();
            using var destinationStream = File.Create(destination);
            sourceStream.CopyTo(destinationStream);
        });
    }

    public void DownloadFolder(MediaDevice mediaDevice, string source, string destination, bool recursive, bool ignoreExceptions)
    {
        Invoke(() =>
        {
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
        });
    }

    private static void DownloadFileIntern(Item item, string path, bool ignoreExceptions)
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
            Trace.WriteLine($"{ex.Message} for {item.GetPath()}");
            if (!ignoreExceptions)
            {
                throw;
            }
        }
    }
    
    public void UploadFile(MediaDevice mediaDevice, Stream stream, string destination)
    {
        Invoke(() =>
        {
            string? folder = Path.GetDirectoryName(destination);
            string fileName = Path.GetFileName(destination);
            Item item = Item.FindFolder(mediaDevice, folder!) ?? throw new DirectoryNotFoundException($"Directory {folder} not found.");

            if (item.GetChildren().Any(i => EqualsName(i.Name, fileName, mediaDevice.IsCaseSensitive)))
            {
                throw new IOException($"File {destination} already exists");
            }

            item.UploadFile(fileName, stream, DateTime.Now, DateTime.Now, DateTime.Now);
        });
    }

    public void UploadFile(MediaDevice mediaDevice, string source, string destination)
    {
        Invoke(() =>
        {
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
        });
    }

    public void UploadFolder(MediaDevice mediaDevice, string source, string destination, bool recursive, bool ignoreExceptions)
    {
        Invoke(() =>
        {
            Item.GetRoot(mediaDevice).CreateSubdirectory(destination);
            if (recursive)
            {
                var di = new DirectoryInfo(source);
                foreach (var fsi in di.EnumerateFileSystemInfos("*", SearchOption.AllDirectories))
                {
                    string path = Path.Combine(destination, GetLocalPath(source, fsi.FullName));

                    if (fsi is FileInfo fi)
                    {
                        UploadFileIntern(mediaDevice, fi, source, destination, ignoreExceptions);
                    }
                    else
                    {
                        Item.GetRoot(mediaDevice).CreateSubdirectory(path);
                    }
                }
            }
            else
            {
                var di = new DirectoryInfo(source);
                foreach (FileInfo fi in di.EnumerateFiles())
                {
                    UploadFileIntern(mediaDevice, fi, source, destination, ignoreExceptions);
                }
            }
        });
    }

    private static void UploadFileIntern(MediaDevice mediaDevice, FileInfo fi, string source, string destination, bool ignoreExceptions)
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
            Trace.WriteLine($"{ex.Message} for {fi.DirectoryName}");
            if (!ignoreExceptions)
            {
                throw;
            }
        }
    }

    #endregion

    #region MediaDevice: MediaFileInfo, MediaDirectoryInfo, MediaDriveInfo and MediaFileSystemInfo based 


    public MediaFileInfo GetFileInfo(MediaDevice mediaDevice, string path)
    {
        return Invoke(() =>
        {
            var item = Item.FindItem(mediaDevice, path) ?? throw new FileNotFoundException($"{path} not found.", path);
            return new MediaFileInfo(mediaDevice, item);
        });
    }

    public MediaDirectoryInfo GetDirectoryInfo(MediaDevice mediaDevice, string path)
    {
        return Invoke(() =>
        {
            var item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"{path} not found.");
            return new MediaDirectoryInfo(mediaDevice, item);
        });
    }

    public IEnumerable<MediaDriveInfo> GetDrives(MediaDevice mediaDevice)
        => InvokeEnumerable(() => GetDrivesIntern(mediaDevice));

    private IEnumerable<MediaDriveInfo> GetDrivesIntern(MediaDevice mediaDevice)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Guid guid = FunctionalCategory.Storage.GetGuid();

        int err = mediaDevice.deviceCapabilities!.GetFunctionalObjects(ref guid!, out IPortableDevicePropVariantCollection objects);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalObjects));

        //ComTrace.WriteObject(objects);
        //var drives = objects.ToStrings();

        uint count = 0;
        int error = objects.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(error, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = objects.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            yield return new MediaDriveInfo(mediaDevice, val.ToString());
        }
    }

    public MediaDirectoryInfo GetRootDirectory(MediaDevice mediaDevice)
    {
        return Invoke(() => new MediaDirectoryInfo(mediaDevice, Item.GetRoot(mediaDevice)));
    }

    public void DownloadFileFromPersistentUniqueId(MediaDevice mediaDevice, string persistentUniqueId, Stream stream)
    {
        Invoke(() =>
        {
            Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
            if (item == null || !item.IsFile)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }
            using Stream sourceStream = item.OpenRead();
            sourceStream.CopyTo(stream);
        });
    }

    #endregion

    #region MediDevice: PersistentUniqueId

    public string GetPathFromPersistentUniqueId(MediaDevice mediaDevice, string persistentUniqueId)
    {
        return Invoke(() =>
        {
            Item item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId) ?? throw new FileNotFoundException($"{persistentUniqueId} not found.");
            return item.GetPath();
        });
    }

    public MediaFileSystemInfo GetFileSystemInfoFromPersistentUniqueId(MediaDevice mediaDevice, string persistentUniqueId)
    {
        return Invoke(() =>
        {
            Item item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId) ?? throw new FileNotFoundException($"{persistentUniqueId} not found.");
            return (MediaFileSystemInfo)(item.IsFile ? new MediaFileInfo(mediaDevice, item) : new MediaDirectoryInfo(mediaDevice, item));
        });
    }

    public void DownloadFileFromPersistentUniqueId(MediaDevice mediaDevice, string persistentUniqueId, string destination)
    {
        Invoke(() =>
        {
            Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
            if (item == null || !item.IsFile)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }
            using var reader = item.OpenRead();
            using var writer = File.Create(destination);
            reader.CopyTo(writer);
        });
    }

    public Stream OpenReadFromPersistentUniqueId(MediaDevice mediaDevice, string persistentUniqueId)
    {
        return Invoke(() =>
        {

            Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
            if (item == null || !item.IsFile)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }
            return item.OpenRead();
        });
    }

    public StreamReader OpenTextFromPersistentUniqueId(MediaDevice mediaDevice, string persistentUniqueId)
    {
        return Invoke(() =>
        {
            Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
            if (item == null || !item.IsFile)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }
            return new StreamReader(item.OpenRead());
        });
    }

    

    #endregion

    #region MediaFileSystemInfo

    public void Refresh(Item item)
    {
        Invoke(() => item.Refresh());
    }

    public MediaDirectoryInfo? GetParent(MediaDevice mediaDevice, Item item)
    {
        return Invoke(() =>
        {
            Item? parent = item.Parent;
            return parent == null ? null : new MediaDirectoryInfo(mediaDevice, parent);
        });
    }

    public void SetCreationTime(Item item, DateTime? value)
    {
        Invoke(() => item.SetDateCreated(value.GetValueOrDefault(DateTime.Now)));
    }

    public void SetLastWriteTime(Item item, DateTime? value)
    {
        Invoke(() => item.SetDateModified(value.GetValueOrDefault(DateTime.Now)));
    }

    public void SetDateAuthored(Item item, DateTime? value)
    {
        Invoke(() => item.SetDateAuthored(value.GetValueOrDefault(DateTime.Now)));
    }

    public void Rename(Item item, string newName)
    {
        Invoke(() => item.Rename(newName));
    }

    #endregion

    #region MediaDirectoryInfo

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(MediaDevice mediaDevice, Item item)
    {
        return InvokeEnumerable(() =>
        {
            return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => new MediaDirectoryInfo(mediaDevice, i));
        });
    }

    public IEnumerable<MediaDirectoryInfo> EnumerateDirectories(MediaDevice mediaDevice, Item item, string searchPattern, SearchOption searchOption)
    {
        return InvokeEnumerable(() =>
        {
            return item.GetChildren(searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => new MediaDirectoryInfo(mediaDevice, i));
        });
    }

    public IEnumerable<MediaFileInfo> EnumerateFiles(MediaDevice mediaDevice, Item item)
    {
        return InvokeEnumerable(() =>
        {
            return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => new MediaFileInfo(mediaDevice, i));
        });
    }

    public IEnumerable<MediaFileInfo> EnumerateFiles(MediaDevice mediaDevice, Item item, string searchPattern, SearchOption searchOption)
    {
        return InvokeEnumerable(() =>
        {
            return item.GetChildren(searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => new MediaFileInfo(mediaDevice, i));
        });
    }

    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfos(MediaDevice mediaDevice, Item item)
    {
        return InvokeEnumerable(() =>
        {
            return item.GetChildren().Select(i => i.Type == ItemType.File ?
                    (MediaFileSystemInfo)new MediaFileInfo(mediaDevice, i) :
                    (MediaFileSystemInfo)new MediaDirectoryInfo(mediaDevice, i));
        });
    }

    public IEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfos(MediaDevice mediaDevice, Item item, string searchPattern, SearchOption searchOption)
    {
        return InvokeEnumerable(() =>
        {
            return item.GetChildren(searchPattern, searchOption).Select(i => i.Type == ItemType.File ?
                    (MediaFileSystemInfo)new MediaFileInfo(mediaDevice, i) :
                    (MediaFileSystemInfo)new MediaDirectoryInfo(mediaDevice, i));
        });
    }

    public MediaDirectoryInfo CreateSubdirectory(MediaDevice mediaDevice, Item item, string path)
    {
        return Invoke(() =>
        {
            Item? dirItem = item.CreateSubdirectory(path);
            return new MediaDirectoryInfo(mediaDevice, dirItem!);
        });
    }

    #endregion

    #region MediaFileInfo

    public void CopyTo(Item item, string destFileName, bool overwrite)
    {
        Invoke(() =>
        {
            using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
            using Stream sourceStream = item.OpenRead();
            sourceStream.CopyTo(file);
        });
    }

    public void CopyIconTo(Item item, string destFileName, bool overwrite)
    {
        Invoke(() =>
        {
            using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
            using Stream sourceStream = item.OpenReadIcon();
            sourceStream.CopyTo(file);
        });

    }

    public void CopyThumbnailTo(Item item, string destFileName, bool overwrite)
    {
        Invoke(() =>
        {
            using FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew);
            using Stream sourceStream = item.OpenReadThumbnail();
            sourceStream.CopyTo(file);
        });
    }

    public Stream OpenRead(Item item)
    {
        return Invoke(() => item.OpenRead());
    }

    public StreamReader OpenText(Item item)
    {
        return Invoke(() => new StreamReader(item.OpenRead()));
    }

    public Stream OpenIcon(Item item)
    {
        return Invoke(() => item.OpenReadIcon());
    }

    public Stream OpenThumbnail(Item item)
    { 
        return Invoke(() =>  item.OpenReadThumbnail());
    }

    #endregion

    #region Internal

    private static string GetLocalPath(string basePath, string fullPath)
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
