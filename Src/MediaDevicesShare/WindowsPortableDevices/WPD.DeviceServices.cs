namespace MediaDevices.Internal;

partial class WPD
{
/*****************************************************************************
    Service Info
******************************************************************************/
/*  Service Info Version */
/*  Service Flags */
/*****************************************************************************
    Common Service Properties
******************************************************************************/
    public static Guid DEVSVC_NAMESPACE_Services = new(0x14fa7268, 0x0b6c, 0x4214, 0x94, 0x87, 0x43, 0x5b, 0x48, 0x0a, 0x8c, 0x4f);

/*  PKEY_Services_ServiceDisplayName
 *
 *  Type: String
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_Services_ServiceDisplayName = new()
    {
        fmtid = DEVSVC_NAMESPACE_Services,
        pid = 2
    };

/*  PKEY_Services_ServiceIcon
 *
 *  Type: AUInt8
 *  Form: ByteArray
 */
    public static PropertyKey DEVSVC_PKEY_Services_ServiceIcon = new()
    {
        fmtid = DEVSVC_NAMESPACE_Services,
        pid = 3
    };

/*  PKEY_Services_ServiceLocale
 *
 *  Contains the RFC4646 compliant language string for data in this service
 *  
 *  Type: String
 *  Form: None
 */
    public static PropertyKey DEVSVC_PKEY_Services_ServiceLocale = new()
    {
        fmtid = DEVSVC_NAMESPACE_Services,
        pid = 4
    };

}
