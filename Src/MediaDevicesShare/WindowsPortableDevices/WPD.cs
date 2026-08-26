namespace MediaDevices.Internal;

[FindFieldsGeneratorAttribute]
internal static partial class WPD
{
/****************************************************************************
 * This section declares WPD guids used in PnP
 ****************************************************************************/
    //
    // GUID_DEVINTERFACE_WPD
    //   This GUID is used to identify devices / drivers that support the WPD DDI.
    //   The WPD Class Extension component enables this mediaDevice interface for WPD Drivers that use it. Clients use this PnP interface when registering for PnP mediaDevice arrival messages for WPD devices.
    public static Guid GUID_DEVINTERFACE_WPD = new(0x6AC27878, 0xA6FA, 0x4155, 0xBA, 0x85, 0xF9, 0x8F, 0x49, 0x1D, 0x4F, 0x33);

    //
    // GUID_DEVINTERFACE_WPD_PRIVATE
    //   This GUID is used to identify devices / drivers that can be used only by a specialized WPD client and will not show up in normal WPD enumeration.
    //   Devices identified with this interface cannot be used with normal WPD applications. Generic WPD drivers and clients should not use this interface.
    public static Guid GUID_DEVINTERFACE_WPD_PRIVATE = new(0xBA0C718F, 0x4DED, 0x49B7, 0xBD, 0xD3, 0xFA, 0xBE, 0x28, 0x66, 0x12, 0x11);

    //
    // GUID_DEVINTERFACE_WPD_SERVICE
    //   This GUID is used to identify services that support the WPD Services DDI.
    //   The WPD Class Extension component enables this mediaDevice interface for WPD Services that use it. Clients use this PnP interface when registering for PnP mediaDevice arrival messages for ALL WPD services. To register for specific categories of services, client should use the service category or service implements GUID.
    public static Guid GUID_DEVINTERFACE_WPD_SERVICE = new(0x9EF44F80, 0x3D64, 0x4246, 0xA6, 0xAA, 0x20, 0x6F, 0x32, 0x8D, 0x1E, 0xDC);

/****************************************************************************
 * This section declares WPD defines
 ****************************************************************************/
/****************************************************************************
 * This section defines flags used in API arguments
 ****************************************************************************/
/****************************************************************************
 * This section declares WPD specific Errors
 ****************************************************************************/
/**************************************************************************** 
 * This section defines all WPD Events
 ****************************************************************************/
    //
    // WPD_EVENT_NOTIFICATION
    //   This GUID is used to identify all WPD driver events to the event sub-system. The driver uses this as the GUID identifier when it queues an event with IWdfDevice::PostEvent(). Applications never use this value.
    public static Guid EVENT_NOTIFICATION = new(0x2BA2E40A, 0x6B4C, 0x4295, 0xBB, 0x43, 0x26, 0x32, 0x2B, 0x99, 0xAE, 0xB2);

    //
    // WPD_EVENT_OBJECT_ADDED
    //   This event is sent after a new object is available on the mediaDevice.
    public static Guid EVENT_OBJECT_ADDED = new(0xA726DA95, 0xE207, 0x4B02, 0x8D, 0x44, 0xBE, 0xF2, 0xE8, 0x6C, 0xBF, 0xFC);

    //
    // WPD_EVENT_OBJECT_REMOVED
    //   This event is sent after a previously existing object has been removed from the mediaDevice.
    public static Guid EVENT_OBJECT_REMOVED = new(0xBE82AB88, 0xA52C, 0x4823, 0x96, 0xE5, 0xD0, 0x27, 0x26, 0x71, 0xFC, 0x38);

    //
    // WPD_EVENT_OBJECT_UPDATED
    //   This event is sent after an object has been updated such that any connected client should refresh its view of that object.
    public static Guid EVENT_OBJECT_UPDATED = new(0x1445A759, 0x2E01, 0x485D, 0x9F, 0x27, 0xFF, 0x07, 0xDA, 0xE6, 0x97, 0xAB);

    //
    // WPD_EVENT_DEVICE_RESET
    //   This event indicates that the mediaDevice is about to be reset, and all connected clients should close their connection to the mediaDevice.
    public static Guid EVENT_DEVICE_RESET = new(0x7755CF53, 0xC1ED, 0x44F3, 0xB5, 0xA2, 0x45, 0x1E, 0x2C, 0x37, 0x6B, 0x27);

    //
    // WPD_EVENT_DEVICE_CAPABILITIES_UPDATED
    //   This event indicates that the mediaDevice capabilities have changed. Clients should re-query the mediaDevice if they have made any decisions based on mediaDevice capabilities.
    public static Guid EVENT_DEVICE_CAPABILITIES_UPDATED = new(0x36885AA1, 0xCD54, 0x4DAA, 0xB3, 0xD0, 0xAF, 0xB3, 0xE0, 0x3F, 0x59, 0x99);

    //
    // WPD_EVENT_STORAGE_FORMAT
    //   This event indicates the progress of a format operation on a storage object.
    public static Guid EVENT_STORAGE_FORMAT = new(0x3782616B, 0x22BC, 0x4474, 0xA2, 0x51, 0x30, 0x70, 0xF8, 0xD3, 0x88, 0x57);

    //
    // WPD_EVENT_OBJECT_TRANSFER_REQUESTED
    //   This event is sent to request an application to transfer a particular object from the mediaDevice.
    public static Guid EVENT_OBJECT_TRANSFER_REQUESTED = new(0x8D16A0A1, 0xF2C6, 0x41DA, 0x8F, 0x19, 0x5E, 0x53, 0x72, 0x1A, 0xDB, 0xF2);

    //
    // WPD_EVENT_DEVICE_REMOVED
    //   This event is sent when a driver for a mediaDevice is being unloaded. This is typically a result of the mediaDevice being unplugged.
    public static Guid EVENT_DEVICE_REMOVED = new(0xE4CBCA1B, 0x6918, 0x48B9, 0x85, 0xEE, 0x02, 0xBE, 0x7C, 0x85, 0x0A, 0xF9);

    //
    // WPD_EVENT_SERVICE_METHOD_COMPLETE
    //   This event is sent when a driver has completed invoking a service method. This event must be sent even when the method fails.
    public static Guid EVENT_SERVICE_METHOD_COMPLETE = new(0x8A33F5F8, 0x0ACC, 0x4D9B, 0x9C, 0xC4, 0x11, 0x2D, 0x35, 0x3B, 0x86, 0xCA);

/****************************************************************************
 * This section defines all WPD content types
 ****************************************************************************/
    //
    // WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT
    //   Indicates this object represents a functional object, not content data on the mediaDevice.
    public static Guid CONTENT_TYPE_FUNCTIONAL_OBJECT = new(0x99ED0160, 0x17FF, 0x4C44, 0x9D, 0x98, 0x1D, 0x7A, 0x6F, 0x94, 0x19, 0x21);

    //
    // WPD_CONTENT_TYPE_FOLDER
    //   Indicates this object is a folder.
    public static Guid CONTENT_TYPE_FOLDER = new(0x27E2E392, 0xA111, 0x48E0, 0xAB, 0x0C, 0xE1, 0x77, 0x05, 0xA0, 0x5F, 0x85);

    //
    // WPD_CONTENT_TYPE_IMAGE
    //   Indicates this object represents image data (e.g. a JPEG file)
    public static Guid CONTENT_TYPE_IMAGE = new(0xef2107d5, 0xa52a, 0x4243, 0xa2, 0x6b, 0x62, 0xd4, 0x17, 0x6d, 0x76, 0x03);

    //
    // WPD_CONTENT_TYPE_DOCUMENT
    //   Indicates this object represents document data (e.g. a MS WORD file, TEXT file, etc.)
    public static Guid CONTENT_TYPE_DOCUMENT = new(0x680ADF52, 0x950A, 0x4041, 0x9B, 0x41, 0x65, 0xE3, 0x93, 0x64, 0x81, 0x55);

    //
    // WPD_CONTENT_TYPE_CONTACT
    //   Indicates this object represents contact data (e.g. name/number, or a VCARD file)
    public static Guid CONTENT_TYPE_CONTACT = new(0xEABA8313, 0x4525, 0x4707, 0x9F, 0x0E, 0x87, 0xC6, 0x80, 0x8E, 0x94, 0x35);

    //
    // WPD_CONTENT_TYPE_CONTACT_GROUP
    //   Indicates this object represents a group of contacts.
    public static Guid CONTENT_TYPE_CONTACT_GROUP = new(0x346B8932, 0x4C36, 0x40D8, 0x94, 0x15, 0x18, 0x28, 0x29, 0x1F, 0x9D, 0xE9);

    //
    // WPD_CONTENT_TYPE_AUDIO
    //   Indicates this object represents audio data (e.g. a WMA or MP3 file)
    public static Guid CONTENT_TYPE_AUDIO = new(0x4AD2C85E, 0x5E2D, 0x45E5, 0x88, 0x64, 0x4F, 0x22, 0x9E, 0x3C, 0x6C, 0xF0);

    //
    // WPD_CONTENT_TYPE_VIDEO
    //   Indicates this object represents video data (e.g. a WMV or AVI file)
    public static Guid CONTENT_TYPE_VIDEO = new(0x9261B03C, 0x3D78, 0x4519, 0x85, 0xE3, 0x02, 0xC5, 0xE1, 0xF5, 0x0B, 0xB9);

    //
    // WPD_CONTENT_TYPE_TELEVISION
    //   Indicates this object represents a television recording.
    public static Guid CONTENT_TYPE_TELEVISION = new(0x60A169CF, 0xF2AE, 0x4E21, 0x93, 0x75, 0x96, 0x77, 0xF1, 0x1C, 0x1C, 0x6E);

    //
    // WPD_CONTENT_TYPE_PLAYLIST
    //   Indicates this object represents a playlist.
    public static Guid CONTENT_TYPE_PLAYLIST = new(0x1A33F7E4, 0xAF13, 0x48F5, 0x99, 0x4E, 0x77, 0x36, 0x9D, 0xFE, 0x04, 0xA3);

    //
    // WPD_CONTENT_TYPE_MIXED_CONTENT_ALBUM
    //   Indicates this object represents an album, which may contain objects of different content types (typically, MUSIC, IMAGE and VIDEO).
    public static Guid CONTENT_TYPE_MIXED_CONTENT_ALBUM = new(0x00F0C3AC, 0xA593, 0x49AC, 0x92, 0x19, 0x24, 0xAB, 0xCA, 0x5A, 0x25, 0x63);

    //
    // WPD_CONTENT_TYPE_AUDIO_ALBUM
    //   Indicates this object represents an audio album.
    public static Guid CONTENT_TYPE_AUDIO_ALBUM = new(0xAA18737E, 0x5009, 0x48FA, 0xAE, 0x21, 0x85, 0xF2, 0x43, 0x83, 0xB4, 0xE6);

    //
    // WPD_CONTENT_TYPE_IMAGE_ALBUM
    //   Indicates this object represents an image album.
    public static Guid CONTENT_TYPE_IMAGE_ALBUM = new(0x75793148, 0x15F5, 0x4A30, 0xA8, 0x13, 0x54, 0xED, 0x8A, 0x37, 0xE2, 0x26);

    //
    // WPD_CONTENT_TYPE_VIDEO_ALBUM
    //   Indicates this object represents a video album.
    public static Guid CONTENT_TYPE_VIDEO_ALBUM = new(0x012B0DB7, 0xD4C1, 0x45D6, 0xB0, 0x81, 0x94, 0xB8, 0x77, 0x79, 0x61, 0x4F);

    //
    // WPD_CONTENT_TYPE_MEMO
    //   Indicates this object represents memo data
    public static Guid CONTENT_TYPE_MEMO = new(0x9CD20ECF, 0x3B50, 0x414F, 0xA6, 0x41, 0xE4, 0x73, 0xFF, 0xE4, 0x57, 0x51);

    //
    // WPD_CONTENT_TYPE_EMAIL
    //   Indicates this object represents e-mail data
    public static Guid CONTENT_TYPE_EMAIL = new(0x8038044A, 0x7E51, 0x4F8F, 0x88, 0x3D, 0x1D, 0x06, 0x23, 0xD1, 0x45, 0x33);

    //
    // WPD_CONTENT_TYPE_APPOINTMENT
    //   Indicates this object represents an appointment in a calendar
    public static Guid CONTENT_TYPE_APPOINTMENT = new(0x0FED060E, 0x8793, 0x4B1E, 0x90, 0xC9, 0x48, 0xAC, 0x38, 0x9A, 0xC6, 0x31);

    //
    // WPD_CONTENT_TYPE_TASK
    //   Indicates this object represents a task for tracking (e.g. a TODO list)
    public static Guid CONTENT_TYPE_TASK = new(0x63252F2C, 0x887F, 0x4CB6, 0xB1, 0xAC, 0xD2, 0x98, 0x55, 0xDC, 0xEF, 0x6C);

    //
    // WPD_CONTENT_TYPE_PROGRAM
    //   Indicates this object represents a file that can be run. This could be a script, executable and so on.
    public static Guid CONTENT_TYPE_PROGRAM = new(0xD269F96A, 0x247C, 0x4BFF, 0x98, 0xFB, 0x97, 0xF3, 0xC4, 0x92, 0x20, 0xE6);

    //
    // WPD_CONTENT_TYPE_GENERIC_FILE
    //   Indicates this object represents a file that does not fall into any of the other predefined WPD types for files.
    public static Guid CONTENT_TYPE_GENERIC_FILE = new(0x0085E0A6, 0x8D34, 0x45D7, 0xBC, 0x5C, 0x44, 0x7E, 0x59, 0xC7, 0x3D, 0x48);

    //
    // WPD_CONTENT_TYPE_CALENDAR
    //   Indicates this object represents a calender
    public static Guid CONTENT_TYPE_CALENDAR = new(0xA1FD5967, 0x6023, 0x49A0, 0x9D, 0xF1, 0xF8, 0x06, 0x0B, 0xE7, 0x51, 0xB0);

    //
    // WPD_CONTENT_TYPE_GENERIC_MESSAGE
    //   Indicates this object represents a message (e.g. SMS message, E-Mail message, etc.)
    public static Guid CONTENT_TYPE_GENERIC_MESSAGE = new(0xE80EAAF8, 0xB2DB, 0x4133, 0xB6, 0x7E, 0x1B, 0xEF, 0x4B, 0x4A, 0x6E, 0x5F);

    //
    // WPD_CONTENT_TYPE_NETWORK_ASSOCIATION
    //   Indicates this object represents an association between a host and a mediaDevice.
    public static Guid CONTENT_TYPE_NETWORK_ASSOCIATION = new(0x031DA7EE, 0x18C8, 0x4205, 0x84, 0x7E, 0x89, 0xA1, 0x12, 0x61, 0xD0, 0xF3);

    //
    // WPD_CONTENT_TYPE_CERTIFICATE
    //   Indicates this object represents certificate used for authentication.
    public static Guid CONTENT_TYPE_CERTIFICATE = new(0xDC3876E8, 0xA948, 0x4060, 0x90, 0x50, 0xCB, 0xD7, 0x7E, 0x8A, 0x3D, 0x87);

    //
    // WPD_CONTENT_TYPE_WIRELESS_PROFILE
    //   Indicates this object represents wireless network access information.
    public static Guid CONTENT_TYPE_WIRELESS_PROFILE = new(0x0BAC070A, 0x9F5F, 0x4DA4, 0xA8, 0xF6, 0x3D, 0xE4, 0x4D, 0x68, 0xFD, 0x6C);

    //
    // WPD_CONTENT_TYPE_MEDIA_CAST
    //   Indicates this object represents a media cast. A media cast object can be though of as a container object that groups related content, similar to how a playlist groups songs to play. Often, a media cast object is used to group media content originally published online.
    public static Guid CONTENT_TYPE_MEDIA_CAST = new(0x5E88B3CC, 0x3E65, 0x4E62, 0xBF, 0xFF, 0x22, 0x94, 0x95, 0x25, 0x3A, 0xB0);

    //
    // WPD_CONTENT_TYPE_SECTION
    //   Indicates this object describes a section of data contained in another object. The WPD_OBJECT_REFERENCES property indicates which object contains the actual data.
    public static Guid CONTENT_TYPE_SECTION = new(0x821089F5, 0x1D91, 0x4DC9, 0xBE, 0x3C, 0xBB, 0xB1, 0xB3, 0x5B, 0x18, 0xCE);

    //
    // WPD_CONTENT_TYPE_UNSPECIFIED
    //   Indicates this object doesn't fall into the predefined WPD content types
    public static Guid CONTENT_TYPE_UNSPECIFIED = new(0x28D8D31E, 0x249C, 0x454E, 0xAA, 0xBC, 0x34, 0x88, 0x31, 0x68, 0xE6, 0x34);

    //
    // WPD_CONTENT_TYPE_ALL
    //   This content type is only valid as a parameter to API functions and driver commands. It should not be reported as a supported content type by the driver.
    public static Guid CONTENT_TYPE_ALL = new(0x80E170D2, 0x1055, 0x4A3E, 0xB9, 0x52, 0x82, 0xCC, 0x4F, 0x8A, 0x86, 0x89);

/**************************************************************************** 
 * This section defines all WPD Functional Categories
 ****************************************************************************/
    //
    // WPD_FUNCTIONAL_CATEGORY_DEVICE
    // Used for the mediaDevice object, which is always the top-most object of the mediaDevice. 
    public static Guid FUNCTIONAL_CATEGORY_DEVICE = new(0x08EA466B, 0xE3A4, 0x4336, 0xA1, 0xF3, 0xA4, 0x4D, 0x2B, 0x5C, 0x43, 0x8C);

    //
    // WPD_FUNCTIONAL_CATEGORY_STORAGE
    // Indicates this object encapsulates storage functionality on the mediaDevice (e.g. memory cards, internal memory) 
    public static Guid FUNCTIONAL_CATEGORY_STORAGE = new(0x23F05BBC, 0x15DE, 0x4C2A, 0xA5, 0x5B, 0xA9, 0xAF, 0x5C, 0xE4, 0x12, 0xEF);

    //
    // WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE
    // Indicates this object encapsulates still image capture functionality on the mediaDevice (e.g. camera or camera attachment) 
    public static Guid FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE = new(0x613CA327, 0xAB93, 0x4900, 0xB4, 0xFA, 0x89, 0x5B, 0xB5, 0x87, 0x4B, 0x79);

    //
    // WPD_FUNCTIONAL_CATEGORY_AUDIO_CAPTURE
    // Indicates this object encapsulates audio capture functionality on the mediaDevice (e.g. voice recorder or other audio recording component) 
    public static Guid FUNCTIONAL_CATEGORY_AUDIO_CAPTURE = new(0x3F2A1919, 0xC7C2, 0x4A00, 0x85, 0x5D, 0xF5, 0x7C, 0xF0, 0x6D, 0xEB, 0xBB);

    //
    // WPD_FUNCTIONAL_CATEGORY_VIDEO_CAPTURE
    // Indicates this object encapsulates video capture functionality on the mediaDevice (e.g. video recorder or video recording component) 
    public static Guid FUNCTIONAL_CATEGORY_VIDEO_CAPTURE = new(0xE23E5F6B, 0x7243, 0x43AA, 0x8D, 0xF1, 0x0E, 0xB3, 0xD9, 0x68, 0xA9, 0x18);

    //
    // WPD_FUNCTIONAL_CATEGORY_SMS
    // Indicates this object encapsulates SMS sending functionality on the mediaDevice (not the receiving or saved SMS messages since those are represented as content objects on the mediaDevice) 
    public static Guid FUNCTIONAL_CATEGORY_SMS = new(0x0044A0B1, 0xC1E9, 0x4AFD, 0xB3, 0x58, 0xA6, 0x2C, 0x61, 0x17, 0xC9, 0xCF);

    //
    // WPD_FUNCTIONAL_CATEGORY_RENDERING_INFORMATION
    // Indicates this object provides information about the rendering characteristics of the mediaDevice. 
    public static Guid FUNCTIONAL_CATEGORY_RENDERING_INFORMATION = new(0x08600BA4, 0xA7BA, 0x4A01, 0xAB, 0x0E, 0x00, 0x65, 0xD0, 0xA3, 0x56, 0xD3);

    //
    // WPD_FUNCTIONAL_CATEGORY_NETWORK_CONFIGURATION
    // Indicates this object encapsulates network configuration functionality on the mediaDevice (e.g. WiFi Profiles, Partnerships). 
    public static Guid FUNCTIONAL_CATEGORY_NETWORK_CONFIGURATION = new(0x48F4DB72, 0x7C6A, 0x4AB0, 0x9E, 0x1A, 0x47, 0x0E, 0x3C, 0xDB, 0xF2, 0x6A);

    //
    // WPD_FUNCTIONAL_CATEGORY_ALL
    // This functional category is only valid as a parameter to API functions and driver commands. It should not be reported as a supported functional category by the driver. 
    public static Guid FUNCTIONAL_CATEGORY_ALL = new(0x2D8A6512, 0xA74C, 0x448E, 0xBA, 0x8A, 0xF4, 0xAC, 0x07, 0xC4, 0x93, 0x99);

/**************************************************************************** 
 * This section defines all WPD Formats
 ****************************************************************************/
    //
    // WPD_OBJECT_FORMAT_ICON
    //   Standard Windows ICON format 
    public static Guid OBJECT_FORMAT_ICON = new(0x077232ED, 0x102C, 0x4638, 0x9C, 0x22, 0x83, 0xF1, 0x42, 0xBF, 0xC8, 0x22);

    //
    // WPD_OBJECT_FORMAT_M4A
    //   Audio file format 
    public static Guid OBJECT_FORMAT_M4A = new(0x30ABA7AC, 0x6FFD, 0x4C23, 0xA3, 0x59, 0x3E, 0x9B, 0x52, 0xF3, 0xF1, 0xC8);

