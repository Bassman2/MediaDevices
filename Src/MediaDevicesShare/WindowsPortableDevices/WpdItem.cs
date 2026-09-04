namespace MediaDevices.WindowsPortableDevices;


[DebuggerDisplay("{this.Type} - {this.Name} - {this.Id}")]
internal class WpdItem
{
    private const int OK = 0;
    //static WpdItem()
    //{
    //    // TODO must do inside main worker

    //    // key collection with all used properties
    //    keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>(ref CLSID.PortableDeviceKeyCollection);

    //    keyCollection.Add(ref WPD.OBJECT_CONTENT_TYPE);
    //    keyCollection.Add(ref WPD.OBJECT_NAME);
    //    keyCollection.Add(ref WPD.OBJECT_ORIGINAL_FILE_NAME);

    //    keyCollection.Add(ref WPD.OBJECT_HINT_LOCATION_DISPLAY_NAME);
    //    keyCollection.Add(ref WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID);
    //    keyCollection.Add(ref WPD.OBJECT_SIZE);
    //    keyCollection.Add(ref WPD.OBJECT_DATE_CREATED);
    //    keyCollection.Add(ref WPD.OBJECT_DATE_MODIFIED);
    //    keyCollection.Add(ref WPD.OBJECT_DATE_AUTHORED);
    //    keyCollection.Add(ref WPD.OBJECT_CAN_DELETE);
    //    keyCollection.Add(ref WPD.OBJECT_ISSYSTEM);
    //    keyCollection.Add(ref WPD.OBJECT_ISHIDDEN);
    //    keyCollection.Add(ref WPD.OBJECT_IS_DRM_PROTECTED);
    //    keyCollection.Add(ref WPD.OBJECT_PARENT_ID);
    //    keyCollection.Add(ref WPD.OBJECT_PERSISTENT_UNIQUE_ID);
    //}

   

    private readonly WpdDevice device;


    private string? name;
    private readonly string? path;
    private WpdItem? parent;
    private static IPortableDeviceKeyCollection? keyCollection = null;

    private const uint PORTABLE_DEVICE_DELETE_NO_RECURSION = 0;
    private const uint PORTABLE_DEVICE_DELETE_WITH_RECURSION = 1;

    internal char DirectorySeparatorChar = '\\';

    private const int numObjectsToRequest = 32;

    public const string RootId = "DEVICE";



    public static WpdItem GetRoot(WpdDevice device)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        return new WpdItem(device, ObjectId.Device, @"\");
    }

