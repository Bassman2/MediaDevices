namespace MediaDevices.WindowsPortableDevices;

partial class WpdDevice
{
    // withou connection

    public string UsbDevice { get; }

    public ManufacturerId ManufacturerId { get; }

    public ushort DeviceId { get; } = 0;    

    public string Description { get; }

    public string FriendlyName { get; }

    public string Manufacturer { get; set; }

    // only after connection

    public string? Name { get; set; } = null;

    public string? SyncPartner { get; set; } = null;

    public string? FirmwareVersion { get; set; } = null;


    public uint? PowerLevel { get; set; } = null;

    public PowerSource? PowerSource { get; set; } = null;

    public string? Protocol { get; set; } = null;

    public string? Model { get; set; } = null;

    public string? SerialNumber { get; set; } = null;

    public bool? SupportsNonConsumable { get; set; } = null;

    public string[]? SupportedDrmSchemes { get; set; } = null;


    public bool? SupportedFormatsAreOrdered { get; set; } = null;


    public DeviceType? DeviceType { get; set; } = null;


    public DeviceTransport? Transport { get; set; } = null;

    /// <summary>
    /// Indicates whether to use the device stage UI for this device.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public DeviceTransport? UseDeviceStage { get; set; } = null;





    #region IPortableDeviceProperties

    public string? SetFriendlyName(string? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues devInValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        devInValues.SetStringValue(ref WPD.DEVICE_FRIENDLY_NAME, value!);

        int err = deviceProperties!.SetValues(WpdItem.RootId, devInValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        // reload mediaDevice values with new friendly name 
        err = deviceProperties.GetValues(WpdItem.RootId, null, out var deviceValues);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetStringValue(ref WPD.DEVICE_FRIENDLY_NAME, out string name);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return name;
    }

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
}
