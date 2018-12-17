namespace MediaDevices.Internal
{
    /// <summary>
    /// Media Device HRESULTS
    /// </summary>
    internal enum HResult : uint
    {
        /// <summary>
        /// OK
        /// </summary>
        S_OK = 0,

        /// <summary>
        /// Not implemented
        /// </summary>
        E_NOT_IMPLEMENTED = 0x80004001,

        /// <summary>
        /// Element not found
        /// </summary>
        E_ELEMENT_NOT_FOUND = 0x80070490,

        /// <summary>
        /// The device connection has already been opened by a prior call to IPortableDevice::Open.
        /// </summary>
        E_WPD_DEVICE_ALREADY_OPENED = 0x802A0001,

        /// <summary>
        /// The device will no longer respond to input.
        /// </summary>
        E_WPD_DEVICE_IS_HUNG = 0x802A0006,

        /// <summary>
        /// The device connection has not yet been opened by a call to IPortableDevice::Open.
        /// </summary>
        E_WPD_DEVICE_NOT_OPEN = 0x802A0002,

        /// <summary>
        /// The interface object has already been attached to the device interface.
        /// </summary>
        E_WPD_OBJECT_ALREADY_ATTACHED_TO_DEVICE = 0x802A0003,

        /// <summary>
        /// The interface object has already been attached to the IPortableDeviceService interface.
        /// </summary>
        E_WPD_OBJECT_ALREADY_ATTACHED_TO_SERVICE = 0x802A00CA,

        /// <summary>
        /// The interface object has not been attached to the device.
        /// </summary>
        E_WPD_OBJECT_NOT_ATTACHED_TO_DEVICE = 0x802A0004,

        /// <summary>
        /// The interface object has not been attached to the IPortableDeviceService interface. Typically, this is returned if the application tries to access methods of an attached interface, such as IPortableDeviceServiceCapabilities, after IPortableDevice::Close is called.
        /// </summary>
        E_WPD_OBJECT_NOT_ATTACHED_TO_SERVICE = 0x802A00CB,

        /// <summary>
        /// IStream::Commit was never called when creating an object with data on a device.
        /// </summary>
        E_WPD_OBJECT_NOT_COMMITED = 0x802A0005,

        /// <summary>
        /// The service connection has already been opened by a prior call to IPortableDevice::Open.
        /// </summary>
        E_WPD_SERVICE_ALREADY_OPENED = 0x802A00C8,

        /// <summary>
        /// The method parameters for IPortableDeviceServiceMethods::Invoke or IPortableDeviceServiceMethods::InvokeAsync are not set in the correct order.The parameter must be set in the ordering specified by WPD_PARAMETER_ATTRIBUTE_ORDER.
        /// </summary>
        E_WPD_SERVICE_BAD_PARAMETER_ORDER = 0x802A00CC,

        /// <summary>
        /// The service connection has not yet been opened by a call to IPortableDeviceService::Open.
        /// </summary>
        E_WPD_SERVICE_NOT_OPEN = 0x802A00C9,

        /// <summary>
        /// The recipient specified for an SMS message is invalid.
        /// </summary>
        E_WPD_SMS_INVALID_RECIPIENT = 0x802A0064,

        /// <summary>
        /// The body of a message specified for an SMS message is invalid.
        /// </summary>
        E_WPD_SMS_INVALID_MESSAGE_BODY = 0x802A0065,

        /// <summary>
        /// The SMS service is unavailable.
        /// </summary>
        E_WPD_SMS_SERVICE_UNAVAILABLE = 0x802A0066,



        /// <summary>
        /// You cannot debug when accessing DRM-protected content.
        /// </summary>
        NS_E_DRM_DEBUGGING_NOT_ALLOWED = 0xC00D2767,

        /// <summary>
        /// The content is not licensed.
        /// </summary>
        NS_E_NOT_LICENSED = 0xC00D00CD,

        /*
        ERROR_ACCESS_DENIED0x80070005 
May be used to indicate that a read-only object or property cannot be modified or deleted. May be used to indicate that the object is being accessed outside its scope, for example a child object that falls outside the hierarchy of a device service. May be used to indicate that the application does not have the access (for example, if access control to devices is restricted by Group Policy) to send WPD commands to the device. 
 
 ERROR_ARITHMETIC_OVERFLOW0x80070216 
May be used to indicate that the number of elements in a data array has exceeded its limits (ULONGLONG).
 
 ERROR_BUSY0x800700AA 
May be used to indicate that the device is busy processing another operation. Applications should wait for that operation to complete before retrying.
 
 ERROR_CANCELLED0x800704C7 
A command sent to the device has been aborted due to a cancellation, e.g. by calling one of the Cancel methods in the WPD API.
 
 ERROR_DATATYPE_MISMATCH0x8007070C 
May be used to indicate that an invalid data packet was received from the device.
 
 ERROR_DEVICE_IN_USE0x80070964 
For an MTP/IP device, indicates that the connection has failed to initialize because the device is in use.
 
 ERROR_DEVICE_NOT_CONNECTE0x8007048F 
The device has been disconnected or unplugged.
 
 ERROR_DIR_NOT_EMPTY0x80070091 
May be used to indicate that a non-recursive delete was called for an object with children. The application should use the recursive delete flag in IPortableDeviceContent::Delete.
 
 ERROR_EMPTY0x800710D2 
May be used to indicate that the device failed to send any resource data when resource data was expected (e.g. a thumbnail or device icon). This usually indicates an error on the device.
 
 ERROR_FILE_NOT_FOUND0x80070002 
May be used to indicate that the device has been disconnected or unplugged.
 
 ERROR_GEN_FAILURE 0x8007001F 
May be used to indicate that the device has stopped responding (hung) or a general failure has occurred on the device. The device may need to be manually reset.
 
 ERROR_INVALID_DATA0x8007000D 
May be used to indicate that data sent to or received from the device cannot be parsed correctly. This may indicate a device-side or a transport error. If MTP vendor operations are sent to the device, this error may indicate that the specified operation parameters are not of the valid VARTYPE. 
 
 ERROR_INVALID_DATATYPE0x8007070C 
May be used to indicate that the specified VARTYPE is invalid for a given property.
 
 ERROR_INVALID_FUNCTION0x80070001 
A write request was made to a resource on the device that was opened in Read mode using IPortableDeviceResources::GetStream, or a read request was made to a resource opened for Write or Create.
 
 ERROR_INVALID_OPERATION0x800710DD 
A non-recursive delete is called for an object with children.
 
 ERROR_INVALID_PARAMETER0x80070057 
The parameter supplied by the application is not valid.
 
 ERROR_INVALID_TIME0x8007076D 
May be used to indicate that a conversion of a datetime property has failed.
 
 ERROR_IO_DEVICE 0x8007045D 
May be used to indicate that the device has stopped responding (hung). The device may need to be manually reset.
 */
        /// <summary>
        /// May be used to indicate that the device supports a property, but that property value is currently empty or uninitialized. 
        /// May be used to indicate that the internal context for a long-running operation no longer exists, as the operation has 
        /// completed or has been cancelled. Examples of such operations include bulk properties, object enumeration, transfer, 
        /// and invoking device service methods. Applications should retry the operation from the beginning. May be used to indicate 
        /// that the specified object does not exist. The child object may be outside of the device service hierarchy. 
        /// </summary>
        ERROR_NOT_FOUND = 0x80070490,

 /*
 ERROR_NOT_READY0x80070015 
May be used to indicate that an operation is not initialized correctly. This usually indicates an internal error, or that the application is using a stale device handle. The application should retry the operation from the beginning, or reopen the device.
 
 ERROR_NOT_SUPPORTED0x80070032 
May be used to indicate that a property or command is not supported by the device.
 
 ERROR_OPERATION_ABORTED0x800703E3 
A command sent to the device has been aborted due to a manual cancellation, e.g. by calling one of the Cancel methods in the WPD API. 
 
 ERROR_READ_FAULT0x8007001E 
May be used to indicate that the device is not sending the correct amount of data.
 
 ERROR_RESOURCE_NOT_AVAILABLE0x8007138E 
May be used to indicate that a resource (such as a thumbnail or an icon) is not present on the device.
 
 ERROR_SEM_TIMEOUT0x80070079 
May be used to indicate that the device has stopped responding (hung). The device may need to be manually reset.
 
 ERROR_TIMEOUT0x800705B4 
May be used to indicate that the device has stopped responding (hung). The device may need to be manually reset.
 
 ERROR_UNSUPPORTED_TYPE0x8007065E 
May be used to indicate that the specified format is not supported by the device.
 
 ERROR_WRITE_FAULT0x8007001D 
May be used to indicate that the application was unable to send the requested amount of data to the device.
 
 WSAETIMEDOUT0x8007274c 
For an MTP/IP device, indicates that the connection to the device has timed out. The device may need to be manually reconnected.
 
*/

        /*
        0x80042003 0x2003 Session Not Open Indicates that the session handle of the operation is not a currently open session. This indicates an internal error in the MTP stack. 
0x80042004 0x2004 Invalid TransactionID Indicates that the TransactionID is zero or does not refer to a valid transaction. This indicates an internal error in the MTP stack. 
0x80042005 0x2005 Operation Not Supported Indicates that the operation code appears to be a valid code, but the device does not support the operation. This indicates an internal error in the MTP stack. 
0x80042006 0x2006 Parameter Not Supported Indicates that a non-zero parameter was specified in conjunction with the operation, and the parameter is not used for that operation. This indicates an internal error in the MTP stack. 
0x80042007 0x2007 Incomplete Transfer Indicates that the transfer did not complete, and any data transferred should be discarded. This response does not correspond to a cancelled transaction. 
0x80042008 0x2008 Invalid StorageID Indicates that a storage ID sent with an operation does not refer to an actual valid store that is present on the device. This indicates an internal error in the MTP stack. 
0x80042009 0x2009 Invalid ObjectHandle Indicates that an object handle does not refer to an actual object that is present on the device. The application should enumerate the storages again. 
0x8004200A 0x200A DeviceProp Not Supported Indicates that the device property code appears to be a valid code, but that property is not supported by the device. This indicates an internal error in the MTP stack. 
0x8004200B 0x200B Invalid ObjectFormatCode Indicates that the device does not support the particular object format code supplied in the given context. 
0x80042012 0x2012 Partial Deletion Indicates that only a subset of the storages indicated for deletion were actually deleted, because some were write-protected or were on stores that are read-only. 
0x80042013 0x2013 Store Not Available Indicates that the store (or the store that contains the indicated object) is not physically available. This can be caused by media ejection. This response shall not be used to indicate that the store is busy. 
0x80042014 0x2014 Specification By Format Unsupported Indicates that the operation attempted to specify action only on objects of a particular format, and that capability is not supported. The operation should be attempted again without specifying by format. Any response of this nature infers that any future attempt to specify by format with the indicated operation will result in the same response. This indicates an internal error in the MTP stack. 
0x80042015 0x2015 No Valid ObjectInfo Indicates that the host did not provide valid object info to device before transferring the object. This indicates an internal error in the MTP stack. 
0x80042016 0x2016 Invalid Code Format Indicates that the data code does not have the correct format, and is therefore not valid. This indicates an internal error in the MTP stack. 
0x80042017 0x2017 Unknown Vendor Code Device does not know how to handle the vendor extended code. 
0x8004201A 0x201A Invalid ParentObject Indicates that the object is not a valid parent object. This indicates an internal error in the MTP stack. 
0x8004201B 0x201B Invalid DeviceProp Format Indicates that an attempt was made to set a device property, but the data is not of the correct size or format. This indicates an internal error in the MTP stack. 
0x8004201C 0x201C Invalid DeviceProp Value Indicates that an attempt was made to set a device property to a value that is not allowed by the device. This indicates an internal error in the MTP stack 
0x8004201E 0x201E Session Already Open Indicates that the host tried to open session while a session is already open. This indicates an internal error in the MTP stack. 
0x8004201F 0x201F Transaction Cancelled May be used to indicate that the operation was interrupted due to manual cancellation. 
0x80042020 0x2020 Specification of Destination Unsupported Indicates that device does not support the specification of destination by the host. This indicates an internal error in the MTP stack. 
0x8004A801 0xA801 Invalid_ObjectPropCode Indicates that the device does not support the sent Object Property Code in this context. This indicates an internal error in the MTP stack. 
0x8004A802 0xA802 Invalid_ObjectProp_Format Indicates that an object property sent to the device is in an unsupported size or type. This indicates an internal error in the MTP stack. 
0x8004A803 0xA803 Invalid_ObjectProp_Value Indicates that an object property sent to the device is the correct type, but contains a value that is not supported. This indicates an internal error in the MTP stack. 
0x8004A804 0xA804 Invalid_ObjectReference Indicates that a sent Object Reference is not valid. Either the reference contains an object handle not present on the device, or the reference attempting to be set is unsupported in context. This can be due to an error in the MTP stack or due to application using a stale storage object. 
0x8004A806 0xA806 Invalid_Dataset Indicates that the dataset sent in the data phase of this operation is invalid. This indicates an internal error in the MTP stack. 
0x8004A807 0xA807 Object_Too_Large Indicates that the object desired to be sent cannot be stored in the file system of the device. This shall not be returned when there is insufficient space on the storage. 
0x8004A301 0xA301 Invalid_ServiceID Indicates that a service ID sent with an operation does not refer to an actual valid service that is present on the device. This indicates an internal error in the MTP stack. 
0x8004A302 0xA302 Invalid_ServicePropCode Indicates that the device does not support the sent Service Property Code in this context. This indicates an internal error in the MTP stack. 

        */
    }
}
