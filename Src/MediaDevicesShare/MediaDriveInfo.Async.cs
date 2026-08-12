namespace MediaDevices;

partial class MediaDriveInfo
{
    public async Task EjectAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);

        await mainWorker.InvokeAsync(() => ProtocolHandler.EjectId(this.mediaDevice, this.objectId), cancellationToken);
    }

    public async Task FormatAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);

        await mainWorker.InvokeAsync(() => ProtocolHandler.FormatId(this.mediaDevice, this.objectId), cancellationToken);
    }
}
