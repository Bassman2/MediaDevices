namespace MediaDevices.Internal;

internal class Command
{
    private readonly IPortableDeviceValues values;
    private IPortableDeviceValues? result;

    private Command(PropertyKey commandKey)
    {
        values = ComHelper.CreateInstance<IPortableDeviceValues>();

        int err = this.values.SetGuidValue(ref WPD.PROPERTY_COMMON_COMMAND_CATEGORY, ref commandKey.fmtid);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetGuidValue), "PROPERTY_COMMON_COMMAND_CATEGORY");

        err = this.values.SetUnsignedIntegerValue(ref WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "PROPERTY_COMMON_COMMAND_ID");
    }

    public static Command Create(PropertyKey commandKey)
    {
        return new Command(commandKey);
    }

    public void Add(PropertyKey key, Guid value)
    {
        int err = this.values.SetGuidValue(ref key, ref value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetGuidValue), "TODO");
    }

    public void Add(PropertyKey key, int value)
    {
        int err = this.values.SetSignedIntegerValue(ref key, value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetSignedIntegerValue), "TODO");

    }

    public void Add(PropertyKey key, uint value)
    {
        int err = this.values.SetUnsignedIntegerValue(ref key, value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "TODO");
    }

    public void Add(PropertyKey key, IPortableDevicePropVariantCollection value)
    {
        int err = this.values.SetIPortableDevicePropVariantCollectionValue(ref key, value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetIPortableDevicePropVariantCollectionValue), "TODO");
    }

    public void Add(PropertyKey key, IEnumerable<int> values)
    {
        var col = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>();

        foreach (var value in values)
        {
            var var = PropVariantFacade.IntToPropVariant(value);
            col.Add(ref var.Value);
        }
        int err = this.values.SetIPortableDevicePropVariantCollectionValue(ref key, col);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetIPortableDevicePropVariantCollectionValue));
    }

    public void Add(PropertyKey key, string value)
    {
        int err = this.values.SetStringValue(ref key, value);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "TODO");
    }

    //public void Add(PropertyKey key, byte[] buffer, int size)
    //{
    //    Marshal..
    //    this.values.SetBufferValue(key, ref buffer, (uint)size);
    //}

    public Guid GetGuid(PropertyKey key)
    {
        this.result!.GetGuidValue(ref key, out Guid value);
        return value;
    }

    public int GetInt(PropertyKey key)
    {
        this.result!.GetSignedIntegerValue(ref key, out int value);
        return value;
    }

    public string GetString(PropertyKey key)
    {
        this.result!.GetStringValue(ref key, out string value);
        return value;
    }
    
    public IEnumerable<PropVariantFacade> GetPropVariants(PropertyKey key) 
    {
        int err = this.result!.GetIUnknownValue(ref key, out object? obj);
        if (err == (int)ErrorCodes.NotFound)
        {
            yield break;
        }
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetIUnknownValue), key.ToName());

        var col = obj as IPortableDevicePropVariantCollection;
    
        uint count = 0;
        err = col!.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            var val = new PropVariantFacade();  // no using
            err = col.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            yield return val;
        }
    }

    //public bool Has(PropertyKey key)
    //{
    //    uint count = 0;
    //    this.result!.GetCount(ref count);
    //    for (uint i = 0; i < count; i++)
    //    {
    //        var k = new PropertyKey();
    //        var v = new PropVariant();
    //        this.result!.GetAt(i, ref k, ref v);
    //        if (key == k)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    public bool Send(IPortableDevice device)
    {
        int err = device.SendCommand(0, this.values, out this.result);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.SendCommand));

        err = result.GetErrorValue(ref WPD.PROPERTY_COMMON_HRESULT, out int error);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetErrorValue));

        //ComTrace.WriteValues(this.result!);

        switch ((ErrorCodes)error)
        {
        case ErrorCodes.OK:
            return true;
        case ErrorCodes.NotImplemented:
            Debug.WriteLine("Command not implemented!");
            return false;
        default:
            throw new Exception($"Error {error:X}");
        }
    }

    ////[Conditional("COMTRACE")]
    //public void WriteResults()
    //{
    //    ComTrace.WriteValues(this.result!);
    //}
}
