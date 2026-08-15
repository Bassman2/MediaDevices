namespace MediaDevices;

partial class MediaFileInfo
{
    /// <summary>
    /// Asynchronously copies the current file on the device to a local file.
    /// The operation is executed on the library's internal worker thread.
    /// </summary>
    /// <param name="destFileName">The destination file path on the local filesystem.</param>
    /// <param name="overwrite">If true, an existing destination file will be overwritten; otherwise an existing file will cause an error.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous copy operation.</returns>
    /// <exception cref="System.IO.IOException">An I/O error occurs, or the destination file already exists and <paramref name="overwrite"/> is false.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">The destination path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">The underlying <see cref="MediaDevice"/> is not connected.</exception>
    /// <exception cref="System.OperationCanceledException">The operation was canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task CopyToAsync(string destFileName, bool overwrite = true, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyTo(item, destFileName, overwrite), cancellationToken);
    }

    /// <summary>
    /// Asynchronously copies the icon associated with the current file on the device to a local file.
    /// The operation is executed on the library's internal worker thread.
    /// </summary>
    /// <param name="destFileName">The destination file path on the local filesystem for the icon.</param>
    /// <param name="overwrite">If true, an existing destination file will be overwritten; otherwise an existing file will cause an error.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous copy operation.</returns>
    /// <exception cref="System.IO.IOException">An I/O error occurs, or the destination file already exists and <paramref name="overwrite"/> is false.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">The destination path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">The underlying <see cref="MediaDevice"/> is not connected.</exception>
    /// <exception cref="System.OperationCanceledException">The operation was canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task CopyIconToAsync(string destFileName, bool overwrite = true, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyIconTo(item, destFileName, overwrite), cancellationToken);
    }

    /// <summary>
    /// Asynchronously copies the thumbnail associated with the current file on the device to a local file.
    /// The operation is executed on the library's internal worker thread.
    /// </summary>
    /// <param name="destFileName">The destination file path on the local filesystem for the thumbnail.</param>
    /// <param name="overwrite">If true, an existing destination file will be overwritten; otherwise an existing file will cause an error.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous copy operation.</returns>
    /// <exception cref="System.IO.IOException">An I/O error occurs, or the destination file already exists and <paramref name="overwrite"/> is false.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">The destination path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">The underlying <see cref="MediaDevice"/> is not connected.</exception>
    /// <exception cref="System.OperationCanceledException">The operation was canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task CopyThumbnailToAsync(string destFileName, bool overwrite = true, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyThumbnailTo(item, destFileName, overwrite), cancellationToken);
    }

    /// <summary>
    /// Asynchronously opens a read-only <see cref="Stream"/> for the current file on the device.
    /// The returned stream is backed by the device transport; the caller is responsible for disposing it.
    /// The operation is executed on the library's internal worker thread.
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task{Stream}"/> that represents the asynchronous operation and yields the opened <see cref="Stream"/>.</returns>
    /// <exception cref="System.IO.IOException">An I/O error occurs while opening the stream.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">The underlying <see cref="MediaDevice"/> is not connected.</exception>
    /// <exception cref="System.OperationCanceledException">The operation was canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenRead(item), cancellationToken);
    }

    /// <summary>
    /// Asynchronously opens a <see cref="Stream"/> containing the file's icon data.
    /// The returned stream must be disposed by the caller. The operation runs on the library's internal worker thread.
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task{Stream}"/> that yields the opened icon <see cref="Stream"/>.</returns>
    /// <exception cref="System.IO.IOException">An I/O error occurs while opening the icon stream.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">The underlying <see cref="MediaDevice"/> is not connected.</exception>
    /// <exception cref="System.OperationCanceledException">The operation was canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<Stream> OpenIconAsync( CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenIcon(item), cancellationToken);
    }

    /// <summary>
    /// Asynchronously opens a <see cref="Stream"/> containing the file's thumbnail data.
    /// The returned stream must be disposed by the caller. The operation runs on the library's internal worker thread.
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task{Stream}"/> that yields the opened thumbnail <see cref="Stream"/>.</returns>
    /// <exception cref="System.IO.IOException">An I/O error occurs while opening the thumbnail stream.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">The underlying <see cref="MediaDevice"/> is not connected.</exception>
    /// <exception cref="System.OperationCanceledException">The operation was canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<Stream> OpenThumbnailAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenThumbnail(item), cancellationToken);
    }

    /// <summary>
    /// Asynchronously opens a <see cref="StreamReader"/> for reading text content of the current file on the device.
    /// The returned <see cref="StreamReader"/> should be disposed by the caller when finished. The operation runs on the library's internal worker thread.
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task{StreamReader}"/> that yields the opened <see cref="StreamReader"/>.</returns>
    /// <exception cref="System.IO.IOException">An I/O error occurs while opening or reading from the stream.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">The underlying <see cref="MediaDevice"/> is not connected.</exception>
    /// <exception cref="System.OperationCanceledException">The operation was canceled via <paramref name="cancellationToken"/>.</exception>
    public async Task<StreamReader> OpenTextAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenText(item), cancellationToken);
    }
}
