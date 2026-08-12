namespace MediaDevices;

partial class MediaFileInfo
{

    public async Task CopyToAsync(string destFileName, bool overwrite = true, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyTo(item, destFileName, overwrite), cancellationToken);
    }

    public async Task CopyIconToAsync(string destFileName, bool overwrite = true, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyIconTo(item, destFileName, overwrite), cancellationToken);
    }

    public async Task CopyThumbnailToAsync(string destFileName, bool overwrite = true, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        await mainWorker.InvokeAsync(() => ProtocolHandler.CopyThumbnailTo(item, destFileName, overwrite), cancellationToken);
    }

    public async Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenRead(item), cancellationToken);
    }

    public async Task<Stream> OpenIconAsync( CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenIcon(item), cancellationToken);
    }

    public async Task<Stream> OpenThumbnailAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenThumbnail(item), cancellationToken);
    }

    public async Task<StreamReader> OpenTextAsync(CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.OpenText(item), cancellationToken);
    }
}