    public static WpdItem Create(WpdDevice device, ObjectId objectId, string? path = null)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return new WpdItem(device, objectId, path);
    }

    //public static WpdItem Create(WpdDevice device, string objectId, string? path = null)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    return new WpdItem(device, objectId, path);
    //}

    public static WpdItem? FindFolder(WpdDevice device, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = FindItem(device, path);
        return item == null || item.Type == ItemType.File ? null : item; 
    }

    public static WpdItem? FindFile(WpdDevice device, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = FindItem(device, path);
        return item == null || item.Type != ItemType.File ? null : item;
    }

    public static WpdItem? FindItem(WpdDevice device, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = WpdItem.GetRoot(device);
        if (path == @"\")
        {
            return item;
        }
        var folders = path.Split([Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar], StringSplitOptions.RemoveEmptyEntries);
        foreach (var folder in folders)
        {
            item = item.GetChildren().FirstOrDefault(i => EqualsName(i.Name, folder, device.IsCaseSensitive));
            if (item == null)
            {
                return null;
            }
        }
        return item;
    }

    public static WpdItem? GetFromPersistentUniqueId(WpdDevice device, string persistentUniqueId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var collection = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>();


        using (var propVariantPUID = PropVariantFacade.StringToPropVariant(persistentUniqueId))
        {
            collection.Add(ref propVariantPUID.Value);
        }
        // request id collection           
        device.deviceContent!.GetObjectIDsFromPersistentUniqueIDs(collection, out IPortableDevicePropVariantCollection results);

        uint count = 0;
        int err = results.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        if (count == 0)
        {
            return null;
        }

        using PropVariantFacade val = new();
        err = results.GetAt(0, ref val.Value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
        
        // return result item
        return WpdItem.Create(device, new ObjectId(val.ToString()));
        //return string.IsNullOrEmpty(mediaObjectId) ? null : WpdItem.Create(mediaDevice, mediaObjectId);
    }

    private WpdItem(WpdDevice device, ObjectId objectId, string? path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.device = device;
        this.ObjectId = objectId;
        this.path = path;

        if (objectId.WpdObjectId == WpdItem.RootId)
        {
            this.Name = @"\";
            this.FullName = @"\";
            this.Type = ItemType.Object;
        }
        else
        {
            Refresh();

            // find full name if no path
            if (string.IsNullOrEmpty(this.path))
            {
                string p = GetPath();
                this.path = Path.GetDirectoryName(p);
                this.FullName = p;
            }
        }
    }

    /// <summary>
    /// Special small constructor for GetPath.
    /// </summary>
    /// <param name="device"></param>
    /// <param name="id"></param>
    private WpdItem(WpdDevice device, ObjectId objectId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.device = device;
        this.ObjectId = objectId;
        if (objectId.IsDevice)
        {
            this.Name = @"\";
            this.FullName = @"\";
            this.Type = ItemType.Object;
        }
        else
        {
            Refresh();
        }
    }

    public void Refresh() 
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        if (!ObjectId.IsDevice)
        {
            GetProperties();

            Guid contentType = this.ContentType;
            if (contentType == WPD.CONTENT_TYPE_FUNCTIONAL_OBJECT)
            {
                this.Name = this.name ?? string.Empty;
                this.Type = ItemType.Object;

            }
            else if (contentType == WPD.CONTENT_TYPE_FOLDER)
            {
                this.Name = this.OriginalFileName;
                this.Type = ItemType.Folder;
            }
            else
            {
                this.Name = this.OriginalFileName;
                this.Type = ItemType.File;
            }
            if (this.path != null) // TODO check if we can remove empty pathes
            {
                // don't use Path.Combine
                this.FullName = this.path.TrimEnd(DirectorySeparatorChar) + DirectorySeparatorChar + this.Name;
            }
        }
    }

    private static IPortableDeviceKeyCollection CreateKeyCollection()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();

        keyCollection.Add(ref WPD.OBJECT_CONTENT_TYPE);
        keyCollection.Add(ref WPD.OBJECT_NAME);
        keyCollection.Add(ref WPD.OBJECT_ORIGINAL_FILE_NAME);

        keyCollection.Add(ref WPD.OBJECT_HINT_LOCATION_DISPLAY_NAME);
        keyCollection.Add(ref WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID);
        keyCollection.Add(ref WPD.OBJECT_SIZE);
        keyCollection.Add(ref WPD.OBJECT_DATE_CREATED);
        keyCollection.Add(ref WPD.OBJECT_DATE_MODIFIED);
        keyCollection.Add(ref WPD.OBJECT_DATE_AUTHORED);
        keyCollection.Add(ref WPD.OBJECT_CAN_DELETE);
        keyCollection.Add(ref WPD.OBJECT_ISSYSTEM);
        keyCollection.Add(ref WPD.OBJECT_ISHIDDEN);
        keyCollection.Add(ref WPD.OBJECT_IS_DRM_PROTECTED);
        keyCollection.Add(ref WPD.OBJECT_PARENT_ID);
        keyCollection.Add(ref WPD.OBJECT_PERSISTENT_UNIQUE_ID);
        return keyCollection;
    }

    private void GetProperties()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        keyCollection ??= CreateKeyCollection();

        // get all predefined values
        int err = device!.deviceProperties!.GetValues(ObjectId, keyCollection, out IPortableDeviceValues values);
        if (err == (int)ErrorCodes.InvalidParameter)
        {
            // some devices (e.g. Amazon Kindle Paperwhite) does not support GetValues with keyCollection
            // so we need to call GetValues with null keyCollection to get all values
            err = device.deviceProperties!.GetValues(ObjectId, null, out values);
        }
        if (err == (int)ErrorCodes.InvalidParameter)
        {
            throw new NotSupportedException($"The device {device.Description} does not support reading properties for item {this.Id}.");
        }
        if (err == (int)ErrorCodes.NotFound)
        {
            throw new FileNotFoundException($"The item {this.ObjectId} was not found on device {device.Description}.");
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues), this);


        if (values.GetGuidValue(ref WPD.OBJECT_CONTENT_TYPE, out var contentType) == OK)
        {
            this.ContentType = contentType; // contentType.FindContentTypeEnum();   
        }
        if (values.GetStringValue(ref WPD.OBJECT_NAME, out var name) == OK)
        {
            this.name  = name;
        }
        if (values.GetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, out var originalFileName) == OK)
        {
            OriginalFileName = originalFileName;
        }
        if (values.GetStringValue(ref WPD.OBJECT_HINT_LOCATION_DISPLAY_NAME, out var hintLocationName) == OK)
        {
            HintLocationName = hintLocationName;
        }
        if (values.GetStringValue(ref WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID, out var parentContainerId) == OK)
        {
            ParentContainerId = parentContainerId;
        }
        if (values.GetUnsignedLargeIntegerValue(ref WPD.OBJECT_SIZE, out var size) == OK)
        {
            Size = size;
        }
        if (values.GetDateTimeValue(ref WPD.OBJECT_DATE_CREATED, out var dateCreated) == OK)
        {
            DateCreated = dateCreated;
        }
        if (values.GetDateTimeValue(ref WPD.OBJECT_DATE_MODIFIED, out var dateModified) == OK)
        {
            DateModified = dateModified;
        }
        if (values.GetDateTimeValue(ref WPD.OBJECT_DATE_AUTHORED, out var dateAuthored) == OK)
        {
            DateAuthored = dateAuthored;
        }
        if (values.GetBoolValue(ref WPD.OBJECT_CAN_DELETE, out var canDelete) == OK)
        {
            CanDelete = canDelete != 0;
        }
        if (values.GetBoolValue(ref WPD.OBJECT_ISSYSTEM, out var isSystem) == OK)
        {
            IsSystem = isSystem != 0;
        }
        if (values.GetBoolValue(ref WPD.OBJECT_ISHIDDEN, out var isHidden) == OK)
        {
            IsHidden = isHidden != 0;
        }
        if (values.GetBoolValue(ref WPD.OBJECT_IS_DRM_PROTECTED, out var isDRMProtected) == OK)
        {
            IsDRMProtected = isDRMProtected != 0;
        }
        if (values.GetStringValue(ref WPD.OBJECT_PARENT_ID, out var parentId) == OK)
        {
            ParentId = parentId;
        }
        if (values.GetStringValue(ref WPD.OBJECT_PERSISTENT_UNIQUE_ID, out var persistentUniqueId) == OK)
        {
            PersistentUniqueId = persistentUniqueId;
        }
    }
       

    #region Value Properties

    public ObjectId ObjectId { get; private set; } = ObjectId.Device;
    public string Name { get; private set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public ItemType Type { get; private set; }        
    public Guid ContentType { get; private set; }
    public string OriginalFileName { get; private set; } = string.Empty;
    public string HintLocationName { get; private set; } = string.Empty;
    public string ParentContainerId { get; private set; } = string.Empty;
    public ulong Size { get; private set; }
    public DateTime? DateCreated { get; private set; }
    public DateTime? DateModified { get; private set; }
    public DateTime? DateAuthored { get; private set; }
    public bool CanDelete { get; private set; }
    public bool IsSystem { get; private set; }
    public bool IsHidden { get; private set; }
    public bool IsDRMProtected { get; private set; }
    public string ParentId { get; private set; } = string.Empty;
    public string PersistentUniqueId { get; private set; } = string.Empty;

    public bool IsRoot => this.ObjectId.IsDevice;

    public bool IsFile => this.Type == ItemType.File; 

    public WpdItem? Parent
    {
        get
        {
            ThreadSafeWorkerException.ThrowIfNotInside();

            this.parent ??= string.IsNullOrEmpty(this.ParentId) ? null : new WpdItem(device, this.ParentId, Path.GetDirectoryName(Path.GetDirectoryName(this.FullName)));
            return this.parent;
        }
    }

    #endregion

    #region Methods

    public IEnumerable<WpdItem> GetChildren()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err = device!.deviceContent!.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs enumerator);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.EnumObjects));
        if (enumerator == null) 
        {
            Debug.WriteLine("IPortableDeviceContent.EnumObjects failed");
            yield break;
        }

        // TODO: check if we can use a smaller number of objects to request, e.g. 1 or 10
        uint fetched = 0;
        var objectIds = new string[numObjectsToRequest];
        err = enumerator.Next(numObjectsToRequest, objectIds, ref fetched);
        MediaDeviceException.ThrowIfComError(err, nameof(IEnumPortableDeviceObjectIDs), nameof(IEnumPortableDeviceObjectIDs.Next));
        while (fetched > 0)
        {
            for (int index = 0; index < fetched; index++)
            {
                WpdItem? item = null;

                try
                {
                    item = WpdItem.Create(device, objectIds[index], this.FullName);
                }
                catch (FileNotFoundException)
                {
                    // handle system files, that cannot be opened or read.
                    // Windows sometimes creates a fake files in e.g. System Volume Information.
                    // Let's handle such situations.
                }
                catch (Exception)
                {

                }

                if (item != null)
                {
                    yield return item;
                }
            }
            enumerator.Next(numObjectsToRequest, objectIds, ref fetched);
        }
    }

    public IEnumerable<WpdItem> GetChildren(string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var regexPattern = FilterToRegex(searchPattern);

        int err = device!.deviceContent!.EnumObjects(0, ObjectId.WpdObjectId, null, out IEnumPortableDeviceObjectIDs enumerator);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.EnumObjects));
        if (enumerator == null) 
        {
            Debug.WriteLine("IPortableDeviceContent.EnumObjects failed");
            yield break; 
        }

        uint fetched = 0;
        var objectIds = new string[numObjectsToRequest];
        err = enumerator.Next(numObjectsToRequest, objectIds, ref fetched);
        MediaDeviceException.ThrowIfComError(err, nameof(IEnumPortableDeviceObjectIDs), nameof(IEnumPortableDeviceObjectIDs.Next));

        while (fetched > 0)
        {
            for (int index = 0; index < fetched; index++)
            {
                WpdItem? item = null;

                try
                {
                    item = WpdItem.Create(device, objectIds[index], this.FullName);
                }
                catch (FileNotFoundException)
                {
                    // handle system files, that cannot be opened or read.
                    // Windows sometimes creates a fake files in e.g.System Volume Information.
                    // Let's handle such situations.
                }

                if (item != null)
                {
                    if (regexPattern == null || (item.Name != null && Regex.IsMatch(item.Name, regexPattern, RegexOptions.IgnoreCase)))
                    {
                        yield return item;
                    }

                    if (searchOption == SearchOption.AllDirectories && item.Type != ItemType.File)
                    {
                        var children = item.GetChildren(searchPattern, searchOption);
                        foreach (var c in children)
                        {
                            yield return c;
                        }
                    }
                }
            }
            enumerator.Next(numObjectsToRequest, objectIds, ref fetched);
        }
    }

    internal WpdItem? CreateSubdirectory(string path, DateTime dateCreated, DateTime dateModified, DateTime dateAuthored)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        WpdItem? child = null;
        WpdItem parent = this;
        var folders = path.Split([Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar], StringSplitOptions.RemoveEmptyEntries);
        foreach (var folder in folders)
        {
            child = parent.GetChildren().FirstOrDefault(i => EqualsName(i.Name, folder, device.IsCaseSensitive));
            if (child == null)
            {
                // create a new directory
                IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

                portableDeviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, parent.Id);
                portableDeviceValues.SetStringValue(ref WPD.OBJECT_NAME, folder);
                portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, folder);
                portableDeviceValues.SetGuidValue(ref WPD.OBJECT_CONTENT_TYPE, ref WPD.CONTENT_TYPE_FOLDER);

                int err;
                using (var facade = PropVariantFacade.DateTimeToPropVariant(dateCreated))
                {
                    err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_CREATED, ref facade.Value);
                    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_CREATED");
                }

                using (var facade = PropVariantFacade.DateTimeToPropVariant(dateModified))
                {
                    err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_MODIFIED, ref facade.Value);
                    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_MODIFIED");
                }

                using (var facade = PropVariantFacade.DateTimeToPropVariant(dateAuthored))
                {
                    err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_AUTHORED, ref facade.Value);
                    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_AUTHORED");
                }

                string id = string.Empty;
                try
                {
                    device!.deviceContent!.CreateObjectWithPropertiesOnly(portableDeviceValues, ref id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
                child = WpdItem.Create(device, id, parent.FullName);
            }
            else if (child.Type == ItemType.File)
            {
                // folder is already a file
                throw new Exception($"A path of the path {folder} is a file");
            }
            else
            {
                // folder exists
                //id = child.Id;
                //new WpdItem()

                // TODO
            }
            parent = child;
        }
        return child;
    }

    public void Delete(bool recursive = false)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var objectIdCollection = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>();

        var propVariantValue = PropVariantFacade.StringToPropVariant(this.Id);
        int err = objectIdCollection.Add(ref propVariantValue.Value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.Add));

        var results = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>();

        // TODO: get the results back and handle failures correctly

        err = device.deviceContent!.Delete(recursive ? PORTABLE_DEVICE_DELETE_WITH_RECURSION : PORTABLE_DEVICE_DELETE_NO_RECURSION, objectIdCollection, ref results);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.Delete));

        // fix for issue #420
        if (err == (int)ErrorCodes.False)
        {
            throw new IOException($"Failed to delete file {Name}!");
        }

        //ComTrace.WriteObjectIntern(objectIdCollection);
    }

    public string GetPath()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        if (this.Id == WpdItem.RootId)
        {
            return @"\";
        }

        WpdItem? item = this;
        var sb = new StringBuilder();
        do
        {
            // ++ TODO
            if (string.IsNullOrWhiteSpace(item.ParentId))
            {
                item = TryHandleNonHierarchicalStorage() ?? throw new Exception($"Problem occurred when trying to get full object path on mediaDevice {this.mediaDevice.Description}.");
            }

            // -- TODO

            sb.Insert(0, item.Name);
            sb.Insert(0, DirectorySeparatorChar);

        } while (!(item = new WpdItem(device, item.ParentId)).IsRoot);
        return sb.ToString();
    }

    // TODO

    /// <summary>
    /// Handles DCF storages specific for Apple iPhones.
    /// </summary>
    /// <returns></returns>
    private WpdItem? TryHandleNonHierarchicalStorage()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        // EXPLANATION
        // Some MTP compatible devices uses different storage formats that Generic
        // Hierarchical storage like WP, Android. Good examples are Apple devices,
        // which are using DCF storage. The specific in that storage is a way how
        // directories handles parent object ID. If in Generic Hierarchical storage
        // we check parent ID of root directory, it contains an ID of functional storage
        // so that means storage ID. In DCF when we check parent ID of root object
        // it will have object ID, not storage ID, e.g. parent id is o10001 (object10001),
        // but storage has ID = s10001 (storage10001). So to find a parent of top most folder
        // we need to fetch an object functional container ID. Which is storage for top most
        // directory.
        
        // TODO
        //var drives = WpdDevice.GetDrives(device);
        //var storageRoot = drives.FirstOrDefault(s => s.RootDirectory!.Id == this.ParentContainerId);
        //if (storageRoot != null)
        //{
        //    return storageRoot.RootDirectory!.item;
        //}

        return null;
    }

    internal Stream OpenRead()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err = device.deviceContent!.Transfer(out IPortableDeviceResources resources);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.Transfer));

        // Fix for Apple problem
        // Explicit GC call to immediately destroy the generated COM wrappers.
        GC.Collect();
        GC.WaitForPendingFinalizers();
        // Allow the Apple driver time to physically close the channel.
        System.Threading.Thread.Sleep(20);

        uint optimalTransferSize = 0; 
        err = resources.GetStream(ObjectId.WpdObjectId, ref WPD.RESOURCE_DEFAULT, 0, ref optimalTransferSize, out var iStream);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceResources), nameof(IPortableDeviceResources.GetStream), Path.Combine(path ?? "empty", name ?? "empty"));

        return new StreamWrapper(iStream, this.Size);
    }

    internal Stream OpenReadThumbnail()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        device.deviceContent!.Transfer(out IPortableDeviceResources resources);

        uint optimalTransferSize = 0;

        int err = resources.GetStream(ObjectId.WpdObjectId, ref WPD.RESOURCE_THUMBNAIL, 0, ref optimalTransferSize, out var iStream); 
        if (err == (int)ErrorCodes.ResourceNotAvailable)
        {
            throw new NotSupportedException($"The device {device.Description} does not support reading thumbnails.");
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceResources), nameof(IPortableDeviceResources.GetStream));
                
        return new StreamWrapper(iStream, this.Size);
    }

    internal Stream OpenReadIcon()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        device.deviceContent!.Transfer(out IPortableDeviceResources resources);

        uint optimalTransferSize = 0;

        int err = resources.GetStream(ObjectId.WpdObjectId, ref WPD.RESOURCE_ICON, 0, ref optimalTransferSize, out var iStream);
        if (err == (int)ErrorCodes.ResourceNotAvailable)
        {
            throw new NotSupportedException($"The device {device.Description} does not support reading icons.");
        }
        if (err == (int)ErrorCodes.InvalidParameter)
        {
            throw new NotSupportedException($"The device {device.Description} does not support reading icons.");
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceResources), nameof(IPortableDeviceResources.GetStream));

        return new StreamWrapper(iStream, this.Size);
    }

    internal void UploadFile(string fileName, Stream stream, DateTime dateCreated, DateTime dateModified, DateTime dateAuthored)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        int err = portableDeviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, ObjectId.WpdObjectId);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "OBJECT_PARENT_ID");

        err = portableDeviceValues.SetUnsignedLargeIntegerValue(ref WPD.OBJECT_SIZE, (ulong)stream.Length);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedLargeIntegerValue), "OBJECT_SIZE");

        err = portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, fileName);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "OBJECT_ORIGINAL_FILE_NAME");

        err = portableDeviceValues.SetStringValue(ref WPD.OBJECT_NAME, fileName);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "OBJECT_NAME");

        using (var facade = PropVariantFacade.DateTimeToPropVariant(dateCreated))
        {
            err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_CREATED, ref facade.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_CREATED");
        }

        using (var facade = PropVariantFacade.DateTimeToPropVariant(dateModified))
        {
            err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_MODIFIED, ref facade.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_MODIFIED");
        }

        using (var facade = PropVariantFacade.DateTimeToPropVariant(dateAuthored))
        {
            err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_AUTHORED, ref facade.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_AUTHORED");
        }


        uint num = 0u;
        string text = string.Empty;
        err = device.deviceContent!.CreateObjectWithPropertiesAndData(portableDeviceValues, out var iStream, ref num, ref text);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.CreateObjectWithPropertiesAndData));
        
        using var destinationStream = new StreamWrapper(iStream);
        stream.CopyTo(destinationStream);
        destinationStream.Flush();
    }

    internal bool Rename(string newName)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        // with OBJECT_NAME does not work for Amazon Kindle Paperwhite
        int err = portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, newName);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "OBJECT_ORIGINAL_FILE_NAME");

        err = device.deviceProperties!.SetValues(ObjectId.WpdObjectId, portableDeviceValues, out IPortableDeviceValues result);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        err = result.GetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, out string check);
        if (err == OK && check == "Error: S_OK")
        {
            // id can change on rename (e.g. Amazon Kindle Paperwhite) so find new one
            var newItem = this.parent!.GetChildren().FirstOrDefault(i => EqualsName(i.Name, newName, device.IsCaseSensitive));
            this.ObjectId = newItem!.ObjectId;

            Refresh();
            return true;
        }
        return false;
    }

    internal void SetDateCreated(DateTime value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_CREATED, ref val.Value);
            device.deviceProperties!.SetValues(ObjectId.WpdObjectId, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteValues(result);
        }

        Refresh();
    }

    internal void SetDateModified(DateTime value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_MODIFIED, ref val.Value);
            device.deviceProperties!.SetValues(ObjectId.WpdObjectId, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteValues(result);
        }

        Refresh();
    }
    
    internal void SetDateAuthored(DateTime value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_AUTHORED, ref val.Value);
            device.deviceProperties!.SetValues(ObjectId.WpdObjectId, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteValues(result);
        }

        Refresh();
    }

    public MediaDriveInfo ToMediaDriveInfo()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        return new MediaDriveInfo(device, ObjectId)
        {
            //FullName = this.FullName,
            //Name = this.Name,
            //Length = this.Size,
            //CreationTime = this.DateCreated,
            //LastWriteTime = this.DateModified,
            //DateAuthored = this.DateAuthored,
            //Attributes = GetAttributes(),
            //PersistentUniqueId = this.PersistentUniqueId
        };
    }

    public MediaFileInfo ToFileInfo()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        return new MediaFileInfo(device, ObjectId)
        {
            FullName = this.FullName,
            Name = this.Name,
            Length = this.Size,
            CreationTime = this.DateCreated,
            LastWriteTime = this.DateModified,
            DateAuthored = this.DateAuthored,
            Attributes = GetAttributes(),
            PersistentUniqueId = this.PersistentUniqueId
        };
    }
    public MediaDirectoryInfo ToDirectoryInfo()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        return new MediaDirectoryInfo(device, ObjectId)
        {
            ObjectId = this.ObjectId,
            FullName = this.FullName,
            Name = this.Name,
            Length = this.Size,
            CreationTime = this.DateCreated,
            LastWriteTime = this.DateModified,
            DateAuthored = this.DateAuthored,
            Attributes = GetAttributes(),
            PersistentUniqueId = this.PersistentUniqueId
        };
    }

    public MediaFileSystemInfo ToFileSystemInfo()
    {
        return Type == ItemType.File ? ToFileInfo() : ToDirectoryInfo();
    }



    #endregion

    #region private

    private MediaFileAttributes GetAttributes()
    {
        MediaFileAttributes attributes = Type switch
        {
            ItemType.File => MediaFileAttributes.Normal,
            ItemType.Folder => MediaFileAttributes.Directory,
            _ => MediaFileAttributes.Object
        };
        attributes |= CanDelete ? MediaFileAttributes.CanDelete : 0;
        attributes |= IsSystem ? MediaFileAttributes.System : 0;
        attributes |= IsHidden ? MediaFileAttributes.Hidden : 0;
        attributes |= IsDRMProtected ? MediaFileAttributes.DRMProtected : 0;
        return attributes;
    }

    private static bool EqualsName(string a, string b, bool isCaseSensitive)
    {
        return isCaseSensitive ? a == b : string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }

    private static string? FilterToRegex(string? filter)
    {
        if (filter == null || filter == "*" || filter == "*.*")
        {
            return null;
        }

        StringBuilder s = new(filter);
        s.Replace(".", @"\.");
        s.Replace("+", @"\+");
        s.Replace("$", @"\$");
        s.Replace("(", @"\(");
        s.Replace(")", @"\)");
        s.Replace("[", @"\[");
        s.Replace("]", @"\]");
        s.Replace("?", ".?");
        s.Replace("*", ".*");
        return s.ToString();
    }

    #endregion
}