    //
    // WPD_OBJECT_FORMAT_NETWORK_ASSOCIATION
    //   Network Association file format. 
    public static Guid OBJECT_FORMAT_NETWORK_ASSOCIATION = new(0xB1020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_X509V3CERTIFICATE
    //   X.509 V3 Certificate file format. 
    public static Guid OBJECT_FORMAT_X509V3CERTIFICATE = new(0xB1030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MICROSOFT_WFC
    //   Windows Connect Now file format. 
    public static Guid OBJECT_FORMAT_MICROSOFT_WFC = new(0xB1040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_3GPA
    //   Audio file format 
    public static Guid OBJECT_FORMAT_3GPA = new(0xE5172730, 0xF971, 0x41EF, 0xA1, 0x0B, 0x22, 0x71, 0xA0, 0x01, 0x9D, 0x7A);

    //
    // WPD_OBJECT_FORMAT_3G2A
    //   Audio file format 
    public static Guid OBJECT_FORMAT_3G2A = new(0x1A11202D, 0x8759, 0x4E34, 0xBA, 0x5E, 0xB1, 0x21, 0x10, 0x87, 0xEE, 0xE4);

    //
    // WPD_OBJECT_FORMAT_ALL
    //   This format is only valid as a parameter to API functions and driver commands. It should not be reported as a supported format by the driver. 
    public static Guid OBJECT_FORMAT_ALL = new(0xC1F62EB2, 0x4BB3, 0x479C, 0x9C, 0xFA, 0x05, 0xB5, 0xF3, 0xA5, 0x7B, 0x22);

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_NULL 
 *
 * This category is used exclusively for the NULL property key define.
 ****************************************************************************/
    public static Guid CATEGORY_NULL = new(0x00000000, 0x0000, 0x0000, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

    //
    // WPD_PROPERTY_NULL  
    //   [ VT_EMPTY ] A NULL property key.
    public static PropertyKey PROPERTY_NULL = new()
    {
        fmtid = CATEGORY_NULL,
        pid = 0
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_OBJECT_PROPERTIES_V1 
 *
 * This category is for all common object properties.
 ****************************************************************************/
    public static Guid OBJECT_PROPERTIES_V1 = new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C);

    //
    // WPD_OBJECT_CONTENT_TYPE  
    //   [ VT_CLSID ] The abstract type for the object content, indicating the kinds of properties and data that may be supported on the object.
    public static PropertyKey OBJECT_CONTENT_TYPE = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_OBJECT_REFERENCES  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of ObjectIDs.
    public static PropertyKey OBJECT_REFERENCES = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 14
    };

    //
    // WPD_OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID  
    //   [ VT_LPWSTR ] Indicates the Object ID of the closest functional object ancestor. For example, objects that represent files/folders under a Storage functional object, will have this property set to the object ID of the storage functional object.
    public static PropertyKey OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 23
    };

    //
    // WPD_OBJECT_GENERATE_THUMBNAIL_FROM_RESOURCE  
    //   [ VT_BOOL ] Indicates whether the thumbnail for this object should be generated from the default resource.
    public static PropertyKey OBJECT_GENERATE_THUMBNAIL_FROM_RESOURCE = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 24
    };

    //
    // WPD_OBJECT_HINT_LOCATION_DISPLAY_NAME  
    //   [ VT_LPWSTR ] If this object appears as a hint location, this property indicates the hint-specific name to display instead of the object name.
    public static PropertyKey OBJECT_HINT_LOCATION_DISPLAY_NAME = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 25
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_OBJECT_PROPERTIES_V2 
 *
 * This category is for all common object properties.
 ****************************************************************************/
    public static Guid OBJECT_PROPERTIES_V2 = new(0x0373CD3D, 0x4A46, 0x40D7, 0xB4, 0xD8, 0x73, 0xE8, 0xDA, 0x74, 0xE7, 0x75);

    //
    // WPD_OBJECT_SUPPORTED_UNITS  
    //   [ VT_UI4 ] Indicates the units supported on this object.
    public static PropertyKey OBJECT_SUPPORTED_UNITS = new()
    {
        fmtid = OBJECT_PROPERTIES_V2,
        pid = 2
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_FUNCTIONAL_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all functional objects.
 ****************************************************************************/
    public static Guid FUNCTIONAL_OBJECT_PROPERTIES_V1 = new(0x8F052D93, 0xABCA, 0x4FC5, 0xA5, 0xAC, 0xB0, 0x1D, 0xF4, 0xDB, 0xE5, 0x98);

    //
    // WPD_FUNCTIONAL_OBJECT_CATEGORY  
    //   [ VT_CLSID ] Indicates the object's functional category.
    public static PropertyKey FUNCTIONAL_OBJECT_CATEGORY = new()
    {
        fmtid = FUNCTIONAL_OBJECT_PROPERTIES_V1,
        pid = 2
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_STORAGE_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STORAGE.
 ****************************************************************************/
    public static Guid STORAGE_OBJECT_PROPERTIES_V1 = new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A);

    //
    // WPD_STORAGE_TYPE  
    //   [ VT_UI4 ] Indicates the type of storage e.g. fixed, removable etc.
    public static PropertyKey STORAGE_TYPE = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_STORAGE_FILE_SYSTEM_TYPE  
    //   [ VT_LPWSTR ] Indicates the file system type e.g. "FAT32" or "NTFS" or "My Special File System"
    public static PropertyKey STORAGE_FILE_SYSTEM_TYPE = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_STORAGE_CAPACITY  
    //   [ VT_UI8 ] Indicates the total storage capacity in bytes.
    public static PropertyKey STORAGE_CAPACITY = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_STORAGE_FREE_SPACE_IN_BYTES  
    //   [ VT_UI8 ] Indicates the available space in bytes.
    public static PropertyKey STORAGE_FREE_SPACE_IN_BYTES = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_STORAGE_FREE_SPACE_IN_OBJECTS  
    //   [ VT_UI8 ] Indicates the available space in objects e.g. available slots on a SIM card.
    public static PropertyKey STORAGE_FREE_SPACE_IN_OBJECTS = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_STORAGE_DESCRIPTION  
    //   [ VT_LPWSTR ] Contains a description of the storage.
    public static PropertyKey STORAGE_DESCRIPTION = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_STORAGE_SERIAL_NUMBER  
    //   [ VT_LPWSTR ] Contains the serial number of the storage.
    public static PropertyKey STORAGE_SERIAL_NUMBER = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_STORAGE_MAX_OBJECT_SIZE  
    //   [ VT_UI8 ] Specifies the maximum size of a single object (in bytes) that can be placed on this storage.
    public static PropertyKey STORAGE_MAX_OBJECT_SIZE = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_STORAGE_CAPACITY_IN_OBJECTS  
    //   [ VT_UI8 ] Indicates the total storage capacity in objects e.g. available slots on a SIM card.
    public static PropertyKey STORAGE_CAPACITY_IN_OBJECTS = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_STORAGE_ACCESS_CAPABILITY  
    //   [ VT_UI4 ] This property identifies any write-protection that globally affects this storage. This takes precedence over access specified on individual objects.
    public static PropertyKey STORAGE_ACCESS_CAPABILITY = new()
    {
        fmtid = STORAGE_OBJECT_PROPERTIES_V1,
        pid = 11
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_NETWORK_ASSOCIATION_PROPERTIES_V1 
 *
 * This category is for properties common to all network association objects.
 ****************************************************************************/
    public static Guid NETWORK_ASSOCIATION_PROPERTIES_V1 = new(0xE4C93C1F, 0xB203, 0x43F1, 0xA1, 0x00, 0x5A, 0x07, 0xD1, 0x1B, 0x02, 0x74);

    //
    // WPD_NETWORK_ASSOCIATION_HOST_NETWORK_IDENTIFIERS  
    //   [ VT_VECTOR | VT_UI1 ] The list of EUI-64 host identifiers valid for this association.
    public static PropertyKey NETWORK_ASSOCIATION_HOST_NETWORK_IDENTIFIERS = new()
    {
        fmtid = NETWORK_ASSOCIATION_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_NETWORK_ASSOCIATION_X509V3SEQUENCE  
    //   [ VT_VECTOR | VT_UI1 ] The sequence of X.509 v3 certificates to be provided for TLS server authentication.
    public static PropertyKey NETWORK_ASSOCIATION_X509V3SEQUENCE = new()
    {
        fmtid = NETWORK_ASSOCIATION_PROPERTIES_V1,
        pid = 3
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE
 ****************************************************************************/
    public static Guid STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1 = new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60);

    //
    // WPD_STILL_IMAGE_CAPTURE_RESOLUTION  
    //   [ VT_LPWSTR ] Controls the size of the image dimensions to capture in pixel width and height.
    public static PropertyKey STILL_IMAGE_CAPTURE_RESOLUTION = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_STILL_IMAGE_CAPTURE_FORMAT  
    //   [ VT_CLSID ] Controls the format of the image to capture.
    public static PropertyKey STILL_IMAGE_CAPTURE_FORMAT = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_STILL_IMAGE_COMPRESSION_SETTING  
    //   [ VT_UI8 ] Controls the mediaDevice-specific quality setting.
    public static PropertyKey STILL_IMAGE_COMPRESSION_SETTING = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_STILL_IMAGE_WHITE_BALANCE  
    //   [ VT_UI4 ] Controls how the mediaDevice weights color channels.
    public static PropertyKey STILL_IMAGE_WHITE_BALANCE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_STILL_IMAGE_RGB_GAIN  
    //   [ VT_LPWSTR ] Controls the RGB gain.
    public static PropertyKey STILL_IMAGE_RGB_GAIN = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_STILL_IMAGE_FNUMBER  
    //   [ VT_UI4 ] Controls the aperture of the lens.
    public static PropertyKey STILL_IMAGE_FNUMBER = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_STILL_IMAGE_FOCAL_LENGTH  
    //   [ VT_UI4 ] Controls the 35mm equivalent focal length.
    public static PropertyKey STILL_IMAGE_FOCAL_LENGTH = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_STILL_IMAGE_FOCUS_DISTANCE  
    //   [ VT_UI4 ] This property corresponds to the focus distance in millimeters
    public static PropertyKey STILL_IMAGE_FOCUS_DISTANCE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_STILL_IMAGE_FOCUS_MODE  
    //   [ VT_UI4 ] Identifies the focusing mode used by the mediaDevice for image capture.
    public static PropertyKey STILL_IMAGE_FOCUS_MODE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_STILL_IMAGE_EXPOSURE_METERING_MODE  
    //   [ VT_UI4 ] Identifies the exposure metering mode used by the mediaDevice for image capture.
    public static PropertyKey STILL_IMAGE_EXPOSURE_METERING_MODE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_STILL_IMAGE_FLASH_MODE  
    //   [ VT_UI4 ] 
    public static PropertyKey STILL_IMAGE_FLASH_MODE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_STILL_IMAGE_EXPOSURE_TIME  
    //   [ VT_UI4 ] Controls the shutter speed of the mediaDevice.
    public static PropertyKey STILL_IMAGE_EXPOSURE_TIME = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 13
    };

    //
    // WPD_STILL_IMAGE_EXPOSURE_PROGRAM_MODE  
    //   [ VT_UI4 ] Controls the exposure program mode of the mediaDevice.
    public static PropertyKey STILL_IMAGE_EXPOSURE_PROGRAM_MODE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 14
    };

    //
    // WPD_STILL_IMAGE_EXPOSURE_INDEX  
    //   [ VT_UI4 ] Controls the emulation of film speed settings.
    public static PropertyKey STILL_IMAGE_EXPOSURE_INDEX = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 15
    };

    //
    // WPD_STILL_IMAGE_EXPOSURE_BIAS_COMPENSATION  
    //   [ VT_I4 ] Controls the adjustment of the auto exposure control.
    public static PropertyKey STILL_IMAGE_EXPOSURE_BIAS_COMPENSATION = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 16
    };

