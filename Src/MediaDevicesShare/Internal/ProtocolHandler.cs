namespace MediaDevices.Internal;

internal static partial class ProtocolHandler
{
    public static void InitMediaDeviceManager(MediaDeviceManager mediaDeviceManager)
    {
        IPortableDeviceManager? intDeviceManager = null;
        IPortableDeviceServiceManager? intServiceManager = null;

        int err = ComHelper.CreateInstance<IPortableDeviceManager>(ref CLSID.PortableDeviceManager, out IPortableDeviceManager? deviceManager);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager));

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

        int err = ComHelper.CreateInstance<IPortableDevice>(ref CLSID.PortableDevice, out mediaDevice.device);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice));

        // set open mediaDevice parameters
        // TODO
        err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var clientInfo);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));

        //IPortableDeviceValues clientInfo = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);
        //(IPortableDeviceValues) new PortableDeviceValues();
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

        if (enableCache == false)
        {
            // disable file list cache
            err = clientInfo.SetGuidValue(ref WPD.CLIENT_EVENT_COOKIE, ref CLSID.NamespaceExtention);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetGuidValue), "NamespaceExtention");
        }

        // open mediaDevice
        err = mediaDevice.device.Open(deviceId, clientInfo);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Open));
        err = mediaDevice.device.Capabilities(out mediaDevice.deviceCapabilities);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Capabilities));
        err = mediaDevice.device.Content(out mediaDevice.deviceContent);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Content));
        err = mediaDevice.deviceContent.Properties(out mediaDevice.deviceProperties);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceContent), nameof(IPortableDeviceContent.Properties));
        err = mediaDevice.deviceProperties.GetValues(Item.RootId, null, out mediaDevice.deviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        //ComTrace.WriteObject(this.deviceValues);

        // TODO
        // advice event handler
        mediaDevice.eventCallback = new EventCallback(mediaDevice);
        err = mediaDevice.device.Advise(0, mediaDevice.eventCallback, null, out mediaDevice.eventCookie);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.Advise));


        // properties



        err = mediaDevice.device.GetPnPDeviceID(out string pnPDeviceID);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.GetPnPDeviceID));
        mediaDevice.PnPDeviceID = pnPDeviceID;

        //mediaDevice.Manufacturer = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_MANUFACTURER) ?? string.Empty;
        //mediaDevice.SyncPartner = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_SYNC_PARTNER);
        //mediaDevice.FirmwareVersion = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_FIRMWARE_VERSION);
        ////mediaDevice.PowerLevel = mediaDevice.deviceValues.GetSignedIntegerValue(WPD.DEVICE_POWER_LEVEL);
        //mediaDevice.PowerSource = (PowerSource?)mediaDevice.deviceValues.GetSignedIntegerValue(WPD.DEVICE_POWER_SOURCE);
        //mediaDevice.Protocol = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_PROTOCOL);
        //mediaDevice.Model = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_MODEL);
        //mediaDevice.SerialNumber = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_SERIAL_NUMBER);
        //mediaDevice.SupportsNonConsumable = mediaDevice.deviceValues.GetBoolValue(WPD.DEVICE_SUPPORTS_NON_CONSUMABLE);
        //mediaDevice.DateTime = mediaDevice.deviceValues.GetDateTimeValue(WPD.DEVICE_DATETIME);
        //mediaDevice.friendlyName = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_FRIENDLY_NAME);
        //mediaDevice.SupportedFormatsAreOrdered = mediaDevice.deviceValues.GetBoolValue(WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED);
        //mediaDevice.DeviceType = (DeviceType?)mediaDevice.deviceValues.GetSignedIntegerValue(WPD.DEVICE_TYPE);
        //mediaDevice.NetworkIdentifier = mediaDevice.deviceValues.GetUnsignedLargeIntegerValue(WPD.DEVICE_NETWORK_IDENTIFIER);
        ////mediaDevice.FunctionalUniqueId = mediaDevice.deviceValues.GetByteArrayValue(WPD.DEVICE_FUNCTIONAL_UNIQUE_ID);
        //mediaDevice.ModelUniqueId = mediaDevice.deviceValues.GetByteArrayValue(WPD.DEVICE_MODEL_UNIQUE_ID);
        //mediaDevice.Transport = (DeviceTransport?)mediaDevice.deviceValues.GetUnsignedIntegerValue(WPD.DEVICE_TRANSPORT);
        //mediaDevice.UseDeviceStage = (DeviceTransport?)mediaDevice.deviceValues.GetUnsignedIntegerValue(WPD.DEVICE_USE_DEVICE_STAGE);


        uint num = 0;
        err = mediaDevice.deviceValues.GetCount(ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetCount));
        for (uint i = 0; i < num; i++)
        {
            using PropVariantFacade val = new();
            err = mediaDevice.deviceValues.GetAt(i, ref val.Key, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetAt));

            if (val.Key == WPD.OBJECT_ID)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string objectId);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.ObjectId = objectId;
            }
            else if (val.Key == WPD.OBJECT_PARENT_ID)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string objectParentId);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.ObjectParentId = objectParentId;
            }
            else if (val.Key == WPD.OBJECT_NAME)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string objectName);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.Name = objectName;
            }
            else if (val.Key == WPD.OBJECT_CONTENT_TYPE)
            {
                err = mediaDevice.deviceValues.GetGuidValue(ref val.Key, out Guid objectContentType);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetGuidValue));
                mediaDevice.ObjectContentType = objectContentType.ToString();
            }
            else if (val.Key == WPD.OBJECT_PERSISTENT_UNIQUE_ID)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string objectPersistentUniqueId);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.PersistentUniqueId = objectPersistentUniqueId;
            }
            else if (val.Key == WPD.OBJECT_FORMAT)
            {
                err = mediaDevice.deviceValues.GetGuidValue(ref val.Key, out Guid objectFormat);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetGuidValue));
                mediaDevice.ObjectFormat = objectFormat.ToString();
            }
            else if (val.Key == WPD.OBJECT_ISHIDDEN)
            {
                err = mediaDevice.deviceValues.GetBoolValue(ref val.Key, out int isHidden);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetBoolValue));
                mediaDevice.IsHidden = isHidden > 0;
            }
            else if (val.Key == WPD.OBJECT_CAN_DELETE)
            {
                err = mediaDevice.deviceValues.GetBoolValue(ref val.Key, out int canDelete);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetBoolValue));
                mediaDevice.CanDelete = canDelete > 0;
            }
            else if (val.Key == WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string containerFunctionalObjectId);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.ContainerFunctionalObjectId = containerFunctionalObjectId;
            }

            else if (val.Key == WPD.FUNCTIONAL_OBJECT_CATEGORY)
            {
                err = mediaDevice.deviceValues.GetGuidValue(ref val.Key, out Guid functionalObjectCategory);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetGuidValue));
                mediaDevice.FunctionalObjectCategory = functionalObjectCategory.ToString();
            }
            else if (val.Key == WPD.DEVICE_SYNC_PARTNER)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string syncPartner);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.SyncPartner = syncPartner;
            }
            else if (val.Key == WPD.DEVICE_FIRMWARE_VERSION)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string firmwareVersion);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.FirmwareVersion = firmwareVersion;
            }
            else if (val.Key == WPD.DEVICE_POWER_LEVEL)
            {
                err = mediaDevice.deviceValues.GetUnsignedIntegerValue(ref val.Key, out uint powerLevel);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetUnsignedIntegerValue));
                mediaDevice.PowerLevel = powerLevel;
            }
            else if (val.Key == WPD.DEVICE_POWER_SOURCE)
            {
                err = mediaDevice.deviceValues.GetUnsignedIntegerValue(ref val.Key, out uint powerSource);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetUnsignedIntegerValue));
                mediaDevice.PowerSource = (PowerSource?)powerSource;
            }
            else if (val.Key == WPD.DEVICE_PROTOCOL)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string protocol);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.Protocol = protocol;
            }
            else if (val.Key == WPD.DEVICE_MANUFACTURER)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string manufacturer);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.Manufacturer = manufacturer;
            }
            else if (val.Key == WPD.DEVICE_MODEL)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string model);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.Model = model;
            }
            else if (val.Key == WPD.DEVICE_SERIAL_NUMBER)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string serialNumber);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.SerialNumber = serialNumber;
            }
            else if (val.Key == WPD.DEVICE_SUPPORTS_NON_CONSUMABLE)
            {
                err = mediaDevice.deviceValues.GetBoolValue(ref val.Key, out var supportsNonConsumable);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetBoolValue));
                mediaDevice.SupportsNonConsumable = supportsNonConsumable > 0;
            }
            else if (val.Key == WPD.DEVICE_DATETIME)
            {
                //err = mediaDevice.deviceValues.GetDateTimeValue(ref val.Key, out DateTime dateTime);
                //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetDateTimeValue));
                //mediaDevice.DateTime = dateTime;
            }
            else if (val.Key == WPD.DEVICE_FRIENDLY_NAME)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string friendlyName);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.friendlyName = friendlyName;
            }
            else if (val.Key == WPD.DEVICE_SUPPORTED_DRM_SCHEMES)
            {
                //err = mediaDevice.deviceValues.GetDateTimeValue(ref val.Key, out DateTime dateTime);
                //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetDateTimeValue));
                //mediaDevice.DateTime = dateTime;
            }
            else if (val.Key == WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED)
            {
                err = mediaDevice.deviceValues.GetBoolValue(ref val.Key, out var supportedFormatsAreOrdered);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetBoolValue));
                mediaDevice.SupportedFormatsAreOrdered = supportedFormatsAreOrdered > 0;
            }
            else if (val.Key == WPD.DEVICE_TYPE)
            {
                err = mediaDevice.deviceValues.GetUnsignedIntegerValue(ref val.Key, out uint deviceType);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetUnsignedIntegerValue));
                mediaDevice.DeviceType = (DeviceType?)deviceType;
            }
            else if (val.Key == WPD.DEVICE_NETWORK_IDENTIFIER)
            {
                err = mediaDevice.deviceValues.GetUnsignedLargeIntegerValue(ref val.Key, out ulong networkIdentifier);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetUnsignedLargeIntegerValue));
                mediaDevice.NetworkIdentifier = networkIdentifier;
            }
            else if (val.Key == WPD.DEVICE_FUNCTIONAL_UNIQUE_ID)
            {
                err = mediaDevice.deviceValues.GetUnsignedIntegerValue(ref val.Key, out uint functionalUniqueId);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetUnsignedIntegerValue));
                //mediaDevice.FunctionalUniqueId = [functionalUniqueId];
            }
            else if (val.Key == WPD.DEVICE_MODEL_UNIQUE_ID)
            {
                err = mediaDevice.deviceValues.GetUnsignedIntegerValue(ref val.Key, out uint modelUniqueId);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetUnsignedIntegerValue));
                //mediaDevice.ModelUniqueId = [modelUniqueId];
            }
            else if (val.Key == WPD.DEVICE_TRANSPORT)
            {
                err = mediaDevice.deviceValues.GetUnsignedIntegerValue(ref val.Key, out uint transport);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetUnsignedIntegerValue));
                mediaDevice.Transport = (DeviceTransport?)transport;
            }
            else if (val.Key == WPD.DEVICE_USE_DEVICE_STAGE)
            {
                err = mediaDevice.deviceValues.GetBoolValue(ref val.Key, out var useDeviceStage);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetBoolValue));
                mediaDevice.UseDeviceStage = (DeviceTransport?)useDeviceStage;
            }
            else if (val.Key == WPD.DEVICE_EDP_IDENTITY)
            {
                err = mediaDevice.deviceValues.GetStringValue(ref val.Key, out string edpItentifier);
                MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));
                mediaDevice.EdpItentifier = edpItentifier;
            }
            else
            {
                string name = val.Key.GetName();
                Trace.WriteLine($"Connect: {name}");
            }
        }


        // Amazon Kindle Fire HDX 7 (2013) has the following properties:
        //Connect: OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID
        //Connect: OBJECT_NAME
        //Connect: PROPERTIES_MTP_VENDOR_EXTENDED_DEVICE_PROPS: 54279
        //Connect: OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID
        //Connect: OBJECT_NAME
        //Connect: PROPERTIES_MTP_VENDOR_EXTENDED_DEVICE_PROPS: 54279

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
