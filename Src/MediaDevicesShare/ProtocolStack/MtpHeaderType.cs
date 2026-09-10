namespace MediaDevices.ProtocolStack;

internal enum MtpHeaderType : ushort
{
    /// <summary>
    /// TYPE_COMMAND
    /// </summary>
    Command = 1,

    /// <summary>
    /// TYPE_DATA
    /// </summary>
    Data = 2,

    /// <summary>
    /// TYPE_RESPONSE
    /// </summary>
    Response = 3,

    /// <summary>
    /// TYPE_EVENT
    /// </summary>
    Event = 4
}
