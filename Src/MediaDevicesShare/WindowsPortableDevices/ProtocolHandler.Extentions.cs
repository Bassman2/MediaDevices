namespace MediaDevices.Internal;

partial class ProtocolHandler
{
    private  const string DeviceId = "DEVICE";

    public static string? GetPropertyString(MediaDevice mediaDevice, PropertyKey propertyKey, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = mediaDevice.deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = mediaDevice.deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetStringValue(ref propertyKey, out var value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public static int? GetPropertyInt(MediaDevice mediaDevice, PropertyKey propertyKey, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = mediaDevice.deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = mediaDevice.deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetSignedIntegerValue(ref propertyKey, out var value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public static uint? GetPropertyUInt(MediaDevice mediaDevice, PropertyKey propertyKey, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = mediaDevice.deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = mediaDevice.deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetUnsignedIntegerValue(ref propertyKey, out var value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public static DateTime? GetPropertyDateTime(MediaDevice mediaDevice, PropertyKey propertyKey, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = mediaDevice.deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = mediaDevice.deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetValue(ref propertyKey, out PropVariant dateTime);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetValue));

        DateTime? value = dateTime.vt == PropVariantType.VT_DATE ? DateTime.FromOADate(dateTime.dateVal) : null;
        dateTime.Release();

        return value;
    }


    public static bool SetProperty(MediaDevice mediaDevice, PropertyKey propertyKey, string? value, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetStringValue(ref propertyKey, value!);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue));

        err = mediaDevice.deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public static bool SetProperty(MediaDevice mediaDevice, PropertyKey propertyKey, int? value, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetSignedIntegerValue(ref propertyKey, value.GetValueOrDefault());
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetSignedIntegerValue));

        err = mediaDevice.deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public static bool SetProperty(MediaDevice mediaDevice, PropertyKey propertyKey, uint? value, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetUnsignedIntegerValue(ref propertyKey, value.GetValueOrDefault());
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue));

        err = mediaDevice.deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public static bool SetProperty(MediaDevice mediaDevice, PropertyKey propertyKey, DateTime? value, string objectId = DeviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        PropVariant dateTime = new() { vt = PropVariantType.VT_DATE, dateVal = value.GetValueOrDefault().ToOADate()};

        int err = deviceValues.SetValue(ref propertyKey, ref dateTime);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue));
        
        err = mediaDevice.deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }
}
