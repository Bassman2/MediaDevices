namespace MediaDevices.Internal;

[GeneratedComClass]
internal partial class EventCallback(MediaDevice device) : IPortableDeviceEventCallback
{
    public void OnEvent(IPortableDeviceValues pEventParameters)
    {
        device.CallEvent(pEventParameters);
    }
}
