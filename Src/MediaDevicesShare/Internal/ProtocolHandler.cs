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

    public static IEnumerable<MediaDevice> GetDevices(IPortableDeviceManager deviceManager, IPortableDeviceServiceManager serviceManager, MainWorker mainWorker)
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

    public static IEnumerable<MediaDevice> GetPrivateDevices(IPortableDeviceManager deviceManager, IPortableDeviceServiceManager serviceManager, MainWorker mainWorker)
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

        mediaDevice.Manufacturer = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_MANUFACTURER) ?? string.Empty;
        mediaDevice.SyncPartner = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_SYNC_PARTNER);
        mediaDevice.FirmwareVersion = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_FIRMWARE_VERSION);
        mediaDevice.PowerLevel = mediaDevice.deviceValues.GetSignedIntegerValue(WPD.DEVICE_POWER_LEVEL);
        mediaDevice.PowerSource = (PowerSource?)mediaDevice.deviceValues.GetSignedIntegerValue(WPD.DEVICE_POWER_SOURCE);
        mediaDevice.Protocol = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_PROTOCOL);
        mediaDevice.Model = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_MODEL);
        mediaDevice.SerialNumber = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_SERIAL_NUMBER);
        mediaDevice.SupportsNonConsumable = mediaDevice.deviceValues.GetBoolValue(WPD.DEVICE_SUPPORTS_NON_CONSUMABLE);
        mediaDevice.DateTime = mediaDevice.deviceValues.GetDateTimeValue(WPD.DEVICE_DATETIME);
        mediaDevice.friendlyName = mediaDevice.deviceValues.GetStringValue(WPD.DEVICE_FRIENDLY_NAME);
        mediaDevice.SupportedFormatsAreOrdered = mediaDevice.deviceValues.GetBoolValue(WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED);
        mediaDevice.DeviceType = (DeviceType?)mediaDevice.deviceValues.GetSignedIntegerValue(WPD.DEVICE_TYPE);
        mediaDevice.NetworkIdentifier = mediaDevice.deviceValues.GetUnsignedLargeIntegerValue(WPD.DEVICE_NETWORK_IDENTIFIER);
        mediaDevice.FunctionalUniqueId = mediaDevice.deviceValues.GetByteArrayValue(WPD.DEVICE_FUNCTIONAL_UNIQUE_ID);
        mediaDevice.ModelUniqueId = mediaDevice.deviceValues.GetByteArrayValue(WPD.DEVICE_MODEL_UNIQUE_ID);
        mediaDevice.Transport = (DeviceTransport?)mediaDevice.deviceValues.GetUnsignedIntegerValue(WPD.DEVICE_TRANSPORT);
        mediaDevice.UseDeviceStage = (DeviceTransport?)mediaDevice.deviceValues.GetUnsignedIntegerValue(WPD.DEVICE_USE_DEVICE_STAGE);


        //uint num = 0;
        //err = mediaDevice.deviceValues.GetCount(ref num);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetCount));
        //for (uint i = 0; i < num; i++)
        //{
        //    using PropVariantFacade val = new();
        //    err = mediaDevice.deviceValues.GetAt(i, ref val.Key, ref val.Value);
        //    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetAt));

        //    switch (val.Key)
        //    {
        //    case var key when key == WPD.DEVICE_MANUFACTURER:
        //        mediaDevice.Manufacturer = val.ToString();
        //        break;
        //    case var key when key == WPD.DEVICE_FRIENDLY_NAME:
        //        mediaDevice.friendlyName = val.ToString();
        //        break;
        //    case var key when key == WPD.DEVICE_MODEL:
        //        mediaDevice.Model = val.ToString();
        //        break;
        //    case var key when key == WPD.DEVICE_SERIAL_NUMBER:
        //        mediaDevice.SerialNumber = val.ToString();
        //        break;
        //    case var key when key == WPD.DEVICE_PROTOCOL:
        //        mediaDevice.Protocol = val.ToString();
        //        break;
        //    case var key when key == WPD.DEVICE_POWER_SOURCE:
        //        mediaDevice.PowerSource = (PowerSource?)val.ToInt();
        //        break;
        //    case var key when key == WPD.DEVICE_POWER_LEVEL:
        //        mediaDevice.PowerLevel = val.ToInt();
        //        break;
        //    }
        //}

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
