namespace MediaDevices;

/// <summary>
/// Represents a portable media mediaDevice connected to the system and exposes
/// basic read-only mediaDevice information such as DeviceId, Description,
/// FriendlyName and Manufacturer.
/// </summary>
/// <remarks>
/// Instances are created internally by MediaDeviceManager and provide a
/// lightweight wrapper around the underlying portable mediaDevice manager APIs.
/// </remarks>
[SupportedOSPlatform("windows")]
[DebuggerDisplay("Description: {Description}, FriendlyName: {FriendlyName}, Manufacturer: {Manufacturer}, PnPDeviceID: {pnPDeviceID}")]
public sealed partial class MediaDevice : IDisposable
{

    #region Fields

    private readonly IPortableDeviceManager deviceManager;
    internal readonly IPortableDeviceServiceManager serviceManager;
    internal readonly ThreadSafeWorker mainWorker;

    internal IPortableDevice? device;
    internal IPortableDeviceContent? deviceContent;
    internal IPortableDeviceProperties? deviceProperties;
    internal IPortableDeviceCapabilities? deviceCapabilities;
    internal IPortableDeviceValues? deviceValues;    
    internal string? eventCookie;
    internal EventCallback? eventCallback;
    internal EventThreadHandler eventThreadHandler;

    #endregion

    #region Properties

    /// <summary>
    /// Device Id of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string DeviceId { get; private set; }

    /// <summary>
    /// Is portable mediaDevice connected.
    /// </summary>
    public bool IsConnected { get; internal set; }

    /// <summary>
    /// Select if path is case sensitive or not. Default is not. 
    /// </summary>
    public bool IsCaseSensitive { get; set; } = false;

    #endregion

 
    #region constructor

    internal MediaDevice(string deviceId, ThreadSafeWorker mainWorker, IPortableDeviceManager deviceManager, IPortableDeviceServiceManager serviceManager)
    {
        // already running in worker thread
        ThreadSafeWorkerException.ThrowIfNotInside(); 

        this.DeviceId = deviceId;
        this.mainWorker = mainWorker;
        this.deviceManager = deviceManager;
        this.serviceManager = serviceManager;

        this.Description = ProtocolHandler.GetDeviceDescription(deviceManager, deviceId);
        this.friendlyName = ProtocolHandler.GetDeviceFriendlyName(deviceManager, deviceId);
        this.Manufacturer = ProtocolHandler.GetDeviceManufacturer(deviceManager, deviceId);

        this.eventThreadHandler = new(this);
    }

    /// <summary>
    /// Releases all resources used by the <see cref="MediaDevice"/> instance.
    /// </summary>
    /// <remarks>
    /// This method ensures proper cleanup of the event thread handler associated with this device.
    /// Call this method when the device instance is no longer needed to prevent resource leaks.
    /// </remarks>
    public void Dispose()
    {
        eventThreadHandler.Dispose();
    }

    #endregion
    
    #region Public Methods

    /// <summary>
    /// Connect to the portable mediaDevice.
    /// </summary>
    /// <param name="access">Specifies the desired access the client is requesting to this mediaDevice.</param>
    /// <param name="share">Specifies the share mode the client is requesting to this mediaDevice.</param>
    /// <param name="enableCache">Enable or disable file list cache. Disabled cache is used by Explorer for a better performance.</param>
    public void Connect(MediaDeviceAccess access = MediaDeviceAccess.Default, MediaDeviceShare share = MediaDeviceShare.Default, bool enableCache = true)
    {
        if (this.IsConnected) return;
        mainWorker.Invoke(() => ProtocolHandler.Connect(this, this.DeviceId, access, share, enableCache));
    }

    /// <summary>
    /// Disconnect from the portable mediaDevice.
    /// </summary>
    public void Disconnect()
    {
        if (!this.IsConnected) return;
        mainWorker.Invoke(() => ProtocolHandler.Disconnect(this));
    }

    /// <summary>
    /// The Cancel method cancels a pending operation on this mediaDevice. 
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void Cancel()
    {
        NotConnectedException.ThrowIfNotConnected(this);
        mainWorker.Invoke(() => ProtocolHandler.Cancel(this));
    }

    /// <summary>
    /// Get mediaDevice services
    /// </summary>
    /// <param name="serviceType">Service type</param>
    /// <returns>List of services</returns>
    public IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceType)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.InvokeEnumerable(() => ProtocolHandler.GetServices(serviceManager, this, serviceType));
    }

    #endregion
}
