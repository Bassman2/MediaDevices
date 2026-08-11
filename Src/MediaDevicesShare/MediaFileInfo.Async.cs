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

    public async Task<Stream> OpenReadAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenRead(item));
    }

    public async Task<Stream> OpenIconAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenIcon(item));
    }

    public async Task<Stream> OpenThumbnailAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenThumbnail(item));
    }

    public async Task<StreamReader> OpenTextAsync()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenText(item));
    }
}
