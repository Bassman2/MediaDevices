namespace MediaDevices;

/// <summary>
/// Manages portable media devices on Windows platforms.
/// This sealed class implements the singleton pattern to provide centralized access to media device operations.
/// </summary>
/// <remarks>
/// The MediaDeviceManager is a singleton that can only be instantiated once. All operations are performed
/// on a dedicated worker thread for thread-safety. The manager handles initialization of COM interfaces
/// for portable device management and service management.
/// 
/// This class is Windows-only and requires the appropriate platform support.
/// </remarks>
[SupportedOSPlatform("windows")]
public sealed partial class MediaDeviceManager : IDisposable
{
    /// <summary>
    /// Static instance of the MediaDeviceManager. Initialized on first access.
    /// </summary>
    private static MediaDeviceManager? instance = new();

    /// <summary>
    /// Thread-safe worker for executing all media device operations on a dedicated thread.
    /// </summary>
    private readonly ThreadSafeWorker mainWorker;

    /// <summary>
    /// Gets the singleton instance of the MediaDeviceManager.
    /// </summary>
    /// <exception cref="System.Exception">Thrown when the MediaDeviceManager has already been disposed.</exception>
    public static MediaDeviceManager Instance => instance ?? throw new Exception("MediaDeviceManager already closed");

    /// <summary>
    /// Gets the main worker thread for all device operations.
    /// </summary>
    /// <remarks>
    /// This is an internal accessor to ensure operations are properly synchronized.
    /// </remarks>
    internal static ThreadSafeWorker MainWorker => Instance.mainWorker;

    /// <summary>
    /// COM interface for accessing portable device management functionality.
    /// </summary>
    internal IPortableDeviceManager? deviceManager;

    /// <summary>
    /// COM interface for accessing portable device service management functionality.
    /// </summary>
    internal IPortableDeviceServiceManager? serviceManager;


    /// <summary>
    /// Static constructor required to ensure static initialization of the singleton instance.
    /// </summary>
    /// <remarks>
    /// Without an explicit static constructor, the static field initialization
    /// will not be properly invoked, which would prevent singleton instantiation.
    /// </remarks>
    static MediaDeviceManager()
    { }

    /// <summary>
    /// Initializes a new instance of the MediaDeviceManager.
    /// </summary>
    /// <remarks>
    /// The constructor sets up the main worker thread and initializes the protocol handler
    /// with COM interfaces for device and service management. This is called once when
    /// the singleton instance is first created.
    /// </remarks>
    private MediaDeviceManager()
    {
        mainWorker = new ThreadSafeWorker();
        mainWorker.Invoke(() => ProtocolHandler.InitMediaDeviceManager(this));
    }

    /// <summary>
    /// Releases all resources managed by the MediaDeviceManager and closes the singleton instance.
    /// </summary>
    /// <remarks>
    /// After calling Dispose, all subsequent calls to the Instance property will throw an exception.
    /// The main worker thread is stopped and disposed, and the singleton instance is set to null.
    /// </remarks>
    public void Dispose()
    {
        mainWorker.Dispose();
        instance = null;
    }

    /// <summary>
    /// Returns an enumerable collection of currently available portable devices.
    /// </summary>
    /// <returns>An enumerable collection of portable devices currently available.</returns>
    public IEnumerable<MediaDevice> GetDevices()
        => mainWorker.InvokeEnumerable(() => ProtocolHandler.GetDevices(deviceManager!, serviceManager!, mainWorker));

    /// <summary>
    /// Returns an enumerable collection of private portable devices.
    /// </summary>
    /// <remarks>
    /// Private devices are typically those with restricted access or special permissions required.
    /// </remarks>
    /// <returns>An enumerable collection of private portable devices.</returns>
    public IEnumerable<MediaDevice> GetPrivateDevices()
        => mainWorker.InvokeEnumerable(() => ProtocolHandler.GetPrivateDevices(deviceManager!, serviceManager!, mainWorker));
}

