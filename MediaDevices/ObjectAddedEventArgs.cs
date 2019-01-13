using MediaDevices.Internal;
using System;
using System.IO;

namespace MediaDevices
{
    /// <summary>
    /// Event argument class for the media device object added event.
    /// </summary>
    public class ObjectAddedEventArgs : MediaDeviceEventArgs
    {
        internal ObjectAddedEventArgs(Events eventEnum, MediaDevice mediaDevice, IPortableDeviceValues eventParameters) 
            : base(eventEnum, mediaDevice, eventParameters)
        {
            eventParameters.TryGetStringValue(WPD.OBJECT_ID, out string objectId);
            this.ObjectId = objectId;
            
            eventParameters.TryGetStringValue(WPD.OBJECT_PERSISTENT_UNIQUE_ID, out string objectPersistentUniqueId);
            this.ObjectPersistentUniqueId = objectPersistentUniqueId;
            
            eventParameters.TryGetStringValue(WPD.OBJECT_NAME, out string objectName);
            this.ObjectName = objectName;
            
            if (eventParameters.TryGetGuidValue(WPD.OBJECT_CONTENT_TYPE, out Guid objectContentType))
            { 
                this.ObjectContentType = EnumExtentions.GetEnumFromAttrGuid<ContentType>(objectContentType); 
            }
            
            if (eventParameters.TryGetGuidValue(WPD.FUNCTIONAL_OBJECT_CATEGORY, out Guid functionalObjectCategory))
            { 
                this.FunctionalObjectCategory = EnumExtentions.GetEnumFromAttrGuid<FunctionalCategory>(functionalObjectCategory);
            }
            
            eventParameters.TryGetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out string objectOriginalFileName);
            this.ObjectOriginalFileName = objectOriginalFileName;
            
            eventParameters.TryGetStringValue(WPD.OBJECT_PARENT_ID, out string objectParentId);
            this.ObjectParentId = objectParentId;

            eventParameters.TryGetStringValue(WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID, out string objectContainerFuntionalObjectId);
            this.ObjectContainerFuntionalObjectId = objectContainerFuntionalObjectId;
        }

        /// <summary>
        /// Id of the added object.
        /// </summary>
        public string ObjectId { get; private set; }

        /// <summary>
        /// Persistent unique id of the added object.
        /// </summary>
        public string ObjectPersistentUniqueId { get; private set; }

        /// <summary>
        /// Name of the added object.
        /// </summary>
        public string ObjectName { get; private set; }

        /// <summary>
        /// Content type of the added object.
        /// </summary>
        public ContentType ObjectContentType { get; private set; }

        /// <summary>
        /// Functional category of the added object
        /// </summary>
        public FunctionalCategory FunctionalObjectCategory { get; private set; }

        /// <summary>
        /// Original file name of the added object
        /// </summary>
        public string ObjectOriginalFileName { get; private set; }

        /// <summary>
        /// Parent id of the added object.
        /// </summary>
        public string ObjectParentId { get; private set; }

        /// <summary>
        /// Container functional id of the added object. 
        /// </summary>
        public string ObjectContainerFuntionalObjectId { get; private set; }

        /// <summary>
        /// Full file name of the added object
        /// </summary>
        public string ObjectFullFileName
        {
            get
            {
                return Item.Create(this.MediaDevice, this.ObjectId).FullName;
            }
        }

        /// <summary>
        /// Read stream of the added object
        /// </summary>
        public Stream ObjectFileStream
        {
            get
            {
                return Item.Create(this.MediaDevice, this.ObjectId).OpenRead();
            }
        }
    }
}
