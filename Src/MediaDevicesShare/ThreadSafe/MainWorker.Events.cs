namespace MediaDevices;

partial class MainWorker
{

    public ObjectAddedEventArgs CreateObjectAddedEventArgs(MediaDevice mediaDevice, Events eventEnum, IPortableDeviceValues eventParameters)
    {
        return Invoke(() => new ObjectAddedEventArgs(eventEnum, mediaDevice, eventParameters));
    }

    public MediaDeviceEventArgs CreateMediaDeviceEventArgs(MediaDevice mediaDevice, Events eventEnum, IPortableDeviceValues eventParameters)
    {
        return Invoke(() => new MediaDeviceEventArgs(eventEnum, mediaDevice, eventParameters));
    }

}
