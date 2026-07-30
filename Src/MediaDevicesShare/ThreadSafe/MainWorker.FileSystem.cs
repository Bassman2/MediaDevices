namespace MediaDevices;

partial class MainWorker
{
    #region MediaDevice

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
            return item.GetChildren(FilterToRegex(searchPattern)!, searchOption).Where(i => i.Type != ItemType.File).Select(i => i.FullName);
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
            string? pattern = MediaDevice.FilterToRegex(searchPattern);
            return item.GetChildren(pattern!, searchOption).Where(i => i.Type == ItemType.File).Select(i => i.FullName);
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
            return item.GetChildren(FilterToRegex(searchPattern), searchOption).Select(i => i.FullName);
        });
    }

    public void CreateDirectory(MediaDevice mediaDevice, string path)
    {
        Invoke(() =>
        {
            Item.GetRoot(mediaDevice).CreateSubdirectory(path);
        });
    }

    public void DeleteDirectory(MediaDevice mediaDevice, string path, bool recursive = false)
    {
        Invoke(() =>
        {
            Item item = Item.FindFolder(mediaDevice, path) ?? throw new DirectoryNotFoundException($"Directory {path} not found.");
            item.Delete(recursive);
        });
    }

    public bool DirectoryExists(MediaDevice mediaDevice, string path)
    {
        return Invoke(() => Item.FindFolder(mediaDevice, path) != null);
    }

    public void DownloadFile(MediaDevice mediaDevice, string path, Stream stream)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, path) ?? throw new FileNotFoundException($"File {path} not found.");
            using Stream sourceStream = item.OpenRead();
            sourceStream.CopyTo(stream);
        });
    }

    public void DownloadIcon(MediaDevice mediaDevice, string path, Stream stream)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, path) ?? throw new FileNotFoundException($"File {path} not found.");
            using var sourceStream = item.OpenReadIcon();
            sourceStream.CopyTo(stream);
        });
    }

    public void DownloadThumbnail(MediaDevice mediaDevice, string path, Stream stream)
    {
        Invoke(() =>
        {
            Item item = Item.FindFile(mediaDevice, path) ?? throw new FileNotFoundException($"File {path} not found.");
            using Stream sourceStream = item.OpenReadThumbnail();
            sourceStream.CopyTo(stream);
        });
    }

    public void UploadFile(MediaDevice mediaDevice, Stream stream, string path)
    {
        Invoke(() =>
        {
            string? folder = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);
            Item item = Item.FindFolder(mediaDevice, folder!) ?? throw new DirectoryNotFoundException($"Directory {folder} not found.");

            if (item.GetChildren().Any(i => EqualsName(i.Name, fileName, mediaDevice.IsCaseSensitive)))
            {
                throw new IOException($"File {path} already exists");
            }

            item.UploadFile(fileName, stream);
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

    public StreamReader? OpenTextFromPersistentUniqueId(MediaDevice mediaDevice, string persistentUniqueId)
    {
        return Invoke(() =>
        {

            Item? item = Item.GetFromPersistentUniqueId(mediaDevice, persistentUniqueId);
            if (item == null || !item.IsFile)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }
            return item == null ? null : new StreamReader(item.OpenRead());
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
            return item.GetChildren(MediaDevice.FilterToRegex(searchPattern) ?? "", searchOption).Where(i => i.Type != ItemType.File).Select(i => new MediaDirectoryInfo(mediaDevice, i));
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
            return item.GetChildren(MediaDevice.FilterToRegex(searchPattern) ?? "", searchOption).Where(i => i.Type == ItemType.File).Select(i => new MediaFileInfo(mediaDevice, i));
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
            return item.GetChildren(MediaDevice.FilterToRegex(searchPattern) ?? "", searchOption).Select(i => i.Type == ItemType.File ?
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
