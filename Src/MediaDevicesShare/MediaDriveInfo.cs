namespace MediaDevices;

/// <summary>
/// Provides properties for drives.
/// </summary>
[DebuggerDisplay("{DriveType}, {Name}, {VolumeLabel}")]
public sealed partial class MediaDriveInfo
{
    private static readonly ThreadSafeWorker worker = ThreadSafeWorker.Instance;
    private readonly IDevice device;
    private readonly string objectId;

    internal MediaDriveInfo(IDevice device, string objectId)
    {
        this.device = device;
        this.objectId = objectId;
       
        ThreadSafeWorkerException.ThrowIfNotInside();

        var info = device.GetStorageInfo(objectId);

        if (info != null)
        {
            this.TotalSize = (long)info.Capacity;
            this.TotalFreeSpace = this.AvailableFreeSpace = (long)info.FreeSpaceInBytes;

            this.DriveFormat = info.FileSystemType;

            this.DriveType = info.Type switch
            {
                StorageType.FixedRam or StorageType.FixedRom => DriveType.Fixed,
                StorageType.RemovableRam or StorageType.RemovableRom => DriveType.Removable,
                _ => DriveType.Unknown,
            };
            this.RootDirectory = new MediaDirectoryInfo(device, Item.Create(device, this.objectId));
            this.Name = this.RootDirectory.FullName;
            this.VolumeLabel = info.Description;
        }
    }

    /// <summary>
    /// Indicates the available space in bytes.
    /// </summary>
    public long AvailableFreeSpace { get; private set; }

    /// <summary>
    /// FormatId of the drive.
    /// </summary>
    public string? DriveFormat { get; private set; }

    /// <summary>
    /// Type of the drive
    /// </summary>
    public DriveType DriveType { get; private set; } = DriveType.Unknown;

    /// <summary>
    /// True is the drive is ready; false if not.
    /// </summary>
    public static bool IsReady => true;

    /// <summary>
    /// Name of the drive
    /// </summary>
    public string? Name { get; private set; }

    /// <summary>
    /// Get the root directory of the drive.
    /// </summary>
    public MediaDirectoryInfo? RootDirectory { get; private set; }

    /// <summary>
    /// Gets the total free space of the mediaDevice in bytes.
    /// </summary>
    public long TotalFreeSpace { get; private set; }

    /// <summary>
    /// Gets the total size of the mediaDevice in bytes.
    /// </summary>
    public long TotalSize { get; private set; }

    /// <summary>
    /// Get the volume lable of the drive.
    /// </summary>
    public string? VolumeLabel { get; private set; }

    /// <summary>
    /// Eject the drive.
    /// </summary>
    public void Eject()
    {
        NotConnectedException.ThrowIfNotConnected(device);
        worker.Invoke(() => device.EjectObjectId(objectId));
    }

    /// <summary>
    /// Format the drive.
    /// </summary>
    public void Format()    
    {
        NotConnectedException.ThrowIfNotConnected(device);
        worker.Invoke(() => device.FormatObjectId(objectId));
    }
}
