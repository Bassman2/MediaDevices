using System.Diagnostics;
using PortableDeviceApiLib;
using System;
using System.IO;

namespace MediaDevices.Internal
{

    [DebuggerDisplay("{this.Type} - {this.Name} - {this.Id}")]
    internal class Item
    {
        private IPortableDeviceProperties deviceProperties;
        private IPortableDeviceKeyCollection keyCollection;
        private IPortableDeviceValues values;
        private string path;

        public const string RootId = "DEVICE";

        public static Item Root { get { return new Item(RootId, RootId, ItemType.Object, @"\"); } }


        public string Id { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public ItemType Type { get; private set; }

        public bool IsRoot { get { return this.Id == RootId; } }

        public Item(string id, string name, ItemType type, string FullName = null)
        {
            this.Id = id;
            this.Name = name;
            this.FullName = FullName;
            this.Type = type;
        }

        public static Item Create(MediaDevice device, string id, string path)
        {
            return new Item(device, id, path);
        }

        public Item(MediaDevice device, string id, string path)
        {
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
                Update();
            }
        }

        public void Update()
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
            this.FullName = Path.Combine(this.path, this.Name);
        }

        #region Value Properties

        public Guid ContentType
        {
            get
            {
                Guid value;
                this.values.TryGetGuidValue(WPD.OBJECT_CONTENT_TYPE, out value);
                return value;
            }
        }

        public string name
        {
            get
            {
                string value;
                this.values.TryGetStringValue(WPD.OBJECT_NAME, out value);
                return value;
            }
        }

        public string OriginalFileName
        {
            get
            {
                string value;
                this.values.TryGetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out value);
                return value;
            }
        }

        public ulong Size
        {
            get
            {
                ulong value = 0;
                this.values.TryGetUnsignedLargeIntegerValue(WPD.OBJECT_SIZE, out value);
                return value;
            }
        }

        public DateTime? DateCreated
        {
            get
            {
                DateTime? value = null;
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_CREATED, out value);
                return value;
            }
        }

        public DateTime? DateModified
        {
            get
            {
                DateTime? value = null;
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_MODIFIED, out value);
                return value;
            }
        }

        public DateTime? DateAuthored
        {
            get
            {
                DateTime? value = null;
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_AUTHORED, out value);
                return value;
            }
        }

        public bool CanDelete
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_CAN_DELETE, out value);
                return value;
            }
        }

        public bool IsSystem
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_ISSYSTEM, out value);
                return value;
            }
        }

        public bool IsHidden
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_ISHIDDEN, out value);
                return value;
            }
        }

        public bool IsDRMProtected
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_IS_DRM_PROTECTED, out value);
                return value;
            }
        }

        public string ParentId
        {
            get
            {
                string value;
                this.values.TryGetStringValue(WPD.OBJECT_PARENT_ID, out value);
                return value;
            }
        }

        #endregion
    }
}
