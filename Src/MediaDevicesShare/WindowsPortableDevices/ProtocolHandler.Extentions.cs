namespace MediaDevices.Internal;

partial class ProtocolHandler
{
    public static string GetDevicePropertyString(MediaDevice mediaDevice, PropertyKey propertyKey)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = mediaDevice.deviceProperties!.GetValues(Item.RootId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = mediaDevice.deviceProperties!.GetValues(Item.RootId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetStringValue(ref propertyKey, out var value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public static int GetDevicePropertyInt(MediaDevice mediaDevice, PropertyKey propertyKey)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = mediaDevice.deviceProperties!.GetValues(Item.RootId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = mediaDevice.deviceProperties!.GetValues(Item.RootId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetSignedIntegerValue(ref propertyKey, out var value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public static uint GetDevicePropertyUInt(MediaDevice mediaDevice, PropertyKey propertyKey)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = mediaDevice.deviceProperties!.GetValues(Item.RootId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = mediaDevice.deviceProperties!.GetValues(Item.RootId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetUnsignedIntegerValue(ref propertyKey, out var value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }


    public static bool SetDeviceProperty(MediaDevice mediaDevice, PropertyKey propertyKey, string value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetStringValue(ref propertyKey, value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue));

        err = mediaDevice.deviceProperties!.SetValues(Item.RootId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public static bool SetDeviceProperty(MediaDevice mediaDevice, PropertyKey propertyKey, int value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetSignedIntegerValue(ref propertyKey, value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetSignedIntegerValue));

        err = mediaDevice.deviceProperties!.SetValues(Item.RootId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public static bool SetDeviceProperty(MediaDevice mediaDevice, PropertyKey propertyKey, uint value)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetUnsignedIntegerValue(ref propertyKey, value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue));

        err = mediaDevice.deviceProperties!.SetValues(Item.RootId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }
}
