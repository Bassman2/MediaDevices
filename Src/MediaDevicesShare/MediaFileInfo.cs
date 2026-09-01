namespace MediaDevices;

/// <summary>
/// Provides properties for files, directories and objects.
/// </summary>
public partial class MediaFileInfo : MediaFileSystemInfo
{
    internal MediaFileInfo(IDevice device, string objectId) : base(device, objectId)
    { }

    /// <summary>
    /// Refreshes the state of the object.
    /// </summary>
    public override void Refresh() => base.Refresh();
    
    /// <summary>
    /// Gets an instance of the parent directory.
    /// </summary>
    public MediaDirectoryInfo? Directory => base.ParentDirectoryInfo;

    /// <summary>
    /// Copies an existing file to a new file, allowing the overwriting of the existing file.
    /// </summary>
    /// <param name="destFileName">The name of the new file to copy to.</param>
    /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false. </param>
    /// <exception cref="System.IO.IOException">An error occurs, or the destination file already exists and overwrite is false. </exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void CopyTo(string destFileName, bool overwrite = true)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        worker.Invoke(() => device.CopyTo(objectId, destFileName, overwrite));
    }

    /// <summary>
    /// Copies an icon of an existing file to a new file, allowing the overwriting of the existing file.
    /// </summary>
    /// <param name="destFileName">The name of the new file to copy to.</param>
    /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false. </param>
    /// <exception cref="System.IO.IOException">An error occurs, or the destination file already exists and overwrite is false. </exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void CopyIconTo(string destFileName, bool overwrite = true)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        worker.Invoke(() => device.CopyIconTo(objectId, destFileName, overwrite));
    }

    /// <summary>
    /// Copies an thumbnail of an existing file to a new file, allowing the overwriting of the existing file.
    /// </summary>
    /// <param name="destFileName">The name of the new file to copy to.</param>
    /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false. </param>
    /// <exception cref="System.IO.IOException">An error occurs, or the destination file already exists and overwrite is false. </exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void CopyThumbnailTo(string destFileName, bool overwrite = true)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        worker.Invoke(() => device.CopyThumbnailTo(objectId, destFileName, overwrite));
    }

    /// <summary>
    /// Creates a read-only FileStream.
    /// </summary>
    /// <returns>A new read-only FileStream object.</returns>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public Stream OpenRead()
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.Invoke(() => device.OpenRead(objectId));
    }

    /// <summary>
    /// Creates a read-only FileStream of the icon.
    /// </summary>
    /// <returns>A new read-only FileStream object.</returns>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public Stream OpenIcon()
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.Invoke(() => device.OpenIcon(objectId));
    }

    /// <summary>
    /// Creates a read-only FileStream of the thumbnail.
    /// </summary>
    /// <returns>A new read-only FileStream object.</returns>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public Stream OpenThumbnail()
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.Invoke(() => device.OpenThumbnail(objectId));
    }

    /// <summary>
    /// Creates a StreamReader with UTF8 encoding that reads from an existing text file.
    /// </summary>
    /// <returns>A new StreamReader with UTF8 encoding.</returns>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public StreamReader OpenText()
    {
        NotConnectedException.ThrowIfNotConnected(device);
        return worker.Invoke(() => device.OpenText(objectId));
    }
}
