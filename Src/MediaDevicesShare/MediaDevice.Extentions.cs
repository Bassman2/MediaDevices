namespace MediaDevices;

partial class MediaDevice
{


    public string GetDevicePropertyString(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this); 
        return mainWorker.Invoke(() => ProtocolHandler.GetDevicePropertyString(this, propertyKey));
    }

    public short GetDevicePropertyInt(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.GetDevicePropertyInt(this, propertyKey));
    }

    public short GetDevicePropertyUInt(PropertyKey propertyKey)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.GetDevicePropertyUInt(this, propertyKey));
    }


    public bool SetDeviceProperty(PropertyKey propertyKey, string value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.SetDeviceProperty(this, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, int value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.SetDeviceProperty(this, propertyKey, value));
    }

    public bool SetDeviceProperty(PropertyKey propertyKey, uint value)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        return mainWorker.Invoke(() => ProtocolHandler.SetDeviceProperty(this, propertyKey, value));
    }

}
