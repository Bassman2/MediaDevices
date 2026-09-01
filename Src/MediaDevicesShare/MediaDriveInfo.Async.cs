namespace MediaDevices;

partial class MediaDriveInfo
{
    /// <summary>
    /// Asynchronously ejects the drive represented by this <see cref="MediaDriveInfo"/>.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to observe while waiting for the operation to complete.
    /// If cancellation is requested the returned <see cref="Task"/> will be canceled.
    /// </param>
    /// <returns>A <see cref="Task"/> that completes when the eject operation has finished.</returns>
    /// <exception cref="NotConnectedException">
    /// Thrown if the underlying device is not connected when the method is called.
    /// </exception>
    public async Task EjectAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);

        await mainWorker.InvokeAsync(() => WpdDevice.EjectId(this.mediaDevice, this.objectId), cancellationToken);
    }

    /// <summary>
    /// Asynchronously formats the drive represented by this <see cref="MediaDriveInfo"/>.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to observe while waiting for the operation to complete.
    /// If cancellation is requested the returned <see cref="Task"/> will be canceled.
    /// </param>
    /// <returns>A <see cref="Task"/> that completes when the format operation has finished.</returns>
    /// <exception cref="NotConnectedException">
    /// Thrown if the underlying device is not connected when the method is called.
    /// </exception>
    public async Task FormatAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);

        await mainWorker.InvokeAsync(() => WpdDevice.FormatId(this.mediaDevice, this.objectId), cancellationToken);
    }
}
