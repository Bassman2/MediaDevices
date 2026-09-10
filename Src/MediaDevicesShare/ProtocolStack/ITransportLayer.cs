namespace MediaDevices.ProtocolStack;

internal interface ITransportLayer : IDisposable
{
    event Action<Events, uint[]>? EventReceived;

    void Connect();
    void Disconnect();

    Task<MtpTransactionResult> SendCommandAsync(OperationCodes opCode, uint[]? parameters = null, CancellationToken cancellationToken = default);

    Task DownloadAsync(uint objectHandle, Stream destinationStream, CancellationToken cancellationToken = default);
    Task UploadAsync(Stream sourceStream, uint streamSize, string remoteFileName, uint targetFolderHandle = 0xFFFFFFFF, CancellationToken cancellationToken = default);
}
