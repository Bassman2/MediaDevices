namespace MediaDevices;

partial class MediaDriveInfo
{
    public async Task FormatAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);

        await mainWorker.InvokeAsync(() => ProtocolHandler.FormatId(this.mediaDevice, this.objectId));
    }
}
