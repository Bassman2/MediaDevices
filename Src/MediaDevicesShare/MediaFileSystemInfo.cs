namespace MediaDevices;

/// <summary>
/// Provides the base class for both MediaFileInfo and MediaDirectoryInfo objects.
/// </summary>
[DebuggerDisplay("{FullName}")]
public abstract partial class MediaFileSystemInfo
{
    /// <summary>
    ///corresponding MediaDevice instance
    /// </summary>
    protected MediaDevice mediaDevice;
    internal ThreadSafeWorker mainWorker;
    internal Item item;

    //private MediaDirectoryInfo? parent;

    internal MediaFileSystemInfo(MediaDevice device, Item item)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.mediaDevice = device;
        this.mainWorker = device.mainWorker;
        this.item = item;

        item.Refresh();
    }

    #region Properties

    /// <summary>
    /// Gets the parent directory of a specified subdirectory.
    /// </summary>
    protected MediaDirectoryInfo? ParentDirectoryInfo
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
            return mainWorker.Invoke(() => ProtocolHandler.GetParent(this.mediaDevice, this.item));
        }
    }

    /// <summary>
    /// Gets the full path of the directory or file.
    /// </summary>
    public string FullName => this.item.FullName;

    /// <summary>
    /// For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.
    /// </summary>
    public string Name => this.item.Name;

    /// <summary>
    /// Gets the size, in bytes, of the current file.   
    /// </summary>
    public ulong Length => this.item.Size;

    /// <summary>
    /// Gets the creation time of the current file or directory.
    /// </summary>
    public DateTime? CreationTime
    {
        get => this.item.DateCreated;
        set
        {
            NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
            mainWorker.Invoke(() => ProtocolHandler.SetCreationTime(this.item, value));
        }
    }

    /// <summary>
    /// Gets the time when the current file or directory was last written to.
    /// </summary>
    public DateTime? LastWriteTime
    {
        get => this.item.DateModified;
        set
        {
            NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
            mainWorker.Invoke(() => ProtocolHandler.SetLastWriteTime(this.item, value));
        }
    }

    /// <summary>
    /// Gets the time when the current file was authored.
    /// </summary>
    public DateTime? DateAuthored
    {
        get => this.item.DateAuthored;
        set
        {
            NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
            mainWorker.Invoke(() => ProtocolHandler.SetDateAuthored(this.item, value));
        }
    }

    /// <summary>
    /// Gets the attributes for the current file, directory or object.
    /// </summary>
    public MediaFileAttributes Attributes
    {
        get
        {
            MediaFileAttributes attributes = this.item.Type switch
            {
                ItemType.File => MediaFileAttributes.Normal,
                ItemType.Folder => MediaFileAttributes.Directory,
                _ => MediaFileAttributes.Object
            };
            attributes |= this.item.CanDelete ? MediaFileAttributes.CanDelete : 0;
            attributes |= this.item.IsSystem ? MediaFileAttributes.System : 0;
            attributes |= this.item.IsHidden ? MediaFileAttributes.Hidden : 0;
            attributes |= this.item.IsDRMProtected ? MediaFileAttributes.DRMProtected : 0;
            return attributes; 
        }
    }

    /// <summary>
    /// Gets the id of the MTP object.
    /// </summary>
    public string Id => this.item.Id;

    /// <summary>
    /// Gets the persistent unique id of the MTP object.
    /// </summary>
    /// <remarks>
    /// A unique cross session object ID, that is not changing when mediaDevice is disconnected.
    /// </remarks>
    public string PersistentUniqueId => this.item.PersistentUniqueId;

    #endregion

    #region Methods

    /// <summary>
    /// Refreshes the state of the object.
    /// </summary>
    public virtual void Refresh()
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        mainWorker.Invoke(() => ProtocolHandler.Refresh(this.item));
    }

    /// <summary>
    /// Rename the folder of file
    /// </summary>
    /// <param name="newName">New name of the file or folder.</param>
    public void Rename(string newName)
    {
        NotConnectedException.ThrowIfNotConnected(this.mediaDevice);
        ArgumentException.ThrowIfNullOrWhiteSpace(newName, nameof(newName));
        mainWorker.Invoke(() => ProtocolHandler.Rename(this.item, newName));
    }

    #endregion

    #region object overrides

    /// <summary>
    /// Gets the hash code for the current object.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => this.item.Id.GetHashCode();

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is MediaFileSystemInfo mfsi && mfsi.Id == this.Id;
    }

    #endregion
}
