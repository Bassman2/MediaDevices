namespace MediaDevices;

partial class MediaDevice
{
    public string? GetDevicePropertyString(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this); 
        return mainWorker.Invoke(() => ProtocolHandler.GetPropertyString(this, propertyKey));
    }

    public int? GetDevicePropertyInt(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.GetPropertyInt(this, propertyKey));
    }

    public uint? GetDevicePropertyUInt(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.GetPropertyUInt(this, propertyKey));
    }

    public DateTime? GetDevicePropertyDateTime(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.GetPropertyDateTime(this, propertyKey));
    }


    public bool SetDeviceProperty(PropertyKey propertyKey, string? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return mainWorker.Invoke(() => ProtocolHandler.SetProperty(this, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, int? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return mainWorker.Invoke(() => ProtocolHandler.SetProperty(this, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, uint? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return mainWorker.Invoke(() => ProtocolHandler.SetProperty(this, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, DateTime? value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return mainWorker.Invoke(() => ProtocolHandler.SetProperty(this, propertyKey, value));
    }

}
