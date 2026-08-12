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

    #region static

    /*
    private static readonly IPortableDeviceManager deviceManager;
    private static readonly IPortableDeviceServiceManager serviceManager;

    
    private static List<MediaDevice> devices;
    private static List<MediaDevice> privateDevices;

    //static MediaDevice()
    //{
    //    try
    //    {
    //        deviceManager = (IPortableDeviceManager)new PortableDeviceManager();
    //        serviceManager = (IPortableDeviceServiceManager)deviceManager;

    //        //var x = new MediaDevMgr();
    //        //var f = new MediaDevMgrClassFactory();
    //        //IWMDeviceManager3 devManager = (IWMDeviceManager3)f;


    //        //devManager.GetRevision(out var revision);
    //        //devManager.GetDeviceCount(out var count);
    //        //devManager.EnumDevices2(out var e);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.ToString());
    //    }

    //    // #define WMDM_E_NOTCERTIFIED                     0x80045005L
    //}

    /// <summary>
    /// Returns an enumerable collection of currently available portable devices.
    /// </summary>
    /// <returns>>An enumerable collection of portable devices currently available.</returns>
    public static IEnumerable<MediaDevice> GetDevices()
    {
        deviceManager.RefreshDeviceList();

        // get number of devices
        uint count = 0;
        deviceManager.GetDevices(null, ref count);

        if (count == 0)
        {
            return new List<MediaDevice>();
        }

        // get mediaDevice IDs
        var deviceIds = new string[count];
        deviceManager.GetDevices(deviceIds, ref count);

        if (devices == null)
        {
            devices = deviceIds.Select(d => new MediaDevice(d)).ToList();
        }
        else
        {
            UpdateDeviceList(devices, deviceIds);
        }
        return devices;
    }

    private static void UpdateDeviceList(List<MediaDevice> deviceList, string[] deviceIdList)
    {
        var idList = deviceIdList.ToList();

        // remove
        var remove = deviceList.Where(d => !idList.Contains(d.DeviceId)).Select(d => d.DeviceId).ToList();
        deviceList.RemoveAll(d => remove.Contains(d.DeviceId));

        // add
        var add = idList.Where(id => !deviceList.Select(d => d.DeviceId).Contains(id)).ToList();
        deviceList.AddRange(add.Select(id => new MediaDevice(id)));
    }

    //public static IEnumerable<MediaDevice> GetDevices(FunctionalCategory category)
    //{
    //    if (category == FunctionalCategory.All)
    //    {
    //        return GetDevices();
    //    }

    //    var devices = GetDevices();

    //    var dev = devices.FirstOrDefault();

    //    dev.deviceCapabilities
    //}

    /// <summary>
    /// Returns an enumerable collection of currently available private portable devices.
    /// </summary>
    /// <returns>>An enumerable collection of private portable devices currently available.</returns>
    public static IEnumerable<MediaDevice> GetPrivateDevices()
    {
        deviceManager.RefreshDeviceList();

        // get number of devices
        uint count = 0;
        deviceManager.GetPrivateDevices(null, ref count);

        if (count == 0)
        {
            return new List<MediaDevice>();
        }

        // get mediaDevice IDs
        var deviceIds = new string[count];
        deviceManager.GetPrivateDevices(deviceIds, ref count);

        if (privateDevices == null)
        {
            privateDevices = deviceIds.Select(d => new MediaDevice(d)).ToList();
        }
        else
        {
            UpdateDeviceList(privateDevices, deviceIds);
        }
        return privateDevices;
    }
    */

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
    /// <param name="service">Service type</param>
    /// <returns>List of services</returns>
    public IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceType)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.InvokeEnumerable(() => ProtocolHandler.GetServices(serviceManager, this, serviceType));
    }

    #endregion
}
