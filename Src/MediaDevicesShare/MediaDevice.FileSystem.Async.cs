namespace MediaDevices;

partial class MediaDevice
{

    public async Task<bool> DirectoryExistsAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.DirectoryExists(this, path), cancellationToken);
    }

    public async Task CreateDirectoryAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.CreateDirectory(this, path), cancellationToken);
    }

    public async Task DeleteDirectoryAsync(string path, bool recursive = false, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DeleteDirectory(this, path, recursive), cancellationToken);
    }

    public async Task<bool> FileExistsAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.FileExists(this, path), cancellationToken);
    }

    public async Task DeleteFileAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DeleteFile(this, path), cancellationToken);
    }

    public async Task RenameAsync(string path, string newName, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        FileSystemPathCheck.ThrowIfInvalidPath(newName, nameof(newName));

        await mainWorker.InvokeAsync(() => ProtocolHandler.Rename(this, path, newName), cancellationToken);
    }

    #region Download & Upload

    public async Task DownloadFileAsync(string source, Stream stream, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFile(this, source, stream), cancellationToken);
    }

    public async Task DownloadFileAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFile(this, source, destination), cancellationToken);
    }

    public async Task DownloadIconAsync(string source, Stream stream, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadIcon(this, source, stream), cancellationToken);
    }

    public async Task DownloadIconAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadIcon(this, source, destination), cancellationToken);
    }

    public async Task DownloadThumbnailAwait(string source, Stream stream, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadThumbnail(this, source, stream), cancellationToken);
    }

    public async Task DownloadThumbnailAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadThumbnail(this, source, destination), cancellationToken);
    }

    public async Task DownloadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source);
        FileSystemPathCheck.ThrowIfInvalidPath(destination);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFolder(this, source, destination, recursive, ignoreExceptions), cancellationToken);
    }


    public async Task UploadFileAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.UploadFile(this, source, destination), cancellationToken);
    }

    public async Task UploadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.UploadFolder(this, source, destination, recursive, ignoreExceptions), cancellationToken);
    }

    #endregion

    #region MediaFileInfo, MediaDirectoryInfo, MediaDriveInfo and MediaFileSystemInfo based 

    public async Task<MediaFileInfo> GetFileInfoAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetFileInfo(this, path), cancellationToken);
    }

    public async Task<MediaDirectoryInfo> GetDirectoryInfoAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetDirectoryInfo(this, path), cancellationToken);
    }

    public async Task<MediaDirectoryInfo> GetRootDirectoryAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetRootDirectory(this), cancellationToken);
    }

    #endregion

    #region PersistentUniqueId

    public async Task<string> GetPathFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetPathFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    public async Task<MediaFileSystemInfo> GetFileSystemInfoFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.GetFileSystemInfoFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    public async Task DownloadFileFromPersistentUniqueIdAsync(string persistentUniqueId, string destination, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFileFromPersistentUniqueId(this, persistentUniqueId, destination), cancellationToken);
    }

    public async Task<Stream> OpenReadFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenReadFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    public async Task<StreamReader?> OpenTextFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenTextFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    #endregion
}

