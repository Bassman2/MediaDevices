namespace MediaDevices.ProtocolStack;

internal class ProtocolLayer
{
    private ITransportLayer transportLayer;

    public ProtocolLayer(ITransportLayer transportLayer)
    {
        this.transportLayer = transportLayer;
    }

    public void SendCommand(OperationCodes opCode, uint transactionId, uint[]? parameters = null)
    {
        byte[] commandPacket = PackageCommand(opCode, transactionId, parameters);
        //transportLayer.Send(commandPacket);
    }

    public static byte[] PackageCommand(OperationCodes opCode, uint transactionId, uint[]? parameters = null)
    {
        parameters ??= [];
        uint packetLength = 12 + ((uint)parameters.Length * 4);

        using MemoryStream ms = new();
        using BinaryWriter writer = new(ms);

        writer.Write(packetLength);
        writer.Write((ushort)MtpHeaderType.Command);
        writer.Write((ushort)opCode);
        writer.Write(transactionId);

        foreach (uint param in parameters) { writer.Write(param); }
        return ms.ToArray();
    }

    public static byte[] PackageData(OperationCodes opCode, uint transactionId, byte[] payload)
    {
        int payloadLength = payload != null ? payload.Length : 0;
        uint totalLength = (uint)(12 + payloadLength);

        using (var ms = new System.IO.MemoryStream())
        using (var writer = new System.IO.BinaryWriter(ms))
        {
            writer.Write(totalLength);       // 4 Bytes: Länge
            writer.Write((ushort)MtpHeaderType.Data);         // 2 Bytes: Typ (0x0002)
            writer.Write((ushort)opCode);            // 2 Bytes: Operation Code
            writer.Write(transactionId);     // 4 Bytes: Transaktions-ID

            if (payloadLength > 0)
            {
                writer.Write(payload!);       // Restliche Bytes: Payload
            }

            return ms.ToArray();
        }
    }

    public static MtpContainerHeader UnpackageHeader(byte[] rawData)
    {
        MtpContainerHeader header = new() { Length = 0, Type = 0, Code = 0, TransactionId = 0 };
        if (rawData == null || rawData.Length < 12) return header;

        using MemoryStream ms = new(rawData);
        using BinaryReader reader = new(ms);

        header.Length = reader.ReadUInt32();
        header.Type = (MtpHeaderType)reader.ReadUInt16();
        header.Code = (MtpResponseCode)reader.ReadUInt16();
        header.TransactionId = reader.ReadUInt32();

        return header;
    }
}
