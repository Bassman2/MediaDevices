namespace MediaDevices.WindowsPortableDevices;

[SupportedOSPlatform("windows")]
internal partial class WpdDevice : IDevice, IDisposable
{
    private const int OK = 0;

    private static Guid namespaceExtention = new(0x35786d3c, 0xb075, 0x49b9, 0x88, 0xdd, 0x02, 0x98, 0x76, 0xe1, 0x1c, 0x01);

    private readonly IPortableDeviceManager deviceManager;

    private IPortableDevice? device;
    private IPortableDeviceCapabilities? deviceCapabilities;
    private string? eventCookie;



    // internal access for WpdItem
    
    internal IPortableDeviceProperties? deviceProperties;

    internal IPortableDeviceContent? deviceContent;

    private readonly IPortableDeviceServiceManager serviceManager;


    private string usbDevice;
    /*
    private readonly IPortableDeviceManager deviceManager;
   

    internal IPortableDevice? device;
    internal IPortableDeviceContent? deviceContent;
    internal IPortableDeviceProperties? deviceProperties;
    internal IPortableDeviceCapabilities? deviceCapabilities;
    internal IPortableDeviceValues? deviceValues;    
    
    internal EventCallback? eventCallback;
    internal EventThreadHandler eventThreadHandler;
    */

    public bool IsConnected { get; set; }

    public bool IsCaseSensitive { get; set; }


    //// \\?\usb#vid_04e8&pid_6860&ms_comp_mtp&samsung_android#6&6e4669b&4&0000#{6ac27878-a6fa-4155-ba85-f98f491d4f33}

    public WpdDevice(IPortableDeviceManager deviceManager, string usbDevice)
    {
        // already running in worker thread
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.deviceManager = deviceManager;
        //this.serviceManager = deviceManager;
        this.usbDevice = usbDevice; 

        //this.eventThreadHandler = new(this);
    }

    public void Dispose()
    { }


    public void Connect(MediaDeviceAccess access, MediaDeviceShare share, bool enableCache)
    {

        // find the app name for client name
        var appName = AppDomain.CurrentDomain.FriendlyName;

        device = ComHelper.CreateInstance<IPortableDevice>();

        // set open mediaDevice parameters
        var clientInfo = ComHelper.CreateInstance<IPortableDeviceValues>();
                
        int err = clientInfo.SetStringValue(ref WPD.CLIENT_NAME, appName);
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

        if (enableCache == false)
        {
            // disable file list cache

            err = clientInfo.SetGuidValue(ref WPD.CLIENT_EVENT_COOKIE, ref namespaceExtention);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetGuidValue), "NamespaceExtention");
        }

        // open mediaDevice
        err = device.Open(usbDevice, clientInfo);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Open));

        clientInfo.Release();

        err = device.Capabilities(out deviceCapabilities);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Capabilities));
        err = device.Content(out deviceContent);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Content));
        err = deviceContent.Properties(out deviceProperties);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.Properties));
        err = deviceProperties.GetValues(WpdItem.RootId, null, out var deviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        // advice event handler
        //mediaDevice.eventCallback = new EventCallback(mediaDevice);
        //err = mediaDevice.device.Advise(0, mediaDevice.eventCallback, null, out mediaDevice.eventCookie);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Advise));


        // properties

        //if (device.GetPnPDeviceID(out string pnPDeviceID) == OK)
        //{
        //    PnPDeviceID = pnPDeviceID;
        //}

        
        if (deviceValues.GetStringValue(ref WPD.OBJECT_NAME, out string objectName) == OK)
        {
            Name = objectName;
        }
        

        if (deviceValues.GetStringValue(ref WPD.DEVICE_SYNC_PARTNER, out string syncPartner) == OK)
        {
            SyncPartner = syncPartner;
        }
        if (deviceValues.GetStringValue(ref WPD.DEVICE_FIRMWARE_VERSION, out string firmwareVersion) == OK)
        {
            FirmwareVersion = firmwareVersion;
        }
        if (deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_POWER_LEVEL, out uint powerLevel) == OK)
        {
            PowerLevel = powerLevel;
        }
        if (deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_POWER_SOURCE, out uint powerSource) == OK)
        {
            PowerSource = (PowerSource?)powerSource;
        }
        if (deviceValues.GetStringValue(ref WPD.DEVICE_PROTOCOL, out string protocol) == OK)
        {
            Protocol = protocol;
        }
        if (deviceValues.GetStringValue(ref WPD.DEVICE_MANUFACTURER, out string manufacturer) == OK)
        {
            Manufacturer = manufacturer;
        }
        if (deviceValues.GetStringValue(ref WPD.DEVICE_MODEL, out string model) == OK)
        {
            Model = model;
        }
        if (deviceValues.GetStringValue(ref WPD.DEVICE_SERIAL_NUMBER, out string serialNumber) == OK)
        {
            SerialNumber = serialNumber;
        }
        if (deviceValues.GetBoolValue(ref WPD.DEVICE_SUPPORTS_NON_CONSUMABLE, out var supportsNonConsumable) == OK)
        {
            SupportsNonConsumable = supportsNonConsumable > 0;
        }



        if (deviceValues.GetStringValue(ref WPD.DEVICE_FRIENDLY_NAME, out string friendlyName) == OK)
        { 
            //friendlyName = friendlyName;
        }
        if (deviceValues.GetStringArrayValue(ref WPD.DEVICE_SUPPORTED_DRM_SCHEMES, out string[] supportedDrmSchemes) == OK)
        {
            SupportedDrmSchemes = supportedDrmSchemes;
        }
        if (deviceValues.GetBoolValue(ref WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED, out var supportedFormatsAreOrdered) == OK)
        {
            SupportedFormatsAreOrdered = supportedFormatsAreOrdered > 0;
        }
        if (deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_TYPE, out uint deviceType) == OK)   
        {
            DeviceType = (DeviceType?)deviceType;
        }
        if (deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_TRANSPORT, out uint transport) == OK)
        {
            Transport = (DeviceTransport?)transport;
        }
        if (deviceValues.GetBoolValue(ref WPD.DEVICE_USE_DEVICE_STAGE, out var useDeviceStage) == OK)
        {
            UseDeviceStage = (DeviceTransport?)useDeviceStage;
        }




        err = deviceProperties.GetPropertyAttributes(WpdItem.RootId, ref WPD.DEVICE_FRIENDLY_NAME, out var attributes);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetPropertyAttributes), "DEVICE_FRIENDLY_NAME");
        err = attributes.GetBoolValue(ref WPD.PROPERTY_ATTRIBUTE_CAN_WRITE, out int canWriteInt);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetBoolValue), "PROPERTY_ATTRIBUTE_CAN_WRITE");
        //IsFriendlyNameEditable = canWriteInt != 0;

        IsConnected = true;
    }

    public void Disconnect()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err;
        if (!IsConnected)
        {
            return;
        }
        if (!string.IsNullOrEmpty(eventCookie))
        {
            err = device!.Unadvise(eventCookie);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Unadvise));
            eventCookie = null;
        }
        err = device!.Close();
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Close));

        IsConnected = false;
    }

    public void Cancel()
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        NotConnectedException.ThrowIfNotConnected(this);
    
        device!.Cancel();
    }

    public ObjectId PathToObjectId(string path, CancellationToken cancellationToken = default)
    {
        WpdItem item = WpdItem.FindFolder(this, path) ?? throw new InvalidOperationException("Path not found");
        return item.ObjectId;
    }
}
 