namespace MediaDevices;

public sealed partial class MediaDeviceManager : IDisposable
{
    private static MediaDeviceManager? instance = new();

    private readonly MainWorker mainWorker;
    
    public static MediaDeviceManager Instance => instance ?? throw new Exception("MediaDeviceManager already closed");

    internal static MainWorker MainWorker => Instance.mainWorker;

    internal IPortableDeviceManager? deviceManager;
    internal IPortableDeviceServiceManager? serviceManager; 


    // without static constructor 
    // private static MediaDeviceManager instance = new MediaDeviceManager();
    // will not be called
    static MediaDeviceManager()
    { }

    private MediaDeviceManager()
    {
        mainWorker = new MainWorker();
        mainWorker.Invoke(() => ProtocolHandler.InitMediaDeviceManager(this));
    }

    public void Dispose()
    {
        mainWorker.Dispose();
        instance = null;
    }

    /// <summary>
    /// Returns an enumerable collection of currently available portable devices.
    /// </summary>
    /// <returns>>An enumerable collection of portable devices currently available.</returns>
    public IEnumerable<MediaDevice>? GetDevices()
        => mainWorker.InvokeEnumerable(() => ProtocolHandler.GetDevices(deviceManager!, serviceManager!, mainWorker));

    public IEnumerable<MediaDevice>? GetPrivateDevices()
        => mainWorker.InvokeEnumerable(() => ProtocolHandler.GetPrivateDevices(deviceManager!, serviceManager!, mainWorker));
}

