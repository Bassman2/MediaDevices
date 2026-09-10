namespace MediaDevices.ProtocolStack;

internal interface ITransportLayer : IDisposable
{
    event Action<Events, uint[]>? EventReceived;

    void Connect();
    void Disconnect();

    Task<MtpTransactionResult> SendCommandAsync(OperationCodes opCode, uint[]? parameters = null, CancellationToken cancellationToken = default);

    Task UploadFromStreamAsync(Stream sourceStream, uint streamSize, string remoteFileName, uint targetFolderHandle = 0xFFFFFFFF, CancellationToken cancellationToken = default);
}
