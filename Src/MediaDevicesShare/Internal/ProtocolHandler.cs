namespace MediaDevices.Internal;

internal static partial class ProtocolHandler
{
    private const int OK = 0;

    private static Guid namespaceExtention = new(0x35786d3c, 0xb075, 0x49b9, 0x88, 0xdd, 0x02, 0x98, 0x76, 0xe1, 0x1c, 0x01);


    public static void InitMediaDeviceManager(MediaDeviceManager mediaDeviceManager)
    {
        IPortableDeviceManager? intDeviceManager = null;
        IPortableDeviceServiceManager? intServiceManager = null;

        IPortableDeviceManager deviceManager = ComHelper.CreateInstance<IPortableDeviceManager>();

        intDeviceManager = deviceManager!;
        intServiceManager = (IPortableDeviceServiceManager)intDeviceManager;

        mediaDeviceManager.deviceManager = intDeviceManager ?? throw new InvalidOperationException("Failed to create mediaDevice manager");
        mediaDeviceManager.serviceManager = intServiceManager ?? throw new InvalidOperationException("Failed to create service manager");

    }

    public static IEnumerable<MediaDevice> GetDevices(IPortableDeviceManager deviceManager, IPortableDeviceServiceManager serviceManager, ThreadSafeWorker mainWorker)
    { 
        int err = deviceManager.RefreshDeviceList();
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.RefreshDeviceList));

        // get number of devices
        int count = 0;
        err = deviceManager.GetDevices(null, ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetDevices));

        if (count == 0)
        {
            return [];
        }
        else
        {
            // get mediaDevice IDs
            var deviceIds = new string[count];
            err = deviceManager.GetDevices(deviceIds, ref count);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetDevices));
            return deviceIds.Select(d => new MediaDevice(d, mainWorker, deviceManager, serviceManager));
        }
    }

    public static IEnumerable<MediaDevice> GetPrivateDevices(IPortableDeviceManager deviceManager, IPortableDeviceServiceManager serviceManager, ThreadSafeWorker mainWorker)
    {

        int err = deviceManager.RefreshDeviceList();
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.RefreshDeviceList));

        // get number of devices
        int count = 0;
        err = deviceManager.GetPrivateDevices(null, ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetPrivateDevices));

        if (count == 0)
        {
            return [];
        }
        else
        {
            // get mediaDevice IDs
            var deviceIds = new string[count];
            err = deviceManager.GetPrivateDevices(deviceIds, ref count);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetPrivateDevices));
            return deviceIds.Select(d => new MediaDevice(d, mainWorker, deviceManager, serviceManager));
        }
    }
    
    public static void Connect(MediaDevice mediaDevice, string deviceId, MediaDeviceAccess access, MediaDeviceShare share, bool enableCache)
    {

        // find the app name for client name
        var appName = AppDomain.CurrentDomain.FriendlyName;

        mediaDevice.device = ComHelper.CreateInstance<IPortableDevice>();

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
        err = mediaDevice.device.Open(deviceId, clientInfo);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Open));

        clientInfo.Release();

        err = mediaDevice.device.Capabilities(out mediaDevice.deviceCapabilities);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Capabilities));
        err = mediaDevice.device.Content(out mediaDevice.deviceContent);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Content));
        err = mediaDevice.deviceContent.Properties(out mediaDevice.deviceProperties);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.Properties));
        err = mediaDevice.deviceProperties.GetValues(Item.RootId, null, out mediaDevice.deviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        // advice event handler
        mediaDevice.eventCallback = new EventCallback(mediaDevice);
        err = mediaDevice.device.Advise(0, mediaDevice.eventCallback, null, out mediaDevice.eventCookie);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Advise));


        // properties

        if (mediaDevice.device.GetPnPDeviceID(out string pnPDeviceID) == OK)
        {
            mediaDevice.PnPDeviceID = pnPDeviceID;
        }

        
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.OBJECT_NAME, out string objectName) == OK)
        {
            mediaDevice.Name = objectName;
        }
        

        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_SYNC_PARTNER, out string syncPartner) == OK)
        {
            mediaDevice.SyncPartner = syncPartner;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_FIRMWARE_VERSION, out string firmwareVersion) == OK)
        {
            mediaDevice.FirmwareVersion = firmwareVersion;
        }
        if (mediaDevice.deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_POWER_LEVEL, out uint powerLevel) == OK)
        {
            mediaDevice.PowerLevel = powerLevel;
        }
        if (mediaDevice.deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_POWER_SOURCE, out uint powerSource) == OK)
        {
            mediaDevice.PowerSource = (PowerSource?)powerSource;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_PROTOCOL, out string protocol) == OK)
        {
            mediaDevice.Protocol = protocol;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_MANUFACTURER, out string manufacturer) == OK)
        {
            mediaDevice.Manufacturer = manufacturer;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_MODEL, out string model) == OK)
        {
            mediaDevice.Model = model;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_SERIAL_NUMBER, out string serialNumber) == OK)
        {
            mediaDevice.SerialNumber = serialNumber;
        }
        if (mediaDevice.deviceValues.GetBoolValue(ref WPD.DEVICE_SUPPORTS_NON_CONSUMABLE, out var supportsNonConsumable) == OK)
        {
            mediaDevice.SupportsNonConsumable = supportsNonConsumable > 0;
        }

        // TODO
        //if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_DATETIME, out string dateTime) == OK)
        //{
        //    mediaDevice.DateTime = DateTime.FromOADate(dateTime);
        //}
        if (mediaDevice.deviceValues.GetValue(ref WPD.DEVICE_DATETIME, out PropVariant dateTime) == OK)
        {
            if (dateTime.vt == PropVariantType.VT_DATE)
            {
                mediaDevice.DateTime = DateTime.FromOADate(dateTime.dateVal);
            }
            dateTime.Release();
            //ComHelper.NativeMethods.PropVariantClear(ref dateTime);
        }

        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_FRIENDLY_NAME, out string friendlyName) == OK)
        { 
            mediaDevice.friendlyName = friendlyName;
        }
        if (mediaDevice.deviceValues.GetStringArrayValue(ref WPD.DEVICE_SUPPORTED_DRM_SCHEMES, out string[] supportedDrmSchemes) == OK)
        {
            mediaDevice.SupportedDrmSchemes = supportedDrmSchemes;
        }
        if (mediaDevice.deviceValues.GetBoolValue(ref WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED, out var supportedFormatsAreOrdered) == OK)
        {
            mediaDevice.SupportedFormatsAreOrdered = supportedFormatsAreOrdered > 0;
        }
        if (mediaDevice.deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_TYPE, out uint deviceType) == OK)   
        {
            mediaDevice.DeviceType = (DeviceType?)deviceType;
        }
        if (mediaDevice.deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_TRANSPORT, out uint transport) == OK)
        {
            mediaDevice.Transport = (DeviceTransport?)transport;
        }
        if (mediaDevice.deviceValues.GetBoolValue(ref WPD.DEVICE_USE_DEVICE_STAGE, out var useDeviceStage) == OK)
        {
            mediaDevice.UseDeviceStage = (DeviceTransport?)useDeviceStage;
        }


