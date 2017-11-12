using System;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;

namespace MediaDevices.Internal
{
    internal class WPD
    {
        #region CATEGORY_COMMON

        public static Guid CATEGORY_COMMON = new Guid(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A);

        public static PropertyKey COMMAND_COMMON_RESET_DEVICE = new PropertyKey()
        {
            fmtid = CATEGORY_COMMON,
            pid = 2
        };

        public static PropertyKey PROPERTY_COMMON_COMMAND_CATEGORY = new PropertyKey()
        {
            fmtid = CATEGORY_COMMON,
            pid = 1001
        };

        public static PropertyKey PROPERTY_COMMON_COMMAND_ID = new PropertyKey()
        {
            fmtid = CATEGORY_COMMON,
            pid = 1002
        };

        public static PropertyKey PROPERTY_COMMON_HRESULT = new PropertyKey()
        {
            fmtid = CATEGORY_COMMON,
            pid = 1003
        };

        public static PropertyKey PROPERTY_COMMON_DRIVER_ERROR_CODE = new PropertyKey()
        {
            fmtid = CATEGORY_COMMON,
            pid = 1004
        };

        public static PropertyKey PROPERTY_COMMON_COMMAND_TARGET = new PropertyKey()
        {
            fmtid = CATEGORY_COMMON,
            pid = 1006
        };

        #endregion

        #region OBJECT_PROPERTIES

        public static Guid OBJECT_PROPERTIES_V1 = new Guid(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C);

        public static PropertyKey OBJECT_ID = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 2
        };

