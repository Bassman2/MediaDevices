namespace MediaDevices.ProtocolStack;

internal struct MtpContainerHeader
{
    public uint Length;
    public MtpHeaderType Type;
    public MtpResponseCode Code;
    public uint TransactionId;
}
