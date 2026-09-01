namespace MediaDevices;

partial class MediaFileSystemInfo
{
    /// <summary>
    /// Asynchronously renames the file or directory represented by this instance.
    /// </summary>
    /// <param name="newName">The new name for the file or directory. Cannot be null or contain only whitespace.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation. The default value is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous rename operation.</returns>
    /// <exception cref="NotConnectedException">Thrown when the associated media device is not connected.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="newName"/> is null or contains only whitespace characters.</exception>
    /// <remarks>
    /// This method validates the connection state and the provided name before invoking the underlying protocol handler.
    /// The operation can be canceled by passing a cancellation token.
    /// </remarks>
    public async Task RenameAsync(string newName, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        ArgumentException.ThrowIfNullOrWhiteSpace(newName, nameof(newName));
        await mainWorker.InvokeAsync (() => WpdDevice.Rename(this.item, newName), cancellationToken);
    }
}
