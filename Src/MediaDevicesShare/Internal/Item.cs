namespace MediaDevices.Internal;


[DebuggerDisplay("{this.Type} - {this.Name} - {this.Id}")]
internal class Item
{
    
    //static Item()
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

    

    public readonly MediaDevice mediaDevice;
    private string? name;
    private readonly string? path;
    private Item? parent;
    private static IPortableDeviceKeyCollection? keyCollection = null;

    private const uint PORTABLE_DEVICE_DELETE_NO_RECURSION = 0;
    private const uint PORTABLE_DEVICE_DELETE_WITH_RECURSION = 1;

    internal char DirectorySeparatorChar = '\\';

    private const int numObjectsToRequest = 32;

    public const string RootId = "DEVICE";



    public static Item GetRoot(MediaDevice device)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        return new Item(device, RootId, @"\");
    }

    public static Item Create(MediaDevice device, string id, string? path = null)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        return new Item(device, id, path);
    }

    public static Item? FindFolder(MediaDevice device, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = FindItem(device, path);
        return item == null || item.Type == ItemType.File ? null : item; 
    }

    public static Item? FindFile(MediaDevice device, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = FindItem(device, path);
        return item == null || item.Type != ItemType.File ? null : item;
    }

    public static Item? FindItem(MediaDevice device, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var item = Item.GetRoot(device);
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

    public static Item? GetFromPersistentUniqueId(MediaDevice device, string persistentUniqueId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        // fill collection with id to request
        //IPortableDevicePropVariantCollection collection = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>(ref CLSID.PortableDevicePropVariantCollection);

        int err = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>(ref CLSID.PortableDevicePropVariantCollection, out var collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection));


        using (var propVariantPUID = PropVariantFacade.StringToPropVariant(persistentUniqueId))
        {
            collection.Add(ref propVariantPUID.Value);
        }
        // request id collection           
        device.deviceContent!.GetObjectIDsFromPersistentUniqueIDs(collection, out IPortableDevicePropVariantCollection results);

        //var s = results.ToStrings().ToArray();
        //string? mediaObjectId = results.ToStrings().FirstOrDefault();

        uint count = 0;
        err = results.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        if (count == 0)
        {
            return null;
        }

        using PropVariantFacade val = new();
        err = results.GetAt(0, ref val.Value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
        
        // return result item
        return Item.Create(device, val.ToString());
        //return string.IsNullOrEmpty(mediaObjectId) ? null : Item.Create(mediaDevice, mediaObjectId);
    }

    private Item(MediaDevice device, string id, string? path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.mediaDevice = device;
        this.Id = id;
        this.path = path;

        if (id == Item.RootId)
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
    private Item(MediaDevice device, string id)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.mediaDevice = device;
        this.Id = id;
        if (id == Item.RootId)
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

        if (this.Id != Item.RootId)
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
        //ThreadSafeWorkerException.ThrowIfNotInside(mediaDevice.mainWorker);

        //var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>(ref CLSID.PortableDeviceKeyCollection);

        int err = ComHelper.CreateInstance<IPortableDeviceKeyCollection>(ref CLSID.PortableDeviceKeyCollection, out var keyCollection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceKeyCollection));


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
        int err = this.mediaDevice!.deviceProperties!.GetValues(this.Id, keyCollection, out IPortableDeviceValues values);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues), this);
        
        // read all properties
        // use a loop to prevent exceptions during calling GetValue for non existing values 
        uint num = 0;
        err = values.GetCount(ref num);
        if (err < 0)
        {
            Trace.TraceError($"COM Error: {ErrorCodes.GetErrorMessage(err)}");
            return;
        }
        for (uint i = 0; i < num; i++)
        {
            //var key = new PropertyKey();
            using var val = new PropVariantFacade();
            err = values.GetAt(i, ref val.Key, ref val.Value);
            if (err < 0)
            {
                Trace.TraceError($"COM Error: {ErrorCodes.GetErrorMessage(err)}");
                continue;
            }
            if (val.Key.fmtid == WPD.OBJECT_PROPERTIES_V1)
            {
                switch ((ObjectProperties)val.Key.pid)
                {
                case ObjectProperties.ContentType:
                    this.ContentType = val;
                    break;

                case ObjectProperties.Name:
                    this.name = val ?? string.Empty;
                    break;

                case ObjectProperties.OriginalFileName:
                    this.OriginalFileName = val;
                    break;

                case ObjectProperties.HintLocationDisplayName:
                    this.HintLocationName = val;
                    break;

                case ObjectProperties.ContainerFunctionalObjectId:
                    this.ParentContainerId = val;
                    break;

                case ObjectProperties.Size:
                    this.Size = val;
                    break;

                case ObjectProperties.DateCreated:
                    this.DateCreated = val;
                    break;

                case ObjectProperties.DateModified:
                    this.DateModified = val;
                    break;

                case ObjectProperties.DateAuthored:
                    this.DateAuthored = val;
                    break;

                case ObjectProperties.CanDelete:
                    this.CanDelete = val;
                    break;

                case ObjectProperties.IsSystem:
                    this.IsSystem = val.ToBool();
                    break;

                case ObjectProperties.IsHidden:
                    this.IsHidden = val;
                    break;

                case ObjectProperties.IsDrmProtected:
                    this.IsDRMProtected = val;
                    break;

                case ObjectProperties.ParentId:
                    this.ParentId = val;
                    break;

                case ObjectProperties.PersistentUniqueId:
                    this.PersistentUniqueId = val;
                    break;
                }
            }
        }
    }

    #region Value Properties

    public string Id { get; private set; } = string.Empty;
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

    public bool IsRoot => this.Id == RootId;

    public bool IsFile => this.Type == ItemType.File; 

    public Item? Parent
    {
        get
        {
            ThreadSafeWorkerException.ThrowIfNotInside();

            this.parent ??= string.IsNullOrEmpty(this.ParentId) ? null : new Item(this.mediaDevice, this.ParentId, Path.GetDirectoryName(Path.GetDirectoryName(this.FullName)));
            return this.parent;
        }
    }

    #endregion

    #region Methods

    public IEnumerable<Item> GetChildren()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err = this.mediaDevice!.deviceContent!.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs enumerator);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.EnumObjects));
        if (enumerator == null) 
        {
            Trace.WriteLine("IPortableDeviceContent.EnumObjects failed");
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
                Item? item = null;

                try
                {
                    item = Item.Create(this.mediaDevice, objectIds[index], this.FullName);
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

    public IEnumerable<Item> GetChildren(string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var regexPattern = FilterToRegex(searchPattern);

        int err = this.mediaDevice!.deviceContent!.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs enumerator);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.EnumObjects));
        if (enumerator == null) 
        {
            Trace.WriteLine("IPortableDeviceContent.EnumObjects failed");
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
                Item? item = null;

                try
                {
                    item = Item.Create(this.mediaDevice, objectIds[index], this.FullName);
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

    internal Item? CreateSubdirectory(string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? child = null;
        Item parent = this;
        var folders = path.Split([Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar], StringSplitOptions.RemoveEmptyEntries);
        foreach (var folder in folders)
        {
            child = parent.GetChildren().FirstOrDefault(i => EqualsName(i.Name, folder, mediaDevice.IsCaseSensitive));
            if (child == null)
            {
                // create a new directory
                // IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

                int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var deviceValues);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));

                deviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, parent.Id);
                deviceValues.SetStringValue(ref WPD.OBJECT_NAME, folder);
                deviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, folder);
                deviceValues.SetGuidValue(ref WPD.OBJECT_CONTENT_TYPE, ref WPD.CONTENT_TYPE_FOLDER);
                string id = string.Empty;
                try
                {
                    this.mediaDevice!.deviceContent!.CreateObjectWithPropertiesOnly(deviceValues, ref id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
                child = Item.Create(this.mediaDevice, id, parent.FullName);
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
                //new Item()

                // TODO
            }
            parent = child;
        }
        return child;
    }

    public void Delete(bool recursive = false)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        //IPortableDevicePropVariantCollection objectIdCollection = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>(ref CLSID.PortableDevicePropVariantCollection);

        int err = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>(ref CLSID.PortableDevicePropVariantCollection, out var objectIdCollection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection));


        var propVariantValue = PropVariantFacade.StringToPropVariant(this.Id);
        objectIdCollection.Add(ref propVariantValue.Value);

        //IPortableDevicePropVariantCollection results = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>(ref CLSID.PortableDevicePropVariantCollection);

        err = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>(ref CLSID.PortableDevicePropVariantCollection, out var results);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection));





        // TODO: get the results back and handle failures correctly

        this.mediaDevice.deviceContent!.Delete(recursive ? PORTABLE_DEVICE_DELETE_WITH_RECURSION : PORTABLE_DEVICE_DELETE_NO_RECURSION, objectIdCollection, ref results);

        ComTrace.WriteObjectIntern(objectIdCollection);
    }

    public string GetPath()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        if (this.Id == Item.RootId)
        {
            return @"\";
        }

        Item? item = this;
        var sb = new StringBuilder();
        do
        {
            // ++ TODO
            if (string.IsNullOrWhiteSpace(item.ParentId))
            {
                item = TryHandleNonHierarchicalStorage() ?? throw new Exception($"Problem occurred when trying to get full object path on mediaDevice {this.mediaDevice.FriendlyName}.");
            }

            // -- TODO

            sb.Insert(0, item.Name);
            sb.Insert(0, DirectorySeparatorChar);

        } while (!(item = new Item(this.mediaDevice, item.ParentId)).IsRoot);
        return sb.ToString();
    }

    // TODO

    /// <summary>
    /// Handles DCF storages specific for Apple iPhones.
    /// </summary>
    /// <returns></returns>
    private static Item? TryHandleNonHierarchicalStorage()
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
        // TODOO
        //var drives = this.mediaDevice.GetDrives();
        //var storageRoot = drives.FirstOrDefault(s => s.RootDirectory.Id == this.ParentContainerId);
        //if (storageRoot != null)
        //{
        //    return storageRoot.RootDirectory.item;
        //}

        return null;
    }

    internal Stream OpenRead()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err = this.mediaDevice.deviceContent!.Transfer(out IPortableDeviceResources resources);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.Transfer));
        
        uint optimalTransferSize = 0;

        err = resources.GetStream(this.Id, ref WPD.RESOURCE_DEFAULT, 0, ref optimalTransferSize, out var res);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceResources), nameof(IPortableDeviceResources.GetStream), Path.Combine(path!, name!));

        // TODO
        IStream wpdStream = (IStream)res;
        return new StreamWrapper(wpdStream, this.Size);
    }

    internal Stream OpenReadThumbnail()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.mediaDevice.deviceContent!.Transfer(out IPortableDeviceResources resources);

        uint optimalTransferSize = 0;

        int err = resources.GetStream(this.Id, ref WPD.RESOURCE_THUMBNAIL, 0, ref optimalTransferSize, out var res); // IStream wpdStream);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceResources), nameof(IPortableDeviceResources.GetStream));

        IStream wpdStream = (IStream)res;
        return new StreamWrapper(wpdStream, this.Size);
    }

    internal Stream OpenReadIcon()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.mediaDevice.deviceContent!.Transfer(out IPortableDeviceResources resources);

        uint optimalTransferSize = 0;

        int err = resources.GetStream(this.Id, ref WPD.RESOURCE_ICON, 0, ref optimalTransferSize, out var res);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceResources), nameof(IPortableDeviceResources.GetStream));

        IStream wpdStream = (IStream)res;
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceResources), nameof(IPortableDeviceResources.GetStream));

        return new StreamWrapper(wpdStream, this.Size);
    }

    internal void UploadFile(string fileName, Stream stream)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out IPortableDeviceValues portableDeviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));

        err = portableDeviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, this.Id);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "OBJECT_PARENT_ID");

        err = portableDeviceValues.SetUnsignedLargeIntegerValue(ref WPD.OBJECT_SIZE, (ulong)stream.Length);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedLargeIntegerValue), "OBJECT_SIZE");

        err = portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, fileName);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "OBJECT_ORIGINAL_FILE_NAME");

        err = portableDeviceValues.SetStringValue(ref WPD.OBJECT_NAME, fileName);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "OBJECT_NAME");
        
        // test
        using var now = PropVariantFacade.DateTimeToPropVariant(DateTime.Now);
        err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_CREATED, ref now.Value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_CREATED");
        err = portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_MODIFIED, ref now.Value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue), "OBJECT_DATE_MODIFIED");

        uint num = 0u;
        string text = string.Empty;
        err = this.mediaDevice.deviceContent!.CreateObjectWithPropertiesAndData(portableDeviceValues, out IStream wpdStream, ref num, ref text);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.CreateObjectWithPropertiesAndData));

        try
        {

            using var destinationStream = new StreamWrapper(wpdStream);
            stream.CopyTo(destinationStream);
            destinationStream.Flush();
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.ToString());
        }
    }

    internal bool Rename(string newName)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        //IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

        int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var portableDeviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));


        // with OBJECT_NAME does not work for Amazon Kindle Paperwhite
        portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, newName);
        this.mediaDevice.deviceProperties!.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
        ComTrace.WriteObjectIntern(result);
        
        if (result.TryGetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out string check))
        {
            if (check == "Error: S_OK")
            {
                // id can change on rename (e.g. Amazon Kindle Paperwhite) so find new one
                var newItem = this.parent!.GetChildren().FirstOrDefault(i => EqualsName(i.Name, newName, mediaDevice.IsCaseSensitive));
                this.Id = newItem!.Id;
                
                Refresh();
                return true;
            }
        }
        return false;
    }

    internal void SetDateCreated(DateTime value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        //IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);
        //new PortableDeviceValues() as IPortableDeviceValues;

        int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var portableDeviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));


        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_CREATED, ref val.Value);
            this.mediaDevice.deviceProperties!.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteObject(result);
        }

        Refresh();
    }

    internal void SetDateModified(DateTime value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        //IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

        int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var portableDeviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));


        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_MODIFIED, ref val.Value);
            this.mediaDevice.deviceProperties!.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteObject(result);
        }

        Refresh();
    }
    
    internal void SetDateAuthored(DateTime value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        //IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

        int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var portableDeviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));


        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_AUTHORED, ref val.Value);
            this.mediaDevice.deviceProperties!.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteObject(result);
        }

        Refresh();
    }

    #endregion

    #region private

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

