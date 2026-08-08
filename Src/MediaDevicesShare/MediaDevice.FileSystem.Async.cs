namespace MediaDevices;

partial class MediaDevice
{
    public async Task DownloadFileAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFile(this, source, destination));
    }

    public async Task DownloadIconAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadIcon(this, source, destination));
    }

    public async Task DownloadThumbnailAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadThumbnail(this, source, destination));
    }

    public async Task DownloadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source);
        FileSystemPathCheck.ThrowIfInvalidPath(destination);
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.DownloadFolder(this, source, destination, recursive, ignoreExceptions));
    }

    public async Task UploadFileAsync(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.UploadFile(this, source, destination));
    }

    public async Task UploadFolderAsync(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        await mainWorker.InvokeAsync(() => ProtocolHandler.UploadFolder(this, source, destination, recursive, ignoreExceptions));
    }

}

