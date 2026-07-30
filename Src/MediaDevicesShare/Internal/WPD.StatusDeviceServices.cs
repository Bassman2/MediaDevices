namespace MediaDevices.Internal;

partial class WPD
{
/*****************************************************************************
    Status Service Info
******************************************************************************/
    public static Guid DEVSVC_SERVICE_Status = new(0x0B9F1048, 0xB94B, 0xDC9A, 0x4e, 0xd7, 0xfe, 0x4f, 0xed, 0x3a, 0x0d, 0xeb);

/*****************************************************************************
    Status Service Properties
******************************************************************************/
    public static Guid DEVSVC_NAMESPACE_StatusSvc = new(0x49cd1f76, 0x5626, 0x4b17, 0xa4, 0xe8, 0x18, 0xb4, 0xaa, 0x1a, 0x22, 0x13);

/*  PKEY_StatusSvc_SignalStrength
 *
 *  Signal strength in "bars" from 0 (no signal) to 4 (excellent signal)
 *  
 *  Type: UInt8
 *  Form: Range
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_SignalStrength = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 2
    };

/*  PKEY_StatusSvc_TextMessages
 *
 *  Number of unread text messages (255 max)
 *  
 *  Type: UInt8
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_TextMessages = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 3
    };

/*  PKEY_StatusSvc_NewPictures
 *
 *  Number of "new" pictures on the mediaDevice (65535 max)
 *  
 *  Type: UInt16
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_NewPictures = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 4
    };

/*  PKEY_StatusSvc_MissedCalls
 *
 *  Number of missed calls on the mediaDevice (255 max)
 *  
 *  Type: UInt8
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_MissedCalls = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 5
    };

/*  PKEY_StatusSvc_VoiceMail
 *
 *  Number of "available" voice mail messages (255 max)
 *  
 *  Type: UInt8
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_VoiceMail = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 6
    };

/*  PKEY_StatusSvc_NetworkName
 *
 *  Network provider network name
 *  
 *  Type: String
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_NetworkName = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 7
    };

/*  PKEY_StatusSvc_NetworkType
 *
 *  Network "type" (e.g. GPRS, EDGE, UMTS, 1xRTT, EVDO, or operator branded)
 *  
 *  Type: String
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_NetworkType = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 8
    };

/*  PKEY_StatusSvc_Roaming
 *
 *  Current network roaming state
 *  
 *  Type: UInt8
 *  Form: Enum
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_Roaming = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 9
    };

/*  PKEY_StatusSvc_BatteryLife
 *
 *  Remaining battery life on the mediaDevice as a percentage between 100 and 0.
 *  
 *  Type: UInt8
 *  Form: Range
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_BatteryLife = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 10
    };

/*  PKEY_StatusSvc_ChargingState
 *
 *  Current charging state of the mediaDevice
 *  
 *  Type: UInt8
 *  Form: Enum
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_ChargingState = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 11
    };

/*  PKEY_StatusSvc_StorageCapacity
 *
 *  Total storage capacity on the mediaDevice (across all storages)
 *  
 *  Type: UInt64
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_StorageCapacity = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 12
    };

/*  PKEY_StatusSvc_StorageFreeSpace
 *
 *  Total free storage capacity on the mediaDevice (across all storages)
 *  
 *  Type: UInt64
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_StatusSvc_StorageFreeSpace = new()
    {
        fmtid = DEVSVC_NAMESPACE_StatusSvc,
        pid = 13
    };

}
