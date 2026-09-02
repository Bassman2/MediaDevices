namespace MediaDevices;

/// <summary>
/// Provides the base class for both MediaFileInfo and MediaDirectoryInfo objects.
/// </summary>
[DebuggerDisplay("{FullName}")]
public abstract partial class MediaFileSystemInfo
{
    internal static readonly ThreadSafeWorker worker = ThreadSafeWorker.Instance;
    internal readonly IDevice device;
    

    internal MediaFileSystemInfo(IDevice device, string objectId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.device = device;
        this.ObjectId = objectId;
        //this.item = item;

        //item.Refresh();
    }

    #region Properties

    /// <summary>
    /// Gets the parent directory of a specified subdirectory.
    /// </summary>
    protected MediaDirectoryInfo? ParentDirectoryInfo 
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(device);
            return worker.Invoke(() => device.GetParent(ObjectId));
        }
    }

    public string ObjectId { get; internal set; }

    /// <summary>
    /// Gets the full path of the directory or file.
    /// </summary>
    public string FullName { get; internal set; }

    /// <summary>
    /// For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// Gets the size, in bytes, of the current file.   
    /// </summary>
    public ulong Length { get; internal set; }

    /// <summary>
    /// Gets the creation time of the current file or directory.
    /// </summary>
    public DateTime? CreationTime { get; internal set; }
    //{
    //    get => this.item.DateCreated;
    //    set
    //    {
    //        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
    //        worker.Invoke(() => WpdDevice.SetCreationTime(this.item, value));
    //    }
    //}

    /// <summary>
    /// Gets the time when the current file or directory was last written to.
    /// </summary>
    public DateTime? LastWriteTime { get; internal set; }
    //{
    //    get => this.item.DateModified;
    //    set
    //    {
    //        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
    //        worker.Invoke(() => WpdDevice.SetLastWriteTime(this.item, value));
    //    }
    //}

    /// <summary>
    /// Gets the time when the current file was authored.
    /// </summary>
    public DateTime? DateAuthored { get; internal set; }
    //{
    //    get => this.item.DateAuthored;
    //    set
    //    {
    //        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
    //        worker.Invoke(() => WpdDevice.SetDateAuthored(this.item, value));
    //    }
    //}

    /// <summary>
    /// Gets the attributes for the current file, directory or object.
    /// </summary>
    public MediaFileAttributes Attributes { get; internal set; }


    /// <summary>
    /// Gets the persistent unique id of the MTP object.
    /// </summary>
    /// <remarks>
    /// A unique cross session object ID, that is not changing when mediaDevice is disconnected.
    /// </remarks>
    public string PersistentUniqueId { get; internal set; }

    #endregion

    #region Methods

    ///// <summary>
    ///// Refreshes the state of the object.
    ///// </summary>
    //public virtual void Refresh()
    //{
    //    NotConnectedException.ThrowIfNotConnected(device);
    //    worker.Invoke(() => device.Refresh(this.item));
    //}

    /// <summary>
    /// Rename the folder of file
    /// </summary>
    /// <param name="newName">New name of the file or folder.</param>
    public void Rename(string newName)
    {
        NotConnectedException.ThrowIfNotConnected(device);
        ArgumentException.ThrowIfNullOrWhiteSpace(newName, nameof(newName));
        worker.Invoke(() => device.Rename(this.item, newName));
    }

    #endregion

    #region object overrides

    /// <summary>
    /// Gets the hash code for the current object.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => ObjectId.GetHashCode();

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is MediaFileSystemInfo mfsi && mfsi.ObjectId == ObjectId;
    }

    #endregion
}