#if DEBUG
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.OBJECT_ID, out string objectId) == OK)
        {
            mediaDevice.Id = objectId;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.OBJECT_PARENT_ID, out string objectParentId) == OK)
        {
            mediaDevice.ParentId = objectParentId;
        }
        if (mediaDevice.deviceValues.GetGuidValue(ref WPD.OBJECT_CONTENT_TYPE, out Guid objectContentType) == OK)
        {
            mediaDevice.ContentType = objectContentType.ToContentTypeEnum();
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.OBJECT_PERSISTENT_UNIQUE_ID, out string objectPersistentUniqueId) == OK)
        {
            mediaDevice.PersistentUniqueId = objectPersistentUniqueId;
        }
        if (mediaDevice.deviceValues.GetGuidValue(ref WPD.OBJECT_FORMAT, out Guid format) == OK)
        {
            mediaDevice.ObjectFormat = format.ToFormatsEnum();
        }
        if (mediaDevice.deviceValues.GetBoolValue(ref WPD.OBJECT_ISHIDDEN, out int isHidden) == OK)
        {
            mediaDevice.IsHidden = isHidden > 0;
        }
        if (mediaDevice.deviceValues.GetBoolValue(ref WPD.OBJECT_CAN_DELETE, out int canDelete) == OK)
        {
            mediaDevice.CanDelete = canDelete > 0;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID, out string containerFunctionalObjectId) == OK)
        {
            mediaDevice.ContainerFunctionalObjectId = containerFunctionalObjectId;
        }

        if (mediaDevice.deviceValues.GetGuidValue(ref WPD.FUNCTIONAL_OBJECT_CATEGORY, out Guid functionalObjectCategory) == OK)
        {
            mediaDevice.FunctionalObjectCategory = functionalObjectCategory.ToFunctionalCategoryEnum();
        }

        if (mediaDevice.deviceValues.GetUnsignedLargeIntegerValue(ref WPD.DEVICE_NETWORK_IDENTIFIER, out ulong networkIdentifier) == OK)
        {   
            mediaDevice.NetworkIdentifier = networkIdentifier;
        }
        if (mediaDevice.deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_FUNCTIONAL_UNIQUE_ID, out uint functionalUniqueId) == OK)
        {
            mediaDevice.FunctionalUniqueId = functionalUniqueId;
        }
        if (mediaDevice.deviceValues.GetUnsignedIntegerValue(ref WPD.DEVICE_MODEL_UNIQUE_ID, out uint modelUniqueId) == OK)
        {
            mediaDevice.ModelUniqueId = modelUniqueId;
        }
        if (mediaDevice.deviceValues.GetStringValue(ref WPD.DEVICE_EDP_IDENTITY, out string edpItentifier) == OK)
        {
            mediaDevice.EdpItentifier = edpItentifier;
        }
#endif

        err = mediaDevice.deviceProperties.GetPropertyAttributes(Item.RootId, ref WPD.DEVICE_FRIENDLY_NAME, out IPortableDeviceValues? attributes);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetPropertyAttributes), "DEVICE_FRIENDLY_NAME");
        err = attributes.GetBoolValue(ref WPD.PROPERTY_ATTRIBUTE_CAN_WRITE, out int canWriteInt);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetBoolValue), "PROPERTY_ATTRIBUTE_CAN_WRITE");
        mediaDevice.IsFriendlyNameEditable = canWriteInt != 0;

        mediaDevice.IsConnected = true;
    }

    public static void Disconnect(MediaDevice mediaDevice)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err;
        if (!mediaDevice.IsConnected)
        {
            return;
        }
        if (!string.IsNullOrEmpty(mediaDevice.eventCookie))
        {
            err = mediaDevice.device!.Unadvise(mediaDevice.eventCookie);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Unadvise));
            mediaDevice.eventCookie = null;
        }
        err = mediaDevice.device!.Close();
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Close));

        mediaDevice.IsConnected = false;
    }

    public static void Cancel(MediaDevice mediaDevice)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        NotConnectedException.ThrowIfNotConnected(mediaDevice);
    
        mediaDevice.device!.Cancel();
    }
}
