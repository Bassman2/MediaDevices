namespace MediaDevices.Internal;

internal static partial class WPD
{
    #region Generic

    public static Guid GenericObjectProperties = new("{ef6b490d-5cd8-437a-affc-da8b60ee4a3c}");

    public static PropertyKey ParentId = new()
    {
        fmtid = GenericObjectProperties,
        pid = 3
    };

    public static PropertyKey Name = new()
    {
        fmtid = GenericObjectProperties,
        pid = 4
    };

    public static PropertyKey PUOID = new()
    {
        fmtid = GenericObjectProperties,
        pid = 5
    };

    public static PropertyKey ObjectFormat = new()
    {
        fmtid = GenericObjectProperties,
        pid = 6
    };

    public static PropertyKey ObjectSize = new()
    {
        fmtid = GenericObjectProperties,
        pid = 11
    };

    public static PropertyKey StorageID = new()
    {
        fmtid = GenericObjectProperties,
        pid = 23
    };

    public static PropertyKey LanguageLocale = new()
    {
        fmtid = GenericObjectProperties,
        pid = 27
    };
    #endregion

    #region Status

    public static Guid STATUSSVC_SERVICE_PROPERTIES = new("{49cd1f76-5626-4b17-a4e8-18b4aa1a2213}");

    public static PropertyKey SignalStrength = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 2
    };

    public static PropertyKey TextMessages = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 3
    };

    public static PropertyKey NewPictures = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 4
    };

    public static PropertyKey MissedCalls = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 5
    };

    public static PropertyKey VoiceMail = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 6
    };

    public static PropertyKey NetworkName = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 7
    };

    public static PropertyKey NetworkType = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 8
    };

    public static PropertyKey Roaming = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 9
    };

    public static PropertyKey BatteryLife = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 10
    };

    public static PropertyKey ChargingState = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 11
    };

    public static PropertyKey StorageCapacity = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 12
    };

    public static PropertyKey StorageFreeSpace = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 13
    };


    public static PropertyKey InternetConnected = new()
    {
        fmtid = STATUSSVC_SERVICE_PROPERTIES,
        pid = 15
    };

    #endregion

    #region Metadata

    public static Guid MetadataServiceProperties = new("{68bb7eeb-9eef-45bd-8de6-3b92a57cae1e}");

    public static PropertyKey ContentID = new()
    {
        fmtid = MetadataServiceProperties,
        pid = 3
    };

    public static PropertyKey DefaultCAB = new()
    {
        fmtid = MetadataServiceProperties,
        pid = 4
    };

    #endregion
}
