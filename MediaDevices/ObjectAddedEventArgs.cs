using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;

namespace MediaDevices
{
    public class ObjectAddedEventArgs : MediaDeviceEventArgs
    {
        internal ObjectAddedEventArgs(Events eventEnum, MediaDevice mediaDevice, IPortableDeviceValues eventParameters) 
            : base(eventEnum, mediaDevice, eventParameters)
        {
            if (ComHelper.HasKeyValue(eventParameters, WPD.OBJECT_ID))
            {
                string objectId = string.Empty;
                eventParameters.GetStringValue(WPD.OBJECT_ID, out objectId);
                this.ObjectId = objectId;
            }

            if (ComHelper.HasKeyValue(eventParameters, WPD.OBJECT_PERSISTENT_UNIQUE_ID))
            {
                string objectPersistentUniqueId = string.Empty;
                eventParameters.GetStringValue(WPD.OBJECT_PERSISTENT_UNIQUE_ID, out objectPersistentUniqueId);
                this.ObjectPersistentUniqueId = objectPersistentUniqueId;
            }

            if (ComHelper.HasKeyValue(eventParameters, WPD.OBJECT_NAME))
            {
                string objectName = string.Empty;
                eventParameters.GetStringValue(WPD.OBJECT_NAME, out objectName);
                this.ObjectName = objectName;
            }

            if (ComHelper.HasKeyValue(eventParameters, WPD.OBJECT_CONTENT_TYPE))
            {
                Guid objectContentType = new Guid();
                eventParameters.GetGuidValue(WPD.OBJECT_CONTENT_TYPE, out objectContentType);
                this.ObjectContentType = EnumExtentions.GetEnumFromAttrGuid<ContentType>(objectContentType); 
            }

            if (ComHelper.HasKeyValue(eventParameters, WPD.FUNCTIONAL_OBJECT_CATEGORY))
            {
                //PROPVARIANT p;
                //eventParameters.GetValue(WPD.FUNCTIONAL_OBJECT_CATEGORY, out p);
                //PropVariant pv = PropVariant.FromValue(p);

                Guid functionalObjectCategory = new Guid();
                eventParameters.GetGuidValue(WPD.FUNCTIONAL_OBJECT_CATEGORY, out functionalObjectCategory);
                this.FunctionalObjectCategory = EnumExtentions.GetEnumFromAttrGuid<FunctionalCategory>(functionalObjectCategory);
            }

            if (ComHelper.HasKeyValue(eventParameters, WPD.OBJECT_ORIGINAL_FILE_NAME))
            {
                string objectOriginalFileName = string.Empty;
                eventParameters.GetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out objectOriginalFileName);
                this.ObjectOriginalFileName = objectOriginalFileName;
            }

            if (ComHelper.HasKeyValue(eventParameters, WPD.OBJECT_PARENT_ID))
            {
                string objectParentId = string.Empty;
                eventParameters.GetStringValue(WPD.OBJECT_PARENT_ID, out objectParentId);
                this.ObjectParentId = objectParentId;
            }

            if (ComHelper.HasKeyValue(eventParameters, WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID))
            {
                string objectContainerFuntionalObjectId = string.Empty;
                eventParameters.GetStringValue(WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID, out objectContainerFuntionalObjectId);
                this.ObjectContainerFuntionalObjectId = objectContainerFuntionalObjectId;
            }
        }

        public string ObjectId { get; private set; }

        public string ObjectPersistentUniqueId { get; private set; }

        public string ObjectName { get; private set; }

        public ContentType ObjectContentType { get; private set; }

        public FunctionalCategory FunctionalObjectCategory { get; private set; }

        public string ObjectOriginalFileName { get; private set; }

        public string ObjectParentId { get; private set; }

        public string ObjectContainerFuntionalObjectId { get; private set; }

        public string ObjectFullFileName
        {
            get
            {
                return this.mediaDevice.GetPath(this.ObjectId);
            }
        }

        public Stream ObjectFileStream
        {
            get
            {
                return this.mediaDevice.OpenRead(this.ObjectId);
            }
        }
    }
}
