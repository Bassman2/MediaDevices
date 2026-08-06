namespace MediaDevices;

partial class MediaFileInfo
{

    public async Task CopyToAsync(string destFileName, bool overwrite = true)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyTo(item, destFileName, overwrite));
    }

    public async Task CopyIconToAsync(string destFileName, bool overwrite = true)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyIconTo(item, destFileName, overwrite));
    }

    public async Task CopyThumbnailToAsync(string destFileName, bool overwrite = true)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyThumbnailTo(item, destFileName, overwrite));
    }
}
