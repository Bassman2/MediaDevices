using System.Diagnostics;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using PortableDeviceApiLib;
using PortableDeviceTypesLib;
using IPortableDeviceKeyCollection = PortableDeviceApiLib.IPortableDeviceKeyCollection;
using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;
using IPortableDevicePropVariantCollection = PortableDeviceApiLib.IPortableDevicePropVariantCollection;
//using PropertyKey = PortableDeviceApiLib._tagpropertykey;
//using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
//using MediaDevices.Internal;
//using System.Reflection;
using System.Text;

namespace MediaDevices.Internal
{

    [DebuggerDisplay("{this.Type} - {this.Name} - {this.Id}")]
    internal class Item
    {
        private MediaDevice device;
        private IPortableDeviceProperties deviceProperties;
        private IPortableDeviceKeyCollection keyCollection;
        private IPortableDeviceValues values;
        private string path;
        private Item parent;

        private const uint PORTABLE_DEVICE_DELETE_NO_RECURSION = 0;
        private const uint PORTABLE_DEVICE_DELETE_WITH_RECURSION = 1;

        internal char DirectorySeparatorChar = '\\';

        public const string RootId = "DEVICE";
        
        public static Item GetRoot(MediaDevice device)
        {
            return new Item(device, RootId, @"\");
        }

        public static Item Create(MediaDevice device, string id, string path = null)
        {
            return new Item(device, id, path);
        }

        public static Item FindFolder(MediaDevice device, string path)
        {
            var item = FindItem(device, path);
            return item == null || item.Type == ItemType.File ? null : item; ;
        }

        public static Item FindFile(MediaDevice device, string path)
        {
            var item = FindItem(device, path);
            return item == null || item.Type != ItemType.File ? null : item;
        }

        public static Item FindItem(MediaDevice device, string path)
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

        public static Item GetFromPersistentUniqueId(MediaDevice device, string persistentUniqueId)
        {
            var propVariantPUID = PropVariant.StringToPropVariant(persistentUniqueId);
            var collection = (IPortableDevicePropVariantCollection)new PortableDevicePropVariantCollection();
            collection.Add(ref propVariantPUID);

            Command cmd = Command.Create(WPD.COMMAND_COMMON_GET_OBJECT_IDS_FROM_PERSISTENT_UNIQUE_IDS);
            cmd.Add(WPD.PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS, collection);
            cmd.Send(device.device);
            string mediaObjectId = cmd.GetPropVariants(WPD.PROPERTY_COMMON_OBJECT_IDS).Select(c => c.ToString()).FirstOrDefault();

            return mediaObjectId == null ? null : Item.Create(device, mediaObjectId);
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public ItemType Type { get; private set; }

        public bool IsRoot { get { return this.Id == RootId; } }

        public bool IsFile { get { return this.Type == ItemType.File; } }

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
                this.deviceProperties = device.deviceProperties;
                this.deviceProperties.GetSupportedProperties(id, out keyCollection);
                //ComTrace.WriteObject(this.deviceProperties, id);
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
                this.deviceProperties = device.deviceProperties;
                this.deviceProperties.GetSupportedProperties(id, out keyCollection);
                //ComTrace.WriteObject(this.deviceProperties, id);
                Refresh();
            }
        }

        public void Refresh() 
        {
            if (this.Id != Item.RootId)
            {
                this.deviceProperties.GetValues(this.Id, this.keyCollection, out this.values);
                
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
                    this.FullName = Path.Combine(this.path, this.Name);
                }

                // TODO test
                if (this.values.TryGetStringValue(WPD.OBJECT_HINT_LOCATION_DISPLAY_NAME, out string value))
                {
                    Trace.TraceInformation($"Refresh OBJECT_HINT_LOCATION_DISPLAY_NAME = {value}");
                }
            }
        }

        #region Value Properties

        public Guid ContentType
        {
            get
            {
                this.values.TryGetGuidValue(WPD.OBJECT_CONTENT_TYPE, out Guid value);
                return value;
            }
        }

        public string name
        {
            get
            {
                this.values.TryGetStringValue(WPD.OBJECT_NAME, out string value);
                return value;
            }
        }

        // TODO ??? currently not use

        /// <summary>
        /// Gets the hint-specific name to display to the user instead of the object name, only if an object is a hint location.
        /// </summary>
        /// <remarks>
        /// Drivers can specify location hints for various object types.
        /// These are preferred storage locations for folders that hold
        /// a particular object type. An equivalent would be the My Pictures
        /// folder for image files in Windows. If this property does not exist,
        /// typically the <see cref="Name"/> is used instead.
        /// </remarks>
        public string HintLocationName
        {
            get
            {
                this.values.TryGetStringValue(WPD.OBJECT_HINT_LOCATION_DISPLAY_NAME, out string value);
                return value;
            }
        }

        // TODO

        /// <summary>
        /// Gets the object ID of the closest functional object that contains this object.
        /// </summary>
        /// <remarks>For example, a file inside a storage functional object will have 
        /// this property set to the ID of the storage functional object.
        /// </remarks>
        public string ParentContainerId
        {
            get
            {
                this.values.TryGetStringValue(WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID, out string value);
                return value;
            }
        }        

