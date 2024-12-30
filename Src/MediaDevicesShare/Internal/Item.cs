namespace MediaDevices.Internal;


[DebuggerDisplay("{this.Type} - {this.Name} - {this.Id}")]
internal class Item
{
    private readonly static IPortableDeviceKeyCollection keyCollection;

    static Item()
    {
        // key collection with all used properties
        keyCollection = (IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();
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
    }

    private readonly MediaDevice device;
    private string name;
    private readonly string path;
    private Item? parent;

    private const uint PORTABLE_DEVICE_DELETE_NO_RECURSION = 0;
    private const uint PORTABLE_DEVICE_DELETE_WITH_RECURSION = 1;

    internal char DirectorySeparatorChar = '\\';

    private const int numObjectsToRequest = 32;

    public const string RootId = "DEVICE";
    
    public static Item GetRoot(MediaDevice device)
    {
        return new Item(device, RootId, @"\");
    }

    public static Item Create(MediaDevice device, string id, string path = null)
    {
        return new Item(device, id, path);
    }

    public static Item? FindFolder(MediaDevice device, string path)
    {
        var item = FindItem(device, path);
        return item == null || item.Type == ItemType.File ? null : item; ;
    }

    public static Item? FindFile(MediaDevice device, string path)
    {
        var item = FindItem(device, path);
        return item == null || item.Type != ItemType.File ? null : item;
    }

    public static Item? FindItem(MediaDevice device, string path)
    {
        var item = Item.GetRoot(device);
        if (path == @"\")
        {
            return item;
        }
        var folders = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var folder in folders)
        {
            item = item.GetChildren().FirstOrDefault(i => device.EqualsName(i.Name, folder));
            if (item == null)
            {
                return null;
            }
        }
        return item;
    }

    public static Item? GetFromPersistentUniqueId(MediaDevice device, string persistentUniqueId)
    {
        // fill collection with id to request
        var collection = (IPortableDevicePropVariantCollection)new PortableDevicePropVariantCollection();

        using (var propVariantPUID = PropVariantFacade.StringToPropVariant(persistentUniqueId))
        {
            collection.Add(ref propVariantPUID.Value);
        }
        // request id collection           
        device.deviceContent.GetObjectIDsFromPersistentUniqueIDs(collection, out IPortableDevicePropVariantCollection results);

        //var s = results.ToStrings().ToArray();
        string? mediaObjectId = results.ToStrings().FirstOrDefault();

        // return result item
        return mediaObjectId == null ? null : Item.Create(device, mediaObjectId);
        //return string.IsNullOrEmpty(mediaObjectId) ? null : Item.Create(device, mediaObjectId);
    }



    private Item(MediaDevice device, string id, string path)
    {
        this.device = device;
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
        this.device = device;
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
        if (this.Id != Item.RootId)
        {
            GetProperties();

            Guid contentType = this.ContentType;
            if (contentType == WPD.CONTENT_TYPE_FUNCTIONAL_OBJECT)
            {
                this.Name = this.name;
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
    
    private void GetProperties()
    {
        IPortableDeviceValues values;
        try
        {
            // get all predefined values
            this.device.deviceProperties.GetValues(this.Id, keyCollection, out values);
        }
        catch (Exception ex)
        {
            Trace.TraceError($"{ex.Message} for {this.Id}");
            return;
        }

        // read all properties
        // use a loop to prevent exceptions during calling GetValue for non existing values 
        uint num = 0;
        values.GetCount(ref num);
        for (uint i = 0; i < num; i++)
        {
            var key = new PropertyKey();
            using (var val = new PropVariantFacade())
            {
                values.GetAt(i, ref key, ref val.Value);

                if (key.fmtid == WPD.OBJECT_PROPERTIES_V1)
                {
                    switch ((ObjectProperties)key.pid)
                    {
                        case ObjectProperties.ContentType:
                            this.ContentType = val;
                            break;

                        case ObjectProperties.Name:
                            this.name = val;
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
    }

    #region Value Properties

    public string? Id { get; private set; }
    public string? Name { get; private set; }
    public string? FullName { get; set; }
    public ItemType Type { get; private set; }        
    public Guid ContentType { get; private set; }
    public string? OriginalFileName { get; private set; }
    public string? HintLocationName { get; private set; }
    public string? ParentContainerId { get; private set; }
    public ulong Size { get; private set; }
    public DateTime? DateCreated { get; private set; }
    public DateTime? DateModified { get; private set; }
    public DateTime? DateAuthored { get; private set; }
    public bool CanDelete { get; private set; }
    public bool IsSystem { get; private set; }
    public bool IsHidden { get; private set; }
    public bool IsDRMProtected { get; private set; }
    public string? ParentId { get; private set; }
    public string? PersistentUniqueId { get; private set; }

    public bool IsRoot { get { return this.Id == RootId; } }

    public bool IsFile { get { return this.Type == ItemType.File; } }

    public Item? Parent
    {
        get
        {
            this.parent ??= string.IsNullOrEmpty(ParentId) ? null : new Item(device, ParentId!, Path.GetDirectoryName(Path.GetDirectoryName(FullName))!);
            return this.parent;
        }
    }

#endregion

    #region Methods

    public IEnumerable<Item> GetChildren()
    {
        this.device.deviceContent.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs enumerator);
        if (enumerator == null) 
        {
            Trace.WriteLine("IPortableDeviceContent.EnumObjects failed");
            yield break;
        }

        uint fetched = 0;
        var objectIds = new string[numObjectsToRequest];
            enumerator.Next(numObjectsToRequest, objectIds, ref fetched);
        while (fetched > 0)
        {
            for (int index = 0; index < fetched; index++)
            {
                Item item = null;

                try
                {
                    item = Item.Create(this.device, objectIds[index], this.FullName);
                }
                catch (FileNotFoundException)
                {
                    // handle system files, that cannot be opened or read.
                    // Windows sometimes creates a fake files in e.g. System Volume Information.
                    // Let's handle such situations.
                }

                if (item != null)
                {
                    yield return item;
                }
            }
                enumerator.Next(numObjectsToRequest, objectIds, ref fetched);
            }
    }

    public IEnumerable<Item> GetChildren(string pattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        this.device.deviceContent.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs enumerator);
        if (enumerator == null) 
        {
            Trace.WriteLine("IPortableDeviceContent.EnumObjects failed");
            yield break; 
        }

        uint fetched = 0;
        var objectIds = new string[numObjectsToRequest];
        enumerator.Next(numObjectsToRequest, objectIds, ref fetched);
        while (fetched > 0)
        {
            for (int index = 0; index < fetched; index++)
            {
                Item item = null;

                try
                {
                    item = Item.Create(this.device, objectIds[index], this.FullName);
                }
                catch (FileNotFoundException)
                {
                    // handle system files, that cannot be opened or read.
                    // Windows sometimes creates a fake files in e.g.System Volume Information.
                    // Let's handle such situations.
                }

                if (item != null)
                {
                    if (pattern == null || (item.Name != null && Regex.IsMatch(item.Name, pattern, RegexOptions.IgnoreCase)))
                    {
                        yield return item;
                    }

                    if (searchOption == SearchOption.AllDirectories && item.Type != ItemType.File)
                    {
                        var children = item.GetChildren(pattern, searchOption);
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

    internal Item CreateSubdirectory(string path)
    {
        Item child = null;
        Item parent = this;
        var folders = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var folder in folders)
        {
            child = parent.GetChildren().FirstOrDefault(i => device.EqualsName(i.Name, folder));
            if (child == null)
            {
                // create a new directory
                IPortableDeviceValues deviceValues = (IPortableDeviceValues)new PortableDeviceValues();
                deviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, parent.Id);
                deviceValues.SetStringValue(ref WPD.OBJECT_NAME, folder);
                deviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, folder);
                deviceValues.SetGuidValue(ref WPD.OBJECT_CONTENT_TYPE, ref WPD.CONTENT_TYPE_FOLDER);
                string id = string.Empty;
                try
                {
                    this.device.deviceContent.CreateObjectWithPropertiesOnly(deviceValues, ref id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
                child = Item.Create(this.device, id, parent.FullName);
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
        var objectIdCollection = (IPortableDevicePropVariantCollection)new PortableDevicePropVariantCollection();

        var propVariantValue = PropVariantFacade.StringToPropVariant(this.Id);
        objectIdCollection.Add(ref propVariantValue.Value);

        IPortableDevicePropVariantCollection results = (IPortableDevicePropVariantCollection) new PortableDevicePropVariantCollection();
        // TODO: get the results back and handle failures correctly
        
        this.device.deviceContent.Delete(recursive ? PORTABLE_DEVICE_DELETE_WITH_RECURSION : PORTABLE_DEVICE_DELETE_NO_RECURSION, objectIdCollection, ref results);

        ComTrace.WriteObject(objectIdCollection);
    }

    public string GetPath()
    {
        if (this.Id == Item.RootId)
        {
            return @"\";
        }

        Item item = this;
        var sb = new StringBuilder();
        do
        {
            // ++ TODO
            if (string.IsNullOrWhiteSpace(item.ParentId))
            {
                item = TryHandleNonHierarchicalStorage();

                if (item == null)
                {
                    throw new Exception($"Problem occurred when trying to get full object path on device {this.device.FriendlyName}.");
                }
            }

            // -- TODO

            sb.Insert(0, item.Name);
            sb.Insert(0, DirectorySeparatorChar);

        } while (!(item = new Item(this.device, item.ParentId)).IsRoot);
        return sb.ToString();
    }

    // TODO

    /// <summary>
    /// Handles DCF storages specific for Apple iPhones.
    /// </summary>
    /// <returns></returns>
    private Item TryHandleNonHierarchicalStorage()
    {
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
        var drives = this.device.GetDrives();
        var storageRoot = drives.FirstOrDefault(s => s.RootDirectory.Id == this.ParentContainerId);
        if (storageRoot != null)
        {
            return storageRoot.RootDirectory.item;
        }
        
        return null;
    }

    internal Stream OpenRead()
    {
        this.device.deviceContent.Transfer(out IPortableDeviceResources resources);

        uint optimalTransferSize = 0;

        resources.GetStream(this.Id, ref WPD.RESOURCE_DEFAULT, 0, ref optimalTransferSize, out IStream wpdStream);

        return new StreamWrapper(wpdStream, this.Size);
    }

    internal Stream OpenReadThumbnail()
    {
        this.device.deviceContent.Transfer(out IPortableDeviceResources resources);

        uint optimalTransferSize = 0;

        resources.GetStream(this.Id, ref WPD.RESOURCE_THUMBNAIL, 0, ref optimalTransferSize, out IStream wpdStream);

        return new StreamWrapper(wpdStream, this.Size);
    }

    internal Stream OpenReadIcon()
    {
        this.device.deviceContent.Transfer(out IPortableDeviceResources resources);

        uint optimalTransferSize = 0;

        resources.GetStream(this.Id, ref WPD.RESOURCE_ICON, 0, ref optimalTransferSize, out IStream wpdStream);

        return new StreamWrapper(wpdStream, this.Size);
    }

    internal void UploadFile(string fileName, Stream stream)
    {

        IPortableDeviceValues portableDeviceValues = new PortableDeviceValues() as IPortableDeviceValues;

        portableDeviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, this.Id);
        portableDeviceValues.SetUnsignedLargeIntegerValue(ref WPD.OBJECT_SIZE, (ulong)stream.Length);
        portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, fileName);
        portableDeviceValues.SetStringValue(ref WPD.OBJECT_NAME, fileName);
        // test
        using (PropVariantFacade now = PropVariantFacade.DateTimeToPropVariant(DateTime.Now))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_CREATED, ref now.Value);
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_MODIFIED, ref now.Value);

            uint num = 0u;
            string text = null;
            this.device.deviceContent.CreateObjectWithPropertiesAndData(portableDeviceValues, out IStream wpdStream, ref num, ref text);

            using (var destinationStream = new StreamWrapper(wpdStream))
            {
                stream.CopyTo(destinationStream);
                destinationStream.Flush();
            }
        }
    }

    internal bool Rename(string newName)
    {
        IPortableDeviceValues portableDeviceValues = (IPortableDeviceValues)new PortableDeviceValues();

        // with OBJECT_NAME does not work for Amazon Kindle Paperwhite
        portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, newName);
        this.device.deviceProperties.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
        ComTrace.WriteObject(result);
        
        if (result.TryGetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out string check))
        {
            if (check == "Error: S_OK")
            {
                // id can change on rename (e.g. Amazon Kindle Paperwhite) so find new one
                var newItem = this.parent.GetChildren().FirstOrDefault(i => device.EqualsName(i.Name, newName));
                this.Id = newItem?.Id;
                
                Refresh();
                return true;
            }
        }
        return false;
    }

    internal void SetDateCreated(DateTime value)
    {
        IPortableDeviceValues portableDeviceValues = new PortableDeviceValues() as IPortableDeviceValues;

        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_CREATED, ref val.Value);
            this.device.deviceProperties.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteObject(result);
        }

        Refresh();
    }

    internal void SetDateModified(DateTime value)
    {
        IPortableDeviceValues portableDeviceValues = new PortableDeviceValues() as IPortableDeviceValues;

        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_MODIFIED, ref val.Value);
            this.device.deviceProperties.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteObject(result);
        }

        Refresh();
    }
    
    internal void SetDateAuthored(DateTime value)
    {
        IPortableDeviceValues portableDeviceValues = new PortableDeviceValues() as IPortableDeviceValues;

        using (PropVariantFacade val = PropVariantFacade.DateTimeToPropVariant(value))
        {
            portableDeviceValues.SetValue(ref WPD.OBJECT_DATE_AUTHORED, ref val.Value);
            this.device.deviceProperties.SetValues(this.Id, portableDeviceValues, out IPortableDeviceValues result);
            ComTrace.WriteObject(result);
        }

        Refresh();
    }

    #endregion
}

