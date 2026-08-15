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
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.CreateSubdirectory(this.mediaDevice, item, path), cancellationToken);
    }

    // TODO
    //public IAsyncEnumerable<MediaDirectoryInfo> EnumerateDirectoriesAsync()
    //{
    //    NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
    //    return mainWorker.InvokeAsyncEnumerable<MediaDirectoryInfo>(() => ProtocolHandler.EnumerateDirectories(this.mediaDevice, this.item));
    //}

    

}
