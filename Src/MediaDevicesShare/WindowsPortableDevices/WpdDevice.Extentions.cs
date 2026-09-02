namespace MediaDevices.WindowsPortableDevices;

partial class WpdDevice
{
    private  const string ObjecId = "DEVICE";

    public string? GetPropertyString(PropertyKey propertyKey, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetStringValue(ref propertyKey, out var value);
        if (err == (int)ErrorCodes.NotFound)
        {
            return null;
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public int? GetPropertyInt(PropertyKey propertyKey, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetSignedIntegerValue(ref propertyKey, out var value);
        if (err == (int)ErrorCodes.NotFound)
        {
            return null;
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public uint? GetPropertyUInt(PropertyKey propertyKey, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetUnsignedIntegerValue(ref propertyKey, out var value);
        if (err == (int)ErrorCodes.NotFound)
        {
            return null;
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetStringValue));

        return value;
    }

    public DateTime? GetPropertyDateTime(PropertyKey propertyKey, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        var keyCollection = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keyCollection.Add(ref propertyKey);

        int err = deviceProperties!.GetValues(objectId, keyCollection, out var deviceValues);
        if (err != 0)
        {
            // some devices does not accept a keyCollection
            err = deviceProperties!.GetValues(objectId, null, out deviceValues);
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues));

        err = deviceValues!.GetValue(ref propertyKey, out PropVariant dateTime);
        if (err == (int)ErrorCodes.NotFound)
        {
            return null;
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetValue));

        DateTime? value = dateTime.vt == PropVariantType.VT_DATE ? DateTime.FromOADate(dateTime.dateVal) : null;
        dateTime.Release();

        return value;
    }


    public bool SetProperty(PropertyKey propertyKey, string? value, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetStringValue(ref propertyKey, value!);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue));

        err = deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public bool SetProperty(PropertyKey propertyKey, int? value, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetSignedIntegerValue(ref propertyKey, value.GetValueOrDefault());
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetSignedIntegerValue));

        err = deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public bool SetProperty(PropertyKey propertyKey, uint? value, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();
        int err = deviceValues.SetUnsignedIntegerValue(ref propertyKey, value.GetValueOrDefault());
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue));

        err = deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

    public bool SetProperty(PropertyKey propertyKey, DateTime? value, string objectId = ObjecId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        IPortableDeviceValues deviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        PropVariant dateTime = new() { vt = PropVariantType.VT_DATE, dateVal = value.GetValueOrDefault().ToOADate()};

        int err = deviceValues.SetValue(ref propertyKey, ref dateTime);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetValue));
        
        err = deviceProperties!.SetValues(objectId, deviceValues, out IPortableDeviceValues _);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.SetValues));

        return true;
    }

   

    //public CommandResponse SendCommand(CommandRequest request)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    int err = device.SendCommand(0, request.values, out var .result);
    //    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.SendCommand));

    //    err = result.GetErrorValue(ref WPD.PROPERTY_COMMON_HRESULT, out int error);
    //    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetErrorValue));

    //    //ComTrace.WriteValues(this.result!);

    //    switch ((ErrorCodes)error)
    //    {
    //    case ErrorCodes.OK:
    //        return true;
    //    case ErrorCodes.NotImplemented:
    //        Debug.WriteLine("Command not implemented!");
    //        return false;
    //    default:
    //        throw new Exception($"Error {error:X}");
    //    }
    //    mediaDevice.device.SendCommand
    //    return new CommandRequest(commandKey);
    //}
}
