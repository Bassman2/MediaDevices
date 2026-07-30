namespace MediaDevices;

partial class MainWorker
{
    #region IPortableDeviceProperties

    public void SetFriendlyName(MediaDevice mediaDevice, string value)
    {
        Invoke(() =>
        {
            //IPortableDeviceValues devInValues = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

            int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var devInValues);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));


            devInValues.SetStringValue(ref WPD.DEVICE_FRIENDLY_NAME, value!);
            mediaDevice.deviceProperties!.SetValues(Item.RootId, devInValues, out IPortableDeviceValues _);

            // reload mediaDevice values with new friendly name 
            mediaDevice.deviceProperties.GetValues(Item.RootId, null, out mediaDevice.deviceValues);
        });
    }

    //public string? GetDescription(MediaDevice mediaDevice)
    //    => Invoke(() => mediaDevice.deviceValues!.GetStringValue(WPD.DEVICE_DESCRIPTION));

    #endregion

    #region IPortableDeviceManager

    public static string? GetDeviceFriendlyName(IPortableDeviceManager portableDeviceManager, string deviceId)
    {
        // already in work loop
        ThreadSafeWorkerException.ThrowIfNotInside();

        int size = 256;
        nint mem = Marshal.AllocHGlobal(size);
        int err = portableDeviceManager.GetDeviceFriendlyName(deviceId, mem, ref size);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetDeviceFriendlyName));
        string? str = Marshal.PtrToStringUni(mem);
        Marshal.FreeHGlobal(mem);
        return str;
    }

    public static string? GetDeviceDescription(IPortableDeviceManager portableDeviceManager, string deviceId)
    {
        // already in work loop
        ThreadSafeWorkerException.ThrowIfNotInside();

        int size = 256;
        nint mem = Marshal.AllocHGlobal(size);
        int err = portableDeviceManager.GetDeviceDescription(deviceId, mem, ref size);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetDeviceDescription));
        string? str = Marshal.PtrToStringUni(mem);
        Marshal.FreeHGlobal(mem);
        return str;
    }

    public static string? GetDeviceManufacturer(IPortableDeviceManager portableDeviceManager, string deviceId)
    {
        // already in work loop
        ThreadSafeWorkerException.ThrowIfNotInside();

        int size = 256;
        nint mem = Marshal.AllocHGlobal(size);
        int err = portableDeviceManager.GetDeviceManufacturer(deviceId, mem, ref size);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetDeviceManufacturer));
        string? str = Marshal.PtrToStringUni(mem);
        Marshal.FreeHGlobal(mem);
        return str;
    }

    #endregion

    #region IPortableDevice

    public string? GetPnPDeviceID(IPortableDevice device)
    {
        // already in work loop
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err = device.GetPnPDeviceID(out string pnPDeviceID);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.GetPnPDeviceID));
        return pnPDeviceID;
    }

    #endregion

    #region IPortableDeviceValues

    public string? GetSyncPartner(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetStringValue(WPD.DEVICE_SYNC_PARTNER));

    public string? GetFirmwareVersion(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetStringValue(WPD.DEVICE_FIRMWARE_VERSION));

    public int? GetPowerLevel(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetSignedIntegerValue(WPD.DEVICE_POWER_LEVEL));

    public PowerSource? GetPowerSource(IPortableDeviceValues deviceValues)
       => Invoke(() => (PowerSource?)deviceValues.GetSignedIntegerValue(WPD.DEVICE_POWER_SOURCE));

    public string? GetProtocol(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetStringValue(WPD.DEVICE_PROTOCOL));

    public string? GetManufacturer(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetStringValue(WPD.DEVICE_MANUFACTURER));

    public string? GetModel(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetStringValue(WPD.DEVICE_MODEL));

    public string? GetSerialNumber(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetStringValue(WPD.DEVICE_SERIAL_NUMBER));

    public bool? GetSupportsNonConsumable(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetBoolValue(WPD.DEVICE_SUPPORTS_NON_CONSUMABLE));

    public DateTime? GetDateTime(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetDateTimeValue(WPD.DEVICE_DATETIME));

    public string? GetFriendlyName(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetStringValue(WPD.DEVICE_FRIENDLY_NAME));

    // TODO
    //public x GetSupportedDRMSchemes(IPortableDeviceValues deviceValues)
    //    => Invoke(() => deviceValues.GetBoolValue(WPD.DEVICE_SUPPORTED_DRM_SCHEMES));

    public bool? GetSupportedFormatsAreOrdered(IPortableDeviceValues deviceValues)
        => Invoke(() => deviceValues.GetBoolValue(WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED));

    public DeviceType? GetDeviceType(IPortableDeviceValues deviceValues)
       => Invoke(() => (DeviceType?)deviceValues.GetSignedIntegerValue(WPD.DEVICE_TYPE));


    public ulong? GetNetworkIdentifier(IPortableDeviceValues deviceValues)
       => Invoke(() => deviceValues.GetUnsignedLargeIntegerValue(WPD.DEVICE_NETWORK_IDENTIFIER));

    // TODO check [ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier 
    public byte[]? GetFunctionalUniqueId(IPortableDeviceValues deviceValues)
       => Invoke(() => deviceValues.GetByteArrayValue(WPD.DEVICE_FUNCTIONAL_UNIQUE_ID));

    // TODO check [ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier 
    public byte[]? GetModelUniqueId(IPortableDeviceValues deviceValues)
       => Invoke(() => deviceValues.GetByteArrayValue(WPD.DEVICE_MODEL_UNIQUE_ID));

    public DeviceTransport? GetTransport(IPortableDeviceValues deviceValues)
       => Invoke(() => (DeviceTransport?)deviceValues.GetUnsignedIntegerValue(WPD.DEVICE_TRANSPORT));

    public DeviceTransport? GetUseDeviceStage(IPortableDeviceValues deviceValues)
       => Invoke(() => (DeviceTransport?)deviceValues.GetUnsignedIntegerValue(WPD.DEVICE_USE_DEVICE_STAGE));

    #endregion
}
