namespace MediaDevices;

/// <summary>
/// MediaDive connector
/// </summary>
public class MediaDeviceConnector : IConnectionRequestCallback
{
    private readonly IPortableDeviceConnector connector;

    /// <summary>
    /// Event signals if complete
    /// </summary>
    public event EventHandler<CompleteEventArgs>? Complete;

//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
//    private MediaDeviceConnector()
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
//    { }

    internal MediaDeviceConnector(IPortableDeviceConnector connector)
    {
        this.connector = connector;
    }

    /// <summary>
    /// Connect to service
    /// </summary>
    public void Connect()
    {
        this.connector.Connect(this);
    }

    /// <summary>
    /// Disconnect from service
    /// </summary>
    public void Disconnect()
    {
        this.connector.Disconnect(this);
    }

    /// <summary>
    /// On completed
    /// </summary>
    /// <param name="hrStatus">Status</param>
    public void OnComplete([In, MarshalAs(UnmanagedType.Error)] int hrStatus)
    {
        this.Complete?.Invoke(this, new CompleteEventArgs(hrStatus));
    }
}
