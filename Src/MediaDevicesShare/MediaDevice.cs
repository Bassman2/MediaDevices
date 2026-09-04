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
    private static readonly ThreadSafeWorker worker = ThreadSafeWorker.Instance;

    private readonly IDevice device;

    public static IEnumerable<MediaDevice> GetDevices() => DeviceFactory.GetDevices();

    internal MediaDevice(IDevice device)
    {
        this.device = device;
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
        //eventThreadHandler.Dispose();
    }

    
    
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
        worker.Invoke(() => device.Connect(access, share, enableCache));
    }

    /// <summary>
    /// Disconnect from the portable mediaDevice.
    /// </summary>
    public void Disconnect()
    {
        if (!this.IsConnected) return;
        worker.Invoke(() => device.Disconnect());
    }

    /// <summary>
    /// The Cancel method cancels a pending operation on this mediaDevice. 
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void Cancel()
    {
        NotConnectedException.ThrowIfNotConnected(this);
        worker.Invoke(() => device.Cancel());
    }

    /// <summary>
    /// Get mediaDevice services
    /// </summary>
    /// <param name="serviceType">Service type</param>
    /// <returns>List of services</returns>
    public IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceType)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return worker.InvokeEnumerable(() => device.GetServices(serviceType));
    }

    #endregion
}