        public static PropertyKey OBJECT_PARENT_ID = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 3
        };

        public static PropertyKey OBJECT_NAME = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 4
        };

        public static PropertyKey OBJECT_CONTENT_TYPE = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 7
        };

        public static PropertyKey OBJECT_ISHIDDEN = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 9
        };

        public static PropertyKey OBJECT_ISSYSTEM = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 10
        };

        public static PropertyKey OBJECT_SIZE = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 11
        };

        public static PropertyKey OBJECT_ORIGINAL_FILE_NAME = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 12
        };

        public static PropertyKey OBJECT_IS_DRM_PROTECTED = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 17
        };

        public static PropertyKey OBJECT_DATE_CREATED = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 18
        };

        public static PropertyKey OBJECT_DATE_MODIFIED = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 19
        };

        public static PropertyKey OBJECT_DATE_AUTHORED = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 20
        };

        public static PropertyKey OBJECT_CAN_DELETE = new PropertyKey()
        {
            fmtid = OBJECT_PROPERTIES_V1,
            pid = 26
        };

        #endregion

        #region DEVICE_PROPERTIES

        public static Guid DEVICE_PROPERTIES_V1 = new Guid(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC);
        public static Guid DEVICE_PROPERTIES_V2 = new Guid(0x463DD662, 0x7FC4, 0x4291, 0x91, 0x1C, 0x7F, 0x4C, 0x9C, 0xCA, 0x97, 0x99);

        public static readonly PropertyKey DEVICE_SYNC_PARTNER = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 2
        };

        public static readonly PropertyKey DEVICE_FIRMWARE_VERSION = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 3
        };

        public static readonly PropertyKey DEVICE_POWER_LEVEL = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 4
        };

        public static readonly PropertyKey DEVICE_POWER_SOURCE = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 5
        };

        public static readonly PropertyKey DEVICE_PROTOCOL = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 6
        };

        public static readonly PropertyKey DEVICE_MANUFACTURER = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 7
        };

        public static readonly PropertyKey DEVICE_MODEL = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 8
        };

        public static readonly PropertyKey DEVICE_SERIAL_NUMBER = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 9
        };

        public static readonly PropertyKey DEVICE_SUPPORTS_NON_CONSUMABLE = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 10
        };

        public static readonly PropertyKey DEVICE_DATETIME = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 11
        };

        public static readonly PropertyKey DEVICE_FRIENDLY_NAME = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 12
        };

        public static readonly PropertyKey DEVICE_SUPPORTED_DRM_SCHEMES = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 13
        };

        public static readonly PropertyKey DEVICE_SUPPORTED_FORMATS_ARE_ORDERED = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 14
        };

        public static readonly PropertyKey DEVICE_TYPE = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 15
        };

        public static readonly PropertyKey DEVICE_NETWORK_IDENTIFIER = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V1,
            pid = 16
        };

        public static readonly PropertyKey DEVICE_FUNCTIONAL_UNIQUE_ID = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V2,
            pid = 2
        };

        public static readonly PropertyKey DEVICE_MODEL_UNIQUE_ID = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V2,
            pid = 3
        };

        public static readonly PropertyKey DEVICE_TRANSPORT = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V2,
            pid = 4
        };

        public static readonly PropertyKey DEVICE_USE_DEVICE_STAGE = new PropertyKey()
        {
            fmtid = DEVICE_PROPERTIES_V2,
            pid = 5
        };

        #endregion

        #region CONTENT_TYPE

        public static Guid CONTENT_TYPE_FUNCTIONAL_OBJECT = new Guid(0x99ED0160, 0x17FF, 0x4C44, 0x9D, 0x98, 0x1D, 0x7A, 0x6F, 0x94, 0x19, 0x21);
        public static Guid CONTENT_TYPE_FOLDER = new Guid(0x27E2E392, 0xA111, 0x48E0, 0xAB, 0x0C, 0xE1, 0x77, 0x05, 0xA0, 0x5F, 0x85);
        public static Guid CONTENT_TYPE_IMAGE = new Guid(0xef2107d5, 0xa52a, 0x4243, 0xa2, 0x6b, 0x62, 0xd4, 0x17, 0x6d, 0x76, 0x03);
        public static Guid CONTENT_TYPE_DOCUMENT = new Guid(0x680ADF52, 0x950A, 0x4041, 0x9B, 0x41, 0x65, 0xE3, 0x93, 0x64, 0x81, 0x55);
        public static Guid CONTENT_TYPE_CONTACT = new Guid(0xEABA8313, 0x4525, 0x4707, 0x9F, 0x0E, 0x87, 0xC6, 0x80, 0x8E, 0x94, 0x35);
        public static Guid CONTENT_TYPE_CONTACT_GROUP = new Guid(0x346B8932, 0x4C36, 0x40D8, 0x94, 0x15, 0x18, 0x28, 0x29, 0x1F, 0x9D, 0xE9);
        public static Guid CONTENT_TYPE_AUDIO = new Guid(0x4AD2C85E, 0x5E2D, 0x45E5, 0x88, 0x64, 0x4F, 0x22, 0x9E, 0x3C, 0x6C, 0xF0);
        public static Guid CONTENT_TYPE_VIDEO = new Guid(0x9261B03C, 0x3D78, 0x4519, 0x85, 0xE3, 0x02, 0xC5, 0xE1, 0xF5, 0x0B, 0xB9);
        public static Guid CONTENT_TYPE_TELEVISION = new Guid(0x60A169CF, 0xF2AE, 0x4E21, 0x93, 0x75, 0x96, 0x77, 0xF1, 0x1C, 0x1C, 0x6E);
        public static Guid CONTENT_TYPE_PLAYLIST = new Guid(0x1A33F7E4, 0xAF13, 0x48F5, 0x99, 0x4E, 0x77, 0x36, 0x9D, 0xFE, 0x04, 0xA3);
        public static Guid CONTENT_TYPE_MIXED_CONTENT_ALBUM = new Guid(0x00F0C3AC, 0xA593, 0x49AC, 0x92, 0x19, 0x24, 0xAB, 0xCA, 0x5A, 0x25, 0x63);
        public static Guid CONTENT_TYPE_AUDIO_ALBUM = new Guid(0xAA18737E, 0x5009, 0x48FA, 0xAE, 0x21, 0x85, 0xF2, 0x43, 0x83, 0xB4, 0xE6);
        public static Guid CONTENT_TYPE_IMAGE_ALBUM = new Guid(0x75793148, 0x15F5, 0x4A30, 0xA8, 0x13, 0x54, 0xED, 0x8A, 0x37, 0xE2, 0x26);
        public static Guid CONTENT_TYPE_VIDEO_ALBUM = new Guid(0x012B0DB7, 0xD4C1, 0x45D6, 0xB0, 0x81, 0x94, 0xB8, 0x77, 0x79, 0x61, 0x4F);
        public static Guid CONTENT_TYPE_MEMO = new Guid(0x9CD20ECF, 0x3B50, 0x414F, 0xA6, 0x41, 0xE4, 0x73, 0xFF, 0xE4, 0x57, 0x51);
        public static Guid CONTENT_TYPE_EMAIL = new Guid(0x8038044A, 0x7E51, 0x4F8F, 0x88, 0x3D, 0x1D, 0x06, 0x23, 0xD1, 0x45, 0x33);
        public static Guid CONTENT_TYPE_APPOINTMENT = new Guid(0x0FED060E, 0x8793, 0x4B1E, 0x90, 0xC9, 0x48, 0xAC, 0x38, 0x9A, 0xC6, 0x31);
        public static Guid CONTENT_TYPE_TASK = new Guid(0x63252F2C, 0x887F, 0x4CB6, 0xB1, 0xAC, 0xD2, 0x98, 0x55, 0xDC, 0xEF, 0x6C);
        public static Guid CONTENT_TYPE_PROGRAM = new Guid(0xD269F96A, 0x247C, 0x4BFF, 0x98, 0xFB, 0x97, 0xF3, 0xC4, 0x92, 0x20, 0xE6);
        public static Guid CONTENT_TYPE_GENERIC_FILE = new Guid(0x0085E0A6, 0x8D34, 0x45D7, 0xBC, 0x5C, 0x44, 0x7E, 0x59, 0xC7, 0x3D, 0x48);
        public static Guid CONTENT_TYPE_CALENDAR = new Guid(0xA1FD5967, 0x6023, 0x49A0, 0x9D, 0xF1, 0xF8, 0x06, 0x0B, 0xE7, 0x51, 0xB0);
        public static Guid CONTENT_TYPE_GENERIC_MESSAGE = new Guid(0xE80EAAF8, 0xB2DB, 0x4133, 0xB6, 0x7E, 0x1B, 0xEF, 0x4B, 0x4A, 0x6E, 0x5F);
        public static Guid CONTENT_TYPE_NETWORK_ASSOCIATION = new Guid(0x031DA7EE, 0x18C8, 0x4205, 0x84, 0x7E, 0x89, 0xA1, 0x12, 0x61, 0xD0, 0xF3);
        public static Guid CONTENT_TYPE_CERTIFICATE = new Guid(0xDC3876E8, 0xA948, 0x4060, 0x90, 0x50, 0xCB, 0xD7, 0x7E, 0x8A, 0x3D, 0x87);
        public static Guid CONTENT_TYPE_WIRELESS_PROFILE = new Guid(0x0BAC070A, 0x9F5F, 0x4DA4, 0xA8, 0xF6, 0x3D, 0xE4, 0x4D, 0x68, 0xFD, 0x6C);
        public static Guid CONTENT_TYPE_MEDIA_CAST = new Guid(0x5E88B3CC, 0x3E65, 0x4E62, 0xBF, 0xFF, 0x22, 0x94, 0x95, 0x25, 0x3A, 0xB0);
        public static Guid CONTENT_TYPE_SECTION = new Guid(0x821089F5, 0x1D91, 0x4DC9, 0xBE, 0x3C, 0xBB, 0xB1, 0xB3, 0x5B, 0x18, 0xCE);
        public static Guid CONTENT_TYPE_UNSPECIFIED = new Guid(0x28D8D31E, 0x249C, 0x454E, 0xAA, 0xBC, 0x34, 0x88, 0x31, 0x68, 0xE6, 0x34);
        public static Guid CONTENT_TYPE_ALL = new Guid(0x80E170D2, 0x1055, 0x4A3E, 0xB9, 0x52, 0x82, 0xCC, 0x4F, 0x8A, 0x86, 0x89);

        #endregion

        #region RESOURCE

        public static Guid RESOURCE = new Guid(0xE81E79BE, 0x34F0, 0x41BF, 0xB5, 0x3F, 0xF1, 0xA0, 0x6A, 0xE8, 0x78, 0x42);

        public static PropertyKey RESOURCE_DEFAULT = new PropertyKey()
        {
            fmtid = RESOURCE,
            pid = 0
        };

        #endregion

        #region EVENTS
        
        public static Guid EVENT_NOTIFICATION = new Guid(0x2BA2E40A, 0x6B4C, 0x4295, 0xBB, 0x43, 0x26, 0x32, 0x2B, 0x99, 0xAE, 0xB2);
        public static Guid EVENT_OBJECT_ADDED = new Guid(0xA726DA95, 0xE207, 0x4B02, 0x8D, 0x44, 0xBE, 0xF2, 0xE8, 0x6C, 0xBF, 0xFC);
        public static Guid EVENT_OBJECT_REMOVED = new Guid(0xBE82AB88, 0xA52C, 0x4823, 0x96, 0xE5, 0xD0, 0x27, 0x26, 0x71, 0xFC, 0x38);
        public static Guid EVENT_OBJECT_UPDATED = new Guid(0x1445A759, 0x2E01, 0x485D, 0x9F, 0x27, 0xFF, 0x07, 0xDA, 0xE6, 0x97, 0xAB);
        public static Guid EVENT_DEVICE_RESET = new Guid(0x7755CF53, 0xC1ED, 0x44F3, 0xB5, 0xA2, 0x45, 0x1E, 0x2C, 0x37, 0x6B, 0x27);
        public static Guid EVENT_DEVICE_CAPABILITIES_UPDATED = new Guid(0x36885AA1, 0xCD54, 0x4DAA, 0xB3, 0xD0, 0xAF, 0xB3, 0xE0, 0x3F, 0x59, 0x99);
        public static Guid EVENT_STORAGE_FORMAT = new Guid(0x3782616B, 0x22BC, 0x4474, 0xA2, 0x51, 0x30, 0x70, 0xF8, 0xD3, 0x88, 0x57);
        public static Guid EVENT_OBJECT_TRANSFER_REQUESTED = new Guid(0x8D16A0A1, 0xF2C6, 0x41DA, 0x8F, 0x19, 0x5E, 0x53, 0x72, 0x1A, 0xDB, 0xF2);
        public static Guid EVENT_DEVICE_REMOVED = new Guid(0xE4CBCA1B, 0x6918, 0x48B9, 0x85, 0xEE, 0x02, 0xBE, 0x7C, 0x85, 0x0A, 0xF9);
        public static Guid EVENT_SERVICE_METHOD_COMPLETE = new Guid(0x8A33F5F8, 0x0ACC, 0x4D9B, 0x9C, 0xC4, 0x11, 0x2D, 0x35, 0x3B, 0x86, 0xCA);

        #endregion

        #region EVENT_PROPERTIES

        public static Guid EVENT_PROPERTIES_V1 = new Guid(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0);
        public static Guid EVENT_PROPERTIES_V2 = new Guid(0x52807B8A, 0x4914, 0x4323, 0x9B, 0x9A, 0x74, 0xF6, 0x54, 0xB2, 0xB8, 0x46);

        public static PropertyKey EVENT_PARAMETER_PNP_DEVICE_ID = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V1,
            pid = 2
        };

        public static PropertyKey EVENT_PARAMETER_EVENT_ID = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V1,
            pid = 3
        };

        public static PropertyKey EVENT_PARAMETER_OPERATION_STATE = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V1,
            pid = 4
        };

        public static PropertyKey EVENT_PARAMETER_OPERATION_PROGRESS = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V1,
            pid = 5
        };

        public static PropertyKey EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V1,
            pid = 6
        };

        public static PropertyKey EVENT_PARAMETER_OBJECT_CREATION_COOKIE = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V1,
            pid = 7
        };

        public static PropertyKey EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V1,
            pid = 8
        };
        
        public static PropertyKey EVENT_PARAMETER_SERVICE_METHOD_CONTEXT = new PropertyKey()
        {
            fmtid = EVENT_PROPERTIES_V2,
            pid = 2
        };

        #endregion

        #region FUNCTIONAL_CATEGORY

        public static Guid FUNCTIONAL_CATEGORY_DEVICE = new Guid(0x08EA466B, 0xE3A4, 0x4336, 0xA1, 0xF3, 0xA4, 0x4D, 0x2B, 0x5C, 0x43, 0x8C);
        public static Guid FUNCTIONAL_CATEGORY_STORAGE = new Guid(0x23F05BBC, 0x15DE, 0x4C2A, 0xA5, 0x5B, 0xA9, 0xAF, 0x5C, 0xE4, 0x12, 0xEF);
        public static Guid FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE = new Guid(0x613CA327, 0xAB93, 0x4900, 0xB4, 0xFA, 0x89, 0x5B, 0xB5, 0x87, 0x4B, 0x79);
        public static Guid FUNCTIONAL_CATEGORY_AUDIO_CAPTURE = new Guid(0x3F2A1919, 0xC7C2, 0x4A00, 0x85, 0x5D, 0xF5, 0x7C, 0xF0, 0x6D, 0xEB, 0xBB);
        public static Guid FUNCTIONAL_CATEGORY_VIDEO_CAPTURE = new Guid(0xE23E5F6B, 0x7243, 0x43AA, 0x8D, 0xF1, 0x0E, 0xB3, 0xD9, 0x68, 0xA9, 0x18);
        public static Guid FUNCTIONAL_CATEGORY_SMS = new Guid(0x0044A0B1, 0xC1E9, 0x4AFD, 0xB3, 0x58, 0xA6, 0x2C, 0x61, 0x17, 0xC9, 0xCF);
        public static Guid FUNCTIONAL_CATEGORY_RENDERING_INFORMATION = new Guid(0x08600BA4, 0xA7BA, 0x4A01, 0xAB, 0x0E, 0x00, 0x65, 0xD0, 0xA3, 0x56, 0xD3);
        public static Guid FUNCTIONAL_CATEGORY_NETWORK_CONFIGURATION = new Guid(0x48F4DB72, 0x7C6A, 0x4AB0, 0x9E, 0x1A, 0x47, 0x0E, 0x3C, 0xDB, 0xF2, 0x6A);
        public static Guid FUNCTIONAL_CATEGORY_ALL = new Guid(0x2D8A6512, 0xA74C, 0x448E, 0xBA, 0x8A, 0xF4, 0xAC, 0x07, 0xC4, 0x93, 0x99);


        #endregion

        #region CATEGORY_OBJECT_PROPERTIES

        public static Guid CATEGORY_OBJECT_PROPERTIES = new Guid(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04);

        public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 2
        };

        public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET_ATTRIBUTES = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 3
        };

        public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 4
        };

        public static PropertyKey COMMAND_OBJECT_PROPERTIES_SET = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 5
        };

        public static PropertyKey COMMAND_OBJECT_PROPERTIES_GET_ALL = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 6
        };

        public static PropertyKey COMMAND_OBJECT_PROPERTIES_DELETE = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 7
        };

        public static PropertyKey PROPERTY_OBJECT_PROPERTIES_OBJECT_ID = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 1001
        };

        public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 1002
        };

        public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 1003
        };

        public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 1004
        };

        public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 1005
        };

        public static PropertyKey PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS = new PropertyKey()
        {
            fmtid = CATEGORY_OBJECT_PROPERTIES,
            pid = 1006
        };

        #endregion

        #region CATEGORY_STORAGE

        public static Guid CATEGORY_STORAGE = new Guid(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94);

        public static PropertyKey COMMAND_STORAGE_FORMAT = new PropertyKey()
        {
            fmtid = CATEGORY_STORAGE,
            pid = 2
        };

        public static PropertyKey COMMAND_STORAGE_EJECT = new PropertyKey()
        {
            fmtid = CATEGORY_STORAGE,
            pid = 4
        };

        public static PropertyKey PROPERTY_STORAGE_OBJECT_ID = new PropertyKey()
        {
            fmtid = CATEGORY_STORAGE,
            pid = 1001
        };

        public static PropertyKey PROPERTY_STORAGE_DESTINATION_OBJECT_ID = new PropertyKey()
        {
            fmtid = CATEGORY_STORAGE,
            pid = 1002
        };

        #endregion

        #region CATEGORY_SMS

        public static Guid CATEGORY_SMS = new Guid(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1);

        public static PropertyKey COMMAND_SMS_SEND = new PropertyKey()
        {
            fmtid = CATEGORY_SMS,
            pid = 2
        };

        public static PropertyKey PROPERTY_SMS_RECIPIENT = new PropertyKey()
        {
            fmtid = CATEGORY_SMS,
            pid = 1001
        };

        public static PropertyKey PROPERTY_SMS_MESSAGE_TYPE = new PropertyKey()
        {
            fmtid = CATEGORY_SMS,
            pid = 1002
        };

        public static PropertyKey PROPERTY_SMS_TEXT_MESSAGE = new PropertyKey()
        {
            fmtid = CATEGORY_SMS,
            pid = 1003
        };

        public static PropertyKey PROPERTY_SMS_BINARY_MESSAGE = new PropertyKey()
        {
            fmtid = CATEGORY_SMS,
            pid = 1004
        };

        public static PropertyKey OPTION_SMS_BINARY_MESSAGE_SUPPORTED = new PropertyKey()
        {
            fmtid = CATEGORY_SMS,
            pid = 5001
        };

        #endregion

        #region CATEGORY_STILL_IMAGE_CAPTURE

        public static Guid CATEGORY_STILL_IMAGE_CAPTURE = new Guid(0x4FCD6982, 0x22A2, 0x4B05, 0xA4, 0x8B, 0x62, 0xD3, 0x8B, 0xF2, 0x7B, 0x32);

        public static PropertyKey COMMAND_STILL_IMAGE_CAPTURE_INITIATE = new PropertyKey()
        {
            fmtid = CATEGORY_STILL_IMAGE_CAPTURE,
            pid = 2
        };

        #endregion

        #region CATEGORY_MEDIA_CAPTURE

        public static Guid CATEGORY_MEDIA_CAPTURE = new Guid(0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8);

        public static PropertyKey COMMAND_MEDIA_CAPTURE_START = new PropertyKey()
        {
            fmtid = CATEGORY_MEDIA_CAPTURE,
            pid = 2
        };

        public static PropertyKey COMMAND_MEDIA_CAPTURE_STOP = new PropertyKey()
        {
            fmtid = CATEGORY_MEDIA_CAPTURE,
            pid = 3
        };

        public static PropertyKey COMMAND_MEDIA_CAPTURE_PAUSE = new PropertyKey()
        {
            fmtid = CATEGORY_MEDIA_CAPTURE,
            pid = 4
        };

        #endregion

        #region CATEGORY_DEVICE_HINTS

        public static Guid CATEGORY_DEVICE_HINTS = new Guid(0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84);

        public static PropertyKey COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION = new PropertyKey()
        {
            fmtid = CATEGORY_DEVICE_HINTS,
            pid = 2
        };

        public static PropertyKey PROPERTY_DEVICE_HINTS_CONTENT_TYPE = new PropertyKey()
        {
            fmtid = CATEGORY_DEVICE_HINTS,
            pid = 1001
        };

        public static PropertyKey PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS = new PropertyKey()
        {
            fmtid = CATEGORY_DEVICE_HINTS,
            pid = 1002
        };

        #endregion

        #region STORAGE_OBJECT_PROPERTIES

        public static Guid STORAGE_OBJECT_PROPERTIES_V1 = new Guid(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A);

        public static PropertyKey STORAGE_TYPE = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 2
        };

        public static PropertyKey STORAGE_FILE_SYSTEM_TYPE = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 3
        };

        public static PropertyKey STORAGE_CAPACITY = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 4
        };

        public static PropertyKey STORAGE_FREE_SPACE_IN_BYTES = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 5
        };

        public static PropertyKey STORAGE_FREE_SPACE_IN_OBJECTS = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 6
        };

        public static PropertyKey STORAGE_DESCRIPTION = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 7
        };

        public static PropertyKey STORAGE_SERIAL_NUMBER = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 8
        };

        public static PropertyKey STORAGE_MAX_OBJECT_SIZE = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 9
        };

        public static PropertyKey STORAGE_CAPACITY_IN_OBJECTS = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 10
        };

        public static PropertyKey STORAGE_ACCESS_CAPABILITY = new PropertyKey()
        {
            fmtid = STORAGE_OBJECT_PROPERTIES_V1,
            pid = 11
        };

        #endregion

        #region CATEGORY_MTP_EXT_VENDOR_OPERATIONS

        public static Guid CATEGORY_MTP_EXT_VENDOR_OPERATIONS = new Guid(0x4d545058, 0x1a2e, 0x4106, 0xa3, 0x57, 0x77, 0x1e, 0x8, 0x19, 0xfc, 0x56);

        public static PropertyKey COMMAND_MTP_EXT_GET_SUPPORTED_VENDOR_OPCODES = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 11
        };

        public static PropertyKey COMMAND_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASE = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 12
        };

        public static PropertyKey COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_READ = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 13
        };

        public static PropertyKey COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_WRITE = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 14
        };

        public static PropertyKey COMMAND_MTP_EXT_READ_DATA = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 15
        };

        public static PropertyKey COMMAND_MTP_EXT_WRITE_DATA = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 16
        };

        public static PropertyKey COMMAND_MTP_EXT_END_DATA_TRANSFER = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 17
        };

        public static PropertyKey COMMAND_MTP_EXT_GET_VENDOR_EXTENSION_DESCRIPTION = new PropertyKey()
        {
            fmtid = CATEGORY_MTP_EXT_VENDOR_OPERATIONS,
            pid = 18
        };

        #endregion
    }
}
