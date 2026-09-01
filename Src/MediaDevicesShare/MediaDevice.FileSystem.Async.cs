namespace MediaDevices;

partial class MediaDevice
{
    /// <summary>
    /// Asynchronously enumerates the directories at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path to enumerate directories from. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{String}"/> that yields directory names found at the specified <paramref name="path"/>.
    /// The caller can asynchronously iterate the returned sequence to receive directory entries.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<string> EnumerateDirectoriesAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeAsyncEnumerable<string>(() => WpdDevice.EnumerateDirectories(this, path, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates the directories at the specified path that match the given search pattern.
    /// </summary>
    /// <param name="path">The path to enumerate directories from. Must be a valid file system path.</param>
    /// <param name="searchPattern">The search string to match against the names of directories. For example, "*" or "Photos*". If <c>null</c> or empty, behavior depends on the underlying protocol handler.</param>
    /// <param name="searchOption">Specifies whether the search operation should include only the current directory or all subdirectories.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{String}"/> that yields directory names matching the provided pattern.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<string> EnumerateDirectoriesAsync(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeAsyncEnumerable(() => WpdDevice.EnumerateDirectories(this, path, searchPattern, searchOption, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates the files at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path to enumerate files from. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{String}"/> that yields file names found at the specified <paramref name="path"/>. The caller can asynchronously iterate the returned sequence to receive file entries.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<string> EnumerateFilesAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeAsyncEnumerable(() => WpdDevice.EnumerateFiles(this, path, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates the files at the specified path that match the given search pattern.
    /// </summary>
    /// <param name="path">The path to enumerate files from. Must be a valid file system path.</param>
    /// <param name="searchPattern">The search string to match against the names of files. For example, "*.jpg" or "Doc*". If <c>null</c> or empty, behavior depends on the underlying protocol handler.</param>
    /// <param name="searchOption">Specifies whether the search operation should include only the current directory or all subdirectories.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{String}"/> that yields file names matching the provided pattern.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<string> EnumerateFilesAsync(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeAsyncEnumerable(() => WpdDevice.EnumerateFiles(this, path, searchPattern, searchOption, cancellationToken), cancellationToken);

    }

    /// <summary>
    /// Asynchronously enumerates file system entries (both files and directories) at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path to enumerate entries from. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{String}"/> that yields file system entry names found at the specified <paramref name="path"/>. The caller can asynchronously iterate the returned sequence to receive entries.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<string> EnumerateFileSystemEntriesAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeAsyncEnumerable(() => WpdDevice.EnumerateFileSystemEntries(this, path, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates file system entries (files and directories) at the specified path that match the given search pattern.
    /// </summary>
    /// <param name="path">The path to enumerate file system entries from. Must be a valid file system path.</param>
    /// <param name="searchPattern">The search string to match against the names of file system entries. For example, "*.*" or "Images*". If <c>null</c> or empty, behavior depends on the underlying protocol handler.</param>
    /// <param name="searchOption">Specifies whether the search operation should include only the current directory or all subdirectories.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{String}"/> that yields file system entry names matching the provided pattern.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<string> EnumerateFileSystemEntriesAsync(string path, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeAsyncEnumerable(() => WpdDevice.EnumerateFileSystemEntries(this, path, searchPattern, searchOption, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously checks whether a directory exists at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path of the directory to check. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result is <c>true</c> if the directory exists; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task<bool> DirectoryExistsAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.DirectoryExists(this, path), cancellationToken);
    }

    /// <summary>
    /// Asynchronously creates a directory at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path where the directory should be created. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task CreateDirectoryAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.CreateDirectory(this, path), cancellationToken);
    }

    /// <summary>
    /// Asynchronously deletes a directory at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path of the directory to delete. Must be a valid file system path.</param>
    /// <param name="recursive"><c>true</c> to delete the directory and all its contents recursively; <c>false</c> to delete only empty directories. Default is <c>false</c>.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task DeleteDirectoryAsync(string path, bool recursive = false, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DeleteDirectory(this, path, recursive), cancellationToken);
    }

    /// <summary>
    /// Asynchronously checks whether a file exists at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path of the file to check. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result is <c>true</c> if the file exists; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task<bool> FileExistsAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.FileExists(this, path), cancellationToken);
    }

    /// <summary>
    /// Asynchronously deletes a file at the specified path on the media device.
    /// </summary>
    /// <param name="path">The path of the file to delete. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task DeleteFileAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DeleteFile(this, path), cancellationToken);
    }

    /// <summary>
    /// Asynchronously renames a file or directory at the specified path to the given new name.
    /// </summary>
    /// <param name="path">The path of the file or directory to rename. Must be a valid file system path.</param>
    /// <param name="newName">The new name for the file or directory. Must be a valid file system path fragment or name.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> or <paramref name="newName"/> is invalid.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task RenameAsync(string path, string newName, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        FileSystemPathCheck.ThrowIfInvalidPath(newName, nameof(newName));

        await worker.InvokeAsync(() => WpdDevice.Rename(this, path, newName), cancellationToken);
    }

    #region Download & Upload

    /// <summary>
    /// Asynchronously downloads a file from the device to the provided destination <see cref="Stream"/>.
    /// </summary>
    /// <param name="source">The path of the file on the media device. Must be a valid file system path.</param>
    /// <param name="stream">The destination stream to which the file contents will be written. Must not be <c>null</c> and should be writable.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is an invalid path.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <c>null</c>.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    /// <remarks>
    /// The method does not dispose the provided <see cref="Stream"/>; the caller remains responsible for its lifetime.
    /// The operation is executed via the internal <c>WpdDevice</c> on the library's main worker.
    /// </remarks>
    public async Task DownloadFileAsync(string source, Stream stream, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadFile(this, source, stream), cancellationToken);
    }

    /// <summary>
    /// Asynchronously downloads a file from the device to a local destination path.
    /// </summary>
    /// <param name="source">The path of the file on the media device. Must be a valid file system path.</param>
    /// <param name="destination">The local destination path where the file will be saved. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> or <paramref name="destination"/> is an invalid path.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    /// <remarks>
    /// The operation is executed via the internal <c>WpdDevice</c> on the library's main worker.
    /// </remarks>
    public async Task DownloadFileAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadFile(this, source, destination), cancellationToken);
    }

    /// <summary>
    /// Asynchronously downloads an icon for the specified item to the provided <see cref="Stream"/>.
    /// </summary>
    /// <param name="source">The path of the item on the media device whose icon should be downloaded. Must be a valid file system path.</param>
    /// <param name="stream">The destination stream to which the icon will be written. Must not be <c>null</c> and should be writable.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is an invalid path.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <c>null</c>.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    /// <remarks>
    /// The method does not dispose the provided <see cref="Stream"/>; the caller remains responsible for its lifetime.
    /// </remarks>
    public async Task DownloadIconAsync(string source, Stream stream, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadIcon(this, source, stream), cancellationToken);
    }

    /// <summary>
    /// Asynchronously downloads an icon for the specified item to a local file path.
    /// </summary>
    /// <param name="source">The path of the item on the media device whose icon should be downloaded. Must be a valid file system path.</param>
    /// <param name="destination">The local destination path where the icon will be saved. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> or <paramref name="destination"/> is an invalid path.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task DownloadIconAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadIcon(this, source, destination), cancellationToken);
    }

    /// <summary>
    /// Asynchronously downloads a thumbnail for the specified item to the provided <see cref="Stream"/>.
    /// </summary>
    /// <param name="source">The path of the item on the media device whose thumbnail should be downloaded. Must be a valid file system path.</param>
    /// <param name="stream">The destination stream to which the thumbnail will be written. Must not be <c>null</c> and should be writable.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> is an invalid path.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <c>null</c>.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    /// <remarks>
    /// The method does not dispose the provided <see cref="Stream"/>; the caller remains responsible for its lifetime.
    /// </remarks>
    public async Task DownloadThumbnailAwait(string source, Stream stream, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadThumbnail(this, source, stream), cancellationToken);
    }

    /// <summary>
    /// Asynchronously downloads a thumbnail for the specified item to a local file path.
    /// </summary>
    /// <param name="source">The path of the item on the media device whose thumbnail should be downloaded. Must be a valid file system path.</param>
    /// <param name="destination">The local destination path where the thumbnail will be saved. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> or <paramref name="destination"/> is an invalid path.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task DownloadThumbnailAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadThumbnail(this, source, destination), cancellationToken);
    }

    /// <summary>
    /// Asynchronously downloads a directory from the device to a local destination path.
    /// </summary>
    /// <param name="source">The path of the directory on the media device to download. Must be a valid file system path.</param>
    /// <param name="destination">The local destination path where the directory will be created. Must be a valid file system path.</param>
    /// <param name="recursive">If <c>true</c>, download directories recursively including all subdirectories; if <c>false</c>, only the top-level contents are downloaded. Default is <c>true</c>.</param>
    /// <param name="ignoreExceptions">If <c>true</c>, exceptions encountered for individual files or subdirectories may be ignored to allow the operation to continue. Default is <c>true</c>.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> or <paramref name="destination"/> is an invalid path.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task DownloadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source);
        FileSystemPathCheck.ThrowIfInvalidPath(destination);
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadFolder(this, source, destination, recursive, ignoreExceptions), cancellationToken);
    }

    /// <summary>
    /// Asynchronously uploads a local file to the specified destination path on the device.
    /// </summary>
    /// <param name="source">The local source file path to upload. Must be a valid file system path.</param>
    /// <param name="destination">The destination path on the media device where the file will be stored. Must be a valid file system path.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous upload operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> or <paramref name="destination"/> is an invalid path.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task UploadFileAsync(string source, string destination, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.UploadFile(this, source, destination), cancellationToken);
    }

    /// <summary>
    /// Asynchronously uploads a local directory to the specified destination on the device.
    /// </summary>
    /// <param name="source">The local source directory path to upload. Must be a valid file system path.</param>
    /// <param name="destination">The destination path on the media device where the directory will be created. Must be a valid file system path.</param>
    /// <param name="recursive">If <c>true</c>, upload directories recursively including all subdirectories; if <c>false</c>, only the top-level contents are uploaded. Default is <c>true</c>.</param>
    /// <param name="ignoreExceptions">If <c>true</c>, exceptions encountered for individual files or subdirectories may be ignored to allow the operation to continue. Default is <c>true</c>.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the asynchronous operation. Default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous upload operation.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="source"/> or <paramref name="destination"/> is an invalid path.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public async Task UploadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.UploadFolder(this, source, destination, recursive, ignoreExceptions), cancellationToken);
    }

    #endregion

    #region MediaFileInfo, MediaDirectoryInfo, MediaDriveInfo and MediaFileSystemInfo based 

    /// <summary>
    /// Asynchronously retrieves file information for the specified path.
    /// </summary>
    /// <param name="path">The file path to retrieve information for. Must be a valid file system path.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="MediaFileInfo"/> for the specified path.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid or empty.</exception>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is cancelled via the <paramref name="cancellationToken"/>.</exception>
    public async Task<MediaFileInfo> GetFileInfoAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.GetFileInfo(this, path), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves directory information for the specified path.
    /// </summary>
    /// <param name="path">The directory path to retrieve information for. Must be a valid file system path.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="MediaDirectoryInfo"/> for the specified path.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is invalid or empty.</exception>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is cancelled via the <paramref name="cancellationToken"/>.</exception>
    public async Task<MediaDirectoryInfo> GetDirectoryInfoAsync(string path, CancellationToken cancellationToken = default)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.GetDirectoryInfo(this, path), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the root directory information of the device.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="MediaDirectoryInfo"/> for the device's root directory.</returns>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is cancelled via the <paramref name="cancellationToken"/>.</exception>
    public async Task<MediaDirectoryInfo> GetRootDirectoryAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.GetRootDirectory(this), cancellationToken);
    }

    #endregion

    #region PersistentUniqueId

    /// <summary>
    /// Asynchronously resolves a persistent unique identifier to a device file system path.
    /// </summary>
    /// <param name="persistentUniqueId">The persistent unique identifier to resolve. Must not be <c>null</c> or empty.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the resolved device file system path as a <see cref="string"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="persistentUniqueId"/> is <c>null</c> or empty.</exception>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<string> GetPathFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.GetPathFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves file system metadata for the resource identified by the persistent unique identifier.
    /// </summary>
    /// <param name="persistentUniqueId">The persistent unique identifier of the resource. Must not be <c>null</c> or empty.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a <see cref="MediaFileSystemInfo"/> describing the resource.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="persistentUniqueId"/> is <c>null</c> or empty.</exception>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<MediaFileSystemInfo> GetFileSystemInfoFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.GetFileSystemInfoFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    /// <summary>
    /// Asynchronously downloads a file identified by a persistent unique identifier to a local destination path.
    /// </summary>
    /// <param name="persistentUniqueId">The persistent unique identifier of the file to download. Must not be <c>null</c> or empty.</param>
    /// <param name="destination">The local destination file path where the file will be saved.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous download operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="persistentUniqueId"/> is <c>null</c> or empty.</exception>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task DownloadFileFromPersistentUniqueIdAsync(string persistentUniqueId, string destination, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        await worker.InvokeAsync(() => WpdDevice.DownloadFileFromPersistentUniqueId(this, persistentUniqueId, destination), cancellationToken);
    }

    /// <summary>
    /// Asynchronously opens a read-only <see cref="Stream"/> for the resource identified by the persistent unique identifier.
    /// </summary>
    /// <param name="persistentUniqueId">The persistent unique identifier of the resource. Must not be <c>null</c> or empty.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a readable <see cref="Stream"/> for the resource.
    /// The caller is responsible for disposing the returned stream when finished.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="persistentUniqueId"/> is <c>null</c> or empty.</exception>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<Stream> OpenReadFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.OpenReadFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    /// <summary>
    /// Asynchronously opens a <see cref="StreamReader"/> for reading text from the resource identified by the persistent unique identifier.
    /// </summary>
    /// <param name="persistentUniqueId">The persistent unique identifier of the resource. Must not be <c>null</c> or empty.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains a <see cref="StreamReader"/> for reading text, or <c>null</c> if the resource could not be opened as text.
    /// The caller is responsible for disposing the returned <see cref="StreamReader"/> when finished.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="persistentUniqueId"/> is <c>null</c> or empty.</exception>
    /// <exception cref="NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<StreamReader?> OpenTextFromPersistentUniqueIdAsync(string persistentUniqueId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return await worker.InvokeAsync(() => WpdDevice.OpenTextFromPersistentUniqueId(this, persistentUniqueId), cancellationToken);
    }

    #endregion
}

