namespace MediaDevices;

/// <summary>
/// Provides properties for drives.
/// </summary>
[DebuggerDisplay("{DriveType}, {Name}, {VolumeLabel}")]
public sealed class MediaDriveInfo
{
    private readonly MediaDevice mediaDevice;
    private readonly ThreadSafeWorker mainWorker;
    private readonly string objectId;
    private readonly MediaStorageInfo? info;

    internal MediaDriveInfo(MediaDevice mediaDevice, string objectId)
    {
        this.mediaDevice = mediaDevice;
        this.mainWorker = mediaDevice.mainWorker;
        this.objectId = objectId;

        ThreadSafeWorkerException.ThrowIfNotInside();

        //this.info = mediaDevice.GetStorageInfo(objectId);
        this.info = ProtocolHandler.GetStorageInfo(mediaDevice, objectId);

        if (this.info != null)
        {
            this.TotalSize = (long)this.info.Capacity;
            this.TotalFreeSpace = this.AvailableFreeSpace = (long)this.info.FreeSpaceInBytes;

            this.DriveFormat = this.info.FileSystemType;

            this.DriveType = this.info.Type switch
            {
                StorageType.FixedRam or StorageType.FixedRom => DriveType.Fixed,
                StorageType.RemovableRam or StorageType.RemovableRom => DriveType.Removable,
                _ => DriveType.Unknown,
            };
            this.RootDirectory = new MediaDirectoryInfo(this.mediaDevice, Item.Create(this.mediaDevice, this.objectId));
            this.Name = this.RootDirectory.FullName;
            this.VolumeLabel = this.info.Description;
        }
    }

    /// <summary>
    /// Indicates the available space in bytes.
    /// </summary>
    public long AvailableFreeSpace { get; private set; }

    /// <summary>
    /// Format of the drive.
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
        this.mediaDevice.InternalEject(this.objectId);
    }

    /// <summary>
    /// Format the drive.
    /// </summary>
    public void Format()
    {
        this.mediaDevice.Format(this.objectId);
    }
}
