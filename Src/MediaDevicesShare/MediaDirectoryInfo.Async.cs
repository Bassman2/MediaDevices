namespace MediaDevices;

partial class MediaDirectoryInfo
{
    public async Task<MediaDirectoryInfo> CreateSubdirectoryAsync(string path)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        return await mainWorker.InvokeAsync(() => ProtocolHandler.CreateSubdirectory(this.mediaDevice, item, path));
    }

    // TODO
    //public IAsyncEnumerable<MediaDirectoryInfo> EnumerateDirectoriesAsync()
    //{
    //    NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
    //    return mainWorker.InvokeAsyncEnumerable<MediaDirectoryInfo>(() => ProtocolHandler.EnumerateDirectories(this.mediaDevice, this.item));
    //}

    

}
