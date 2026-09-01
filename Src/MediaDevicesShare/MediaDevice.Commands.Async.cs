namespace MediaDevices;

partial class MediaDevice
{
    /// <summary>
    /// Asynchronously formats the storage at the specified path on the connected media device.
    /// </summary>
    /// <param name="path">The path of the storage to format. Cannot be null or empty.</param>
    /// <param name="cancellationToken">A token to request cancellation of the operation. Defaults to <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task representing the asynchronous format operation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the media device is not connected.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="path"/> is null or empty.</exception>
    /// <remarks>
    /// This method validates that the media device is connected and that a valid path is provided
    /// before invoking the format operation. The actual formatting is performed on the main worker thread.
    /// </remarks>
    public async Task FormatStorageAsync(string path, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));

        await worker.InvokeAsync(() => WpdDevice.FormatPath(this, path), cancellationToken);
    }
}
