namespace MediaDevices;

partial class MediaDirectoryInfo
{
    /// <summary>
    /// Asynchronously creates a subdirectory with the specified path within the current directory.
    /// </summary>
    /// <param name="path">The name or relative path of the subdirectory to create.</param>
    /// <param name="cancellationToken">A cancellation token to monitor for cancellation requests. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="MediaDirectoryInfo"/> object representing the newly created subdirectory.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> is <c>null</c> or an empty string.</exception>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    /// <remarks>
    /// This method communicates with the media device through the protocol handler to create the subdirectory.
    /// The operation respects the provided cancellation token and can be cancelled at any time.
    /// </remarks>
    public async Task<MediaDirectoryInfo> CreateSubdirectoryAsync(string path, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(device);
        return await worker.InvokeAsync(() => device.CreateDirectory(ObjectId, path, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates the subdirectories of the current directory.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{MediaDirectoryInfo}"/> that yields <see cref="MediaDirectoryInfo"/> instances for each subdirectory. Enumeration is lazy and supports cancellation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<MediaDirectoryInfo> EnumerateDirectoriesAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.InvokeAsyncEnumerable(() => device.EnumerateDirectories(ObjectId, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates the subdirectories of the current directory that match the specified search pattern.
    /// </summary>
    /// <param name="searchPattern">The search string to match against the names of subdirectories. For example, "*" or "Images*". If <c>null</c> or empty, behavior depends on the underlying protocol handler.</param>
    /// <param name="searchOption">Specifies whether the search operation should include only the current directory or all subdirectories.</param>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{MediaDirectoryInfo}"/> that yields <see cref="MediaDirectoryInfo"/> instances for each matching subdirectory. Enumeration is lazy and supports cancellation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<MediaDirectoryInfo> EnumerateDirectoriesAsync(string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.InvokeAsyncEnumerable(() => device.EnumerateDirectories(ObjectId, searchPattern, searchOption, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates the files in the current directory.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{MediaFileInfo}"/> that yields <see cref="MediaFileInfo"/> instances for each file. Enumeration is lazy and supports cancellation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<MediaFileInfo> EnumerateFilesAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.InvokeAsyncEnumerable(() => device.EnumerateFiles(ObjectId, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates the files in the current directory that match the specified search pattern.
    /// </summary>
    /// <param name="searchPattern">The search string to match against the names of files. For example, "*.jpg" or "Doc*". If <c>null</c> or empty, behavior depends on the underlying protocol handler.</param>
    /// <param name="searchOption">Specifies whether the search operation should include only the current directory or all subdirectories.</param>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{MediaFileInfo}"/> that yields <see cref="MediaFileInfo"/> instances for each matching file. Enumeration is lazy and supports cancellation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<MediaFileInfo> EnumerateFilesAsync(string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.InvokeAsyncEnumerable(() => device.EnumerateFiles(ObjectId, searchPattern, searchOption, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates file system entries (files and directories) in the current directory.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{MediaFileSystemInfo}"/> that yields <see cref="MediaFileSystemInfo"/> instances for each file system entry. Enumeration is lazy and supports cancellation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfosAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.InvokeAsyncEnumerable(() => device.EnumerateFileSystemInfos(ObjectId, cancellationToken), cancellationToken);
    }

    /// <summary>
    /// Asynchronously enumerates file system entries (files and directories) in the current directory that match the specified search pattern.
    /// </summary>
    /// <param name="searchPattern">The search string to match against the names of file system entries. For example, "*.*" or "Images*". If <c>null</c> or empty, behavior depends on the underlying protocol handler.</param>
    /// <param name="searchOption">Specifies whether the search operation should include only the current directory or all subdirectories.</param>
    /// <param name="cancellationToken">A cancellation token to observe while enumerating. The default is <see cref="CancellationToken.None"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{MediaFileSystemInfo}"/> that yields <see cref="MediaFileSystemInfo"/> instances for each matching entry. Enumeration is lazy and supports cancellation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    public IAsyncEnumerable<MediaFileSystemInfo> EnumerateFileSystemInfosAsync(string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.InvokeAsyncEnumerable(() => device.EnumerateFileSystemInfos(ObjectId, searchPattern, searchOption, cancellationToken), cancellationToken);
    }
}
