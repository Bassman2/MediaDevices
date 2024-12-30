﻿namespace MediaDevices.Internal;

internal class Command
{
    private readonly IPortableDeviceValues values;
    private IPortableDeviceValues? result;

    private Command(PropertyKey commandKey)
    {
        this.values = (IPortableDeviceValues)new PortableDeviceValues();
        this.values.SetGuidValue(ref WPD.PROPERTY_COMMON_COMMAND_CATEGORY, ref commandKey.fmtid);
        this.values.SetUnsignedIntegerValue(ref WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);
    }

    public static Command Create(PropertyKey commandKey)
    {
        return new Command(commandKey);
    }

    public void Add(PropertyKey key, Guid value)
    {
        this.values.SetGuidValue(ref key, ref value);
    }

    public void Add(PropertyKey key, int value)
    {
        this.values.SetSignedIntegerValue(ref key, value);
    }

    public void Add(PropertyKey key, uint value)
    {
        this.values.SetUnsignedIntegerValue(ref key, value);
    }

    public void Add(PropertyKey key, IPortableDevicePropVariantCollection value)
    {
        this.values.SetIPortableDevicePropVariantCollectionValue(ref key, value);
    }
    
    public void Add(PropertyKey key, IEnumerable<int> values)
    {
        IPortableDevicePropVariantCollection col = (IPortableDevicePropVariantCollection) new PortableDevicePropVariantCollection();
        foreach (var value in values)
        {
            var var = PropVariantFacade.IntToPropVariant(value);
            col.Add(ref var.Value);
        }
        this.values.SetIPortableDevicePropVariantCollectionValue(ref key, col);
    }

    public void Add(PropertyKey key, string value)
    {
        this.values.SetStringValue(ref key, value);
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
        this.result!.GetIUnknownValue(ref key, out object obj);
        var col = (IPortableDevicePropVariantCollection)obj;
    
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            var val = new PropVariantFacade();
            col.GetAt(i, ref val.Value);
            yield return val;
        }
    }

    public bool Has(PropertyKey key)
    {
        uint count = 0;
        this.result!.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            var k = new PropertyKey();
            var v = new PropVariant();
            this.result.GetAt(i, ref k, ref v);
            if (key == k)
            {
                return true;
            }
        }
        return false;
    }

    public bool Send(IPortableDevice device)
    {
        device.SendCommand(0, this.values, out this.result);

        result.GetErrorValue(ref WPD.PROPERTY_COMMON_HRESULT, out int error);
        switch ((HResult)error)
        {
        case HResult.S_OK:
            return true;
        case HResult.E_NOT_IMPLEMENTED:
            Debug.WriteLine("Command not implemented!");
            return false;
        default:
            throw new Exception($"Error {error:X}");
        }
    }

    [Conditional("COMTRACE")]
    public void WriteResults()
    {
        ComTrace.WriteObject(this.result!);
    }
}
