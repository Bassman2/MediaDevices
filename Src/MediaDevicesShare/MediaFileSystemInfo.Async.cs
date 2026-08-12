namespace MediaDevices;

partial class MediaFileSystemInfo
{
    public async Task RenameAsync(string newName, CancellationToken cancellationToken = default)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        ArgumentException.ThrowIfNullOrWhiteSpace(newName, nameof(newName));
        await mainWorker.InvokeAsync (() => ProtocolHandler.Rename(this.item, newName), cancellationToken);
    }
}
