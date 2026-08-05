namespace MediaDevices;

partial class MediaDevice
{

    public async Task DownloadFileAsync(string source, string destination)
    {
        ArgumentPathException.ThrowIfNullOrNotPath(source, nameof(source));
        ArgumentPathException.ThrowIfNullOrNotPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFile(this, source, destination));
    }

    /*
    public async Task DownloadIconAsync(string source, string destination)
    {
        ArgumentPathException.ThrowIfNullOrNotPath(source, nameof(source));
        ArgumentPathException.ThrowIfNullOrNotPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeAsync(() => mainWorker.DownloadIcon(this, source, destination));
    }

    public async Task DownloadThumbnailAsync(string source, string destination)
    {
        ArgumentPathException.ThrowIfNullOrNotPath(source, nameof(source));
        ArgumentPathException.ThrowIfNullOrNotPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => mainWorker.DownloadThumbnail(this, source, destination));
    }

    public async Task DownloadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        ArgumentPathException.ThrowIfNullOrNotPath(source);
        ArgumentPathException.ThrowIfNullOrNotPath(destination);
        NotConnectedException.ThrowIfNotConnected(this);


        Directory.CreateDirectory(destination);
        return await mainWorker.InvokeAsync(() => mainWorker.DownloadFolder(this, source, destination, recursive, ignoreExceptions));
    }

    public async Task UploadFileAsync(string source, string destination)
    {
        ArgumentPathException.ThrowIfNullOrNotPath(source, nameof(source));
        ArgumentPathException.ThrowIfNullOrNotPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => mainWorker.UploadFile(this, source, destination));
    }

    public async Task UploadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        ArgumentPathException.ThrowIfNullOrNotPath(source, nameof(source));
        ArgumentPathException.ThrowIfNullOrNotPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        return await mainWorker.InvokeAsync(() => mainWorker.UploadFolder(this, source, destination, recursive, ignoreExceptions));
    }
    */
}

