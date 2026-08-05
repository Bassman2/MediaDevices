namespace MediaDevices;

partial class MediaDevice
{
    public async Task FormatStorageAsync(string path)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));

        await mainWorker.InvokeAsync(() => ProtocolHandler.FormatPath(this, path));
    }
}
