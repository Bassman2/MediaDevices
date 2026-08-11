namespace MediaDevices;

partial class MediaDevice
{

    public async Task<bool> DirectoryExistsAsync(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.DirectoryExists(this, path));
    }

    public async Task CreateDirectoryAsync(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.CreateDirectory(this, path));
    }

    public async Task DeleteDirectoryAsync(string path, bool recursive = false)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DeleteDirectory(this, path, recursive));
    }

    public async Task<bool> FileExistsAsync(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.FileExists(this, path));
    }

    public async Task DeleteFileAsync(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DeleteFile(this, path));
    }

    public async Task RenameAsync(string path, string newName)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        FileSystemPathCheck.ThrowIfInvalidPath(newName, nameof(newName));

        await mainWorker.InvokeAsync(() => ProtocolHandler.Rename(this, path, newName));
    }

    #region Download & Upload

    public async Task DownloadFileAsync(string source, Stream stream)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFile(this, source, stream));
    }

    public async Task DownloadFileAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFile(this, source, destination));
    }

    public async Task DownloadIconAsync(string source, Stream stream)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadIcon(this, source, stream));
    }

    public async Task DownloadIconAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadIcon(this, source, destination));
    }

    public async Task DownloadThumbnailAwait(string source, Stream stream)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadThumbnail(this, source, stream));
    }

    public async Task DownloadThumbnailAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadThumbnail(this, source, destination));
    }

    public async Task DownloadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source);
        FileSystemPathCheck.ThrowIfInvalidPath(destination);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFolder(this, source, destination, recursive, ignoreExceptions));
    }


    public async Task UploadFileAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.UploadFile(this, source, destination));
    }

    public async Task UploadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.UploadFolder(this, source, destination, recursive, ignoreExceptions));
    }

    #endregion

    #region MediaFileInfo, MediaDirectoryInfo, MediaDriveInfo and MediaFileSystemInfo based 

    public async Task<MediaFileInfo> GetFileInfoAsync(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetFileInfo(this, path));
    }

    public async Task<MediaDirectoryInfo> GetDirectoryInfoAsync(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetDirectoryInfo(this, path));
    }

    public async Task<MediaDirectoryInfo> GetRootDirectoryAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetRootDirectory(this));
    }

    #endregion

    #region PersistentUniqueId

    public async Task<string> GetPathFromPersistentUniqueIdAsync(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetPathFromPersistentUniqueId(this, persistentUniqueId));
    }

    public async Task<MediaFileSystemInfo> GetFileSystemInfoFromPersistentUniqueIdAsync(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetFileSystemInfoFromPersistentUniqueId(this, persistentUniqueId));
    }

    public async Task DownloadFileFromPersistentUniqueIdAsync(string persistentUniqueId, string destination)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFileFromPersistentUniqueId(this, persistentUniqueId, destination));
    }

    public async Task<Stream> OpenReadFromPersistentUniqueIdAsync(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenReadFromPersistentUniqueId(this, persistentUniqueId));
    }

    public async Task<StreamReader?> OpenTextFromPersistentUniqueIdAsync(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenTextFromPersistentUniqueId(this, persistentUniqueId));
    }

    #endregion
}

