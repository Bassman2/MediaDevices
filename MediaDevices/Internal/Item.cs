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
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using MediaDevices.Internal;
using System.Reflection;
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

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public ItemType Type { get; private set; }

        public bool IsRoot { get { return this.Id == RootId; } }
        
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

        public Item Parent
        {
            get
            {
                if (this.parent == null)
                {
                    this.parent = new Item(this.device, ParentId, Path.GetDirectoryName(Path.GetDirectoryName(this.FullName)));
                }
                return this.parent;
            }
        }

        #endregion

        #region Methods

        public IEnumerable<Item> GetChildren()
        {
            this.device.deviceContent.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs objectIds);

            uint fetched = 0;
            objectIds.Next(1, out string objectId, ref fetched);
            while (fetched > 0)
            {
                Item item = Item.Create(this.device, objectId, this.FullName);
                yield return item;
                objectIds.Next(1, out objectId, ref fetched);
            }
        }

        public IEnumerable<Item> GetChildren(string pattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            this.device.deviceContent.EnumObjects(0, this.Id, null, out IEnumPortableDeviceObjectIDs objectIds);

            uint fetched = 0;
            objectIds.Next(1, out string objectId, ref fetched);
            while (fetched > 0)
            {
                Item item = Item.Create(this.device, objectId, this.FullName);
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
                sb.Insert(0, item.Name);
                sb.Insert(0, DirectorySeparatorChar);

            } while (!(item = new Item(this.device, item.ParentId)).IsRoot);
            return sb.ToString();
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

        #endregion
    }
}
