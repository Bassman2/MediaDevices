namespace MediaDevices;

partial class MediaDriveInfo
{
    public async Task EjectAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);

        await mainWorker.InvokeAsync(() => ProtocolHandler.EjectId(this.mediaDevice, this.objectId));
    }

    public async Task FormatAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);

        await mainWorker.InvokeAsync(() => ProtocolHandler.FormatId(this.mediaDevice, this.objectId));
    }
}
