namespace MediaDevices.ProtocolStack;

internal interface ITransportLayer
{
    public byte BulkInPipe { get; set; }
    public byte BulkOutPipe { get; set; }

    /// <summary>
    /// Öffnet das Gerät und sucht die Endpunkte.
    /// </summary>
    bool ConnectToHardware(object deviceIdentifier);

    /// <summary>
    /// Sendet rohe Bytes synchron an das Gerät (Bulk Out).
    /// </summary>
    bool WriteRawBytes(byte[] data);

    /// <summary>
    /// Liest rohe Bytes synchron vom Gerät (Bulk In).
    /// </summary>
    byte[] ReadRawBytes(int expectedSize);
}