    //
    // WPD_STILL_IMAGE_CAPTURE_DELAY  
    //   [ VT_UI4 ] Controls the amount of time delay between the capture trigger and the actual data capture (in milliseconds).
    public static PropertyKey STILL_IMAGE_CAPTURE_DELAY = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 17
    };

    //
    // WPD_STILL_IMAGE_CAPTURE_MODE  
    //   [ VT_UI4 ] Controls the type of still image capture.
    public static PropertyKey STILL_IMAGE_CAPTURE_MODE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 18
    };

    //
    // WPD_STILL_IMAGE_CONTRAST  
    //   [ VT_UI4 ] Controls the perceived contrast of captured images.
    public static PropertyKey STILL_IMAGE_CONTRAST = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 19
    };

    //
    // WPD_STILL_IMAGE_SHARPNESS  
    //   [ VT_UI4 ] Controls the perceived sharpness of the captured image.
    public static PropertyKey STILL_IMAGE_SHARPNESS = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 20
    };

    //
    // WPD_STILL_IMAGE_DIGITAL_ZOOM  
    //   [ VT_UI4 ] Controls the effective zoom ratio of a digital camera's acquired image scaled by a factor of 10.
    public static PropertyKey STILL_IMAGE_DIGITAL_ZOOM = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 21
    };

    //
    // WPD_STILL_IMAGE_EFFECT_MODE  
    //   [ VT_UI4 ] Controls the special effect mode of the capture.
    public static PropertyKey STILL_IMAGE_EFFECT_MODE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 22
    };

    //
    // WPD_STILL_IMAGE_BURST_NUMBER  
    //   [ VT_UI4 ] Controls the number of images that the mediaDevice will attempt to capture upon initiation of a burst operation.
    public static PropertyKey STILL_IMAGE_BURST_NUMBER = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 23
    };

    //
    // WPD_STILL_IMAGE_BURST_INTERVAL  
    //   [ VT_UI4 ] Controls the time delay between captures upon initiation of a burst operation.
    public static PropertyKey STILL_IMAGE_BURST_INTERVAL = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 24
    };

    //
    // WPD_STILL_IMAGE_TIMELAPSE_NUMBER  
    //   [ VT_UI4 ] Controls the number of images that the mediaDevice will attempt to capture upon initiation of a time-lapse capture.
    public static PropertyKey STILL_IMAGE_TIMELAPSE_NUMBER = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 25
    };

    //
    // WPD_STILL_IMAGE_TIMELAPSE_INTERVAL  
    //   [ VT_UI4 ] Controls the time delay between captures upon initiation of a time-lapse operation.
    public static PropertyKey STILL_IMAGE_TIMELAPSE_INTERVAL = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 26
    };

    //
    // WPD_STILL_IMAGE_FOCUS_METERING_MODE  
    //   [ VT_UI4 ] Controls which automatic focus mechanism is used by the mediaDevice.
    public static PropertyKey STILL_IMAGE_FOCUS_METERING_MODE = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 27
    };

    //
    // WPD_STILL_IMAGE_UPLOAD_URL  
    //   [ VT_LPWSTR ] Used to describe the URL that the mediaDevice may use to upload images upon capture.
    public static PropertyKey STILL_IMAGE_UPLOAD_URL = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 28
    };

    //
    // WPD_STILL_IMAGE_ARTIST  
    //   [ VT_LPWSTR ] Contains the owner/user of the mediaDevice, which may be inserted as meta-data into any images that are captured.
    public static PropertyKey STILL_IMAGE_ARTIST = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 29
    };

    //
    // WPD_STILL_IMAGE_CAMERA_MODEL  
    //   [ VT_LPWSTR ] Contains the model of the mediaDevice
    public static PropertyKey STILL_IMAGE_CAMERA_MODEL = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 30
    };

    //
    // WPD_STILL_IMAGE_CAMERA_MANUFACTURER  
    //   [ VT_LPWSTR ] Contains the manufacturer of the mediaDevice
    public static PropertyKey STILL_IMAGE_CAMERA_MANUFACTURER = new()
    {
        fmtid = STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1,
        pid = 31
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_RENDERING_INFORMATION_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_AUDIO_RENDERING_INFORMATION
 ****************************************************************************/
    public static Guid RENDERING_INFORMATION_OBJECT_PROPERTIES_V1 = new(0xC53D039F, 0xEE23, 0x4A31, 0x85, 0x90, 0x76, 0x39, 0x87, 0x98, 0x70, 0xB4);

    //
    // WPD_RENDERING_INFORMATION_PROFILES  
    //   [ VT_UNKNOWN ] IPortableDeviceValuesCollection, where each element indicates the property settings for a supported profile.
    public static PropertyKey RENDERING_INFORMATION_PROFILES = new()
    {
        fmtid = RENDERING_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPE  
    //   [ VT_UI4 ] Indicates whether a given entry (i.e. an IPortableDeviceValues) in WPD_RENDERING_INFORMATION_PROFILES relates to an Object or a Resource.
    public static PropertyKey RENDERING_INFORMATION_PROFILE_ENTRY_TYPE = new()
    {
        fmtid = RENDERING_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_RENDERING_INFORMATION_PROFILE_ENTRY_CREATABLE_RESOURCES  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection identifying the resources that can be created on an object with this rendering profile.
    public static PropertyKey RENDERING_INFORMATION_PROFILE_ENTRY_CREATABLE_RESOURCES = new()
    {
        fmtid = RENDERING_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 4
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CLIENT_INFORMATION_PROPERTIES_V1 
 *
 * 
 ****************************************************************************/
    public static Guid CLIENT_INFORMATION_PROPERTIES_V1 = new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59);

    //
    // WPD_CLIENT_NAME  
    //   [ VT_LPWSTR ] Specifies the name the client uses to identify itself.
    public static PropertyKey CLIENT_NAME = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_CLIENT_MAJOR_VERSION  
    //   [ VT_UI4 ] Specifies the major version of the client.
    public static PropertyKey CLIENT_MAJOR_VERSION = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_CLIENT_MINOR_VERSION  
    //   [ VT_UI4 ] Specifies the major version of the client.
    public static PropertyKey CLIENT_MINOR_VERSION = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_CLIENT_REVISION  
    //   [ VT_UI4 ] Specifies the revision (or build number) of the client.
    public static PropertyKey CLIENT_REVISION = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_CLIENT_WMDRM_APPLICATION_PRIVATE_KEY  
    //   [ VT_VECTOR | VT_UI1 ] Specifies the Windows Media DRM application private key of the client.
    public static PropertyKey CLIENT_WMDRM_APPLICATION_PRIVATE_KEY = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_CLIENT_WMDRM_APPLICATION_CERTIFICATE  
    //   [ VT_VECTOR | VT_UI1 ] Specifies the Windows Media DRM application certificate of the client.
    public static PropertyKey CLIENT_WMDRM_APPLICATION_CERTIFICATE = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE  
    //   [ VT_UI4 ] Specifies the Security Quality of Service for the connection to the driver. This relates to the Security Quality of Service flags for CreateFile. For example, these allow or disallow a driver to impersonate the client.
    public static PropertyKey CLIENT_SECURITY_QUALITY_OF_SERVICE = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_CLIENT_DESIRED_ACCESS  
    //   [ VT_UI4 ] Specifies the desired access the client is requesting to this driver. The possible values are the same as for CreateFile (e.g. GENERIC_READ, GENERIC_WRITE etc.).
    public static PropertyKey CLIENT_DESIRED_ACCESS = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_CLIENT_SHARE_MODE  
    //   [ VT_UI4 ] Specifies the share mode the client is requesting to this driver. The possible values are the same as for CreateFile (e.g. FILE_SHARE_READ, FILE_SHARE_WRITE etc.).
    public static PropertyKey CLIENT_SHARE_MODE = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_CLIENT_EVENT_COOKIE  
    //   [ VT_LPWSTR ] Client supplied cookie returned by the driver in events posted as a direct result of operations issued by this client.
    public static PropertyKey CLIENT_EVENT_COOKIE = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_CLIENT_MINIMUM_RESULTS_BUFFER_SIZE  
    //   [ VT_UI4 ] Specifies the minimum buffer size (in bytes) used for sending commands to the driver.
    public static PropertyKey CLIENT_MINIMUM_RESULTS_BUFFER_SIZE = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_CLIENT_MANUAL_CLOSE_ON_DISCONNECT  
    //   [ VT_BOOL ] An advanced option for clients that wish to manually call IPortableDevice::Close or IPortableDeviceService::Close for each object on mediaDevice disconnect, instead of relying on the API to call Close on its behalf.
    public static PropertyKey CLIENT_MANUAL_CLOSE_ON_DISCONNECT = new()
    {
        fmtid = CLIENT_INFORMATION_PROPERTIES_V1,
        pid = 13
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_PROPERTY_ATTRIBUTES_V1 
 *
 * 
 ****************************************************************************/
    public static Guid PROPERTY_ATTRIBUTES_V1 = new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37);

    //
    // WPD_PROPERTY_ATTRIBUTE_FORM  
    //   [ VT_UI4 ] Specifies the form of the valid values allowed for this property.
    public static PropertyKey PROPERTY_ATTRIBUTE_FORM = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 2
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_CAN_READ  
    //   [ VT_BOOL ] Indicates whether client applications have permission to Read the property.
    public static PropertyKey PROPERTY_ATTRIBUTE_CAN_READ = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 3
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_CAN_WRITE  
    //   [ VT_BOOL ] Indicates whether client applications have permission to Write the property.
    public static PropertyKey PROPERTY_ATTRIBUTE_CAN_WRITE = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 4
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_CAN_DELETE  
    //   [ VT_BOOL ] Indicates whether client applications have permission to Delete the property.
    public static PropertyKey PROPERTY_ATTRIBUTE_CAN_DELETE = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 5
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_DEFAULT_VALUE  
    //   [ VT_XXXX ] Specifies the default value for a write-able property.
    public static PropertyKey PROPERTY_ATTRIBUTE_DEFAULT_VALUE = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 6
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_FAST_PROPERTY  
    //   [ VT_BOOL ] If True, then this property belongs to the PORTABLE_DEVICE_FAST_PROPERTIES group.
    public static PropertyKey PROPERTY_ATTRIBUTE_FAST_PROPERTY = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 7
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_RANGE_MIN  
    //   [ VT_XXXX ] The minimum value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.
    public static PropertyKey PROPERTY_ATTRIBUTE_RANGE_MIN = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 8
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_RANGE_MAX  
    //   [ VT_XXXX ] The maximum value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.
    public static PropertyKey PROPERTY_ATTRIBUTE_RANGE_MAX = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 9
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_RANGE_STEP  
    //   [ VT_XXXX ] The step value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.
    public static PropertyKey PROPERTY_ATTRIBUTE_RANGE_STEP = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 10
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_ENUMERATION_ELEMENTS  
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection containing the enumeration values.
    public static PropertyKey PROPERTY_ATTRIBUTE_ENUMERATION_ELEMENTS = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 11
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_REGULAR_EXPRESSION  
    //   [ VT_LPWSTR ] A regular expression string indicating acceptable values for properties whose form is WPD_PROPERTY_ATTRIBUTE_FORM_REGULAR_EXPRESSION.
    public static PropertyKey PROPERTY_ATTRIBUTE_REGULAR_EXPRESSION = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 12
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_MAX_SIZE  
    //   [ VT_UI8 ] This indicates the maximum size (in bytes) for the value of this property.
    public static PropertyKey PROPERTY_ATTRIBUTE_MAX_SIZE = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V1,
        pid = 13
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_PROPERTY_ATTRIBUTES_V2 
 *
 * This category defines additional property attributes used by mediaDevice services.
 ****************************************************************************/
    public static Guid PROPERTY_ATTRIBUTES_V2 = new(0x5D9DA160, 0x74AE, 0x43CC, 0x85, 0xA9, 0xFE, 0x55, 0x5A, 0x80, 0x79, 0x8E);

    //
    // WPD_PROPERTY_ATTRIBUTE_NAME  
    //   [ VT_LPWSTR ] Contains the name of the property.
    public static PropertyKey PROPERTY_ATTRIBUTE_NAME = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V2,
        pid = 2
    };

    //
    // WPD_PROPERTY_ATTRIBUTE_VARTYPE  
    //   [ VT_UI4 ] Contains the VARTYPE of the property.
    public static PropertyKey PROPERTY_ATTRIBUTE_VARTYPE = new()
    {
        fmtid = PROPERTY_ATTRIBUTES_V2,
        pid = 3
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CLASS_EXTENSION_OPTIONS_V1 
 *
 * This category of properties relates to options used for the WPD mediaDevice class extension
 ****************************************************************************/
    public static Guid CLASS_EXTENSION_OPTIONS_V1 = new(0x6309FFEF, 0xA87C, 0x4CA7, 0x84, 0x34, 0x79, 0x75, 0x76, 0xE4, 0x0A, 0x96);

    //
    // WPD_CLASS_EXTENSION_OPTIONS_SUPPORTED_CONTENT_TYPES  
    //   [ VT_UNKNOWN ] Indicates the (super-set) list of content types supported by the driver (similar to calling WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES on WPD_FUNCTIONAL_CATEGORY_ALL).
    public static PropertyKey CLASS_EXTENSION_OPTIONS_SUPPORTED_CONTENT_TYPES = new()
    {
        fmtid = CLASS_EXTENSION_OPTIONS_V1,
        pid = 2
    };

    //
    // WPD_CLASS_EXTENSION_OPTIONS_DONT_REGISTER_WPD_DEVICE_INTERFACE  
    //   [ VT_BOOL ] Indicates that the caller does not want the WPD class extension library to register the WPD Device Class interface. The caller will take responsibility for doing it.
    public static PropertyKey CLASS_EXTENSION_OPTIONS_DONT_REGISTER_WPD_DEVICE_INTERFACE = new()
    {
        fmtid = CLASS_EXTENSION_OPTIONS_V1,
        pid = 3
    };

    //
    // WPD_CLASS_EXTENSION_OPTIONS_REGISTER_WPD_PRIVATE_DEVICE_INTERFACE  
    //   [ VT_BOOL ] Indicates that the caller wants the WPD class extension library to register the private WPD Device Class interface.
    public static PropertyKey CLASS_EXTENSION_OPTIONS_REGISTER_WPD_PRIVATE_DEVICE_INTERFACE = new()
    {
        fmtid = CLASS_EXTENSION_OPTIONS_V1,
        pid = 4
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CLASS_EXTENSION_OPTIONS_V2 
 *
 * This category of properties relates to options used for the WPD mediaDevice class extension
 ****************************************************************************/
    public static Guid CLASS_EXTENSION_OPTIONS_V2 = new(0x3E3595DA, 0x4D71, 0x49FE, 0xA0, 0xB4, 0xD4, 0x40, 0x6C, 0x3A, 0xE9, 0x3F);

    //
    // WPD_CLASS_EXTENSION_OPTIONS_MULTITRANSPORT_MODE  
    //   [ VT_BOOL ] Indicates that the caller wants the WPD class extension library to go into Multi-Transport mode (if TRUE).
    public static PropertyKey CLASS_EXTENSION_OPTIONS_MULTITRANSPORT_MODE = new()
    {
        fmtid = CLASS_EXTENSION_OPTIONS_V2,
        pid = 2
    };

    //
    // WPD_CLASS_EXTENSION_OPTIONS_DEVICE_IDENTIFICATION_VALUES  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the mediaDevice identification values (WPD_DEVICE_MANUFACTURER, WPD_DEVICE_MODEL, WPD_DEVICE_FIRMWARE_VERSION and WPD_DEVICE_FUNCTIONAL_UNIQUE_ID). Include this with other Class Extension options when initializing.
    public static PropertyKey CLASS_EXTENSION_OPTIONS_DEVICE_IDENTIFICATION_VALUES = new()
    {
        fmtid = CLASS_EXTENSION_OPTIONS_V2,
        pid = 3
    };

    //
    // WPD_CLASS_EXTENSION_OPTIONS_TRANSPORT_BANDWIDTH  
    //   [ VT_UI4 ] Indicates the theoretical maximum bandwidth of the transport in kilobits per second.
    public static PropertyKey CLASS_EXTENSION_OPTIONS_TRANSPORT_BANDWIDTH = new()
    {
        fmtid = CLASS_EXTENSION_OPTIONS_V2,
        pid = 4
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CLASS_EXTENSION_OPTIONS_V3 
 *
 * This category of properties relates to options used for the WPD mediaDevice class extension
 ****************************************************************************/
    public static Guid CLASS_EXTENSION_OPTIONS_V3 = new(0x65C160F8, 0x1367, 0x4CE2, 0x93, 0x9D, 0x83, 0x10, 0x83, 0x9F, 0x0D, 0x30);

    //
    // WPD_CLASS_EXTENSION_OPTIONS_SILENCE_AUTOPLAY  
    //   [ VT_BOOL ] Indicates that the caller wants Autoplay to be silent when the mediaDevice is connected (if TRUE).
    public static PropertyKey CLASS_EXTENSION_OPTIONS_SILENCE_AUTOPLAY = new()
    {
        fmtid = CLASS_EXTENSION_OPTIONS_V3,
        pid = 2
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_RESOURCE_ATTRIBUTES_V1 
 *
 * 
 ****************************************************************************/
    public static Guid RESOURCE_ATTRIBUTES_V1 = new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6);

    //
    // WPD_RESOURCE_ATTRIBUTE_TOTAL_SIZE  
    //   [ VT_UI8 ] Total size in bytes of the resource data.
    public static PropertyKey RESOURCE_ATTRIBUTE_TOTAL_SIZE = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 2
    };

    //
    // WPD_RESOURCE_ATTRIBUTE_CAN_READ  
    //   [ VT_BOOL ] Indicates whether client applications have permission to open the resource for Read access.
    public static PropertyKey RESOURCE_ATTRIBUTE_CAN_READ = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 3
    };

    //
    // WPD_RESOURCE_ATTRIBUTE_CAN_WRITE  
    //   [ VT_BOOL ] Indicates whether client applications have permission to open the resource for Write access.
    public static PropertyKey RESOURCE_ATTRIBUTE_CAN_WRITE = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 4
    };

    //
    // WPD_RESOURCE_ATTRIBUTE_CAN_DELETE  
    //   [ VT_BOOL ] Indicates whether client applications have permission to Delete a resource from the mediaDevice.
    public static PropertyKey RESOURCE_ATTRIBUTE_CAN_DELETE = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 5
    };

    //
    // WPD_RESOURCE_ATTRIBUTE_OPTIMAL_READ_BUFFER_SIZE  
    //   [ VT_UI4 ] The recommended buffer size a caller should use when doing buffered reads on the resource.
    public static PropertyKey RESOURCE_ATTRIBUTE_OPTIMAL_READ_BUFFER_SIZE = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 6
    };

    //
    // WPD_RESOURCE_ATTRIBUTE_OPTIMAL_WRITE_BUFFER_SIZE  
    //   [ VT_UI4 ] The recommended buffer size a caller should use when doing buffered writes on the resource.
    public static PropertyKey RESOURCE_ATTRIBUTE_OPTIMAL_WRITE_BUFFER_SIZE = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 7
    };

    //
    // WPD_RESOURCE_ATTRIBUTE_FORMAT  
    //   [ VT_CLSID ] Indicates the format of the resource data.
    public static PropertyKey RESOURCE_ATTRIBUTE_FORMAT = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 8
    };

    //
    // WPD_RESOURCE_ATTRIBUTE_RESOURCE_KEY  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing a single value, which is the key identifying the resource.
    public static PropertyKey RESOURCE_ATTRIBUTE_RESOURCE_KEY = new()
    {
        fmtid = RESOURCE_ATTRIBUTES_V1,
        pid = 9
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_DEVICE_PROPERTIES_V1 
 *
 * 
 ****************************************************************************/
    public static Guid DEVICE_PROPERTIES_V1 = new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC);

    //
    // WPD_DEVICE_SYNC_PARTNER  
    //   [ VT_LPWSTR ] Indicates a human-readable description of a synchronization partner for the mediaDevice.
    public static PropertyKey DEVICE_SYNC_PARTNER = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_DEVICE_FIRMWARE_VERSION  
    //   [ VT_LPWSTR ] Indicates the firmware version for the mediaDevice.
    public static PropertyKey DEVICE_FIRMWARE_VERSION = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_DEVICE_POWER_LEVEL  
    //   [ VT_UI4 ] Indicates the power level of the mediaDevice's battery.
    public static PropertyKey DEVICE_POWER_LEVEL = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_DEVICE_POWER_SOURCE  
    //   [ VT_UI4 ] Indicates the power source of the mediaDevice e.g. whether it is battery or external.
    public static PropertyKey DEVICE_POWER_SOURCE = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_DEVICE_PROTOCOL  
    //   [ VT_LPWSTR ] Identifies the mediaDevice protocol being used.
    public static PropertyKey DEVICE_PROTOCOL = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_DEVICE_MANUFACTURER  
    //   [ VT_LPWSTR ] Identifies the mediaDevice manufacturer.
    public static PropertyKey DEVICE_MANUFACTURER = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_DEVICE_MODEL  
    //   [ VT_LPWSTR ] Identifies the mediaDevice model.
    public static PropertyKey DEVICE_MODEL = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_DEVICE_SERIAL_NUMBER  
    //   [ VT_LPWSTR ] Identifies the serial number of the mediaDevice.
    public static PropertyKey DEVICE_SERIAL_NUMBER = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_DEVICE_SUPPORTS_NON_CONSUMABLE  
    //   [ VT_BOOL ] Indicates whether the mediaDevice supports non-consumable objects.
    public static PropertyKey DEVICE_SUPPORTS_NON_CONSUMABLE = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_DEVICE_DATETIME  
    //   [ VT_DATE ] Represents the current date and time settings of the mediaDevice.
    public static PropertyKey DEVICE_DATETIME = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_DEVICE_FRIENDLY_NAME  
    //   [ VT_LPWSTR ] Represents the friendly name set by the user on the mediaDevice.
    public static PropertyKey DEVICE_FRIENDLY_NAME = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_DEVICE_SUPPORTED_DRM_SCHEMES  
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of VT_LPWSTR values indicating the Digital Rights Management schemes supported by the driver.
    public static PropertyKey DEVICE_SUPPORTED_DRM_SCHEMES = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 13
    };

    //
    // WPD_DEVICE_SUPPORTED_FORMATS_ARE_ORDERED  
    //   [ VT_BOOL ] Indicates whether the supported formats returned from the mediaDevice are in a preferred order. (First format in the list is most preferred by the mediaDevice, while the last is the least preferred.)
    public static PropertyKey DEVICE_SUPPORTED_FORMATS_ARE_ORDERED = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 14
    };

    //
    // WPD_DEVICE_TYPE  
    //   [ VT_UI4 ] Indicates the mediaDevice type, used for representation purposes only. Functional characteristics of the mediaDevice are decided through functional objects.
    public static PropertyKey DEVICE_TYPE = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 15
    };

    //
    // WPD_DEVICE_NETWORK_IDENTIFIER  
    //   [ VT_UI8 ] Indicates the EUI-64 network identifier of the mediaDevice, used for out-of-band Network Association operations.
    public static PropertyKey DEVICE_NETWORK_IDENTIFIER = new()
    {
        fmtid = DEVICE_PROPERTIES_V1,
        pid = 16
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_DEVICE_PROPERTIES_V2 
 *
 * 
 ****************************************************************************/
    public static Guid DEVICE_PROPERTIES_V2 = new(0x463DD662, 0x7FC4, 0x4291, 0x91, 0x1C, 0x7F, 0x4C, 0x9C, 0xCA, 0x97, 0x99);

    //
    // WPD_DEVICE_FUNCTIONAL_UNIQUE_ID  
    //   [ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier common across multiple transports supported by the mediaDevice.
    public static PropertyKey DEVICE_FUNCTIONAL_UNIQUE_ID = new()
    {
        fmtid = DEVICE_PROPERTIES_V2,
        pid = 2
    };

    //
    // WPD_DEVICE_MODEL_UNIQUE_ID  
    //   [ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier for cosmetic differentiation among different models of the mediaDevice.
    public static PropertyKey DEVICE_MODEL_UNIQUE_ID = new()
    {
        fmtid = DEVICE_PROPERTIES_V2,
        pid = 3
    };

    //
    // WPD_DEVICE_TRANSPORT  
    //   [ VT_UI4 ] Indicates the transport type (USB, IP, Bluetooth, etc.).
    public static PropertyKey DEVICE_TRANSPORT = new()
    {
        fmtid = DEVICE_PROPERTIES_V2,
        pid = 4
    };

    //
    // WPD_DEVICE_USE_DEVICE_STAGE  
    //   [ VT_BOOL ] If this property exists and is set to TRUE, the mediaDevice can be used with Device Stage.
    public static PropertyKey DEVICE_USE_DEVICE_STAGE = new()
    {
        fmtid = DEVICE_PROPERTIES_V2,
        pid = 5
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_DEVICE_PROPERTIES_V3 
 *
 * 
 ****************************************************************************/
    public static Guid DEVICE_PROPERTIES_V3 = new(0x6C2B878C, 0xC2EC, 0x490D, 0xB4, 0x25, 0xD7, 0xA7, 0x5E, 0x23, 0xE5, 0xED);

    //
    // WPD_DEVICE_EDP_IDENTITY  
    //   [ VT_LPWSTR ] Represents EDP identity of the mediaDevice.
    public static PropertyKey DEVICE_EDP_IDENTITY = new()
    {
        fmtid = DEVICE_PROPERTIES_V3,
        pid = 1
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_SERVICE_PROPERTIES_V1 
 *
 * 
 ****************************************************************************/
    public static Guid SERVICE_PROPERTIES_V1 = new(0x7510698A, 0xCB54, 0x481C, 0xB8, 0xDB, 0x0D, 0x75, 0xC9, 0x3F, 0x1C, 0x06);

    //
    // WPD_SERVICE_VERSION  
    //   [ VT_LPWSTR ] Indicates the implementation version of a service.
    public static PropertyKey SERVICE_VERSION = new()
    {
        fmtid = SERVICE_PROPERTIES_V1,
        pid = 2
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_EVENT_PROPERTIES_V1 
 *
 * The properties in this category are for properties that may be needed for event processing, but do not have object property equivalents (i.e. they are not exposed as object properties, but rather, used only as event parameters).
 ****************************************************************************/
    public static Guid EVENT_PROPERTIES_V1 = new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0);

    //
    // WPD_EVENT_PARAMETER_PNP_DEVICE_ID  
    //   [ VT_LPWSTR ] Indicates the mediaDevice that originated the event.
    public static PropertyKey EVENT_PARAMETER_PNP_DEVICE_ID = new()
    {
        fmtid = EVENT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_EVENT_PARAMETER_EVENT_ID  
    //   [ VT_CLSID ] Indicates the event sent.
    public static PropertyKey EVENT_PARAMETER_EVENT_ID = new()
    {
        fmtid = EVENT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_EVENT_PARAMETER_OPERATION_STATE  
    //   [ VT_UI4 ] Indicates the current state of the operation (e.g. started, running, stopped etc.).
    public static PropertyKey EVENT_PARAMETER_OPERATION_STATE = new()
    {
        fmtid = EVENT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_EVENT_PARAMETER_OPERATION_PROGRESS  
    //   [ VT_UI4 ] Indicates the progress of a currently executing operation. Value is from 0 to 100, with 100 indicating that the operation is complete.
    public static PropertyKey EVENT_PARAMETER_OPERATION_PROGRESS = new()
    {
        fmtid = EVENT_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID  
    //   [ VT_LPWSTR ] Uniquely identifies the parent object, similar to WPD_OBJECT_PARENT_ID, but this ID will not change between sessions.
    public static PropertyKey EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID = new()
    {
        fmtid = EVENT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_EVENT_PARAMETER_OBJECT_CREATION_COOKIE  
    //   [ VT_LPWSTR ] This is the cookie handed back to a client when it requested an object creation using the IPortableDeviceContent::CreateObjectWithPropertiesAndData method.
    public static PropertyKey EVENT_PARAMETER_OBJECT_CREATION_COOKIE = new()
    {
        fmtid = EVENT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED  
    //   [ VT_BOOL ] Indicates that the child hiearchy for the object has changed.
    public static PropertyKey EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED = new()
    {
        fmtid = EVENT_PROPERTIES_V1,
        pid = 8
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_EVENT_PROPERTIES_V2 
 *
 * The properties in this category are for properties that may be needed for event processing, but do not have object property equivalents (i.e. they are not exposed as object properties, but rather, used only as event parameters).
 ****************************************************************************/
    public static Guid EVENT_PROPERTIES_V2 = new(0x52807B8A, 0x4914, 0x4323, 0x9B, 0x9A, 0x74, 0xF6, 0x54, 0xB2, 0xB8, 0x46);

    //
    // WPD_EVENT_PARAMETER_SERVICE_METHOD_CONTEXT  
    //   [ VT_LPWSTR ] Indicates the service method invocation context.
    public static PropertyKey EVENT_PARAMETER_SERVICE_METHOD_CONTEXT = new()
    {
        fmtid = EVENT_PROPERTIES_V2,
        pid = 2
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_EVENT_OPTIONS_V1 
 *
 * The properties in this category describe event options.
 ****************************************************************************/
    public static Guid EVENT_OPTIONS_V1 = new(0xB3D8DAD7, 0xA361, 0x4B83, 0x8A, 0x48, 0x5B, 0x02, 0xCE, 0x10, 0x71, 0x3B);

    //
    // WPD_EVENT_OPTION_IS_BROADCAST_EVENT  
    //   [ VT_BOOL ] Indicates that the event is broadcast to all clients.
    public static PropertyKey EVENT_OPTION_IS_BROADCAST_EVENT = new()
    {
        fmtid = EVENT_OPTIONS_V1,
        pid = 2
    };

    //
    // WPD_EVENT_OPTION_IS_AUTOPLAY_EVENT  
    //   [ VT_BOOL ] Indicates that the event is sent to and handled by Autoplay.
    public static PropertyKey EVENT_OPTION_IS_AUTOPLAY_EVENT = new()
    {
        fmtid = EVENT_OPTIONS_V1,
        pid = 3
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_EVENT_ATTRIBUTES_V1 
 *
 * The properties in this category describe event attributes.
 ****************************************************************************/
    public static Guid EVENT_ATTRIBUTES_V1 = new(0x10C96578, 0x2E81, 0x4111, 0xAD, 0xDE, 0xE0, 0x8C, 0xA6, 0x13, 0x8F, 0x6D);

    //
    // WPD_EVENT_ATTRIBUTE_NAME  
    //   [ VT_LPWSTR ] Contains the name of the event.
    public static PropertyKey EVENT_ATTRIBUTE_NAME = new()
    {
        fmtid = EVENT_ATTRIBUTES_V1,
        pid = 2
    };

    //
    // WPD_EVENT_ATTRIBUTE_PARAMETERS  
    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the event parameters.
    public static PropertyKey EVENT_ATTRIBUTE_PARAMETERS = new()
    {
        fmtid = EVENT_ATTRIBUTES_V1,
        pid = 3
    };

    //
    // WPD_EVENT_ATTRIBUTE_OPTIONS  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the event options.
    public static PropertyKey EVENT_ATTRIBUTE_OPTIONS = new()
    {
        fmtid = EVENT_ATTRIBUTES_V1,
        pid = 4
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_API_OPTIONS_V1 
 *
 * The properties in this category describe API options.
 ****************************************************************************/
    public static Guid API_OPTIONS_V1 = new(0x10E54A3E, 0x052D, 0x4777, 0xA1, 0x3C, 0xDE, 0x76, 0x14, 0xBE, 0x2B, 0xC4);

    //
    // WPD_API_OPTION_USE_CLEAR_DATA_STREAM  
    //   [ VT_BOOL ] Indicates that the data stream created for data transfer will be clear only (i.e. No DRM will be involved).
    public static PropertyKey API_OPTION_USE_CLEAR_DATA_STREAM = new()
    {
        fmtid = API_OPTIONS_V1,
        pid = 2
    };

    //
    // WPD_API_OPTION_IOCTL_ACCESS  
    //   [ VT_UI4 ] An optional property that clients can add to the IN parameter set of IPortableDevice::SendCommand to specify the access required for the command. The Portable Device API uses this to identify whether the IOCTL sent to the driver is sent with FILE_READ_ACCESS or (FILE_READ_ACCESS | FILE_WRITE_ACCESS) access flags.
    public static PropertyKey API_OPTION_IOCTL_ACCESS = new()
    {
        fmtid = API_OPTIONS_V1,
        pid = 3
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_FORMAT_ATTRIBUTES_V1 
 *
 * The properties in this category describe format attributes.
 ****************************************************************************/
    public static Guid FORMAT_ATTRIBUTES_V1 = new(0xA0A02000, 0xBCAF, 0x4BE8, 0xB3, 0xF5, 0x23, 0x3F, 0x23, 0x1C, 0xF5, 0x8F);

    //
    // WPD_FORMAT_ATTRIBUTE_NAME  
    //   [ VT_LPWSTR ] Contains the name of the format.
    public static PropertyKey FORMAT_ATTRIBUTE_NAME = new()
    {
        fmtid = FORMAT_ATTRIBUTES_V1,
        pid = 2
    };

    //
    // WPD_FORMAT_ATTRIBUTE_MIMETYPE  
    //   [ VT_LPWSTR ] Contains the MIME type of the format.
    public static PropertyKey FORMAT_ATTRIBUTE_MIMETYPE = new()
    {
        fmtid = FORMAT_ATTRIBUTES_V1,
        pid = 3
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_METHOD_ATTRIBUTES_V1 
 *
 * The properties in this category describe method attributes.
 ****************************************************************************/
    public static Guid METHOD_ATTRIBUTES_V1 = new(0xF17A5071, 0xF039, 0x44AF, 0x8E, 0xFE, 0x43, 0x2C, 0xF3, 0x2E, 0x43, 0x2A);

    //
    // WPD_METHOD_ATTRIBUTE_NAME  
    //   [ VT_LPWSTR ] Contains the name of the method.
    public static PropertyKey METHOD_ATTRIBUTE_NAME = new()
    {
        fmtid = METHOD_ATTRIBUTES_V1,
        pid = 2
    };

    //
    // WPD_METHOD_ATTRIBUTE_ASSOCIATED_FORMAT  
    //   [ VT_CLSID ] Contains the format this method applies to. This is GUID_NULL if the method does not apply to a format.
    public static PropertyKey METHOD_ATTRIBUTE_ASSOCIATED_FORMAT = new()
    {
        fmtid = METHOD_ATTRIBUTES_V1,
        pid = 3
    };

    //
    // WPD_METHOD_ATTRIBUTE_ACCESS  
    //   [ VT_UI4 ] Indicates the required access for a method.
    public static PropertyKey METHOD_ATTRIBUTE_ACCESS = new()
    {
        fmtid = METHOD_ATTRIBUTES_V1,
        pid = 4
    };

    //
    // WPD_METHOD_ATTRIBUTE_PARAMETERS  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing the method parameters.
    public static PropertyKey METHOD_ATTRIBUTE_PARAMETERS = new()
    {
        fmtid = METHOD_ATTRIBUTES_V1,
        pid = 5
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_PARAMETER_ATTRIBUTES_V1 
 *
 * The properties in this category describe parameter attributes.
 ****************************************************************************/
    public static Guid PARAMETER_ATTRIBUTES_V1 = new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58);

    //
    // WPD_PARAMETER_ATTRIBUTE_ORDER  
    //   [ VT_UI4 ] The order (starting from 0) of a method parameter.
    public static PropertyKey PARAMETER_ATTRIBUTE_ORDER = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 2
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_USAGE  
    //   [ VT_UI4 ] The usage of the method parameter.
    public static PropertyKey PARAMETER_ATTRIBUTE_USAGE = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 3
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_FORM  
    //   [ VT_UI4 ] Specifies the form of the valid values allowed for this parameter.
    public static PropertyKey PARAMETER_ATTRIBUTE_FORM = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 4
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_DEFAULT_VALUE  
    //   [ VT_XXXX ] Specifies the default value for this parameter.
    public static PropertyKey PARAMETER_ATTRIBUTE_DEFAULT_VALUE = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 5
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_RANGE_MIN  
    //   [ VT_XXXX ] The minimum value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.
    public static PropertyKey PARAMETER_ATTRIBUTE_RANGE_MIN = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 6
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_RANGE_MAX  
    //   [ VT_XXXX ] The maximum value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.
    public static PropertyKey PARAMETER_ATTRIBUTE_RANGE_MAX = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 7
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_RANGE_STEP  
    //   [ VT_XXXX ] The step value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.
    public static PropertyKey PARAMETER_ATTRIBUTE_RANGE_STEP = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 8
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_ENUMERATION_ELEMENTS  
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection containing the enumeration values.
    public static PropertyKey PARAMETER_ATTRIBUTE_ENUMERATION_ELEMENTS = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 9
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_REGULAR_EXPRESSION  
    //   [ VT_LPWSTR ] A regular expression string indicating acceptable values for parameters whose form is WPD_PARAMETER_ATTRIBUTE_FORM_REGULAR_EXPRESSION.
    public static PropertyKey PARAMETER_ATTRIBUTE_REGULAR_EXPRESSION = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 10
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_MAX_SIZE  
    //   [ VT_UI8 ] This indicates the maximum size (in bytes) for the value of this parameter.
    public static PropertyKey PARAMETER_ATTRIBUTE_MAX_SIZE = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 11
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_VARTYPE  
    //   [ VT_UI4 ] Contains the VARTYPE of the parameter.
    public static PropertyKey PARAMETER_ATTRIBUTE_VARTYPE = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 12
    };

    //
    // WPD_PARAMETER_ATTRIBUTE_NAME  
    //   [ VT_LPWSTR ] Contains the parameter name.
    public static PropertyKey PARAMETER_ATTRIBUTE_NAME = new()
    {
        fmtid = PARAMETER_ATTRIBUTES_V1,
        pid = 13
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_COMMON 
 *
 * 
 ****************************************************************************/
    public static Guid CATEGORY_COMMON = new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A);

    // ======== Commands ========
    //
    // WPD_COMMAND_COMMON_RESET_DEVICE 
    //    This command is sent by clients to reset the mediaDevice. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     None
    // Results:
    //     None
    public static PropertyKey COMMAND_COMMON_RESET_DEVICE = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 2
    };

    //
    // WPD_COMMAND_COMMON_GET_OBJECT_IDS_FROM_PERSISTENT_UNIQUE_IDS 
    //    This command is sent when a client wants to get current ObjectIDs representing objects specified by previously acquired Persistent Unique IDs. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_COMMON_OBJECT_IDS 
    public static PropertyKey COMMAND_COMMON_GET_OBJECT_IDS_FROM_PERSISTENT_UNIQUE_IDS = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 3
    };

    //
    // WPD_COMMAND_COMMON_SAVE_CLIENT_INFORMATION 
    //    This command is sent when a client first connects to a mediaDevice. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_COMMON_CLIENT_INFORMATION 
    // Results:
    //     [ Optional ]  WPD_PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT 
    public static PropertyKey COMMAND_COMMON_SAVE_CLIENT_INFORMATION = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 4
    };

    //
    // WPD_PROPERTY_COMMON_COMMAND_CATEGORY  
    //   [ VT_CLSID ] Specifies the command Category (i.e. the GUID portion of the PROPERTYKEY indicating the command).
    public static PropertyKey PROPERTY_COMMON_COMMAND_CATEGORY = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1001
    };

    //
    // WPD_PROPERTY_COMMON_COMMAND_ID  
    //   [ VT_UI4 ] Specifies the command ID, which is the PID portion of the PROPERTYKEY indicating the command.
    public static PropertyKey PROPERTY_COMMON_COMMAND_ID = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1002
    };

    //
    // WPD_PROPERTY_COMMON_HRESULT  
    //   [ VT_ERROR ] The driver sets this to be the HRESULT of the requested operation.
    public static PropertyKey PROPERTY_COMMON_HRESULT = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1003
    };

    //
    // WPD_PROPERTY_COMMON_DRIVER_ERROR_CODE  
    //   [ VT_UI4 ] Special driver specific code which driver may return on error. Typically only for use with diagnostic tools or vertical solutions.
    public static PropertyKey PROPERTY_COMMON_DRIVER_ERROR_CODE = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1004
    };

    //
    // WPD_PROPERTY_COMMON_COMMAND_TARGET  
    //   [ VT_LPWSTR ] Identifies the object which the command is intended for.
    public static PropertyKey PROPERTY_COMMON_COMMAND_TARGET = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1006
    };

    //
    // WPD_PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Persistent Unique IDs.
    public static PropertyKey PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1007
    };

    //
    // WPD_PROPERTY_COMMON_OBJECT_IDS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Objects IDs.
    public static PropertyKey PROPERTY_COMMON_OBJECT_IDS = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1008
    };

    //
    // WPD_PROPERTY_COMMON_CLIENT_INFORMATION  
    //   [ VT_UNKNOWN ] IPortableDeviceValues used to identify itself to the driver.
    public static PropertyKey PROPERTY_COMMON_CLIENT_INFORMATION = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1009
    };

    //
    // WPD_PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT  
    //   [ VT_LPWSTR ] Driver specified context which will be sent for the particular client on all subsequent operations.
    public static PropertyKey PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1010
    };

    //
    // WPD_PROPERTY_COMMON_ACTIVITY_ID  
    //   [ VT_CLSID ] An optional ActivityID set either by a client or by WPD API, when ETW tracing is enabled.
    public static PropertyKey PROPERTY_COMMON_ACTIVITY_ID = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 1011
    };

    // ======== Command Options ========
    //
    // WPD_OPTION_VALID_OBJECT_IDS 
    //   [ VT_UNKNOWN ]  IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Objects IDs of the objects that support the command. 
    public static PropertyKey OPTION_VALID_OBJECT_IDS = new()
    {
        fmtid = CATEGORY_COMMON,
        pid = 5001
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_OBJECT_ENUMERATION 
 *
 * The commands in this category are used for basic object enumeration.
 ****************************************************************************/
    public static Guid CATEGORY_OBJECT_ENUMERATION = new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC);

    // ======== Commands ========
    //
    // WPD_COMMAND_OBJECT_ENUMERATION_START_FIND 
    //    The driver receives this command when a client wishes to start enumeration. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_PARENT_ID 
    //     [ Optional ]  WPD_PROPERTY_OBJECT_ENUMERATION_FILTER 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
    public static PropertyKey COMMAND_OBJECT_ENUMERATION_START_FIND = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 2
    };

    //
    // WPD_COMMAND_OBJECT_ENUMERATION_FIND_NEXT 
    //    This command is used when the client requests the next batch of ObjectIDs during enumeration. Only objects that match the constraints set up in WPD_COMMAND_OBJECT_ENUMERATION_START_FIND should be returned. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS 
    public static PropertyKey COMMAND_OBJECT_ENUMERATION_FIND_NEXT = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 3
    };

    //
    // WPD_COMMAND_OBJECT_ENUMERATION_END_FIND 
    //    The driver should destroy any resources associated with this enumeration context. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_ENUMERATION_END_FIND = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 4
    };

    //
    // WPD_PROPERTY_OBJECT_ENUMERATION_PARENT_ID  
    //   [ VT_LPWSTR ] The ObjectID specifying the parent object where enumeration should start.
    public static PropertyKey PROPERTY_OBJECT_ENUMERATION_PARENT_ID = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 1001
    };

    //
    // WPD_PROPERTY_OBJECT_ENUMERATION_FILTER  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which specifies the properties used to filter on. If the caller does not want filtering, then this value will not be set.
    public static PropertyKey PROPERTY_OBJECT_ENUMERATION_FILTER = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 1002
    };

    //
    // WPD_PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS  
    //   [ VT_UNKNOWN ] This is an IPortableDevicePropVariantCollection of ObjectIDs (of type VT_LPWSTR). If 0 objects are returned, this should be an empty collection, not NULL.
    public static PropertyKey PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 1003
    };

    //
    // WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT  
    //   [ VT_LPWSTR ] This is a driver-specified identifier for the context associated with this enumeration.
    public static PropertyKey PROPERTY_OBJECT_ENUMERATION_CONTEXT = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 1004
    };

    //
    // WPD_PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED  
    //   [ VT_UI4 ] The maximum number of ObjectIDs to return back to the client.
    public static PropertyKey PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED = new()
    {
        fmtid = CATEGORY_OBJECT_ENUMERATION,
        pid = 1005
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_OBJECT_PROPERTIES 
 *
 * This category of commands is used to perform basic property operations such as Reading/Writing values, listing supported values and so on.
 ****************************************************************************/
    public static Guid CATEGORY_OBJECT_PROPERTIES = new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04);

    // ======== Commands ========
    //
    // WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED 
    //    This command is used when the client requests the list of properties supported by the specified object. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 2
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_GET_ATTRIBUTES 
    //    This command is used when the client requests the property attributes for the specified object properties. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 3
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_GET 
    //    This command is used when the client requests a set of property values for the specified object. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 4
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_SET 
    //    This command is used when the client requests to write a set of property values on the specified object. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_SET = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 5
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_GET_ALL 
    //    This command is used when the client requests all property values for the specified object. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET_ALL = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 6
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_DELETE 
    //    This command is sent when the caller wants to delete properties from the specified object. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
    // Results:
    //     [ Optional ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_DELETE = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 7
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID  
    //   [ VT_LPWSTR ] The ObjectID specifying the object whose properties are being queried/manipulated.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_OBJECT_ID = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 1001
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS  
    //   [ VT_UNKNOWN ] An IPortableDeviceKeyCollection identifying which specific property values we are querying/manipulating.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 1002
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the attributes for each property requested.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 1003
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the values read. For any property whose value could not be read, the type must be set to VT_ERROR, and the 'scode' field must contain the failure HRESULT.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 1004
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each property write operation.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 1005
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each property delete operation.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES,
        pid = 1006
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_OBJECT_PROPERTIES_BULK 
 *
 * This category contains commands and properties for property operations across multiple objects.
 ****************************************************************************/
    public static Guid CATEGORY_OBJECT_PROPERTIES_BULK = new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E);

    // ======== Commands ========
    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_START 
    //    Initializes the operation to get the property values for all caller-specified objects. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS 
    //     [ Optional ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_START = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 2
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_NEXT 
    //    Get the next set of property values. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_NEXT = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 3
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_END 
    //    Ends the bulk property operation for getting property values by object list. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_END = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 4
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_START 
    //    Initializes the operation to get the property values for objects of the specified format 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH 
    //     [ Optional ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_START = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 5
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_NEXT 
    //    Get the next set of property values. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_NEXT = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 6
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_END 
    //    Ends the bulk property operation for getting property values by object format. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_END = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 7
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_START 
    //    Initializes the operation to set the property values for specified objects. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_START = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 8
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_NEXT 
    //    Set the next set of property values. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS 
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_NEXT = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 9
    };

    //
    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_END 
    //    Ends the bulk property operation for setting property values by object list. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_END = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 10
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS  
    //   [ VT_UNKNOWN ] A collection of ObjectIDs for which supported property list must be returned.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1001
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT  
    //   [ VT_LPWSTR ] The driver-specified context identifying this particular bulk operation.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1002
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES  
    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValuesCollection specifying the next set of IPortableDeviceValues elements.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_VALUES = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1003
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS  
    //   [ VT_UNKNOWN ] Contains an IPortableDeviceKeyCollection specifying which properties the caller wants to return. May not exist, which indicates caller wants ALL properties.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1004
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH  
    //   [ VT_UI4 ] Contains a value specifying the hierarchical depth from the parent to include in this operation.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1005
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID  
    //   [ VT_LPWSTR ] Contains the ObjectID of the object to start the operation from.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1006
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT  
    //   [ VT_CLSID ] Specifies the object format the client is interested in.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1007
    };

    //
    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS  
    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValuesCollection specifying the set of IPortableDeviceValues elements indicating the write results for each property set.
    public static PropertyKey PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS = new()
    {
        fmtid = CATEGORY_OBJECT_PROPERTIES_BULK,
        pid = 1008
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_OBJECT_RESOURCES 
 *
 * The commands in this category are used for basic object resource enumeration and transfer.
 ****************************************************************************/
    public static Guid CATEGORY_OBJECT_RESOURCES = new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A);

    // ======== Commands ========
    //
    // WPD_COMMAND_OBJECT_RESOURCES_GET_SUPPORTED 
    //    This command is sent when a client wants to get the list of resources supported on a particular object. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_GET_SUPPORTED = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 2
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_GET_ATTRIBUTES 
    //    This command is used when the client requests the attributes for the specified object resource. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_GET_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 3
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_OPEN 
    //    This command is sent when a client wants to use a particular resource on an object. 
    // Access:
    //     Dependent on the value of WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE.  STGM_READ will indicate FILE_READ_ACCESS for the command, anything else will indicate (FILE_READ_ACCESS | FILE_WRITE_ACCESS).
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE 
    //     [ Optional ]  WPD_PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_OPEN = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 4
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_READ 
    //    This command is sent when a client wants to read the next band of data from a previously opened object resource. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ 
    //     [ Required except when the driver returns TRUE for the WPD_OPTION_OBJECT_RESOURCES_NO_INPUT_BUFFER_ON_READ option. ]  WPD_PROPERTY_OBJECT_RESOURCES_DATA 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_DATA 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_READ = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 5
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_WRITE 
    //    This command is sent when a client wants to write the next band of data to a previously opened object resource. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_DATA 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_WRITE = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 6
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_CLOSE 
    //    This command is sent when a client is finished transferring data to a previously opened object resource. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_RESOURCES_CLOSE = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 7
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_DELETE 
    //    This command is sent when the client wants to delete the data associated with the specified resources from the specified object. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_RESOURCES_DELETE = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 8
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_CREATE_RESOURCE 
    //    This command is sent when a client wants to create a new object resource on the mediaDevice. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_CREATE_RESOURCE = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 9
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_REVERT 
    //    This command is sent when a client wants to cancel the resource creation request that is currently still in progress. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_RESOURCES_REVERT = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 10
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_SEEK 
    //    This command is sent when a client wants to seek to a specific offset in the data stream. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_SEEK = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 11
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_COMMIT 
    //    This command is sent when a client wants to commit changes to a data stream. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_RESOURCES_COMMIT = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 12
    };

    //
    // WPD_COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS 
    //    This command is sent when a client wants to seek to a specific offset in the data stream using alternate units. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_STREAM_UNITS 
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START 
    public static PropertyKey COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 13
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID  
    //   [ VT_LPWSTR ] 
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_OBJECT_ID = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1001
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE  
    //   [ VT_UI4 ] Specifies the type of access the client is requesting for the resource.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_ACCESS_MODE = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1002
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS  
    //   [ VT_UNKNOWN ] 
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1003
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the attributes for the resource requested.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1004
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT  
    //   [ VT_LPWSTR ] This is a driver-specified identifier for the context associated with the resource operation.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_CONTEXT = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1005
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ  
    //   [ VT_UI4 ] Specifies the number of bytes the client is requesting to read.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1006
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ  
    //   [ VT_UI4 ] Specifies the number of bytes actually read from the resource.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1007
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE  
    //   [ VT_UI4 ] Specifies the number of bytes the client is requesting to write.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1008
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN  
    //   [ VT_UI4 ] Driver sets this to let caller know how many bytes were actually written.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1009
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_DATA  
    //   [ VT_VECTOR | VT_UI1 ] 
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_DATA = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1010
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE  
    //   [ VT_UI4 ] Indicates the optimal transfer buffer size (in bytes) that clients should use when reading/writing this resource.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1011
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET  
    //   [ VT_I8 ] Displacement to be added to the location indicated by the WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG parameter.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1012
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG  
    //   [ VT_UI4 ] Specifies the origin of the displacement for the seek operation.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1013
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START  
    //   [ VT_UI8 ] Value of the new seek pointer from the beginning of the data stream.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1014
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS  
    //   [ VT_BOOL ] A Boolean value that specifies whether this resource supports operations (such as seek) using alternate units. This occurs if the driver can understand WPD_COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1015
    };

    //
    // WPD_PROPERTY_OBJECT_RESOURCES_STREAM_UNITS  
    //   [ VT_UI4 ] The units for the WPD_PROPERTY_OBJECT_SEEK_OFFSET parameter and the WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START result.
    public static PropertyKey PROPERTY_OBJECT_RESOURCES_STREAM_UNITS = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 1016
    };

    // ======== Command Options ========
    //
    // WPD_OPTION_OBJECT_RESOURCES_SEEK_ON_READ_SUPPORTED 
    //   [ VT_BOOL ]  Indicates whether the driver can Seek on a resource opened for Read access. 
    public static PropertyKey OPTION_OBJECT_RESOURCES_SEEK_ON_READ_SUPPORTED = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 5001
    };

    //
    // WPD_OPTION_OBJECT_RESOURCES_SEEK_ON_WRITE_SUPPORTED 
    //   [ VT_BOOL ]  Indicates whether the driver can Seek on a resource opened for Write access. 
    public static PropertyKey OPTION_OBJECT_RESOURCES_SEEK_ON_WRITE_SUPPORTED = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 5002
    };

    //
    // WPD_OPTION_OBJECT_RESOURCES_NO_INPUT_BUFFER_ON_READ 
    //   [ VT_BOOL ]  Indicates whether the driver requires an input buffer for WPD_COMMAND_OBJECT_RESOURCES_READ. If not set, defaults to False. 
    public static PropertyKey OPTION_OBJECT_RESOURCES_NO_INPUT_BUFFER_ON_READ = new()
    {
        fmtid = CATEGORY_OBJECT_RESOURCES,
        pid = 5003
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_OBJECT_MANAGEMENT 
 *
 * The commands specified in this category are used to Create/Delete objects on the mediaDevice.
 ****************************************************************************/
    public static Guid CATEGORY_OBJECT_MANAGEMENT = new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89);

    // ======== Commands ========
    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_ONLY 
    //    This command is sent when a client wants to create a new object on the mediaDevice, specified only by properties. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_ONLY = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 2
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_AND_DATA 
    //    This command is sent when a client wants to create a new object on the mediaDevice, specified by properties and data. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_AND_DATA = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 3
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_WRITE_OBJECT_DATA 
    //    This command is sent when a client wants to write the next band of data to a newly created object or an object being updated. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE 
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DATA 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_WRITE_OBJECT_DATA = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 4
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_COMMIT_OBJECT 
    //    This command is sent when a client has finished sending all the data associated with an object creation or update request, and wishes to ensure that the object is saved to the mediaDevice. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_COMMIT_OBJECT = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 5
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_REVERT_OBJECT 
    //    This command is sent when a client wants to cancel the object creation or update request that is currently still in progress. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_REVERT_OBJECT = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 6
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS 
    //    This command is sent when the client wishes to remove a set of objects from the mediaDevice. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS 
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 7
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_MOVE_OBJECTS 
    //    This command will move the specified objects to the destination folder. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_MOVE_OBJECTS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 8
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_COPY_OBJECTS 
    //    This command will copy the specified objects to the destination folder. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_COPY_OBJECTS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 9
    };

    //
    // WPD_COMMAND_OBJECT_MANAGEMENT_UPDATE_OBJECT_WITH_PROPERTIES_AND_DATA 
    //    This command is sent when a client wants to update the object's data and dependent properties simultaneously. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE 
    public static PropertyKey COMMAND_OBJECT_MANAGEMENT_UPDATE_OBJECT_WITH_PROPERTIES_AND_DATA = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 10
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which specifies the properties used to create the new object.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1001
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT  
    //   [ VT_LPWSTR ] This is a driver-specified identifier for the context associated with this 'create object' operation.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_CONTEXT = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1002
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE  
    //   [ VT_UI4 ] Specifies the number of bytes the client is requesting to write.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1003
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN  
    //   [ VT_UI4 ] Indicates the number of bytes written for the object.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1004
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_DATA  
    //   [ VT_VECTOR | VT_UI1 ] Indicates binary data of the object being created on the mediaDevice.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_DATA = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1005
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID  
    //   [ VT_LPWSTR ] Identifies a newly created object on the mediaDevice.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1006
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS  
    //   [ VT_UI4 ] Indicates if the delete operation should be recursive or not.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1007
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE  
    //   [ VT_UI4 ] Indicates the optimal transfer buffer size (in bytes) that clients should use when writing this object's data.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1008
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR, containing the ObjectIDs to delete.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1009
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1010
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID  
    //   [ VT_LPWSTR ] Indicates the destination folder for the move operation.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1011
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1012
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1013
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the object properties to update.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1014
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_PROPERTY_KEYS  
    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the property keys required to update this object.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_PROPERTY_KEYS = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1015
    };

    //
    // WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_FORMAT  
    //   [ VT_CLSID ] Indicates the object format the caller is interested in.
    public static PropertyKey PROPERTY_OBJECT_MANAGEMENT_OBJECT_FORMAT = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 1016
    };

    // ======== Command Options ========
    //
    // WPD_OPTION_OBJECT_MANAGEMENT_RECURSIVE_DELETE_SUPPORTED 
    //   [ VT_BOOL ]  Indicates whether the driver supports recursive deletion. 
    public static PropertyKey OPTION_OBJECT_MANAGEMENT_RECURSIVE_DELETE_SUPPORTED = new()
    {
        fmtid = CATEGORY_OBJECT_MANAGEMENT,
        pid = 5001
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_CAPABILITIES 
 *
 * This command category is used to query capabilities of the mediaDevice.
 ****************************************************************************/
    public static Guid CATEGORY_CAPABILITIES = new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56);

    // ======== Commands ========
    //
    // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_COMMANDS 
    //    Return all commands supported by this driver. This includes custom commands, if any. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS 
    public static PropertyKey COMMAND_CAPABILITIES_GET_SUPPORTED_COMMANDS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 2
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_COMMAND_OPTIONS 
    //    Returns the supported options for the specified command. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_COMMAND 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_COMMAND_OPTIONS 
    public static PropertyKey COMMAND_CAPABILITIES_GET_COMMAND_OPTIONS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 3
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FUNCTIONAL_CATEGORIES 
    //    This command is used by clients to query the functional categories supported by the driver. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES 
    public static PropertyKey COMMAND_CAPABILITIES_GET_SUPPORTED_FUNCTIONAL_CATEGORIES = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 4
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_FUNCTIONAL_OBJECTS 
    //    Retrieves the ObjectIDs of the objects belonging to the specified functional category. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS 
    public static PropertyKey COMMAND_CAPABILITIES_GET_FUNCTIONAL_OBJECTS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 5
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES 
    //    Retrieves the list of content types supported by this driver for the specified functional category. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_CONTENT_TYPES 
    public static PropertyKey COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 6
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMATS 
    //    This command is used to query the possible formats supported by the specified content type (e.g. for image objects, the driver may choose to support JPEG and BMP files). 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_CONTENT_TYPE 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FORMATS 
    public static PropertyKey COMMAND_CAPABILITIES_GET_SUPPORTED_FORMATS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 7
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES 
    //    Get the list of properties that an object of the given format supports. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FORMAT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS 
    public static PropertyKey COMMAND_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 8
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_FIXED_PROPERTY_ATTRIBUTES 
    //    Returns the property attributes that are the same for all objects of the given format. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FORMAT 
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES 
    public static PropertyKey COMMAND_CAPABILITIES_GET_FIXED_PROPERTY_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 9
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_EVENTS 
    //    Return all events supported by this driver. This includes custom events, if any. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_SUPPORTED_EVENTS 
    public static PropertyKey COMMAND_CAPABILITIES_GET_SUPPORTED_EVENTS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 10
    };

    //
    // WPD_COMMAND_CAPABILITIES_GET_EVENT_OPTIONS 
    //    Return extra information about a specified event, such as whether the event is for notification or action purposes. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_EVENT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CAPABILITIES_EVENT_OPTIONS 
    public static PropertyKey COMMAND_CAPABILITIES_GET_EVENT_OPTIONS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 11
    };

    //
    // WPD_PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS  
    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing all commands a driver supports.
    public static PropertyKey PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1001
    };

    //
    // WPD_PROPERTY_CAPABILITIES_COMMAND  
    //   [ VT_UNKNOWN ] Indicates the command whose options the caller is interested in.
    public static PropertyKey PROPERTY_CAPABILITIES_COMMAND = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1002
    };

    //
    // WPD_PROPERTY_CAPABILITIES_COMMAND_OPTIONS  
    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant command options.
    public static PropertyKey PROPERTY_CAPABILITIES_COMMAND_OPTIONS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1003
    };

    //
    // WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES  
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_CLSID which indicates the functional categories supported by the driver.
    public static PropertyKey PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1004
    };

    //
    // WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY  
    //   [ VT_CLSID ] The category the caller is interested in.
    public static PropertyKey PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1005
    };

    //
    // WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS  
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection (of type VT_LPWSTR) containing the ObjectIDs of the functional objects who belong to the specified functional category.
    public static PropertyKey PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1006
    };

    //
    // WPD_PROPERTY_CAPABILITIES_CONTENT_TYPES  
    //   [ VT_UNKNOWN ] Indicates list of content types supported for the specified functional category.
    public static PropertyKey PROPERTY_CAPABILITIES_CONTENT_TYPES = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1007
    };

    //
    // WPD_PROPERTY_CAPABILITIES_CONTENT_TYPE  
    //   [ VT_CLSID ] Indicates the content type whose formats the caller is interested in.
    public static PropertyKey PROPERTY_CAPABILITIES_CONTENT_TYPE = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1008
    };

    //
    // WPD_PROPERTY_CAPABILITIES_FORMATS  
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of VT_CLSID values indicating the formats supported for the specified content type.
    public static PropertyKey PROPERTY_CAPABILITIES_FORMATS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1009
    };

    //
    // WPD_PROPERTY_CAPABILITIES_FORMAT  
    //   [ VT_CLSID ] Specifies the format the caller is interested in.
    public static PropertyKey PROPERTY_CAPABILITIES_FORMAT = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1010
    };

    //
    // WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS  
    //   [ VT_UNKNOWN ] An IPortableDeviceKeyCollection containing the property keys.
    public static PropertyKey PROPERTY_CAPABILITIES_PROPERTY_KEYS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1011
    };

    //
    // WPD_PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES  
    //   [ VT_UNKNOWN ] An IPortableDeviceValues containing the property attributes.
    public static PropertyKey PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1012
    };

    //
    // WPD_PROPERTY_CAPABILITIES_SUPPORTED_EVENTS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of VT_CLSID values containing all events a driver supports.
    public static PropertyKey PROPERTY_CAPABILITIES_SUPPORTED_EVENTS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1013
    };

    //
    // WPD_PROPERTY_CAPABILITIES_EVENT  
    //   [ VT_CLSID ] Indicates the event the caller is interested in.
    public static PropertyKey PROPERTY_CAPABILITIES_EVENT = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1014
    };

    //
    // WPD_PROPERTY_CAPABILITIES_EVENT_OPTIONS  
    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant event options.
    public static PropertyKey PROPERTY_CAPABILITIES_EVENT_OPTIONS = new()
    {
        fmtid = CATEGORY_CAPABILITIES,
        pid = 1015
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_STORAGE 
 *
 * This category is for commands and parameters for storage functional objects.
 ****************************************************************************/
    public static Guid CATEGORY_STORAGE = new(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94);

    // ======== Commands ========
    //
    // WPD_COMMAND_STORAGE_FORMAT 
    //    This command will format the storage. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_STORAGE_OBJECT_ID 
    // Results:
    //     None
    public static PropertyKey COMMAND_STORAGE_FORMAT = new()
    {
        fmtid = CATEGORY_STORAGE,
        pid = 2
    };

    //
    // WPD_COMMAND_STORAGE_EJECT 
    //    This will eject the storage, if it is a removable store and is capable of being ejected by the mediaDevice. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_STORAGE_OBJECT_ID 
    // Results:
    //     None
    public static PropertyKey COMMAND_STORAGE_EJECT = new()
    {
        fmtid = CATEGORY_STORAGE,
        pid = 4
    };

    //
    // WPD_PROPERTY_STORAGE_OBJECT_ID  
    //   [ VT_LPWSTR ] Indicates the object to format, move or eject.
    public static PropertyKey PROPERTY_STORAGE_OBJECT_ID = new()
    {
        fmtid = CATEGORY_STORAGE,
        pid = 1001
    };

    //
    // WPD_PROPERTY_STORAGE_DESTINATION_OBJECT_ID  
    //   [ VT_LPWSTR ] Indicates the (folder) object destination for a move operation.
    public static PropertyKey PROPERTY_STORAGE_DESTINATION_OBJECT_ID = new()
    {
        fmtid = CATEGORY_STORAGE,
        pid = 1002
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_SMS 
 *
 * The commands in this category relate to Short-Message-Service functionality, typically exposed on mobile phones.
 ****************************************************************************/
    public static Guid CATEGORY_SMS = new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1);

    // ======== Commands ========
    //
    // WPD_COMMAND_SMS_SEND 
    //    This command is used to initiate the sending of an SMS message. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
    //     [ Required ]  WPD_PROPERTY_SMS_RECIPIENT 
    //     [ Required ]  WPD_PROPERTY_SMS_MESSAGE_TYPE 
    //     [ Optional ]  WPD_PROPERTY_SMS_TEXT_MESSAGE 
    //     [ Optional ]  WPD_PROPERTY_SMS_BINARY_MESSAGE 
    // Results:
    //     None
    public static PropertyKey COMMAND_SMS_SEND = new()
    {
        fmtid = CATEGORY_SMS,
        pid = 2
    };

    //
    // WPD_PROPERTY_SMS_RECIPIENT  
    //   [ VT_LPWSTR ] Indicates the recipient's address.
    public static PropertyKey PROPERTY_SMS_RECIPIENT = new()
    {
        fmtid = CATEGORY_SMS,
        pid = 1001
    };

    //
    // WPD_PROPERTY_SMS_MESSAGE_TYPE  
    //   [ VT_UI4 ] Indicates whether the message is binary or text.
    public static PropertyKey PROPERTY_SMS_MESSAGE_TYPE = new()
    {
        fmtid = CATEGORY_SMS,
        pid = 1002
    };

    //
    // WPD_PROPERTY_SMS_TEXT_MESSAGE  
    //   [ VT_LPWSTR ] if WPD_PROPERTY_SMS_MESSAGE_TYPE == SMS_TEXT_MESSAGE, then this will contain the message body.
    public static PropertyKey PROPERTY_SMS_TEXT_MESSAGE = new()
    {
        fmtid = CATEGORY_SMS,
        pid = 1003
    };

    //
    // WPD_PROPERTY_SMS_BINARY_MESSAGE  
    //   [ VT_VECTOR | VT_UI1 ] if WPD_PROPERTY_SMS_MESSAGE_TYPE == SMS_BINARY_MESSAGE, then this will contain the binary message body.
    public static PropertyKey PROPERTY_SMS_BINARY_MESSAGE = new()
    {
        fmtid = CATEGORY_SMS,
        pid = 1004
    };

    // ======== Command Options ========
    //
    // WPD_OPTION_SMS_BINARY_MESSAGE_SUPPORTED 
    //   [ VT_BOOL ]  Indicates whether the driver can support binary messages as well as text messages. 
    public static PropertyKey OPTION_SMS_BINARY_MESSAGE_SUPPORTED = new()
    {
        fmtid = CATEGORY_SMS,
        pid = 5001
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_STILL_IMAGE_CAPTURE 
 *
 * 
 ****************************************************************************/
    public static Guid CATEGORY_STILL_IMAGE_CAPTURE = new(0x4FCD6982, 0x22A2, 0x4B05, 0xA4, 0x8B, 0x62, 0xD3, 0x8B, 0xF2, 0x7B, 0x32);

    // ======== Commands ========
    //
    // WPD_COMMAND_STILL_IMAGE_CAPTURE_INITIATE 
    //    Initiates a still image capture. This is processed as a single command i.e. there is no start or stop required. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
    // Results:
    //     None
    public static PropertyKey COMMAND_STILL_IMAGE_CAPTURE_INITIATE = new()
    {
        fmtid = CATEGORY_STILL_IMAGE_CAPTURE,
        pid = 2
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_MEDIA_CAPTURE 
 *
 * 
 ****************************************************************************/
    public static Guid CATEGORY_MEDIA_CAPTURE = new(0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8);

    // ======== Commands ========
    //
    // WPD_COMMAND_MEDIA_CAPTURE_START 
    //    Initiates a media capture operation that will only be ended by a subsequent WPD_COMMAND_MEDIA_CAPTURE_STOP command. Typically used to capture media streams such as audio and video. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
    // Results:
    //     None
    public static PropertyKey COMMAND_MEDIA_CAPTURE_START = new()
    {
        fmtid = CATEGORY_MEDIA_CAPTURE,
        pid = 2
    };

    //
    // WPD_COMMAND_MEDIA_CAPTURE_STOP 
    //    Ends a media capture operation started by a WPD_COMMAND_MEDIA_CAPTURE_START command. Typically used to end capture of media streams such as audio and video. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
    // Results:
    //     None
    public static PropertyKey COMMAND_MEDIA_CAPTURE_STOP = new()
    {
        fmtid = CATEGORY_MEDIA_CAPTURE,
        pid = 3
    };

    //
    // WPD_COMMAND_MEDIA_CAPTURE_PAUSE 
    //    Pauses a media capture operation started by a WPD_COMMAND_MEDIA_CAPTURE_START command. Typically used to pause capture of media streams such as audio and video. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
    // Results:
    //     None
    public static PropertyKey COMMAND_MEDIA_CAPTURE_PAUSE = new()
    {
        fmtid = CATEGORY_MEDIA_CAPTURE,
        pid = 4
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_DEVICE_HINTS 
 *
 * The commands in this category relate to hints that a mediaDevice can provide to improve end-user experience.
 ****************************************************************************/
    public static Guid CATEGORY_DEVICE_HINTS = new(0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84);

    // ======== Commands ========
    //
    // WPD_COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION 
    //    This command is used to retrieve the ObjectIDs of folders that contain the specified content type. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_DEVICE_HINTS_CONTENT_TYPE 
    // Results:
    //     [ Required ]  WPD_PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS 
    public static PropertyKey COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION = new()
    {
        fmtid = CATEGORY_DEVICE_HINTS,
        pid = 2
    };

    //
    // WPD_PROPERTY_DEVICE_HINTS_CONTENT_TYPE  
    //   [ VT_CLSID ] Indicates the WPD content type that the caller is looking for. For example, to get the top-level folder objects that contain images, this parameter would be WPD_CONTENT_TYPE_IMAGE.
    public static PropertyKey PROPERTY_DEVICE_HINTS_CONTENT_TYPE = new()
    {
        fmtid = CATEGORY_DEVICE_HINTS,
        pid = 1001
    };

    //
    // WPD_PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of folder ObjectIDs.
    public static PropertyKey PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS = new()
    {
        fmtid = CATEGORY_DEVICE_HINTS,
        pid = 1002
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CLASS_EXTENSION_V1 
 *
 * The commands in this category relate to the WPD mediaDevice class extension.
 ****************************************************************************/
    public static Guid CLASS_EXTENSION_V1 = new(0x33FB0D11, 0x64A3, 0x4FAC, 0xB4, 0xC7, 0x3D, 0xFE, 0xAA, 0x99, 0xB0, 0x51);

    // ======== Commands ========
    //
    // WPD_COMMAND_CLASS_EXTENSION_WRITE_DEVICE_INFORMATION 
    //    This command is used to update the a cache of mediaDevice-specific information. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS 
    public static PropertyKey COMMAND_CLASS_EXTENSION_WRITE_DEVICE_INFORMATION = new()
    {
        fmtid = CLASS_EXTENSION_V1,
        pid = 2
    };

    //
    // WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the values.
    public static PropertyKey PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES = new()
    {
        fmtid = CLASS_EXTENSION_V1,
        pid = 1001
    };

    //
    // WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS  
    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each value write operation.
    public static PropertyKey PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS = new()
    {
        fmtid = CLASS_EXTENSION_V1,
        pid = 1002
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CLASS_EXTENSION_V2 
 *
 * The commands in this category relate to the WPD mediaDevice class extension.
 ****************************************************************************/
    public static Guid CLASS_EXTENSION_V2 = new(0x7F0779B5, 0xFA2B, 0x4766, 0x9C, 0xB2, 0xF7, 0x3B, 0xA3, 0x0B, 0x67, 0x58);

    // ======== Commands ========
    //
    // WPD_COMMAND_CLASS_EXTENSION_REGISTER_SERVICE_INTERFACES 
    //    This command is used to register a service's Plug and Play interfaces. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS 
    public static PropertyKey COMMAND_CLASS_EXTENSION_REGISTER_SERVICE_INTERFACES = new()
    {
        fmtid = CLASS_EXTENSION_V2,
        pid = 2
    };

    //
    // WPD_COMMAND_CLASS_EXTENSION_UNREGISTER_SERVICE_INTERFACES 
    //    This command is used to unregister a service's Plug and Play interfaces. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID 
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS 
    public static PropertyKey COMMAND_CLASS_EXTENSION_UNREGISTER_SERVICE_INTERFACES = new()
    {
        fmtid = CLASS_EXTENSION_V2,
        pid = 3
    };

    //
    // WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID  
    //   [ VT_LPWSTR ] The Object ID of the service.
    public static PropertyKey PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID = new()
    {
        fmtid = CLASS_EXTENSION_V2,
        pid = 1001
    };

    //
    // WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES  
    //   [ VT_UNKNOWN ] This is an IPortablePropVariantCollection of type VT_CLSID which contains the interface GUIDs that this service implements, including the service type GUID.
    public static PropertyKey PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES = new()
    {
        fmtid = CLASS_EXTENSION_V2,
        pid = 1002
    };

    //
    // WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS  
    //   [ VT_UNKNOWN ] This is an IPortablePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.
    public static PropertyKey PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS = new()
    {
        fmtid = CLASS_EXTENSION_V2,
        pid = 1003
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_NETWORK_CONFIGURATION 
 *
 * The commands in this category are used for Network Association and WiFi Configuration.
 ****************************************************************************/
    public static Guid CATEGORY_NETWORK_CONFIGURATION = new(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4);

    // ======== Commands ========
    //
    // WPD_COMMAND_GENERATE_KEYPAIR 
    //    Initiates the generation of a public/private key pair and returns the public key. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_PUBLIC_KEY 
    public static PropertyKey COMMAND_GENERATE_KEYPAIR = new()
    {
        fmtid = CATEGORY_NETWORK_CONFIGURATION,
        pid = 2
    };

    //
    // WPD_COMMAND_COMMIT_KEYPAIR 
    //    Commits a public/private key pair. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     None
    // Results:
    //     None
    public static PropertyKey COMMAND_COMMIT_KEYPAIR = new()
    {
        fmtid = CATEGORY_NETWORK_CONFIGURATION,
        pid = 3
    };

    //
    // WPD_COMMAND_PROCESS_WIRELESS_PROFILE 
    //    Initiates the processing of a Wireless Profile file. 
    // Access:
    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
    // Results:
    //     None
    public static PropertyKey COMMAND_PROCESS_WIRELESS_PROFILE = new()
    {
        fmtid = CATEGORY_NETWORK_CONFIGURATION,
        pid = 4
    };

    //
    // WPD_PROPERTY_PUBLIC_KEY  
    //   [ VT_VECTOR | VT_UI1 ] A public key generated for RSA key exchange.
    public static PropertyKey PROPERTY_PUBLIC_KEY = new()
    {
        fmtid = CATEGORY_NETWORK_CONFIGURATION,
        pid = 1001
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_SERVICE_COMMON 
 *
 * The commands in this category relate to a mediaDevice service.
 ****************************************************************************/
    public static Guid CATEGORY_SERVICE_COMMON = new(0x322F071D, 0x36EF, 0x477F, 0xB4, 0xB5, 0x6F, 0x52, 0xD7, 0x34, 0xBA, 0xEE);

    // ======== Commands ========
    //
    // WPD_COMMAND_SERVICE_COMMON_GET_SERVICE_OBJECT_ID 
    //    This command is used to get the service object identifier. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_OBJECT_ID 
    public static PropertyKey COMMAND_SERVICE_COMMON_GET_SERVICE_OBJECT_ID = new()
    {
        fmtid = CATEGORY_SERVICE_COMMON,
        pid = 2
    };

    //
    // WPD_PROPERTY_SERVICE_OBJECT_ID  
    //   [ VT_LPWSTR ] Contains the service object identifier.
    public static PropertyKey PROPERTY_SERVICE_OBJECT_ID = new()
    {
        fmtid = CATEGORY_SERVICE_COMMON,
        pid = 1001
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_SERVICE_CAPABILITIES 
 *
 * The commands in this category relate to capabilities of a mediaDevice service.
 ****************************************************************************/
    public static Guid CATEGORY_SERVICE_CAPABILITIES = new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89);

    // ======== Commands ========
    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS 
    //    This command is used to get the methods that apply to a service. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 2
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS_BY_FORMAT 
    //    This command is used to get the methods that apply to a format of a service. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS_BY_FORMAT = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 3
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_ATTRIBUTES 
    //    This command is used to get the attributes of a method. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_METHOD_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 4
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_PARAMETER_ATTRIBUTES 
    //    This command is used to get the attributes of a parameter used in a method. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD 
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_METHOD_PARAMETER_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 5
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMATS 
    //    This command is used to get formats supported by this service. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMATS 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMATS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 6
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_ATTRIBUTES 
    //    This command is used to get attributes of a format, such as the format name. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 7
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES 
    //    This command is used to get supported properties of a format. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 8
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_PROPERTY_ATTRIBUTES 
    //    This command is used to get the property attributes that are same for all objects of a given format on the service. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_PROPERTY_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 9
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_EVENTS 
    //    This command is used to get the supported events of the service. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_EVENTS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 10
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_ATTRIBUTES 
    //    This command is used to get the attributes of an event. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_EVENT_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 11
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_PARAMETER_ATTRIBUTES 
    //    This command is used to get the attributes of a parameter used in an event. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT 
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_EVENT_PARAMETER_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 12
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_INHERITED_SERVICES 
    //    This command is used to get the inherited services. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_INHERITED_SERVICES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 13
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_RENDERING_PROFILES 
    //    This command is used to get the resource rendering profiles for a format. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_RENDERING_PROFILES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 14
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_COMMANDS 
    //    Return all commands supported by this driver for a service. This includes custom commands, if any. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     None
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_COMMANDS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 15
    };

    //
    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_COMMAND_OPTIONS 
    //    Returns the supported options for the specified command. 
    // Access:
    //     FILE_READ_ACCESS
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS 
    public static PropertyKey COMMAND_SERVICE_CAPABILITIES_GET_COMMAND_OPTIONS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 16
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing methods that apply to a service.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1001
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT  
    //   [ VT_CLSID ] Indicates the format the caller is interested in.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_FORMAT = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1002
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD  
    //   [ VT_CLSID ] Indicates the method the caller is interested in.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_METHOD = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1003
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the method attributes.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1004
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER  
    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the parameter the caller is interested in.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_PARAMETER = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1005
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the parameter attributes.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1006
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_FORMATS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing the formats.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_FORMATS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1007
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the format attributes, such as the format name and MIME Type.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1008
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS  
    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the supported property keys.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1009
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the property attributes.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1010
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS  
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing all events supported by the service.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1011
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT  
    //   [ VT_CLSID ] Indicates the event the caller is interested in.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_EVENT = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1012
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the event attributes.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1013
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE  
    //   [ VT_UI4 ] Indicates the inheritance type the caller is interested in.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1014
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES  
    //   [ VT_UNKNOWN ] Contains the list of inherited services.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1015
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES  
    //   [ VT_UNKNOWN ] Contains the list of format rendering profiles.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1016
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS  
    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing all commands a driver supports for a service.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1017
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND  
    //   [ VT_UNKNOWN ] Indicates the command whose options the caller is interested in.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_COMMAND = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1018
    };

    //
    // WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS  
    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant command options.
    public static PropertyKey PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS = new()
    {
        fmtid = CATEGORY_SERVICE_CAPABILITIES,
        pid = 1019
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CATEGORY_SERVICE_METHODS 
 *
 * The commands in this category relate to methods of a mediaDevice service.
 ****************************************************************************/
    public static Guid CATEGORY_SERVICE_METHODS = new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC);

    // ======== Commands ========
    //
    // WPD_COMMAND_SERVICE_METHODS_START_INVOKE 
    //    Invokes a service method. 
    // Access:
    //     Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD 
    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_PARAMETER_VALUES 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
    public static PropertyKey COMMAND_SERVICE_METHODS_START_INVOKE = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 2
    };

    //
    // WPD_COMMAND_SERVICE_METHODS_CANCEL_INVOKE 
    //    This command is sent when a client wants to cancel a method that is currently still in progress. 
    // Access:
    //     Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
    // Results:
    //     None
    public static PropertyKey COMMAND_SERVICE_METHODS_CANCEL_INVOKE = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 3
    };

    //
    // WPD_COMMAND_SERVICE_METHODS_END_INVOKE 
    //    This command is sent in response to a WPD_EVENT_SERVICE_METHOD_COMPLETE event from the driver to retrieve the method results. 
    // Access:
    //     Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
    // Parameters:
    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
    // Results:
    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_RESULT_VALUES 
    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_HRESULT 
    public static PropertyKey COMMAND_SERVICE_METHODS_END_INVOKE = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 4
    };

    //
    // WPD_PROPERTY_SERVICE_METHOD  
    //   [ VT_CLSID ] Indicates the method to invoke.
    public static PropertyKey PROPERTY_SERVICE_METHOD = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 1001
    };

    //
    // WPD_PROPERTY_SERVICE_METHOD_PARAMETER_VALUES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the method parameters.
    public static PropertyKey PROPERTY_SERVICE_METHOD_PARAMETER_VALUES = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 1002
    };

    //
    // WPD_PROPERTY_SERVICE_METHOD_RESULT_VALUES  
    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the method results.
    public static PropertyKey PROPERTY_SERVICE_METHOD_RESULT_VALUES = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 1003
    };

    //
    // WPD_PROPERTY_SERVICE_METHOD_CONTEXT  
    //   [ VT_LPWSTR ] The unique context identifying this method operation.
    public static PropertyKey PROPERTY_SERVICE_METHOD_CONTEXT = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 1004
    };

    //
    // WPD_PROPERTY_SERVICE_METHOD_HRESULT  
    //   [ VT_ERROR ] Contains the status HRESULT of this method invocation.
    public static PropertyKey PROPERTY_SERVICE_METHOD_HRESULT = new()
    {
        fmtid = CATEGORY_SERVICE_METHODS,
        pid = 1005
    };

