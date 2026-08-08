namespace MediaDevices.Internal;

partial class ProtocolHandler
{
    #region IPortableDeviceProperties

    public static string? SetFriendlyName(MediaDevice mediaDevice, string? value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        //IPortableDeviceValues devInValues = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

        IPortableDeviceValues devInValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        //int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var devInValues);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));


        devInValues.SetStringValue(ref WPD.DEVICE_FRIENDLY_NAME, value!);
        mediaDevice.deviceProperties!.SetValues(Item.RootId, devInValues, out IPortableDeviceValues _);

        // reload mediaDevice values with new friendly name 
        mediaDevice.deviceProperties.GetValues(Item.RootId, null, out mediaDevice.deviceValues);

        return mediaDevice.deviceValues!.GetStringValue(WPD.DEVICE_FRIENDLY_NAME);
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
