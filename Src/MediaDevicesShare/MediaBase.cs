//namespace MediaDevices;

//public abstract class MediaBase(MediaDevice device, string objId = MediaBase.DeviceId)
//{
//    private const string DeviceId = "DEVICE";

//    internal static readonly ThreadSafeWorker mainWorker = ThreadSafeWorker.Instance;
    
//    protected readonly MediaDevice mediaDevice = device;

//    protected readonly string objectId = objId;

//    public string? GetPropertyString(PropertyKey propertyKey)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        return mainWorker.Invoke(() => WpdDevice.GetPropertyString(mediaDevice, propertyKey));
//    }

//    public int? GetPropertyInt(PropertyKey propertyKey)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        return mainWorker.Invoke(() => WpdDevice.GetPropertyInt(mediaDevice, propertyKey));
//    }

//    public uint? GetPropertyUInt(PropertyKey propertyKey)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        return mainWorker.Invoke(() => WpdDevice.GetPropertyUInt(mediaDevice, propertyKey));
//    }

//    public DateTime? GetPropertyDateTime(PropertyKey propertyKey)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        return mainWorker.Invoke(() => WpdDevice.GetPropertyDateTime(mediaDevice, propertyKey));
//    }


//    public bool SetProperty(PropertyKey propertyKey, string? value)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        ArgumentNullException.ThrowIfNull(value, nameof(value));

//        return mainWorker.Invoke(() => WpdDevice.SetProperty(mediaDevice, propertyKey, value));
//    }

//    public bool SetProperty(PropertyKey propertyKey, int? value)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        ArgumentNullException.ThrowIfNull(value, nameof(value));

//        return mainWorker.Invoke(() => WpdDevice.SetProperty(mediaDevice, propertyKey, value));
//    }

//    public bool SetProperty(PropertyKey propertyKey, uint? value)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        ArgumentNullException.ThrowIfNull(value, nameof(value));

//        return mainWorker.Invoke(() => WpdDevice.SetProperty(mediaDevice, propertyKey, value));
//    }

//    public bool SetProperty(PropertyKey propertyKey, DateTime? value)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        ArgumentNullException.ThrowIfNull(value, nameof(value));

//        return mainWorker.Invoke(() => WpdDevice.SetProperty(mediaDevice, propertyKey, value));
//    }

   

//    public CommandResponse SendCammand(CommandRequest request)
//    {
//        NotConnectedException.ThrowIfNotConnected(mediaDevice);
//        return request.SendCommand(mediaDevice);
//    }
//}
