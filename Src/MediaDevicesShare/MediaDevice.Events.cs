namespace MediaDevices;

partial class MediaDevice
{
    #region events

    /// <summary>
    /// This event is sent after a new object is available on the mediaDevice.
    /// </summary>
    public event EventHandler<ObjectAddedEventArgs>? ObjectAdded;

    /// <summary>
    /// This event is sent after a previously existing object has been removed from the mediaDevice.
    /// </summary>
    /// 
    public event EventHandler<MediaDeviceEventArgs>? ObjectRemoved;

    /// <summary>
    /// This event is sent after an object has been updated such that any connected client should refresh its view of that object.
    /// </summary>
    public event EventHandler<MediaDeviceEventArgs>? ObjectUpdated;

    /// <summary>
    /// This event indicates that the mediaDevice is about to be reset, and all connected clients should close their connection to the mediaDevice. 
    /// </summary>
    public event EventHandler<MediaDeviceEventArgs>? DeviceReset;

    /// <summary>
    /// This event indicates that the mediaDevice capabilities have changed. Clients should re-query the mediaDevice if they have made any decisions based on mediaDevice capabilities.
    /// </summary>
    public event EventHandler<MediaDeviceEventArgs>? DeviceCapabilitiesUpdated;

    /// <summary>
    /// This event indicates the progress of a format operation on a storage object.
    /// </summary>
    public event EventHandler<MediaDeviceEventArgs>? StorageFormat;

    /// <summary>
    /// This event is sent to request an application to transfer a particular object from the mediaDevice.
    /// </summary>
    public event EventHandler<MediaDeviceEventArgs>? ObjectTransferRequest;

    /// <summary>
    /// This event is sent when a driver for a mediaDevice is being unloaded. This is typically a result of the mediaDevice being unplugged.
    /// </summary>
    public event EventHandler<MediaDeviceEventArgs>? DeviceRemoved;

    /// <summary>
    /// This event is sent when a driver has completed invoking a service method. This event must be sent even when the method fails.
    /// </summary>
    public event EventHandler<MediaDeviceEventArgs>? ServiceMethodComplete;

    #endregion

    private ObjectAddedEventArgs CreateObjectAddedEventArgs(MediaDevice mediaDevice, Events eventEnum, IPortableDeviceValues eventParameters)
    {
        return mainWorker.Invoke(() => new ObjectAddedEventArgs(eventEnum, mediaDevice, eventParameters));
    }

    private MediaDeviceEventArgs CreateMediaDeviceEventArgs(MediaDevice mediaDevice, Events eventEnum, IPortableDeviceValues eventParameters)
    {
        return mainWorker.Invoke(() => new MediaDeviceEventArgs(eventEnum, mediaDevice, eventParameters));
    }

    internal void CallEvent(IPortableDeviceValues eventParameters)
    {
        ThreadSafeWorkerException.ThrowIfNotOutside();
        
        int err = eventParameters.GetGuidValue(ref WPD.EVENT_PARAMETER_EVENT_ID, out Guid eventGuid);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetGuidValue), "EVENT_PARAMETER_EVENT_ID");
        Events eventEnum = eventGuid.ToEventsEnum();

        MediaDeviceEventArgs? eventArgs = eventEnum switch
        {
            Events.ObjectAdded => new ObjectAddedEventArgs(eventEnum, this, eventParameters),
            Events.ObjectRemoved or
            Events.ObjectUpdated or
            Events.DeviceReset or
            Events.StorageFormat or
            Events.ObjectTransferRequest or
            Events.DeviceCapabilitiesUpdated or
            Events.DeviceRemoved or
            Events.ServiceMethodComplete => new MediaDeviceEventArgs(eventEnum, this, eventParameters),
            _ => null
        };

        if (eventArgs != null)
        {
            eventThreadHandler.Invoke(eventArgs);
        }
    }

    internal void InvokeEvent(MediaDeviceEventArgs eventArgs)
    {
        if (Environment.CurrentManagedThreadId != eventThreadHandler.ThreadId)
        {
            throw new ThreadSafeWorkerException("Not in event Thread");
        }

        switch (eventArgs.Event)
        {
        case Events.ObjectAdded:
            this.ObjectAdded?.Invoke(this, (ObjectAddedEventArgs)eventArgs);
            break;
        case Events.ObjectRemoved:
            this.ObjectRemoved?.Invoke(this, eventArgs);
            break;
        case Events.ObjectUpdated:
            this.ObjectUpdated?.Invoke(this, eventArgs);
            break;
        case Events.DeviceReset:
            this.DeviceReset?.Invoke(this, eventArgs);
            break;
        case Events.DeviceCapabilitiesUpdated:
            this.DeviceCapabilitiesUpdated?.Invoke(this, eventArgs);
            break;
        case Events.StorageFormat:
            this.StorageFormat?.Invoke(this, eventArgs);
            break;
        case Events.ObjectTransferRequest:
            this.ObjectTransferRequest?.Invoke(this, eventArgs);
            break;
        case Events.DeviceRemoved:
            this.DeviceRemoved?.Invoke(this, eventArgs);
            break;
        case Events.ServiceMethodComplete:
            this.ServiceMethodComplete?.Invoke(this, eventArgs);
            break;
        default:
            break;
        }
    }
}
