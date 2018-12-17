namespace MediaDevices
{
    /// <summary>
    /// Commands for the device
    /// </summary>
    public enum Commands : ulong
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Key]
        Unknown,

        #region WPD_CATEGORY_COMMON

        /// <summary>
        /// This command is sent by clients to reset the device. 
        /// </summary>
        [Key(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A, 2)]
        ResetDevice,

        /// <summary>
        /// This command is sent when a client wants to get current ObjectIDs representing 
        /// objects specified by previously acquired Persistent Unique IDs. 
        /// </summary>
        [Key(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A, 3)]
        GetObjectIdsFromPersistenUniqueIds,

        /// <summary>
        /// This command is sent when a client first connects to a device. 
        /// </summary>
        [Key(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A, 4)]
        SaveClientInformation,

        #endregion

        #region WPD_CATEGORY_DEVICE_HINTS

        /// <summary>
        /// This command is used to retrieve the ObjectIDs of folders that contain the specified content type
        /// </summary>
        [Key(0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84, 2)]
        GetContentLocation,

        #endregion

        #region WPD_CATEGORY_STORAGE

        /// <summary>
        /// This command will format the storage. 
        /// </summary>
        [Key(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94, 2)]
        StorageFormat,

        /// <summary>
        /// This will eject the storage, if it is a removable store and is capable of being ejected by the device. 
        /// </summary>
        [Key(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94, 4)]
        StorageEject,

        #endregion

        #region WPD_CATEGORY_SMS

        /// <summary>
        /// This command is used to initiate the sending of an SMS message. 
        /// </summary>
        [Key(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1, 2)]
        SmsSend,

        #endregion

        #region WPD_CATEGORY_STILL_IMAGE_CAPTURE

        /// <summary>
        /// Initiates a still image capture. This is processed as a single command i.e. there is no start or stop required. 
        /// </summary>
        [Key(0x4FCD6982, 0x22A2, 0x4B05, 0xA4, 0x8B, 0x62, 0xD3, 0x8B, 0xF2, 0x7B, 0x32, 2)]
        StillImageCaptureInitiate,

        #endregion

        #region WPD_CATEGORY_OBJECT_ENUMERATION

        /// <summary>
        /// The driver receives this command when a client wishes to start enumeration.
        /// </summary>
        [Key(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC, 2)]
        ObjectEnumerationStartFind,

        /// <summary>
        /// The driver receives this command when a client wishes to start enumeration.
        /// </summary>
        [Key(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC, 3)]
        ObjectEnumerationFindNext,

        /// <summary>
        /// The driver should destroy any resources associated with this enumeration context.
        /// </summary>
        [Key(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC, 4)]
        ObjectEnumerationEndFind,

        #endregion

        #region WPD_CATEGORY_OBJECT_PROPERTIES

        /// <summary>
        /// This command is used when the client requests the list of properties supported by the specified object.
        /// </summary>
        [Key(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04, 2)]
        ObjectPropertiesGetSupported,

        /// <summary>
        /// This command is used when the client requests the property attributes for the specified object properties.
        /// </summary>
        [Key(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04, 3)]
        ObjectPropertiesGetAttribute,

        /// <summary>
        /// This command is used when the client requests a set of property values for the specified object. 
        /// </summary>
        [Key(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04, 4)]
        ObjectPropertiesGet,

        /// <summary>
        /// This command is used when the client requests to write a set of property values on the specified object. 
        /// </summary>
        [Key(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04, 5)]
        ObjectPropertiesSet,

        /// <summary>
        /// This command is used when the client requests all property values for the specified object. 
        /// </summary>
        [Key(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04, 6)]
        ObjectPropertiesGetAll,

        /// <summary>
        /// This command is sent when the caller wants to delete properties from the specified object. 
        /// </summary>
        [Key(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04, 7)]
        ObjectPropertiesDelete,

        #endregion

        #region WPD_CATEGORY_OBJECT_RESOURCES

        /// <summary>
        /// This command is sent when a client wants to get the list of resources supported on a particular object. 
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 2)]
        ObjectResourcesGetSupported,

        /// <summary>
        /// This command is used when the client requests the attributes for the specified object resource.
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 3)]
        ObjectResourcesGetAttributes,

        /// <summary>
        /// Dependent on the value of WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE.  
        /// STGM_READ will indicate FILE_READ_ACCESS for the command, anything else will indicate (FILE_READ_ACCESS | FILE_WRITE_ACCESS).
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 4)]
        ObjectResourcesOpen,

        /// <summary>
        /// This command is sent when a client wants to read the next band of data from a previously opened object resource.
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 5)]
        ObjectResourcesRead,

        /// <summary>
        /// This command is sent when a client wants to write the next band of data to a previously opened object resource. 
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 6)]
        ObjectResourcesWrite,

        /// <summary>
        /// This command is sent when a client is finished transferring data to a previously opened object resource. 
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 7)]
        ObjectResourcesClose,

        /// <summary>
        /// This command is sent when the client wants to delete the data associated with the specified resources from the specified object.
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 8)]
        ObjectResourcesDelete,

        /// <summary>
        /// This command is sent when a client wants to create a new object resource on the device. 
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 9)]
        ObjectResourcesCreateResource,

        /// <summary>
        /// This command is sent when a client wants to cancel the resource creation request that is currently still in progress.
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 10)]
        ObjectResourcesRevert,

        /// <summary>
        /// This command is sent when a client wants to seek to a specific offset in the data stream.
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 11)]
        ObjectResourcesSeek,

        /// <summary>
        /// This command is sent when a client wants to commit changes to a data stream. 
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 12)]
        ObjectResourcesCommit,

        /// <summary>
        /// This command is sent when a client wants to seek to a specific offset in the data stream using alternate units.  
        /// </summary>
        [Key(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A, 13)]
        ObjectResourcesSeekInUnits,

        #endregion

        #region WPD_CATEGORY_CAPABILITIES

        /// <summary>
        /// Return all commands supported by this driver. This includes custom commands, if any.   
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 2)]
        CapabilitiesGetSupportedCommands,

        /// <summary>
        /// Returns the supported options for the specified command.  
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 3)]
        CapabilitiesGetCommandOptions,

        /// <summary>
        /// This command is used by clients to query the functional categories supported by the driver. 
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 4)]
        CapabilitiesGetSupportedFunctionalCategories,

        /// <summary>
        ///  Retrieves the ObjectIDs of the objects belonging to the specified functional category. 
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 5)]
        CapabilitiesGetFunctionalObjects,

        /// <summary>
        ///  Retrieves the list of content types supported by this driver for the specified functional category. 
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 6)]
        CapabilitiesGetSupportedContentTypes,

        /// <summary>
        ///  This command is used to query the possible formats supported by the specified content type 
        ///  (e.g. for image objects, the driver may choose to support JPEG and BMP files).
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 7)]
        CapabilitiesGetSupportedFormats,

        /// <summary>
        ///  Get the list of properties that an object of the given format supports. 
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 8)]
        CapabilitiesGetSupportedFormatProperties,

        /// <summary>
        /// Returns the property attributes that are the same for all objects of the given format. 
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 9)]
        CapabilitiesGetFixedPropertyAttributes,

        /// <summary>
        /// Return all events supported by this driver. This includes custom events, if any.
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 10)]
        CapabilitiesGetSupportedEvents,

        /// <summary>
        /// Return extra information about a specified event, such as whether the event is for notification or action purposes. 
        /// </summary>
        [Key(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56, 11)]
        CapabilitiesGetEventOptions,

        #endregion

        #region WPD_CATEGORY_OBJECT_MANAGEMENT

        /// <summary>
        /// This command is sent when a client wants to create a new object on the device, specified only by properties.
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 2)]
        ObjectManagementCreateObjectWithPropertiesOnly,

        /// <summary>
        /// This command is sent when a client wants to create a new object on the device, specified by properties and data. 
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 3)]
        ObjectManagementCreateObjectWithPropertiesAndData,

        /// <summary>
        /// This command is sent when a client wants to write the next band of data to a newly created object or an object being updated. 
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 4)]
        ObjectManagementWriteObjectData,

        /// <summary>
        /// This command is sent when a client has finished sending all the data associated with an object creation or update request,
        /// and wishes to ensure that the object is saved to the device. 
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 5)]
        ObjectManagementCommitObject,

        /// <summary>
        /// This command is sent when a client wants to cancel the object creation or update request that is currently still in progress.
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 6)]
        ObjectManagementRevertObject,

        /// <summary>
        /// This command is sent when the client wishes to remove a set of objects from the device.
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 7)]
        ObjectManagementDeleteObjects,

        /// <summary>
        /// This command will move the specified objects to the destination folder. 
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 8)]
        ObjectManagementMoveObjects,

        /// <summary>
        /// This command will copy the specified objects to the destination folder. 
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 9)]
        ObjectManagementCopyObjects,

        /// <summary>
        /// This command is sent when a client wants to update the object's data and dependent properties simultaneously. 
        /// </summary>
        [Key(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89, 10)]
        ObjectManagementUpdateObjectsWithPropertiesAnsData,

        #endregion

        #region WPD_CATEGORY_OBJECT_PROPERTIES_BULK

        /// <summary>
        /// Initializes the operation to get the property values for all caller-specified objects. 
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 2)]
        ObjectPropertiesBulkGetValuesByObjectListStart,

        /// <summary>
        /// Get the next set of property values. 
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 3)]
        ObjectPropertiesBulkGetValuesByObjectListNext,

        /// <summary>
        /// Ends the bulk property operation for getting property values by object list. 
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 4)]
        ObjectPropertiesBulkGetValuesByObjectListEnd,

        /// <summary>
        /// Initializes the operation to get the property values for objects of the specified format 
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 5)]
        ObjectPropertiesBulkGetValuesByObjectFormatStart,

        /// <summary>
        /// Get the next set of property values. 
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 6)]
        ObjectPropertiesBulkGetValuesByObjectFormatNext,

        /// <summary>
        /// Ends the bulk property operation for getting property values by object format.  
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 7)]
        ObjectPropertiesBulkGetValuesByObjectFormatEnd,

        /// <summary>
        /// Initializes the operation to set the property values for specified objects.
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 8)]
        ObjectPropertiesBulkSetValuesByObjectListStart,

        /// <summary>
        /// Set the next set of property values. 
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 9)]
        ObjectPropertiesBulkSetValuesByObjectListNext,

        /// <summary>
        /// Ends the bulk property operation for setting property values by object list.  
        /// </summary>
        [Key(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E, 10)]
        ObjectPropertiesBulkSetValuesByObjectListEnd,

        #endregion

        #region WPD_CATEGORY_NETWORK_CONFIGURATION

        /// <summary>
        /// Initiates the generation of a public/private key pair and returns the public key.   
        /// </summary>
        [Key(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4, 2)]
        GenerateKeypair,

        /// <summary>
        /// Commits a public/private key pair.  
        /// </summary>
        [Key(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4, 3)]
        CommitKeypair,

        /// <summary>
        /// Initiates the processing of a Wireless Profile file.  
        /// </summary>
        [Key(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4, 4)]
        ProcessWirelessProfile,

        #endregion

        #region WPD_CATEGORY_MTP_EXT_VENDOR_OPERATIONS

        /// <summary>
        /// Queries for vendor extended operation codes.   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 11)]
        MtpExtVendorGetSupportedVendorOpcodes,

        /// <summary>
        /// Sends a MTP command block that no data phase follows.   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 12)]
        MtpExtVendorExecuteCommandWithoutDataPhase,

        /// <summary>
        /// Sends a MTP command block followed by a data phase with data from Device to Host.   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 13)]
        MtpExtVendorExecuteCommandWithDataToRead,

        /// <summary>
        /// sends a MTP command block followed by a data phase with data from Host to Device.   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 14)]
        MtpExtVendorExecuteCommandWithDataToWrite,

        /// <summary>
        /// receives a chunk of data from device following WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_READ.   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 15)]
        MtpExtVendorReadData,

        /// <summary>
        /// sends a chunk of data to device following WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_WRITE.   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 16)]
        MtpExtVendorWriteData,

        /// <summary>
        /// Completes a data transfer and read response from device. The transfer is initiated by either 
        /// WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_READ, or WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_WRITE.   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 17)]
        MtpExtVendorEndDataTransfer,

        /// <summary>
        /// Retrieves the vendor extension description string (as defined by DeviceInfo dataset).   
        /// </summary>
        [Key(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56, 18)]
        MtpExtVendorGetVendorExtensionDescription,

        #endregion
    }
}
