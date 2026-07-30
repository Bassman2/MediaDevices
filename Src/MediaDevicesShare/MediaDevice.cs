using System.Reflection;

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
[DebuggerDisplay("Description: {Description}, FriendlyName: {FriendlyName}, Manufacturer: {Manufacturer}, PnPDeviceID: {pnPDeviceID}")]
public sealed partial class MediaDevice : IDisposable
{
    private readonly IPortableDeviceManager deviceManager;
    internal readonly IPortableDeviceServiceManager serviceManager;

    #region Fields

    internal IPortableDevice device;
    internal IPortableDeviceContent? deviceContent;
    internal IPortableDeviceProperties? deviceProperties;
    internal IPortableDeviceCapabilities? deviceCapabilities;
    internal IPortableDeviceValues? deviceValues;
    private readonly string description = string.Empty;
    private string friendlyName = string.Empty;
    private readonly string manufacturer = string.Empty;
    //private readonly string pnPDeviceID = string.Empty;
    internal string? eventCookie;
    internal EventCallback? eventCallback;

    internal readonly MainWorker mainWorker;

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
    //        Trace.TraceError(ex.ToString());
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

    internal MediaDevice(string deviceId, MainWorker mainWorker, IPortableDeviceManager deviceManager, IPortableDeviceServiceManager serviceManager)
    {
        // already running in worker thread
        ThreadSafeWorkerException.ThrowIfNotInside(); 

        this.DeviceId = deviceId;
        this.mainWorker = mainWorker;
        this.deviceManager = deviceManager;
        this.serviceManager = serviceManager;

        this.description = MainWorker.GetDeviceDescription(deviceManager, deviceId) ?? string.Empty;
        this.friendlyName = MainWorker.GetDeviceFriendlyName(deviceManager, deviceId) ?? string.Empty;
        this.manufacturer = MainWorker.GetDeviceManufacturer(deviceManager, deviceId) ?? string.Empty;
        
        //this.device = ComHelper.CreateInstance<IPortableDevice>(ref CLSID.PortableDevice);

        int err = ComHelper.CreateInstance<IPortableDevice>(ref CLSID.PortableDevice, out this.device);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice));

    }

    public void Dispose()
    {

    }

    #endregion
    
    #region Public Methods

    /// <summary>
    /// Connect to the portable mediaDevice.
    /// </summary>
    /// <param name="access">Specifies the desired access the client is requesting to this mediaDevice.</param>
    /// <param name="share">Specifies the share mode the client is requesting to this mediaDevice.</param>
    /// <param name="enableCache">Enable or disable file list cache. Disabled cache is used by Explorer for a better performance.</param>
    public void Connect(MediaDeviceAccess access = MediaDeviceAccess.Default, MediaDeviceShare share = MediaDeviceShare.Default, bool enableCache = false)
    {
        if (this.IsConnected)
        {
            return;
        }

        mainWorker.Connect(this, this.DeviceId, access, share, enableCache);

        /*
        // find the app name for client name
        var appName = AppDomain.CurrentDomain.FriendlyName; 

        // set open mediaDevice parameters
        // TODO
        int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var clientInfo);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));

        err = clientInfo.SetStringValue(ref WPD.CLIENT_NAME, appName);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "CLIENT_NAME");

        err = clientInfo.SetUnsignedIntegerValue(ref WPD.CLIENT_MAJOR_VERSION, 1);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "CLIENT_MAJOR_VERSION");

        err = clientInfo.SetUnsignedIntegerValue(ref WPD.CLIENT_MINOR_VERSION, 0);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "CLIENT_MINOR_VERSION");

        err = clientInfo.SetUnsignedIntegerValue(ref WPD.CLIENT_REVISION, 0);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "CLIENT_REVISION");

        // Some mediaDevice drivers need to impersonate the caller in order to function correctly. Since our application does not
        // need to restrict its identity, specify SECURITY_IMPERSONATION so that we work with all devices.
        err = clientInfo.SetUnsignedIntegerValue(ref WPD.CLIENT_SECURITY_QUALITY_OF_SERVICE, (uint)Security.IMPERSONATION);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "CLIENT_SECURITY_QUALITY_OF_SERVICE");

        if (access != MediaDeviceAccess.Default)
        {
            err = clientInfo.SetUnsignedIntegerValue(ref WPD.CLIENT_DESIRED_ACCESS, (uint)access);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "CLIENT_DESIRED_ACCESS");
        }
        if (share != MediaDeviceShare.Default)
        {
            err = clientInfo.SetUnsignedIntegerValue(ref WPD.CLIENT_SHARE_MODE, (uint)share);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "CLIENT_SHARE_MODE");
        }

        // TODO
        if (enableCache == false)
        {
            // disable file list cache
            //err = clientInfo.SetGuidValue(ref WPD.CLIENT_EVENT_COOKIE, ref WPD.CLSID_PORTABLE_DEVICES);
            //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetGuidValue), "CLSID_PORTABLE_DEVICES");
            //err = clientInfo.SetStringValue(ref WPD.CLIENT_EVENT_COOKIE, "{35786D3C-B075-49B9-88DD-029876E11C01}");
            //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "CLIENT_EVENT_COOKIE");
        }

        // open mediaDevice
        err = this.device.Open(this.DeviceId, clientInfo);
        MediaDeviceException.ThrowIfComError(err, "IPortableDevice", "Open");

        // get IPortableDeviceContent instance
        err = this.device.Content(out this.deviceContent);
        MediaDeviceException.ThrowIfComError(err, "IPortableDevice", "Content");

        // get IPortableDeviceProperties instance
        err = this.deviceContent.Properties(out this.deviceProperties);
        MediaDeviceException.ThrowIfComError(err, "IPortableDeviceProperties", "Properties");

        // get IPortableDeviceValues instance
        err = this.deviceProperties.GetValues(Item.RootId, null, out this.deviceValues);
        MediaDeviceException.ThrowIfComError(err, "IPortableDeviceProperties", "GetValues");

        // get IPortableDeviceCapabilities instance
        err = this.device.Capabilities(out this.deviceCapabilities);
        MediaDeviceException.ThrowIfComError(err, "IPortableDevice", "Capabilities");
        
        ComTrace.WriteObject(this.deviceValues);

        // TODO
        // advice event handler
        this.eventCallback = new EventCallback(this);
        //err = this.mediaDevice.Advise(0, this.eventCallback, null, out var eventCookie);
        //MediaDeviceException.ThrowIfComError(err, "IPortableDevice", "Advise");
        //this.eventCookie = eventCookie;
        
        this.IsConnected = true;
        */
    }

    /// <summary>
    /// Disconnect from the portable mediaDevice.
    /// </summary>
    public void Disconnect()
    {
        if (!this.IsConnected)
        {
            return;
        }
        mainWorker.Disconnect(this);
        //if (!string.IsNullOrEmpty(this.eventCookie))
        //{
        //    this.device.Unadvise(this.eventCookie);
        //    this.eventCookie = null;
        //}
        //this.device.Close();
        //this.IsConnected = false;
    }

    /// <summary>
    /// The Cancel method cancels a pending operation on this mediaDevice. 
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void Cancel()
    {
        if (!this.IsConnected)
        {
            throw new NotConnectedException("Not connected");
        }
        mainWorker.Cancel(this);
    }

    // private static Guid GUID_DEVINTERFACE_WPD_SERVICECATION = new Guid(0x9EF44F80, 0x3D64, 0x4246, 0xA6, 0xAA, 0x20, 0x6F, 0x32, 0x8D, 0x1E, 0xDC);

    /// <summary>
    /// Get mediaDevice services
    /// </summary>
    /// <param name="service">Service type</param>
    /// <returns>List of services</returns>
    public IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceType)
        => mainWorker.GetServices(this, serviceType);


    #endregion

    #region Internal Methods

    //internal static bool IsPath(string path)
    //{
    //    return !string.IsNullOrWhiteSpace(path) && path.IndexOfAny(Path.GetInvalidPathChars()) < 0;
    //}

    internal bool EqualsName(string a, string b)
    {
        return this.IsCaseSensitive ? a == b : string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }

    internal static string? FilterToRegex(string? filter)
    {
        if (filter == null || filter == "*" || filter == "*.*")
        {
            return null;
        }

        StringBuilder s = new(filter);
        s.Replace(".", @"\.");
        s.Replace("+", @"\+");
        s.Replace("$", @"\$");
        s.Replace("(", @"\(");
        s.Replace(")", @"\)");
        s.Replace("[", @"\[");
        s.Replace("]", @"\]");
        s.Replace("?", ".?");
        s.Replace("*", ".*");
        return s.ToString();
    }

    #endregion
}