        public string OriginalFileName
        {
            get
            {
                this.values.TryGetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out string value);
                return value;
            }
        }

        public ulong Size
        {
            get
            {
                this.values.TryGetUnsignedLargeIntegerValue(WPD.OBJECT_SIZE, out ulong value);
                return value;
            }
        }

        public DateTime? DateCreated
        {
            get
            {
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_CREATED, out DateTime? value);
                return value;
            }
        }

        public DateTime? DateModified
        {
            get
            {
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_MODIFIED, out DateTime? value);
                return value;
            }
        }

        public DateTime? DateAuthored
        {
            get
            {
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_AUTHORED, out DateTime? value);
                return value;
            }
        }

        public bool CanDelete
        {
            get
            {
                this.values.TryGetBoolValue(WPD.OBJECT_CAN_DELETE, out bool value);
                return value;
            }
        }

        public bool IsSystem
        {
            get
            {
                this.values.TryGetBoolValue(WPD.OBJECT_ISSYSTEM, out bool value);
                return value;
            }
        }

        public bool IsHidden
        {
            get
            {
                this.values.TryGetBoolValue(WPD.OBJECT_ISHIDDEN, out bool value);
                return value;
            }
        }

        public bool IsDRMProtected
        {
            get
            {
                this.values.TryGetBoolValue(WPD.OBJECT_IS_DRM_PROTECTED, out bool value);
                return value;
            }
        }

        public string ParentId
        {
            get
            {
                this.values.TryGetStringValue(WPD.OBJECT_PARENT_ID, out string value);
                return value;
            }
        }

        public string PersistentUniqueId
        {
            get
            {
                this.values.TryGetStringValue(WPD.OBJECT_PERSISTENT_UNIQUE_ID, out string value);
                return value;
            }
        }

        public Item Parent
        {
            get
            {
                if (this.parent == null)
                {
                    this.parent = string.IsNullOrEmpty(this.ParentId) ? null : new Item(this.device, this.ParentId, Path.GetDirectoryName(Path.GetDirectoryName(this.FullName)));
                }
                return this.parent;
            }
        }

        #endregion

        #region Methods

        public IEnumerable<Item> GetChildren()
        {
            this.device.deviceContent.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs objectIds);
            if (objectIds == null) 
            {
                Trace.WriteLine("IPortableDeviceContent.EnumObjects failed");
                yield break;
            }

            uint fetched = 0;
            objectIds.Next(1, out string objectId, ref fetched);
            while (fetched > 0)
            {
                Item item = null;

                try
                {
                    item = Item.Create(this.device, objectId, this.FullName);
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

                objectIds.Next(1, out objectId, ref fetched);
            }
        }

        public IEnumerable<Item> GetChildren(string pattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            this.device.deviceContent.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs objectIds);
            if (objectIds == null) 
            {
                Trace.WriteLine("IPortableDeviceContent.EnumObjects failed");
                yield break; 
            }

            uint fetched = 0;
            objectIds.Next(1, out string objectId, ref fetched);
            while (fetched > 0)
            {
                Item item = null;

                try
                {
                    item = Item.Create(this.device, objectId, this.FullName);
                }
                catch (FileNotFoundException)
                {
                    // handle system files, that cannot be opened or read.
                    // Windows sometimes creates a fake files in e.g. System Volume Information.
                    // Let's handle such situations.
                }

                if (item != null)
                {
                    if (pattern == null || Regex.IsMatch(item.Name, pattern, RegexOptions.IgnoreCase))
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

                objectIds.Next(1, out objectId, ref fetched);
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
                    this.device.deviceContent.CreateObjectWithPropertiesOnly(deviceValues, ref id);
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
            var objectIdCollection = (IPortableDevicePropVariantCollection)new PortableDeviceTypesLib.PortableDevicePropVariantCollection();

            var propVariantValue = PropVariant.StringToPropVariant(this.Id);
            objectIdCollection.Add(ref propVariantValue);

            IPortableDevicePropVariantCollection results = (PortableDeviceApiLib.IPortableDevicePropVariantCollection) new PortableDevicePropVariantCollection();
            // TODO: get the results back and handle failures correctly
            this.device.deviceContent.Delete(recursive ? PORTABLE_DEVICE_DELETE_WITH_RECURSION : PORTABLE_DEVICE_DELETE_NO_RECURSION, objectIdCollection, null);

            ComTrace.WriteObject(objectIdCollection);
        }

        public string GetPath()
        {
            if (this.Id == Item.RootId)
            {
                return @"\";
            }

            Item item = this;
            StringBuilder sb = new StringBuilder();
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

            PortableDeviceApiLib.IStream wpdStream;
            uint optimalTransferSize = 0;

            resources.GetStream(this.Id, ref WPD.RESOURCE_DEFAULT, 0, ref optimalTransferSize, out wpdStream);

            return new StreamWrapper(wpdStream);
        }

        internal void UploadFile(string fileName, Stream stream)
        {

            IPortableDeviceValues portableDeviceValues = new PortableDeviceValues() as IPortableDeviceValues;

            portableDeviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, this.Id);
            portableDeviceValues.SetUnsignedLargeIntegerValue(ref WPD.OBJECT_SIZE, (ulong)stream.Length);
            portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, fileName);
            portableDeviceValues.SetStringValue(ref WPD.OBJECT_NAME, fileName);

            uint num = 0u;
            string text = null;
            this.device.deviceContent.CreateObjectWithPropertiesAndData(portableDeviceValues, out PortableDeviceApiLib.IStream wpdStream, ref num, ref text);

            using (StreamWrapper destinationStream = new StreamWrapper(wpdStream))
            {
                stream.CopyTo(destinationStream);
                destinationStream.Flush();
            }
        }

        internal void Rename(string newName)
        {
            IPortableDeviceValues portableDeviceValues = new PortableDeviceValues() as IPortableDeviceValues;
            IPortableDeviceValues result;
            
            portableDeviceValues.SetStringValue(ref WPD.OBJECT_NAME, newName);
            portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, newName);
            this.deviceProperties.SetValues(this.Id, portableDeviceValues, out result);
            //ComTrace.WriteObject(result);
                        
            Refresh();
        }


        #endregion
    }
}
