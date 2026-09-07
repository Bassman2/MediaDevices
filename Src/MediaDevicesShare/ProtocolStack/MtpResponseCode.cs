namespace MediaDevices.ProtocolStack;

internal enum MtpResponseCode : ushort
{
    /// <summary>
    /// MTP_RC_OK
    /// </summary>
    OK = 0x2001,

    /// <summary>
    /// MTP_RC_GENERAL_ERROR
    /// </summary>
    GeneralError = 0x2002,

    /// <summary>
    /// MTP_RC_SESSION_NOT_OPEN
    /// </summary>
    SessionNotOpen = 0x2003,

    /// <summary>
    /// MTP_RC_OPERATION_NOT_SUPPORTED
    /// </summary>
    OperationNotSupported = 0x2005,

    /// <summary>
    /// MTP_RC_PARAMETER_NOT_SUPPORTED
    /// </summary>
    ParameterNotSupported = 0x2006,

    /// <summary>
    /// MTP_RC_DEVICE_PROP_NOT_SUPPORTED
    /// </summary>
    DevicePropNotSupported = 0x200A,

    /// <summary>
    /// MTP_RC_OBJECT_WRITE_PROTECTED
    /// </summary>
    ObjectWriteProtected = 0x2017,

    /// <summary>
    /// MTP_RC_INVALID_PARAMETER
    /// </summary>
    InvalidParameter = 0x201D,


}
