namespace MediaDevices;

partial class MediaDevice
{
    public string? GetDevicePropertyString(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this); 
        return worker.Invoke(() => device.GetPropertyString(ObjectId.Device, propertyKey));
    }

    public int? GetDevicePropertyInt(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return worker.Invoke(() => device.GetPropertyInt(ObjectId.Device, propertyKey));
    }

    public uint? GetDevicePropertyUInt(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return worker.Invoke(() => device.GetPropertyUInt(ObjectId.Device, propertyKey));
    }

    public DateTime? GetDevicePropertyDateTime(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return worker.Invoke(() => device.GetPropertyDateTime(ObjectId.Device, propertyKey));
    }


    public bool SetDeviceProperty(PropertyKey propertyKey, string? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return worker.Invoke(() => device.SetProperty(ObjectId.Device, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, int? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return worker.Invoke(() => device.SetProperty(ObjectId.Device, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, uint? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return worker.Invoke(() => device.SetProperty(ObjectId.Device, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, DateTime? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return worker.Invoke(() => device.SetProperty(ObjectId.Device, propertyKey, value));
    }

}
