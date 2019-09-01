namespace MediaDevices.Internal
{
    internal enum PropertyKeys : ulong
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Key]
        Unknown,

        #region OBJECT_PROPERTIES_V1

        /// <summary>
        /// Uniquely identifies object on the Portable Device. Recommended Device Services Property: PKEY_GenericObj_ObjectID
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 2)]
        ObjectId,

        /// <summary>
        /// Object identifier indicating the parent object. Recommended Device Services Property: PKEY_GenericObj_ParentID
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 3)]
        ObjectParentId,

        /// <summary>
        /// The display name for this object. Recommended Device Services Property: PKEY_GenericObj_Name
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 4)]
        ObjectName,

        /// <summary>
        /// Uniquely identifies the object on the Portable Device, similar to WPD_OBJECT_ID, but this ID will not change between sessions.
        /// Recommended Device Services Property: PKEY_GenericObj_PersistentUID
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 5)]
        ObjectPersistentUniqueId,

        /// <summary>
        /// Indicates the format of the object's data.
        /// Recommended Device Services Property: PKEY_GenericObj_ObjectFormat
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 6)]
        ObjectFormat,

        /// <summary>
        /// The abstract type for the object content, indicating the kinds of properties and data that may be supported on the object.
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 7)]
        ObjectContentType,

        /// <summary>
        /// Indicates whether the object should be hidden.
        /// Recommended Device Services Property: PKEY_GenericObj_Hidden
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 9)]
        ObjectIsHidden,

        /// <summary>
        /// Indicates whether the object represents system data.
        /// Recommended Device Services Property: PKEY_GenericObj_SystemObject
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 10)]
        ObjectIsSystem,

        /// <summary>
        /// The size of the object data.
        /// Recommended Device Services Property: PKEY_GenericObj_ObjectSize
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 11)]
        ObjectSize,

        /// <summary>
        /// Contains the name of the file this object represents.
        /// Recommended Device Services Property: PKEY_GenericObj_ObjectFileName
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 12)]
        ObjectOriginalFileName,

        /// <summary>
        /// This property determines whether or not this object is intended to be understood by the device, or whether it has been placed on the device just for storage.
        /// Recommended Device Services Property: PKEY_GenericObj_NonConsumable
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 13)]
        ObjectNonConsumable,

        /// <summary>
        /// IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of ObjectIDs.
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 14)]
        ObjectReferences,

        /// <summary>
        /// String containing a list of keywords associated with this object.
        /// Recommended Device Services Property: PKEY_GenericObj_Keywords
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 15)]
        ObjectKeywords,

        /// <summary>
        /// Opaque string set by client to retain state between sessions without retaining a catalogue of connected device content.
        /// Recommended Device Services Property: PKEY_GenericObj_SyncID
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 16)]
        ObjectSyncId,

        /// <summary>
        /// Indicates whether the media data is DRM protected.
        /// Recommended Device Services Property: PKEY_GenericObj_DRMStatus
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 17)]
        ObjectIsDRMProtected,

        /// <summary>
        /// Indicates the date and time the object was created on the device.
        /// Recommended Device Services Property: PKEY_GenericObj_DateCreated
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 18)]
        ObjectDateCreated,

        /// <summary>
        /// Indicates the date and time the object was modified on the device.
        /// Recommended Device Services Property: PKEY_GenericObj_DateModified
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 19)]
        ObjectDateModified,

        /// <summary>
        /// Indicates the date and time the object was authored (e.g. for music, this would be the date the music was recorded).
        /// Recommended Device Services Property: PKEY_GenericObj_DateAuthored
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 20)]
        ObjectDateAuthored,

        /// <summary>
        /// IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of ObjectIDs.
        /// Recommended Device Services Property: PKEY_GenericObj_ReferenceParentID
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 21)]
        ObjectBackReferences,

        /// <summary>
        /// Indicates the Object ID of the closest functional object ancestor. For example, objects that represent files/folders under a Storage functional object, will have this property set to the object ID of the storage functional object.
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 23)]
        ObjectContainerFunctionalObjectId,

        /// <summary>
        /// Indicates whether the thumbnail for this object should be generated from the default resource.
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 24)]
        ObjectGenerateThumbnailFromResource,

        /// <summary>
        /// If this object appears as a hint location, this property indicates the hint-specific name to display instead of the object name.
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 25)]
        ObjectHintLocationDisplayName,

        /// <summary>
        /// Indicates whether the object can be deleted, or not.
        /// Recommended Device Services Property: PKEY_GenericObj_ProtectionStatus
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 26)]
        ObjectCanDelete,

        /// <summary>
        /// Identifies the language of this object. If multiple languages are contained in this object, it should identify the primary language (if any).
        /// Recommended Device Services Property: PKEY_GenericObj_LanguageLocale
        /// </summary>
        [Key(0xef6b490d, 0x5cd8, 0x437a, 0xaf, 0xfc, 0xda, 0x8b, 0x60, 0xee, 0x4a, 0x3c, 27)]
        ObjectLanguageLocal,

        #endregion

        #region OBJECT_PROPERTIES_V2

        /// <summary>
        /// Indicates the units supported on this object.
        /// </summary>
        [Key(0x0373cd3d, 0x4a46, 0x40d7, 0xb4, 0xd8, 0x73, 0xe8, 0xda, 0x74, 0xe7, 0x75, 2)]
        ObjectSupportedUnits,

        #endregion

        #region FUNCTIONAL_OBJECT_PROPERTIES_V1

        /// <summary>
        /// Indicates the object's functional category.
        /// </summary>
        [Key(0x8f052d93, 0xabca, 0x4fc5, 0xa5, 0xac, 0xb0, 0x1d, 0xf4, 0xdb, 0xe5, 0x98, 2)]
        FunctionalObjectCategory,

        #endregion

        #region STORAGE_OBJECT_PROPERTIES_V1

        /// <summary>
        /// Indicates the type of storage e.g. fixed, removable etc.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 2)]
        StorageType,

        /// <summary>
        /// Indicates the file system type e.g. "FAT32" or "NTFS" or "My Special File System"
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 3)]
        StorageFileSystemType,

        /// <summary>
        /// Indicates the total storage capacity in bytes.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 4)]
        StorageCapacity,

        /// <summary>
        /// Indicates the available space in bytes.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 5)]
        StorageFreeSpaceInBytes,

        /// <summary>
        /// Indicates the available space in objects e.g. available slots on a SIM card.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 6)]
        StorageFreeSpaceInObjects,

        /// <summary>
        /// Contains a description of the storage.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 7)]
        StorageDescription,

        /// <summary>
        /// Contains the serial number of the storage.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 8)]
        StorageSerialNumber,

        /// <summary>
        /// Specifies the maximum size of a single object (in bytes) that can be placed on this storage.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 9)]
        StorageMaxObjectSize,

        /// <summary>
        /// Indicates the total storage capacity in objects e.g. available slots on a SIM card.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 10)]
        StorageCapacityInObjects,

        /// <summary>
        /// This property identifies any write-protection that globally affects this storage. This takes precedence over access specified on individual objects.
        /// </summary>
        [Key(0x01a3057a, 0x74d6, 0x4e80, 0xbe, 0xa7, 0xdc, 0x4c, 0x21, 0x2c, 0xe5, 0x0a, 11)]
        StorageAccessCapability,

        #endregion
    }
}
