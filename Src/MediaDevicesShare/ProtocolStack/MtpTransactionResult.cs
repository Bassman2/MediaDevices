namespace MediaDevices.ProtocolStack;

internal class MtpTransactionResult
{
    public MtpResponseCode ResponseCode { get; set; }
    public byte[] Data { get; set; } = [];
}