/****************************************************************************
 * This section defines all Resource keys.  Resources are place-holders for
 * binary data.
 *
 ****************************************************************************/
    //
    //  WPD_RESOURCE_DEFAULT 
    // Represents the entire object's data. There can be only one default resource on an object. 
    public static PropertyKey RESOURCE_DEFAULT = new()
    {
        fmtid = new(0xE81E79BE, 0x34F0, 0x41BF, 0xB5, 0x3F, 0xF1, 0xA0, 0x6A, 0xE8, 0x78, 0x42),
        pid = 0
    };

    //
    //  WPD_RESOURCE_CONTACT_PHOTO 
    // Represents the contact's photo data. 
    public static PropertyKey RESOURCE_CONTACT_PHOTO = new()
    {
        fmtid = new(0x2C4D6803, 0x80EA, 0x4580, 0xAF, 0x9A, 0x5B, 0xE1, 0xA2, 0x3E, 0xDD, 0xCB),
        pid = 0
    };

    //
    //  WPD_RESOURCE_THUMBNAIL 
    // Represents the thumbnail data for an object. 
    public static PropertyKey RESOURCE_THUMBNAIL = new()
    {
        fmtid = new(0xC7C407BA, 0x98FA, 0x46B5, 0x99, 0x60, 0x23, 0xFE, 0xC1, 0x24, 0xCF, 0xDE),
        pid = 0
    };

    //
    //  WPD_RESOURCE_ICON 
    // Represents the icon data for an object. 
    public static PropertyKey RESOURCE_ICON = new()
    {
        fmtid = new(0xF195FED8, 0xAA28, 0x4EE3, 0xB1, 0x53, 0xE1, 0x82, 0xDD, 0x5E, 0xDC, 0x39),
        pid = 0
    };

    //
    //  WPD_RESOURCE_AUDIO_CLIP 
    // Represents an audio sample data for an object. 
    public static PropertyKey RESOURCE_AUDIO_CLIP = new()
    {
        fmtid = new(0x3BC13982, 0x85B1, 0x48E0, 0x95, 0xA6, 0x8D, 0x3A, 0xD0, 0x6B, 0xE1, 0x17),
        pid = 0
    };

    //
    //  WPD_RESOURCE_ALBUM_ART 
    // Represents the album artwork this media originated from. 
    public static PropertyKey RESOURCE_ALBUM_ART = new()
    {
        fmtid = new(0xF02AA354, 0x2300, 0x4E2D, 0xA1, 0xB9, 0x3B, 0x67, 0x30, 0xF7, 0xFA, 0x21),
        pid = 0
    };

    //
    //  WPD_RESOURCE_GENERIC 
    // Represents an arbitrary binary blob associated with this object. 
    public static PropertyKey RESOURCE_GENERIC = new()
    {
        fmtid = new(0xB9B9F515, 0xBA70, 0x4647, 0x94, 0xDC, 0xFA, 0x49, 0x25, 0xE9, 0x5A, 0x07),
        pid = 0
    };

    //
    //  WPD_RESOURCE_VIDEO_CLIP 
    // Represents a video sample for an object. 
    public static PropertyKey RESOURCE_VIDEO_CLIP = new()
    {
        fmtid = new(0xB566EE42, 0x6368, 0x4290, 0x86, 0x62, 0x70, 0x18, 0x2F, 0xB7, 0x9F, 0x20),
        pid = 0
    };

    //
    //  WPD_RESOURCE_BRANDING_ART 
    // Represents the product branding artwork or logo for an object. This resource is typically found on, but not limited to the mediaDevice object. 
    public static PropertyKey RESOURCE_BRANDING_ART = new()
    {
        fmtid = new(0xB633B1AE, 0x6CAF, 0x4A87, 0x95, 0x89, 0x22, 0xDE, 0xD6, 0xDD, 0x58, 0x99),
        pid = 0
    };

