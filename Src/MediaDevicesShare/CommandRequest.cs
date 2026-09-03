//namespace MediaDevices;

//public class CommandRequest
//{
//    private static readonly ThreadSafeWorker worker = ThreadSafeWorker.Instance;

//    private readonly IPortableDeviceValues values;

//    public CommandRequest(PropertyKey commandKey)
//    {
//        this.values = worker.Invoke(() =>
//        {
//            IPortableDeviceValues values = ComHelper.CreateInstance<IPortableDeviceValues>();

//            int err = values.SetGuidValue(ref WPD.PROPERTY_COMMON_COMMAND_CATEGORY, ref commandKey.fmtid);
//            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetGuidValue), "PROPERTY_COMMON_COMMAND_CATEGORY");

//            err = values.SetUnsignedIntegerValue(ref WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);
//            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "PROPERTY_COMMON_COMMAND_ID");

//            return values;
//        });
//    }

//    public void Add(PropertyKey key, Guid value)
//    {
//        worker.Invoke(() =>
//        {
//            int err = this.values.SetGuidValue(ref key, ref value);
//            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetGuidValue), "TODO");
//        });
//    }

//    public void Add(PropertyKey key, int value)
//    {
//        worker.Invoke(() =>
//        {
//            int err = this.values.SetSignedIntegerValue(ref key, value);
//            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetSignedIntegerValue), "TODO");
//        });

//    }

//    public void Add(PropertyKey key, uint value)
//    {
//        worker.Invoke(() =>
//        {
//            int err = this.values.SetUnsignedIntegerValue(ref key, value);
//            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetUnsignedIntegerValue), "TODO");
//        });
//    }

//    //public void Add(PropertyKey key, IPortableDevicePropVariantCollection value)
//    //{
//    //    worker.Invoke(() =>
//    //    {
//    //        int err = this.values.SetIPortableDevicePropVariantCollectionValue(ref key, value);
//    //        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetIPortableDevicePropVariantCollectionValue), "TODO");
//    //    });
//    //}

//    public void Add(PropertyKey key, IEnumerable<int> values)
//    {
//        worker.Invoke(() =>
//        {
//            var col = ComHelper.CreateInstance<IPortableDevicePropVariantCollection>();

//            foreach (var value in values)
//            {
//                var var = PropVariantFacade.IntToPropVariant(value);
//                col.Add(ref var.Value);
//            }
//            int err = this.values.SetIPortableDevicePropVariantCollectionValue(ref key, col);
//            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetIPortableDevicePropVariantCollectionValue));
//        });
//    }

//    public void Add(PropertyKey key, string value)
//    {
//        worker.Invoke(() =>
//        {
//            int err = this.values.SetStringValue(ref key, value);
//            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.SetStringValue), "TODO");
//        });
//    }

//    internal CommandResponse SendCommand(MediaDevice mediaDevice)
//    {
//        ThreadSafeWorkerException.ThrowIfNotInside();

//        int err = mediaDevice.device!.SendCommand(0, values, out var result);
//        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevice), nameof(IPortableDevice.SendCommand));

//        err = result.GetErrorValue(ref WPD.PROPERTY_COMMON_HRESULT, out int error);
//        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetErrorValue));

//        if (error != (int)ErrorCodes.OK)
//        switch ((ErrorCodes)error)
//        {
//        case ErrorCodes.NotImplemented:
//            throw new NotImplementedException();
//        default:
//            throw new Exception($"Error {error:X}");
//        }

//        return new CommandResponse(result);
//    }
//}