/****************************************************************************
 * This section defines the legacy WPD definitions
 *
 * When WPD_SERVICES_STRICT mode is defined, these definitions are removed
 * from this header file. You may find replacements or equivalents
 * in the Device Services headers (for example, BridgeDeviceService.h).
 ****************************************************************************/
/****************************************************************************
 * This section defines the legacy WPD Formats
 ****************************************************************************/
    //
    // WPD_OBJECT_FORMAT_PROPERTIES_ONLY
    //   This object has no data stream and is completely specified by properties only.
    //   Device Services FormatId: FORMAT_Association
    public static Guid OBJECT_FORMAT_PROPERTIES_ONLY = new(0x30010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_UNSPECIFIED
    //   An undefined object format on the mediaDevice (e.g. objects that can not be classified by the other defined WPD format codes)
    //   Device Services FormatId: FORMAT_Undefined
    public static Guid OBJECT_FORMAT_UNSPECIFIED = new(0x30000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_SCRIPT
    //   A mediaDevice model-specific script
    //   Device Services FormatId: FORMAT_DeviceScript
    public static Guid OBJECT_FORMAT_SCRIPT = new(0x30020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_EXECUTABLE
    //   A mediaDevice model-specific binary executable
    //   Device Services FormatId: FORMAT_DeviceExecutable
    public static Guid OBJECT_FORMAT_EXECUTABLE = new(0x30030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_TEXT
    //   A text file
    //   Device Services FormatId: FORMAT_TextDocument
    public static Guid OBJECT_FORMAT_TEXT = new(0x30040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_HTML
    //   A HyperText Markup Language file (text)
    //   Device Services FormatId: FORMAT_HTMLDocument
    public static Guid OBJECT_FORMAT_HTML = new(0x30050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_DPOF
    //   A Digital Print Order File (text)
    //   Device Services FormatId: FORMAT_DPOFDocument
    public static Guid OBJECT_FORMAT_DPOF = new(0x30060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_AIFF
    //   Audio file format
    //   Device Services FormatId: FORMAT_AIFFFile
    public static Guid OBJECT_FORMAT_AIFF = new(0x30070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_WAVE
    //   Audio file format
    //   Device Services FormatId: FORMAT_WAVFile
    public static Guid OBJECT_FORMAT_WAVE = new(0x30080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MP3
    //   Audio file format
    //   Device Services FormatId: FORMAT_MP3File
    public static Guid OBJECT_FORMAT_MP3 = new(0x30090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_AVI
    //   Video file format
    //   Device Services FormatId: FORMAT_AVIFile
    public static Guid OBJECT_FORMAT_AVI = new(0x300A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MPEG
    //   Video file format
    //   Device Services FormatId: FORMAT_MPEGFile
    public static Guid OBJECT_FORMAT_MPEG = new(0x300B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_ASF
    //   Video file format (Microsoft Advanced Streaming FormatId)
    //   Device Services FormatId: FORMAT_ASFFile
    public static Guid OBJECT_FORMAT_ASF = new(0x300C0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_EXIF
    //   Image file format (Exchangeable File FormatId), JEIDA standard
    //   Device Services FormatId: FORMAT_EXIFImage
    public static Guid OBJECT_FORMAT_EXIF = new(0x38010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_TIFFEP
    //   Image file format (Tag Image File FormatId for Electronic Photography)
    //   Device Services FormatId: FORMAT_TIFFEPImage
    public static Guid OBJECT_FORMAT_TIFFEP = new(0x38020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_FLASHPIX
    //   Image file format (Structured Storage Image FormatId)
    //   Device Services FormatId: FORMAT_FlashPixImage
    public static Guid OBJECT_FORMAT_FLASHPIX = new(0x38030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_BMP
    //   Image file format (Microsoft Windows Bitmap file)
    //   Device Services FormatId: FORMAT_BMPImage
    public static Guid OBJECT_FORMAT_BMP = new(0x38040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_CIFF
    //   Image file format (Canon Camera Image File FormatId)
    //   Device Services FormatId: FORMAT_CIFFImage
    public static Guid OBJECT_FORMAT_CIFF = new(0x38050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_GIF
    //   Image file format (Graphics Interchange FormatId)
    //   Device Services FormatId: FORMAT_GIFImage
    public static Guid OBJECT_FORMAT_GIF = new(0x38070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_JFIF
    //   Image file format (JPEG Interchange FormatId)
    //   Device Services FormatId: FORMAT_JFIFImage
    public static Guid OBJECT_FORMAT_JFIF = new(0x38080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_PCD
    //   Image file format (PhotoCD Image Pac)
    //   Device Services FormatId: FORMAT_PCDImage
    public static Guid OBJECT_FORMAT_PCD = new(0x38090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_PICT
    //   Image file format (Quickdraw Image FormatId)
    //   Device Services FormatId: FORMAT_PICTImage
    public static Guid OBJECT_FORMAT_PICT = new(0x380A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_PNG
    //   Image file format (Portable Network Graphics)
    //   Device Services FormatId: FORMAT_PNGImage
    public static Guid OBJECT_FORMAT_PNG = new(0x380B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_TIFF
    //   Image file format (Tag Image File FormatId)
    //   Device Services FormatId: FORMAT_TIFFImage
    public static Guid OBJECT_FORMAT_TIFF = new(0x380D0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_TIFFIT
    //   Image file format (Tag Image File FormatId for Informational Technology) Graphic Arts
    //   Device Services FormatId: FORMAT_TIFFITImage
    public static Guid OBJECT_FORMAT_TIFFIT = new(0x380E0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_JP2
    //   Image file format (JPEG2000 Baseline File FormatId)
    //   Device Services FormatId: FORMAT_JP2Image
    public static Guid OBJECT_FORMAT_JP2 = new(0x380F0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_JPX
    //   Image file format (JPEG2000 Extended File FormatId)
    //   Device Services FormatId: FORMAT_JPXImage
    public static Guid OBJECT_FORMAT_JPX = new(0x38100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_WBMP
    //   Image file format (Wireless Application Protocol Bitmap FormatId)
    //   Device Services FormatId: FORMAT_WBMPImage
    public static Guid OBJECT_FORMAT_WBMP = new(0xB8030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_JPEGXR
    //   Image file format (JPEG XR, also known as HD Photo)
    //   Device Services FormatId: FORMAT_JPEGXRImage
    public static Guid OBJECT_FORMAT_JPEGXR = new(0xB8040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT
    //   Image file format
    //   Device Services FormatId: FORMAT_HDPhotoImage
    public static Guid OBJECT_FORMAT_WINDOWSIMAGEFORMAT = new(0xB8810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_WMA
    //   Audio file format (Windows Media Audio)
    //   Device Services FormatId: FORMAT_WMAFile
    public static Guid OBJECT_FORMAT_WMA = new(0xB9010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_WMV
    //   Video file format (Windows Media Video)
    //   Device Services FormatId: FORMAT_WMVFile
    public static Guid OBJECT_FORMAT_WMV = new(0xB9810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_WPLPLAYLIST
    //   Playlist file format
    //   Device Services FormatId: FORMAT_WPLPlaylist
    public static Guid OBJECT_FORMAT_WPLPLAYLIST = new(0xBA100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_M3UPLAYLIST
    //   Playlist file format
    //   Device Services FormatId: FORMAT_M3UPlaylist
    public static Guid OBJECT_FORMAT_M3UPLAYLIST = new(0xBA110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MPLPLAYLIST
    //   Playlist file format
    //   Device Services FormatId: FORMAT_MPLPlaylist
    public static Guid OBJECT_FORMAT_MPLPLAYLIST = new(0xBA120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_ASXPLAYLIST
    //   Playlist file format
    //   Device Services FormatId: FORMAT_ASXPlaylist
    public static Guid OBJECT_FORMAT_ASXPLAYLIST = new(0xBA130000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_PLSPLAYLIST
    //   Playlist file format
    //   Device Services FormatId: FORMAT_PSLPlaylist
    public static Guid OBJECT_FORMAT_PLSPLAYLIST = new(0xBA140000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP
    //   Generic format for contact group objects
    //   Device Services FormatId: FORMAT_AbstractContactGroup
    public static Guid OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP = new(0xBA060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST
    //   MediaCast file format
    //   Device Services FormatId: FORMAT_AbstractMediacast
    public static Guid OBJECT_FORMAT_ABSTRACT_MEDIA_CAST = new(0xBA0B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_VCALENDAR1
    //   VCALENDAR file format (VCALENDAR Version 1)
    //   Device Services FormatId: FORMAT_VCalendar1
    public static Guid OBJECT_FORMAT_VCALENDAR1 = new(0xBE020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_ICALENDAR
    //   ICALENDAR file format (VCALENDAR Version 2)
    //   Device Services FormatId: FORMAT_ICalendar
    public static Guid OBJECT_FORMAT_ICALENDAR = new(0xBE030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_ABSTRACT_CONTACT
    //   Abstract contact file format
    //   Device Services FormatId: FORMAT_AbstractContact
    public static Guid OBJECT_FORMAT_ABSTRACT_CONTACT = new(0xBB810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_VCARD2
    //   VCARD file format (VCARD Version 2)
    //   Device Services FormatId: FORMAT_VCard2Contact
    public static Guid OBJECT_FORMAT_VCARD2 = new(0xBB820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_VCARD3
    //   VCARD file format (VCARD Version 3)
    //   Device Services FormatId: FORMAT_VCard3Contact
    public static Guid OBJECT_FORMAT_VCARD3 = new(0xBB830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_XML
    //   XML file format.
    //   Device Services FormatId: FORMAT_XMLDocument
    public static Guid OBJECT_FORMAT_XML = new(0xBA820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_AAC
    //   Audio file format
    //   Device Services FormatId: FORMAT_AACFile
    public static Guid OBJECT_FORMAT_AAC = new(0xB9030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_AUDIBLE
    //   Audio file format
    //   Device Services FormatId: FORMAT_AudibleFile
    public static Guid OBJECT_FORMAT_AUDIBLE = new(0xB9040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_FLAC
    //   Audio file format
    //   Device Services FormatId: FORMAT_FLACFile
    public static Guid OBJECT_FORMAT_FLAC = new(0xB9060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_QCELP
    //   Audio file format (Qualcomm Code Excited Linear Prediction)
    //   Device Services FormatId: FORMAT_QCELPFile
    public static Guid OBJECT_FORMAT_QCELP = new(0xB9070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_AMR
    //   Audio file format (Adaptive Multi-Rate audio codec)
    //   Device Services FormatId: FORMAT_AMRFile
    public static Guid OBJECT_FORMAT_AMR = new(0xB9080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_OGG
    //   Audio file format
    //   Device Services FormatId: FORMAT_OGGFile
    public static Guid OBJECT_FORMAT_OGG = new(0xB9020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MP4
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_MPEG4File
    public static Guid OBJECT_FORMAT_MP4 = new(0xB9820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MP2
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_MPEG2File
    public static Guid OBJECT_FORMAT_MP2 = new(0xB9830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MICROSOFT_WORD
    //   Microsoft Office Word Document file format.
    //   Device Services FormatId: FORMAT_WordDocument
    public static Guid OBJECT_FORMAT_MICROSOFT_WORD = new(0xBA830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MHT_COMPILED_HTML
    //   MHT Compiled HTML Document file format.
    //   Device Services FormatId: FORMAT_MHTDocument
    public static Guid OBJECT_FORMAT_MHT_COMPILED_HTML = new(0xBA840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MICROSOFT_EXCEL
    //   Microsoft Office Excel Document file format.
    //   Device Services FormatId: FORMAT_ExcelDocument
    public static Guid OBJECT_FORMAT_MICROSOFT_EXCEL = new(0xBA850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT
    //   Microsoft Office PowerPoint Document file format.
    //   Device Services FormatId: FORMAT_PowerPointDocument
    public static Guid OBJECT_FORMAT_MICROSOFT_POWERPOINT = new(0xBA860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_3GP
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_3GPPFile
    public static Guid OBJECT_FORMAT_3GP = new(0xB9840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_3G2
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_3GPP2File
    public static Guid OBJECT_FORMAT_3G2 = new(0xB9850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_AVCHD
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_AVCHDFile
    public static Guid OBJECT_FORMAT_AVCHD = new(0xB9860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_ATSCTS
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_ATSCTSFile
    public static Guid OBJECT_FORMAT_ATSCTS = new(0xB9870000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_DVBTS
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_DVBTSFile
    public static Guid OBJECT_FORMAT_DVBTS = new(0xB9880000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

    //
    // WPD_OBJECT_FORMAT_MKV
    //   Audio or Video file format
    //   Device Services FormatId: FORMAT_MKVFile
    public static Guid OBJECT_FORMAT_MKV = new(0xB9900000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

/****************************************************************************
 * This section defines the legacy WPD Properties
 ****************************************************************************/
    //
    // WPD_OBJECT_ID 
    //   [ VT_LPWSTR ] Uniquely identifies object on the Portable Device.
    //   Recommended Device Services Property: PKEY_GenericObj_ObjectID
    public static PropertyKey OBJECT_ID = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 2
    };

    // WPD_OBJECT_PARENT_ID 
    //   [ VT_LPWSTR ] Object identifier indicating the parent object.
    //   Recommended Device Services Property: PKEY_GenericObj_ParentID
    public static PropertyKey OBJECT_PARENT_ID = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 3
    };

    // WPD_OBJECT_NAME 
    //   [ VT_LPWSTR ] The display name for this object.
    //   Recommended Device Services Property: PKEY_GenericObj_Name
    public static PropertyKey OBJECT_NAME = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 4
    };

    // WPD_OBJECT_PERSISTENT_UNIQUE_ID 
    //   [ VT_LPWSTR ] Uniquely identifies the object on the Portable Device, similar to WPD_OBJECT_ID, but this ID will not change between sessions.
    //   Recommended Device Services Property: PKEY_GenericObj_PersistentUID
    public static PropertyKey OBJECT_PERSISTENT_UNIQUE_ID = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 5
    };

    // WPD_OBJECT_FORMAT 
    //   [ VT_CLSID ] Indicates the format of the object's data.
    //   Recommended Device Services Property: PKEY_GenericObj_ObjectFormat
    public static PropertyKey OBJECT_FORMAT = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 6
    };

    // WPD_OBJECT_ISHIDDEN 
    //   [ VT_BOOL ] Indicates whether the object should be hidden.
    //   Recommended Device Services Property: PKEY_GenericObj_Hidden
    public static PropertyKey OBJECT_ISHIDDEN = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 9
    };

    // WPD_OBJECT_ISSYSTEM 
    //   [ VT_BOOL ] Indicates whether the object represents system data.
    //   Recommended Device Services Property: PKEY_GenericObj_SystemObject
    public static PropertyKey OBJECT_ISSYSTEM = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 10
    };

    // WPD_OBJECT_SIZE 
    //   [ VT_UI8 ] The size of the object data.
    //   Recommended Device Services Property: PKEY_GenericObj_ObjectSize
    public static PropertyKey OBJECT_SIZE = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 11
    };

    // WPD_OBJECT_ORIGINAL_FILE_NAME 
    //   [ VT_LPWSTR ] Contains the name of the file this object represents.
    //   Recommended Device Services Property: PKEY_GenericObj_ObjectFileName
    public static PropertyKey OBJECT_ORIGINAL_FILE_NAME = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 12
    };

    // WPD_OBJECT_NON_CONSUMABLE 
    //   [ VT_BOOL ] This property determines whether or not this object is intended to be understood by the mediaDevice, or whether it has been placed on the mediaDevice just for storage.
    //   Recommended Device Services Property: PKEY_GenericObj_NonConsumable
    public static PropertyKey OBJECT_NON_CONSUMABLE = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 13
    };

    // WPD_OBJECT_KEYWORDS 
    //   [ VT_LPWSTR ] String containing a list of keywords associated with this object.
    //   Recommended Device Services Property: PKEY_GenericObj_Keywords
    public static PropertyKey OBJECT_KEYWORDS = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 15
    };

    // WPD_OBJECT_SYNC_ID 
    //   [ VT_LPWSTR ] Opaque string set by client to retain state between sessions without retaining a catalogue of connected mediaDevice content.
    //   Recommended Device Services Property: PKEY_GenericObj_SyncID
    public static PropertyKey OBJECT_SYNC_ID = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 16
    };

    // WPD_OBJECT_IS_DRM_PROTECTED 
    //   [ VT_BOOL ] Indicates whether the media data is DRM protected.
    //   Recommended Device Services Property: PKEY_GenericObj_DRMStatus
    public static PropertyKey OBJECT_IS_DRM_PROTECTED = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 17
    };

    // WPD_OBJECT_DATE_CREATED 
    //   [ VT_DATE ] Indicates the date and time the object was created on the mediaDevice.
    //   Recommended Device Services Property: PKEY_GenericObj_DateCreated
    public static PropertyKey OBJECT_DATE_CREATED = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 18
    };

    // WPD_OBJECT_DATE_MODIFIED 
    //   [ VT_DATE ] Indicates the date and time the object was modified on the mediaDevice.
    //   Recommended Device Services Property: PKEY_GenericObj_DateModified
    public static PropertyKey OBJECT_DATE_MODIFIED = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 19
    };

    // WPD_OBJECT_DATE_AUTHORED 
    //   [ VT_DATE ] Indicates the date and time the object was authored (e.g. for music, this would be the date the music was recorded).
    //   Recommended Device Services Property: PKEY_GenericObj_DateAuthored
    public static PropertyKey OBJECT_DATE_AUTHORED = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 20
    };

    // WPD_OBJECT_BACK_REFERENCES 
    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of ObjectIDs.
    //   Recommended Device Services Property: PKEY_GenericObj_ReferenceParentID
    public static PropertyKey OBJECT_BACK_REFERENCES = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 21
    };

    // WPD_OBJECT_CAN_DELETE 
    //   [ VT_BOOL ] Indicates whether the object can be deleted, or not.
    //   Recommended Device Services Property: PKEY_GenericObj_ProtectionStatus
    public static PropertyKey OBJECT_CAN_DELETE = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 26
    };

    // WPD_OBJECT_LANGUAGE_LOCALE 
    //   [ VT_LPWSTR ] Identifies the language of this object. If multiple languages are contained in this object, it should identify the primary language (if any).
    //   Recommended Device Services Property: PKEY_GenericObj_LanguageLocale
    public static PropertyKey OBJECT_LANGUAGE_LOCALE = new()
    {
        fmtid = OBJECT_PROPERTIES_V1,
        pid = 27
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_FOLDER_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all folder objects.
 ****************************************************************************/
    public static Guid FOLDER_OBJECT_PROPERTIES_V1 = new(0x7E9A7ABF, 0xE568, 0x4B34, 0xAA, 0x2F, 0x13, 0xBB, 0x12, 0xAB, 0x17, 0x7D);

    //
    // WPD_FOLDER_CONTENT_TYPES_ALLOWED 
    //   [ VT_UNKNOWN ] Indicates the subset of content types that can be created in this folder directly (i.e. children may have different restrictions).
    //   Recommended Device Services Property: None
    public static PropertyKey FOLDER_CONTENT_TYPES_ALLOWED = new()
    {
        fmtid = FOLDER_OBJECT_PROPERTIES_V1,
        pid = 2
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_IMAGE_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all image objects.
 ****************************************************************************/
    public static Guid IMAGE_OBJECT_PROPERTIES_V1 = new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB);

    //
    // WPD_IMAGE_BITDEPTH 
    //   [ VT_UI4 ] Indicates the bitdepth of an image
    //   Recommended Device Services Property: PKEY_ImageObj_ImageBitDepth
    public static PropertyKey IMAGE_BITDEPTH = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_IMAGE_CROPPED_STATUS 
    //   [ VT_UI4 ] Signals whether the file has been cropped.
    //   Recommended Device Services Property: PKEY_ImageObj_IsCropped
    public static PropertyKey IMAGE_CROPPED_STATUS = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_IMAGE_COLOR_CORRECTED_STATUS 
    //   [ VT_UI4 ] Signals whether the file has been color corrected.
    //   Recommended Device Services Property: PKEY_ImageObj_IsColorCorrected
    public static PropertyKey IMAGE_COLOR_CORRECTED_STATUS = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_IMAGE_FNUMBER 
    //   [ VT_UI4 ] Identifies the aperture setting of the lens when this image was captured.
    //   Recommended Device Services Property: PKEY_ImageObj_Aperature
    public static PropertyKey IMAGE_FNUMBER = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_IMAGE_EXPOSURE_TIME 
    //   [ VT_UI4 ] Identifies the shutter speed of the mediaDevice when this image was captured.
    //   Recommended Device Services Property: PKEY_ImageObj_Exposure
    public static PropertyKey IMAGE_EXPOSURE_TIME = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_IMAGE_EXPOSURE_INDEX 
    //   [ VT_UI4 ] Identifies the emulation of film speed settings when this image was captured.
    //   Recommended Device Services Property: PKEY_ImageObj_ISOSpeed
    public static PropertyKey IMAGE_EXPOSURE_INDEX = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_IMAGE_HORIZONTAL_RESOLUTION 
    //   [ VT_R8 ] Indicates the horizontal resolution (DPI) of an image
    //   Recommended Device Services Property: None
    public static PropertyKey IMAGE_HORIZONTAL_RESOLUTION = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_IMAGE_VERTICAL_RESOLUTION 
    //   [ VT_R8 ] Indicates the vertical resolution (DPI) of an image
    //   Recommended Device Services Property: None
    public static PropertyKey IMAGE_VERTICAL_RESOLUTION = new()
    {
        fmtid = IMAGE_OBJECT_PROPERTIES_V1,
        pid = 10
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_DOCUMENT_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all document objects.
 ****************************************************************************/
    public static Guid DOCUMENT_OBJECT_PROPERTIES_V1 = new(0x0B110203, 0xEB95, 0x4F02, 0x93, 0xE0, 0x97, 0xC6, 0x31, 0x49, 0x3A, 0xD5);

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_MEDIA_PROPERTIES_V1 
 *
 * This category is for properties common to media objects (e.g. audio and video).
 ****************************************************************************/
    public static Guid MEDIA_PROPERTIES_V1 = new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8);

    //
    // WPD_MEDIA_TOTAL_BITRATE 
    //   [ VT_UI4 ] The total number of bits that one second will consume.
    //   Recommended Device Services Property: PKEY_MediaObj_TotalBitRate
    public static PropertyKey MEDIA_TOTAL_BITRATE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_MEDIA_BITRATE_TYPE 
    //   [ VT_UI4 ] Further qualifies the bitrate of audio or video data.
    //   Recommended Device Services Property: PKEY_MediaObj_BitRateType
    public static PropertyKey MEDIA_BITRATE_TYPE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_MEDIA_COPYRIGHT 
    //   [ VT_LPWSTR ] Indicates the copyright information.
    //   Recommended Device Services Property: PKEY_GenericObj_Copyright
    public static PropertyKey MEDIA_COPYRIGHT = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_MEDIA_SUBSCRIPTION_CONTENT_ID 
    //   [ VT_LPWSTR ] Provides additional information to identify a piece of content relative to an online subscription service.
    //   Recommended Device Services Property: PKEY_MediaObj_SubscriptionContentID
    public static PropertyKey MEDIA_SUBSCRIPTION_CONTENT_ID = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_MEDIA_USE_COUNT 
    //   [ VT_UI4 ] Indicates the total number of times this media has been played or viewed on the mediaDevice.
    //   Recommended Device Services Property: PKEY_MediaObj_UseCount
    public static PropertyKey MEDIA_USE_COUNT = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_MEDIA_SKIP_COUNT 
    //   [ VT_UI4 ] Indicates the total number of times this media was setup to be played or viewed but was manually skipped by the user.
    //   Recommended Device Services Property: PKEY_MediaObj_SkipCount
    public static PropertyKey MEDIA_SKIP_COUNT = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_MEDIA_LAST_ACCESSED_TIME 
    //   [ VT_DATE ] Indicates the date and time the media was last accessed on the mediaDevice.
    //   Recommended Device Services Property: PKEY_GenericObj_DateAccessed
    public static PropertyKey MEDIA_LAST_ACCESSED_TIME = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_MEDIA_PARENTAL_RATING 
    //   [ VT_LPWSTR ] Indicates the parental rating of the media file.
    //   Recommended Device Services Property: PKEY_MediaObj_ParentalRating
    public static PropertyKey MEDIA_PARENTAL_RATING = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_MEDIA_META_GENRE 
    //   [ VT_UI4 ] Further qualifies a piece of media in a contextual way.
    //   Recommended Device Services Property: PKEY_MediaObj_MediaType
    public static PropertyKey MEDIA_META_GENRE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_MEDIA_COMPOSER 
    //   [ VT_LPWSTR ] Identifies the composer when the composer is not the artist who performed it.
    //   Recommended Device Services Property: PKEY_MediaObj_Composer
    public static PropertyKey MEDIA_COMPOSER = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_MEDIA_EFFECTIVE_RATING 
    //   [ VT_UI4 ] Contains an assigned rating for media not set by the user, but is generated based upon usage statistics.
    //   Recommended Device Services Property: PKEY_MediaObj_EffectiveRating
    public static PropertyKey MEDIA_EFFECTIVE_RATING = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_MEDIA_SUB_TITLE 
    //   [ VT_LPWSTR ] Further qualifies the title when the title is ambiguous or general.
    //   Recommended Device Services Property: PKEY_MediaObj_Subtitle
    public static PropertyKey MEDIA_SUB_TITLE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 13
    };

    //
    // WPD_MEDIA_RELEASE_DATE 
    //   [ VT_DATE ] Indicates when the media was released.
    //   Recommended Device Services Property: PKEY_MediaObj_DateOriginalRelease
    public static PropertyKey MEDIA_RELEASE_DATE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 14
    };

    //
    // WPD_MEDIA_SAMPLE_RATE 
    //   [ VT_UI4 ] Indicates the number of times media selection was sampled per second during encoding.
    //   Recommended Device Services Property: PKEY_MediaObj_SampleRate
    public static PropertyKey MEDIA_SAMPLE_RATE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 15
    };

    //
    // WPD_MEDIA_STAR_RATING 
    //   [ VT_UI4 ] Indicates the star rating for this media.
    //   Recommended Device Services Property: None
    public static PropertyKey MEDIA_STAR_RATING = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 16
    };

    //
    // WPD_MEDIA_USER_EFFECTIVE_RATING 
    //   [ VT_UI4 ] Indicates the rating for this media.
    //   Recommended Device Services Property: PKEY_MediaObj_UserRating
    public static PropertyKey MEDIA_USER_EFFECTIVE_RATING = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 17
    };

    //
    // WPD_MEDIA_TITLE 
    //   [ VT_LPWSTR ] Indicates the title of this media.
    //   Recommended Device Services Property: None
    public static PropertyKey MEDIA_TITLE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 18
    };

    //
    // WPD_MEDIA_DURATION 
    //   [ VT_UI8 ] Indicates the duration of this media in milliseconds.
    //   Recommended Device Services Property: PKEY_MediaObj_Duration
    public static PropertyKey MEDIA_DURATION = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 19
    };

    //
    // WPD_MEDIA_BUY_NOW 
    //   [ VT_BOOL ] TBD
    //   Recommended Device Services Property: None
    public static PropertyKey MEDIA_BUY_NOW = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 20
    };

    //
    // WPD_MEDIA_ENCODING_PROFILE 
    //   [ VT_LPWSTR ] Media codecs may be encoded in accordance with a profile, which defines a particular encoding algorithm or optimization process.
    //   Recommended Device Services Property: PKEY_MediaObj_EncodingProfile
    public static PropertyKey MEDIA_ENCODING_PROFILE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 21
    };

    //
    // WPD_MEDIA_WIDTH 
    //   [ VT_UI4 ] Indicates the width of an object in pixels
    //   Recommended Device Services Property: PKEY_MediaObj_Width
    public static PropertyKey MEDIA_WIDTH = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 22
    };

    //
    // WPD_MEDIA_HEIGHT 
    //   [ VT_UI4 ] Indicates the height of an object in pixels
    //   Recommended Device Services Property: PKEY_MediaObj_Height
    public static PropertyKey MEDIA_HEIGHT = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 23
    };

    //
    // WPD_MEDIA_ARTIST 
    //   [ VT_LPWSTR ] Indicates the artist for this media.
    //   Recommended Device Services Property: PKEY_MediaObj_Artist
    public static PropertyKey MEDIA_ARTIST = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 24
    };

    //
    // WPD_MEDIA_ALBUM_ARTIST 
    //   [ VT_LPWSTR ] Indicates the artist of the entire album rather than for a particular track.
    //   Recommended Device Services Property: PKEY_MediaObj_AlbumArtist
    public static PropertyKey MEDIA_ALBUM_ARTIST = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 25
    };

    //
    // WPD_MEDIA_OWNER 
    //   [ VT_LPWSTR ] Indicates the e-mail address of the owner for this media.
    //   Recommended Device Services Property: PKEY_MediaObj_Owner
    public static PropertyKey MEDIA_OWNER = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 26
    };

    //
    // WPD_MEDIA_MANAGING_EDITOR 
    //   [ VT_LPWSTR ] Indicates the e-mail address of the managing editor for this media.
    //   Recommended Device Services Property: PKEY_MediaObj_Editor
    public static PropertyKey MEDIA_MANAGING_EDITOR = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 27
    };

    //
    // WPD_MEDIA_WEBMASTER 
    //   [ VT_LPWSTR ] Indicates the e-mail address of the Webmaster for this media.
    //   Recommended Device Services Property: PKEY_MediaObj_WebMaster
    public static PropertyKey MEDIA_WEBMASTER = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 28
    };

    //
    // WPD_MEDIA_SOURCE_URL 
    //   [ VT_LPWSTR ] Identifies the source URL for this object.
    //   Recommended Device Services Property: PKEY_MediaObj_URLSource
    public static PropertyKey MEDIA_SOURCE_URL = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 29
    };

    //
    // WPD_MEDIA_DESTINATION_URL 
    //   [ VT_LPWSTR ] Identifies the URL that an object is linked to if a user clicks on it.
    //   Recommended Device Services Property: PKEY_MediaObj_URLLink
    public static PropertyKey MEDIA_DESTINATION_URL = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 30
    };

    //
    // WPD_MEDIA_DESCRIPTION 
    //   [ VT_LPWSTR ] Contains a description of the media content for this object.
    //   Recommended Device Services Property: PKEY_GenericObj_Description
    public static PropertyKey MEDIA_DESCRIPTION = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 31
    };

    //
    // WPD_MEDIA_GENRE 
    //   [ VT_LPWSTR ] A text field indicating the genre this media belongs to.
    //   Recommended Device Services Property: PKEY_MediaObj_Genre
    public static PropertyKey MEDIA_GENRE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 32
    };

    //
    // WPD_MEDIA_TIME_BOOKMARK 
    //   [ VT_UI8 ] Indicates a bookmark (in milliseconds) of the last position played or viewed on media that have duration.
    //   Recommended Device Services Property: PKEY_MediaObj_BookmarkTime
    public static PropertyKey MEDIA_TIME_BOOKMARK = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 33
    };

    //
    // WPD_MEDIA_OBJECT_BOOKMARK 
    //   [ VT_LPWSTR ] Indicates a WPD_OBJECT_ID of the last object viewed or played for those objects that refer to a list of objects (such as playlists or media casts).
    //   Recommended Device Services Property: PKEY_MediaObj_BookmarkObject
    public static PropertyKey MEDIA_OBJECT_BOOKMARK = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 34
    };

    //
    // WPD_MEDIA_LAST_BUILD_DATE 
    //   [ VT_DATE ] Indicates the last time a series in a media cast was changed or edited.
    //   Recommended Device Services Property: PKEY_GenericObj_DateRevised
    public static PropertyKey MEDIA_LAST_BUILD_DATE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 35
    };

    //
    // WPD_MEDIA_BYTE_BOOKMARK 
    //   [ VT_UI8 ] Indicates a bookmark (as a zero-based byte offset) of the last position played or viewed on this media object.
    //   Recommended Device Services Property: PKEY_MediaObj_BookmarkByte
    public static PropertyKey MEDIA_BYTE_BOOKMARK = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 36
    };

    //
    // WPD_MEDIA_TIME_TO_LIVE 
    //   [ VT_UI8 ] It is the number of minutes that indicates how long a channel can be cached before refreshing from the source. Applies to WPD_CONTENT_TYPE_MEDIA_CAST objects.
    //   Recommended Device Services Property: PKEY_GenericObj_TimeToLive
    public static PropertyKey MEDIA_TIME_TO_LIVE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 37
    };

    //
    // WPD_MEDIA_GUID 
    //   [ VT_LPWSTR ] A text field indicating the GUID of this media.
    //   Recommended Device Services Property: PKEY_MediaObj_MediaUID
    public static PropertyKey MEDIA_GUID = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 38
    };

    //
    // WPD_MEDIA_SUB_DESCRIPTION 
    //   [ VT_LPWSTR ] Contains a sub description of the media content for this object.
    //   Recommended Device Services Property: PKEY_GenericObj_SubDescription
    public static PropertyKey MEDIA_SUB_DESCRIPTION = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 39
    };

    //
    // WPD_MEDIA_AUDIO_ENCODING_PROFILE 
    //   [ VT_LPWSTR ] Media codecs may be encoded in accordance with a profile, which defines a particular encoding algorithm or optimization process.
    //   Recommended Device Services Property: PKEY_MediaObj_AudioEncodingProfile
    public static PropertyKey MEDIA_AUDIO_ENCODING_PROFILE = new()
    {
        fmtid = MEDIA_PROPERTIES_V1,
        pid = 49
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_CONTACT_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all contact objects.
 ****************************************************************************/
    public static Guid CONTACT_OBJECT_PROPERTIES_V1 = new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B);

    //
    // WPD_CONTACT_DISPLAY_NAME 
    //   [ VT_LPWSTR ] Indicates the display name of the contact (e.g "John Doe")
    //   Recommended Device Services Property: None
    public static PropertyKey CONTACT_DISPLAY_NAME = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_CONTACT_FIRST_NAME 
    //   [ VT_LPWSTR ] Indicates the first name of the contact (e.g. "John")
    //   Recommended Device Services Property: PKEY_ContactObj_GivenName
    public static PropertyKey CONTACT_FIRST_NAME = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_CONTACT_MIDDLE_NAMES 
    //   [ VT_LPWSTR ] Indicates the middle name of the contact
    //   Recommended Device Services Property: PKEY_ContactObj_MiddleNames
    public static PropertyKey CONTACT_MIDDLE_NAMES = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_CONTACT_LAST_NAME 
    //   [ VT_LPWSTR ] Indicates the last name of the contact (e.g. "Doe")
    //   Recommended Device Services Property: PKEY_ContactObj_FamilyName
    public static PropertyKey CONTACT_LAST_NAME = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_CONTACT_PREFIX 
    //   [ VT_LPWSTR ] Indicates the prefix of the name of the contact (e.g. "Mr.")
    //   Recommended Device Services Property: PKEY_ContactObj_Title
    public static PropertyKey CONTACT_PREFIX = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_CONTACT_SUFFIX 
    //   [ VT_LPWSTR ] Indicates the suffix of the name of the contact (e.g. "Jr.")
    //   Recommended Device Services Property: PKEY_ContactObj_Suffix
    public static PropertyKey CONTACT_SUFFIX = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_CONTACT_PHONETIC_FIRST_NAME 
    //   [ VT_LPWSTR ] The phonetic guide for pronouncing the contact's first name.
    //   Recommended Device Services Property: PKEY_ContactObj_PhoneticGivenName
    public static PropertyKey CONTACT_PHONETIC_FIRST_NAME = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_CONTACT_PHONETIC_LAST_NAME 
    //   [ VT_LPWSTR ] The phonetic guide for pronouncing the contact's last name.
    //   Recommended Device Services Property: PKEY_ContactObj_PhoneticFamilyName
    public static PropertyKey CONTACT_PHONETIC_LAST_NAME = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_CONTACT_PERSONAL_FULL_POSTAL_ADDRESS 
    //   [ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive, PhoneLand, WA 12345")
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressFull
    public static PropertyKey CONTACT_PERSONAL_FULL_POSTAL_ADDRESS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_LINE1 
    //   [ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive")
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressStreet
    public static PropertyKey CONTACT_PERSONAL_POSTAL_ADDRESS_LINE1 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_LINE2 
    //   [ VT_LPWSTR ] Indicates the second line of a postal address of the contact
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressLine2
    public static PropertyKey CONTACT_PERSONAL_POSTAL_ADDRESS_LINE2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_CITY 
    //   [ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand")
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressCity
    public static PropertyKey CONTACT_PERSONAL_POSTAL_ADDRESS_CITY = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 13
    };

    //
    // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_REGION 
    //   [ VT_LPWSTR ] Indicates the region of a postal address of the contact
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressRegion
    public static PropertyKey CONTACT_PERSONAL_POSTAL_ADDRESS_REGION = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 14
    };

    //
    // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_POSTAL_CODE 
    //   [ VT_LPWSTR ] Indicates the postal code of the address.
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressPostalCode
    public static PropertyKey CONTACT_PERSONAL_POSTAL_ADDRESS_POSTAL_CODE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 15
    };

    //
    // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_COUNTRY 
    //   [ VT_LPWSTR ] 
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressCountry
    public static PropertyKey CONTACT_PERSONAL_POSTAL_ADDRESS_COUNTRY = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 16
    };

    //
    // WPD_CONTACT_BUSINESS_FULL_POSTAL_ADDRESS 
    //   [ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive, PhoneLand, WA 12345")
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressFull
    public static PropertyKey CONTACT_BUSINESS_FULL_POSTAL_ADDRESS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 17
    };

    //
    // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_LINE1 
    //   [ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive")
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressStreet
    public static PropertyKey CONTACT_BUSINESS_POSTAL_ADDRESS_LINE1 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 18
    };

    //
    // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_LINE2 
    //   [ VT_LPWSTR ] Indicates the second line of a postal address of the contact
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressLine2
    public static PropertyKey CONTACT_BUSINESS_POSTAL_ADDRESS_LINE2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 19
    };

    //
    // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_CITY 
    //   [ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand")
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressCity
    public static PropertyKey CONTACT_BUSINESS_POSTAL_ADDRESS_CITY = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 20
    };

    //
    // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_REGION 
    //   [ VT_LPWSTR ] 
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressRegion
    public static PropertyKey CONTACT_BUSINESS_POSTAL_ADDRESS_REGION = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 21
    };

    //
    // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_POSTAL_CODE 
    //   [ VT_LPWSTR ] Indicates the postal code of the address.
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressPostalCode
    public static PropertyKey CONTACT_BUSINESS_POSTAL_ADDRESS_POSTAL_CODE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 22
    };

    //
    // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_COUNTRY 
    //   [ VT_LPWSTR ] 
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressCountry
    public static PropertyKey CONTACT_BUSINESS_POSTAL_ADDRESS_COUNTRY = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 23
    };

    //
    // WPD_CONTACT_OTHER_FULL_POSTAL_ADDRESS 
    //   [ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive, PhoneLand, WA 12345").
    //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressFull
    public static PropertyKey CONTACT_OTHER_FULL_POSTAL_ADDRESS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 24
    };

    //
    // WPD_CONTACT_OTHER_POSTAL_ADDRESS_LINE1 
    //   [ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive").
    //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressStreet
    public static PropertyKey CONTACT_OTHER_POSTAL_ADDRESS_LINE1 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 25
    };

    //
    // WPD_CONTACT_OTHER_POSTAL_ADDRESS_LINE2 
    //   [ VT_LPWSTR ] Indicates the second line of a postal address of the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressLine2
    public static PropertyKey CONTACT_OTHER_POSTAL_ADDRESS_LINE2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 26
    };

    //
    // WPD_CONTACT_OTHER_POSTAL_ADDRESS_CITY 
    //   [ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand").
    //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressCity
    public static PropertyKey CONTACT_OTHER_POSTAL_ADDRESS_CITY = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 27
    };

    //
    // WPD_CONTACT_OTHER_POSTAL_ADDRESS_REGION 
    //   [ VT_LPWSTR ] Indicates the region of a postal address of the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressRegion
    public static PropertyKey CONTACT_OTHER_POSTAL_ADDRESS_REGION = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 28
    };

    //
    // WPD_CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_CODE 
    //   [ VT_LPWSTR ] Indicates the postal code of the address.
    //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressPostalCode
    public static PropertyKey CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_CODE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 29
    };

    //
    // WPD_CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_COUNTRY 
    //   [ VT_LPWSTR ] Indicates the country/region of the postal address.
    //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressCountry
    public static PropertyKey CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_COUNTRY = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 30
    };

    //
    // WPD_CONTACT_PRIMARY_EMAIL_ADDRESS 
    //   [ VT_LPWSTR ] Indicates the primary email address for the contact e.g. "someone@example.com"
    //   Recommended Device Services Property: PKEY_ContactObj_Email
    public static PropertyKey CONTACT_PRIMARY_EMAIL_ADDRESS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 31
    };

    //
    // WPD_CONTACT_PERSONAL_EMAIL 
    //   [ VT_LPWSTR ] Indicates the personal email address for the contact e.g. "someone@example.com"
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalEmail
    public static PropertyKey CONTACT_PERSONAL_EMAIL = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 32
    };

    //
    // WPD_CONTACT_PERSONAL_EMAIL2 
    //   [ VT_LPWSTR ] Indicates an alternate personal email address for the contact e.g. "someone@example.com"
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalEmail2
    public static PropertyKey CONTACT_PERSONAL_EMAIL2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 33
    };

    //
    // WPD_CONTACT_BUSINESS_EMAIL 
    //   [ VT_LPWSTR ] Indicates the business email address for the contact e.g. "someone@example.com"
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessEmail
    public static PropertyKey CONTACT_BUSINESS_EMAIL = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 34
    };

    //
    // WPD_CONTACT_BUSINESS_EMAIL2 
    //   [ VT_LPWSTR ] Indicates an alternate business email address for the contact e.g. "someone@example.com"
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessEmail2
    public static PropertyKey CONTACT_BUSINESS_EMAIL2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 35
    };

    //
    // WPD_CONTACT_OTHER_EMAILS 
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR, where each element is an alternate email addresses for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_OtherEmail
    public static PropertyKey CONTACT_OTHER_EMAILS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 36
    };

    //
    // WPD_CONTACT_PRIMARY_PHONE 
    //   [ VT_LPWSTR ] Indicates the primary phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_Phone
    public static PropertyKey CONTACT_PRIMARY_PHONE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 37
    };

    //
    // WPD_CONTACT_PERSONAL_PHONE 
    //   [ VT_LPWSTR ] Indicates the personal phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalPhone
    public static PropertyKey CONTACT_PERSONAL_PHONE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 38
    };

    //
    // WPD_CONTACT_PERSONAL_PHONE2 
    //   [ VT_LPWSTR ] Indicates an alternate personal phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalPhone2
    public static PropertyKey CONTACT_PERSONAL_PHONE2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 39
    };

    //
    // WPD_CONTACT_BUSINESS_PHONE 
    //   [ VT_LPWSTR ] Indicates the business phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessPhone
    public static PropertyKey CONTACT_BUSINESS_PHONE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 40
    };

    //
    // WPD_CONTACT_BUSINESS_PHONE2 
    //   [ VT_LPWSTR ] Indicates an alternate business phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessPhone2
    public static PropertyKey CONTACT_BUSINESS_PHONE2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 41
    };

    //
    // WPD_CONTACT_MOBILE_PHONE 
    //   [ VT_LPWSTR ] Indicates the mobile phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_MobilePhone
    public static PropertyKey CONTACT_MOBILE_PHONE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 42
    };

    //
    // WPD_CONTACT_MOBILE_PHONE2 
    //   [ VT_LPWSTR ] Indicates an alternate mobile phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_MobilePhone2
    public static PropertyKey CONTACT_MOBILE_PHONE2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 43
    };

    //
    // WPD_CONTACT_PERSONAL_FAX 
    //   [ VT_LPWSTR ] Indicates the personal fax number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalFax
    public static PropertyKey CONTACT_PERSONAL_FAX = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 44
    };

    //
    // WPD_CONTACT_BUSINESS_FAX 
    //   [ VT_LPWSTR ] Indicates the business fax number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessFax
    public static PropertyKey CONTACT_BUSINESS_FAX = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 45
    };

    //
    // WPD_CONTACT_PAGER 
    //   [ VT_LPWSTR ] 
    //   Recommended Device Services Property: PKEY_ContactObj_Pager
    public static PropertyKey CONTACT_PAGER = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 46
    };

    //
    // WPD_CONTACT_OTHER_PHONES 
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR, where each element is an alternate phone number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_OtherPhone
    public static PropertyKey CONTACT_OTHER_PHONES = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 47
    };

    //
    // WPD_CONTACT_PRIMARY_WEB_ADDRESS 
    //   [ VT_LPWSTR ] Indicates the primary web address for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_WebAddress
    public static PropertyKey CONTACT_PRIMARY_WEB_ADDRESS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 48
    };

    //
    // WPD_CONTACT_PERSONAL_WEB_ADDRESS 
    //   [ VT_LPWSTR ] Indicates the personal web address for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_PersonalWebAddress
    public static PropertyKey CONTACT_PERSONAL_WEB_ADDRESS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 49
    };

    //
    // WPD_CONTACT_BUSINESS_WEB_ADDRESS 
    //   [ VT_LPWSTR ] Indicates the business web address for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_BusinessWebAddress
    public static PropertyKey CONTACT_BUSINESS_WEB_ADDRESS = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 50
    };

    //
    // WPD_CONTACT_INSTANT_MESSENGER 
    //   [ VT_LPWSTR ] Indicates the instant messenger address for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_IMAddress
    public static PropertyKey CONTACT_INSTANT_MESSENGER = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 51
    };

    //
    // WPD_CONTACT_INSTANT_MESSENGER2 
    //   [ VT_LPWSTR ] Indicates an alternate instant messenger address for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_IMAddress2
    public static PropertyKey CONTACT_INSTANT_MESSENGER2 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 52
    };

    //
    // WPD_CONTACT_INSTANT_MESSENGER3 
    //   [ VT_LPWSTR ] Indicates an alternate instant messenger address for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_IMAddress3
    public static PropertyKey CONTACT_INSTANT_MESSENGER3 = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 53
    };

    //
    // WPD_CONTACT_COMPANY_NAME 
    //   [ VT_LPWSTR ] Indicates the company name for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_Organization
    public static PropertyKey CONTACT_COMPANY_NAME = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 54
    };

    //
    // WPD_CONTACT_PHONETIC_COMPANY_NAME 
    //   [ VT_LPWSTR ] The phonetic guide for pronouncing the contact's company name.
    //   Recommended Device Services Property: PKEY_ContactObj_PhoneticOrganization
    public static PropertyKey CONTACT_PHONETIC_COMPANY_NAME = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 55
    };

    //
    // WPD_CONTACT_ROLE 
    //   [ VT_LPWSTR ] Indicates the role for the contact e.g. "Software Engineer".
    //   Recommended Device Services Property: PKEY_ContactObj_Role
    public static PropertyKey CONTACT_ROLE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 56
    };

    //
    // WPD_CONTACT_BIRTHDATE 
    //   [ VT_DATE ] Indicates the birthdate for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_Birthdate
    public static PropertyKey CONTACT_BIRTHDATE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 57
    };

    //
    // WPD_CONTACT_PRIMARY_FAX 
    //   [ VT_LPWSTR ] Indicates the primary fax number for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_Fax
    public static PropertyKey CONTACT_PRIMARY_FAX = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 58
    };

    //
    // WPD_CONTACT_SPOUSE 
    //   [ VT_LPWSTR ] Indicates the full name of the spouse/domestic partner for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_Spouse
    public static PropertyKey CONTACT_SPOUSE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 59
    };

    //
    // WPD_CONTACT_CHILDREN 
    //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR, where each element is the full name of a child of the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_Children
    public static PropertyKey CONTACT_CHILDREN = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 60
    };

    //
    // WPD_CONTACT_ASSISTANT 
    //   [ VT_LPWSTR ] Indicates the full name of the assistant for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_Assistant
    public static PropertyKey CONTACT_ASSISTANT = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 61
    };

    //
    // WPD_CONTACT_ANNIVERSARY_DATE 
    //   [ VT_DATE ] Indicates the anniversary date for the contact.
    //   Recommended Device Services Property: PKEY_ContactObj_AnniversaryDate
    public static PropertyKey CONTACT_ANNIVERSARY_DATE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 62
    };

    //
    // WPD_CONTACT_RINGTONE 
    //   [ VT_LPWSTR ] Indicates an object id of a ringtone file on the mediaDevice.
    //   Recommended Device Services Property: PKEY_ContactObj_Ringtone
    public static PropertyKey CONTACT_RINGTONE = new()
    {
        fmtid = CONTACT_OBJECT_PROPERTIES_V1,
        pid = 63
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_MUSIC_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all music objects.
 ****************************************************************************/
    public static Guid MUSIC_OBJECT_PROPERTIES_V1 = new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6);

    //
    // WPD_MUSIC_ALBUM 
    //   [ VT_LPWSTR ] Indicates the album of the music file.
    //   Recommended Device Services Property: PKEY_MediaObj_AlbumName
    public static PropertyKey MUSIC_ALBUM = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_MUSIC_TRACK 
    //   [ VT_UI4 ] Indicates the track number for the music file.
    //   Recommended Device Services Property: PKEY_MediaObj_Track
    public static PropertyKey MUSIC_TRACK = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_MUSIC_LYRICS 
    //   [ VT_LPWSTR ] Indicates the lyrics for the music file.
    //   Recommended Device Services Property: PKEY_AudioObj_Lyrics
    public static PropertyKey MUSIC_LYRICS = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_MUSIC_MOOD 
    //   [ VT_LPWSTR ] Indicates the mood for the music file.
    //   Recommended Device Services Property: PKEY_MediaObj_Mood
    public static PropertyKey MUSIC_MOOD = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_AUDIO_BITRATE 
    //   [ VT_UI4 ] Indicates the bit rate for the audio data, specified in bits per second.
    //   Recommended Device Services Property: PKEY_AudioObj_AudioBitRate
    public static PropertyKey AUDIO_BITRATE = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_AUDIO_CHANNEL_COUNT 
    //   [ VT_R4 ] Indicates the number of channels in this audio file e.g. 1, 2, 5.1 etc.
    //   Recommended Device Services Property: PKEY_AudioObj_Channels
    public static PropertyKey AUDIO_CHANNEL_COUNT = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_AUDIO_FORMAT_CODE 
    //   [ VT_UI4 ] Indicates the registered WAVE format code.
    //   Recommended Device Services Property: PKEY_AudioObj_AudioFormatCode
    public static PropertyKey AUDIO_FORMAT_CODE = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_AUDIO_BIT_DEPTH 
    //   [ VT_UI4 ] This property identifies the bit-depth of the audio.
    //   Recommended Device Services Property: PKEY_AudioObj_AudioBitDepth
    public static PropertyKey AUDIO_BIT_DEPTH = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_AUDIO_BLOCK_ALIGNMENT 
    //   [ VT_UI4 ] This property identifies the audio block alignment
    //   Recommended Device Services Property: PKEY_AudioObj_AudioBlockAlignment
    public static PropertyKey AUDIO_BLOCK_ALIGNMENT = new()
    {
        fmtid = MUSIC_OBJECT_PROPERTIES_V1,
        pid = 13
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_VIDEO_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all video objects.
 ****************************************************************************/
    public static Guid VIDEO_OBJECT_PROPERTIES_V1 = new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A);

    //
    // WPD_VIDEO_AUTHOR 
    //   [ VT_LPWSTR ] Indicates the author of the video file.
    //   Recommended Device Services Property: PKEY_MediaObj_Producer
    public static PropertyKey VIDEO_AUTHOR = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_VIDEO_RECORDEDTV_STATION_NAME 
    //   [ VT_LPWSTR ] Indicates the TV station the video was recorded from.
    //   Recommended Device Services Property: PKEY_VideoObj_Source
    public static PropertyKey VIDEO_RECORDEDTV_STATION_NAME = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_VIDEO_RECORDEDTV_CHANNEL_NUMBER 
    //   [ VT_UI4 ] Indicates the TV channel number the video was recorded from.
    //   Recommended Device Services Property: None
    public static PropertyKey VIDEO_RECORDEDTV_CHANNEL_NUMBER = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_VIDEO_RECORDEDTV_REPEAT 
    //   [ VT_BOOL ] Indicates whether the recorded TV program was a repeat showing.
    //   Recommended Device Services Property: None
    public static PropertyKey VIDEO_RECORDEDTV_REPEAT = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_VIDEO_BUFFER_SIZE 
    //   [ VT_UI4 ] Indicates the video buffer size.
    //   Recommended Device Services Property: PKEY_MediaObj_BufferSize
    public static PropertyKey VIDEO_BUFFER_SIZE = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_VIDEO_CREDITS 
    //   [ VT_LPWSTR ] Indicates the credit text for the video file.
    //   Recommended Device Services Property: PKEY_MediaObj_Credits
    public static PropertyKey VIDEO_CREDITS = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_VIDEO_KEY_FRAME_DISTANCE 
    //   [ VT_UI4 ] Indicates the interval between key frames in milliseconds.
    //   Recommended Device Services Property: PKEY_VideoObj_KeyFrameDistance
    public static PropertyKey VIDEO_KEY_FRAME_DISTANCE = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_VIDEO_QUALITY_SETTING 
    //   [ VT_UI4 ] Indicates the quality setting for the video file.
    //   Recommended Device Services Property: PKEY_MediaObj_EncodingQuality
    public static PropertyKey VIDEO_QUALITY_SETTING = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_VIDEO_SCAN_TYPE 
    //   [ VT_UI4 ] This property identifies the video scan information.
    //   Recommended Device Services Property: PKEY_VideoObj_ScanType
    public static PropertyKey VIDEO_SCAN_TYPE = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_VIDEO_BITRATE 
    //   [ VT_UI4 ] Indicates the bitrate for the video data.
    //   Recommended Device Services Property: PKEY_VideoObj_VideoBitRate
    public static PropertyKey VIDEO_BITRATE = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 13
    };

    //
    // WPD_VIDEO_FOURCC_CODE 
    //   [ VT_UI4 ] The registered FourCC code indicating the codec used for the video file.
    //   Recommended Device Services Property: PKEY_VideoObj_VideoFormatCode
    public static PropertyKey VIDEO_FOURCC_CODE = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 14
    };

    //
    // WPD_VIDEO_FRAMERATE 
    //   [ VT_UI4 ] Indicates the frame rate for the video data.
    //   Recommended Device Services Property: PKEY_VideoObj_VideoFrameRate
    public static PropertyKey VIDEO_FRAMERATE = new()
    {
        fmtid = VIDEO_OBJECT_PROPERTIES_V1,
        pid = 15
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_COMMON_INFORMATION_OBJECT_PROPERTIES_V1 
 *
 * This category is properties that pertain to informational objects such as appointments, tasks, memos and even documents.
 ****************************************************************************/
    public static Guid COMMON_INFORMATION_OBJECT_PROPERTIES_V1 = new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F);

    //
    // WPD_COMMON_INFORMATION_SUBJECT 
    //   [ VT_LPWSTR ] Indicates the subject field of this object.
    //   Recommended Device Services Property: PKEY_MessageObj_Subject
    public static PropertyKey COMMON_INFORMATION_SUBJECT = new()
    {
        fmtid = COMMON_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_COMMON_INFORMATION_BODY_TEXT 
    //   [ VT_LPWSTR ] This property contains the body text of an object, in plaintext or HTML format.
    //   Recommended Device Services Property: PKEY_MessageObj_Body
    public static PropertyKey COMMON_INFORMATION_BODY_TEXT = new()
    {
        fmtid = COMMON_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_COMMON_INFORMATION_PRIORITY 
    //   [ VT_UI4 ] Indicates the priority of this object.
    //   Recommended Device Services Property: PKEY_MessageObj_Priority
    public static PropertyKey COMMON_INFORMATION_PRIORITY = new()
    {
        fmtid = COMMON_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_COMMON_INFORMATION_START_DATETIME 
    //   [ VT_DATE ] For appointments, tasks and similar objects, this indicates the date/time that this item is scheduled to start.
    //   Recommended Device Services Property: PKEY_MessageObj_PatternValidStartDate
    public static PropertyKey COMMON_INFORMATION_START_DATETIME = new()
    {
        fmtid = COMMON_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 5
    };

    //
    // WPD_COMMON_INFORMATION_END_DATETIME 
    //   [ VT_DATE ] For appointments, tasks and similar objects, this indicates the date/time that this item is scheduled to end.
    //   Recommended Device Services Property: PKEY_MessageObj_PatternValidEndDate
    public static PropertyKey COMMON_INFORMATION_END_DATETIME = new()
    {
        fmtid = COMMON_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_COMMON_INFORMATION_NOTES 
    //   [ VT_LPWSTR ] For appointments, tasks and similar objects, this indicates any notes for this object.
    //   Recommended Device Services Property: None
    public static PropertyKey COMMON_INFORMATION_NOTES = new()
    {
        fmtid = COMMON_INFORMATION_OBJECT_PROPERTIES_V1,
        pid = 7
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_MEMO_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all memo objects.
 ****************************************************************************/
    public static Guid MEMO_OBJECT_PROPERTIES_V1 = new(0x5FFBFC7B, 0x7483, 0x41AD, 0xAF, 0xB9, 0xDA, 0x3F, 0x4E, 0x59, 0x2B, 0x8D);

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_EMAIL_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all email objects.
 ****************************************************************************/
    public static Guid EMAIL_OBJECT_PROPERTIES_V1 = new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5);

    //
    // WPD_EMAIL_TO_LINE 
    //   [ VT_LPWSTR ] Indicates the normal recipients for the message.
    //   Recommended Device Services Property: PKEY_MessageObj_To
    public static PropertyKey EMAIL_TO_LINE = new()
    {
        fmtid = EMAIL_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_EMAIL_CC_LINE 
    //   [ VT_LPWSTR ] Indicates the copied recipients for the message.
    //   Recommended Device Services Property: PKEY_MessageObj_CC
    public static PropertyKey EMAIL_CC_LINE = new()
    {
        fmtid = EMAIL_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_EMAIL_BCC_LINE 
    //   [ VT_LPWSTR ] Indicates the recipients for the message who receive a "blind copy".
    //   Recommended Device Services Property: PKEY_MessageObj_BCC
    public static PropertyKey EMAIL_BCC_LINE = new()
    {
        fmtid = EMAIL_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_EMAIL_HAS_BEEN_READ 
    //   [ VT_BOOL ] Indicates whether the user has read this message.
    //   Recommended Device Services Property: PKEY_MessageObj_Read
    public static PropertyKey EMAIL_HAS_BEEN_READ = new()
    {
        fmtid = EMAIL_OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_EMAIL_RECEIVED_TIME 
    //   [ VT_DATE ] Indicates at what time the message was received.
    //   Recommended Device Services Property: PKEY_MessageObj_ReceivedTime
    public static PropertyKey EMAIL_RECEIVED_TIME = new()
    {
        fmtid = EMAIL_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_EMAIL_HAS_ATTACHMENTS 
    //   [ VT_BOOL ] Indicates whether this message has attachments.
    //   Recommended Device Services Property: None
    public static PropertyKey EMAIL_HAS_ATTACHMENTS = new()
    {
        fmtid = EMAIL_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_EMAIL_SENDER_ADDRESS 
    //   [ VT_LPWSTR ] Indicates who sent the message.
    //   Recommended Device Services Property: PKEY_MessageObj_Sender
    public static PropertyKey EMAIL_SENDER_ADDRESS = new()
    {
        fmtid = EMAIL_OBJECT_PROPERTIES_V1,
        pid = 10
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_APPOINTMENT_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all appointment objects.
 ****************************************************************************/
    public static Guid APPOINTMENT_OBJECT_PROPERTIES_V1 = new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3);

    //
    // WPD_APPOINTMENT_LOCATION 
    //   [ VT_LPWSTR ] Indicates the location of the appointment e.g. "Building 5, Conf. room 7".
    //   Recommended Device Services Property: PKEY_CalendarObj_Location
    public static PropertyKey APPOINTMENT_LOCATION = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_APPOINTMENT_TYPE 
    //   [ VT_LPWSTR ] Indicates the type of appointment e.g. "Personal", "Business" etc.
    //   Recommended Device Services Property: None
    public static PropertyKey APPOINTMENT_TYPE = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 7
    };

    //
    // WPD_APPOINTMENT_REQUIRED_ATTENDEES 
    //   [ VT_LPWSTR ] Semi-colon separated list of required attendees.
    //   Recommended Device Services Property: None
    public static PropertyKey APPOINTMENT_REQUIRED_ATTENDEES = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_APPOINTMENT_OPTIONAL_ATTENDEES 
    //   [ VT_LPWSTR ] Semi-colon separated list of optional attendees.
    //   Recommended Device Services Property: None
    public static PropertyKey APPOINTMENT_OPTIONAL_ATTENDEES = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 9
    };

    //
    // WPD_APPOINTMENT_ACCEPTED_ATTENDEES 
    //   [ VT_LPWSTR ] Semi-colon separated list of attendees who have accepted the appointment.
    //   Recommended Device Services Property: PKEY_CalendarObj_Accepted
    public static PropertyKey APPOINTMENT_ACCEPTED_ATTENDEES = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_APPOINTMENT_RESOURCES 
    //   [ VT_LPWSTR ] Semi-colon separated list of resources needed for the appointment.
    //   Recommended Device Services Property: None
    public static PropertyKey APPOINTMENT_RESOURCES = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 11
    };

    //
    // WPD_APPOINTMENT_TENTATIVE_ATTENDEES 
    //   [ VT_LPWSTR ] Semi-colon separated list of attendees who have tentatively accepted the appointment.
    //   Recommended Device Services Property: PKEY_CalendarObj_Tentative
    public static PropertyKey APPOINTMENT_TENTATIVE_ATTENDEES = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 12
    };

    //
    // WPD_APPOINTMENT_DECLINED_ATTENDEES 
    //   [ VT_LPWSTR ] Semi-colon separated list of attendees who have declined the appointment.
    //   Recommended Device Services Property: PKEY_CalendarObj_Declined
    public static PropertyKey APPOINTMENT_DECLINED_ATTENDEES = new()
    {
        fmtid = APPOINTMENT_OBJECT_PROPERTIES_V1,
        pid = 13
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_TASK_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all task objects.
 ****************************************************************************/
    public static Guid TASK_OBJECT_PROPERTIES_V1 = new(0xE354E95E, 0xD8A0, 0x4637, 0xA0, 0x3A, 0x0C, 0xB2, 0x68, 0x38, 0xDB, 0xC7);

    //
    // WPD_TASK_STATUS 
    //   [ VT_LPWSTR ] Indicates the status of the task e.g. "In Progress".
    //   Recommended Device Services Property: None
    public static PropertyKey TASK_STATUS = new()
    {
        fmtid = TASK_OBJECT_PROPERTIES_V1,
        pid = 6
    };

    //
    // WPD_TASK_PERCENT_COMPLETE 
    //   [ VT_UI4 ] Indicates how much of the task has been completed.
    //   Recommended Device Services Property: PKEY_TaskObj_Complete
    public static PropertyKey TASK_PERCENT_COMPLETE = new()
    {
        fmtid = TASK_OBJECT_PROPERTIES_V1,
        pid = 8
    };

    //
    // WPD_TASK_REMINDER_DATE 
    //   [ VT_DATE ] Indicates the date and time set for the reminder. If this value is 0, then it is assumed that this task has no reminder.
    //   Recommended Device Services Property: PKEY_TaskObj_ReminderDateTime
    public static PropertyKey TASK_REMINDER_DATE = new()
    {
        fmtid = TASK_OBJECT_PROPERTIES_V1,
        pid = 10
    };

    //
    // WPD_TASK_OWNER 
    //   [ VT_LPWSTR ] Indicates the owner of the task.
    //   Recommended Device Services Property: None
    public static PropertyKey TASK_OWNER = new()
    {
        fmtid = TASK_OBJECT_PROPERTIES_V1,
        pid = 11
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_SMS_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_SMS
 ****************************************************************************/
    public static Guid SMS_OBJECT_PROPERTIES_V1 = new(0x7E1074CC, 0x50FF, 0x4DD1, 0xA7, 0x42, 0x53, 0xBE, 0x6F, 0x09, 0x3A, 0x0D);

    //
    // WPD_SMS_PROVIDER 
    //   [ VT_LPWSTR ] Indicates the service provider name.
    //   Recommended Device Services Property: None
    public static PropertyKey SMS_PROVIDER = new()
    {
        fmtid = SMS_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_SMS_TIMEOUT 
    //   [ VT_UI4 ] Indicates the number of milliseconds until a timeout is returned.
    //   Recommended Device Services Property: None
    public static PropertyKey SMS_TIMEOUT = new()
    {
        fmtid = SMS_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_SMS_MAX_PAYLOAD 
    //   [ VT_UI4 ] Indicates the maximum number of bytes that can be contained in a message.
    //   Recommended Device Services Property: None
    public static PropertyKey SMS_MAX_PAYLOAD = new()
    {
        fmtid = SMS_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_SMS_ENCODING 
    //   [ VT_UI4 ] Indicates how the driver will encode the text message sent by the client.
    //   Recommended Device Services Property: None
    public static PropertyKey SMS_ENCODING = new()
    {
        fmtid = SMS_OBJECT_PROPERTIES_V1,
        pid = 5
    };

/****************************************************************************
 * This section defines all Commands, Parameters and Options associated with:
 * WPD_SECTION_OBJECT_PROPERTIES_V1 
 *
 * This category is for properties common to all objects whose content type is WPD_CONTENT_TYPE_SECTION
 ****************************************************************************/
    public static Guid SECTION_OBJECT_PROPERTIES_V1 = new(0x516AFD2B, 0xC64E, 0x44F0, 0x98, 0xDC, 0xBE, 0xE1, 0xC8, 0x8F, 0x7D, 0x66);

    //
    // WPD_SECTION_DATA_OFFSET 
    //   [ VT_UI8 ] Indicates the zero-based offset of the data for the referenced object.
    //   Recommended Device Services Property: None
    public static PropertyKey SECTION_DATA_OFFSET = new()
    {
        fmtid = SECTION_OBJECT_PROPERTIES_V1,
        pid = 2
    };

    //
    // WPD_SECTION_DATA_LENGTH 
    //   [ VT_UI8 ] Indicates the length of data for the referenced object.
    //   Recommended Device Services Property: None
    public static PropertyKey SECTION_DATA_LENGTH = new()
    {
        fmtid = SECTION_OBJECT_PROPERTIES_V1,
        pid = 3
    };

    //
    // WPD_SECTION_DATA_UNITS 
    //   [ VT_UI4 ] Indicates the units for WPD_SECTION_DATA_OFFSET and WPD_SECTION_DATA_LENGTH properties on this object (e.g. offset in bytes, offset in milliseconds etc.).
    //   Recommended Device Services Property: None
    public static PropertyKey SECTION_DATA_UNITS = new()
    {
        fmtid = SECTION_OBJECT_PROPERTIES_V1,
        pid = 4
    };

    //
    // WPD_SECTION_DATA_REFERENCED_OBJECT_RESOURCE 
    //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing a single value, which is the key identifying the resource on the referenced object which the WPD_SECTION_DATA_OFFSET and WPD_SECTION_DATA_LENGTH apply to.
    //   Recommended Device Services Property: None
    public static PropertyKey SECTION_DATA_REFERENCED_OBJECT_RESOURCE = new()
    {
        fmtid = SECTION_OBJECT_PROPERTIES_V1,
        pid = 5
    };

/****************************************************************************
 * This section defines Structures and Macros used by driver writers to
 * simplify Wpd Command Access checks.
 * Sample Usage:
 *
 * - Add table used to lookup the Access required for Wpd Commands
 * BEGIN_WPD_COMMAND_ACCESS_MAP(g_WpdCommandAccessMap)
 *    DECLARE_WPD_STANDARD_COMMAND_ACCESS_ENTRIES
 *    - Add any custom commands here e.g.
 *    WPD_COMMAND_ACCESS_ENTRY(MyCustomCommand, WPD_COMMAND_ACCESS_READWRITE)
 * END_WPD_COMMAND_ACCESS_MAP
 * - This enables the driver to use VERIFY_WPD_COMMAND_ACCESS to check command access function for us.
 * DECLARE_VERIFY_WPD_COMMAND_ACCESS;
 * ...
 * - When the driver receives a WPD IOCTL, it can check that the IOCTL specified matches
 *    the command payload with:
 *    hr = VERIFY_WPD_COMMAND_ACCESS(ControlCode, pParams, g_WpdCommandAccessMap);
 ****************************************************************************/
/****************************************************************************
 * This section defines the inline helper functions
 ****************************************************************************/
}
