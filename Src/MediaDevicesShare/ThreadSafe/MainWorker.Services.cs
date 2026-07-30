namespace MediaDevices;

partial class MainWorker
{
    public IEnumerable<MediaDeviceService> GetServices(MediaDevice mediaDevice, MediaDeviceServices serviceType)
        =>  InvokeEnumerable(() => GetServicesIntern(mediaDevice, serviceType));

    public IEnumerable<MediaDeviceService> GetServicesIntern(MediaDevice mediaDevice, MediaDeviceServices serviceTypes)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Guid serviceGuid = serviceTypes.GetGuid();
        uint num = 0;
        int err = serviceManager.GetDeviceServices(mediaDevice.DeviceId, ref serviceGuid, null, ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceServiceManager), nameof(IPortableDeviceServiceManager.GetDeviceServices));

        if (num == 0)
        {
            yield break;
        }
        string[] services = new string[num];
        err = serviceManager.GetDeviceServices(mediaDevice.DeviceId, ref serviceGuid, services, ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceServiceManager), nameof(IPortableDeviceServiceManager.GetDeviceServices));

        foreach (var service in services)
        {
            yield return new MediaDeviceService(mediaDevice, service);
        }
    }

    public IEnumerable<Commands> SupportedCommands(IPortableDeviceServiceCapabilities capabilities)
        => InvokeEnumerable(() => SupportedCommandsIntern(capabilities));

    private IEnumerable<Commands> SupportedCommandsIntern(IPortableDeviceServiceCapabilities capabilities)
    {
        int err = capabilities.GetSupportedCommands(out IPortableDeviceKeyCollection commands);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedCommands));
        //return commands.ToCommands();

        uint count = 0;
        err = commands.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceKeyCollection), nameof(IPortableDeviceKeyCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            PropertyKey key = new();
            err = commands.GetAt(i, ref key);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceKeyCollection), nameof(IPortableDeviceKeyCollection.GetAt));
            //yield return (Commands)GetEnumFromAttrKey<Commands>(key)!;
            yield return key.FindCommandsEnum();
        }
    }

    public IEnumerable<Events> SupportedEvents(IPortableDeviceServiceCapabilities capabilities)
        => InvokeEnumerable(() => SupportedEventsIntern(capabilities));

    public IEnumerable<Events> SupportedEventsIntern(IPortableDeviceServiceCapabilities capabilities)
    {
        int err = capabilities.GetSupportedEvents(out IPortableDevicePropVariantCollection events);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
        //return events.ToEvents();

        uint count = 0;
        err = events.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = events.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            //yield return (Events)GetEnumFromAttrGuid<Events>(val.ToGuid())!;
            Guid guid = val.ToGuid();
            yield return guid.FindEventsEnum();
        }
    }

    public IEnumerable<Formats> SupportedFormats(IPortableDeviceServiceCapabilities capabilities)
        => InvokeEnumerable(() => SupportedFormatsIntern(capabilities));

    public IEnumerable<Formats> SupportedFormatsIntern(IPortableDeviceServiceCapabilities capabilities)
    {
        int err = capabilities.GetSupportedFormats(out IPortableDevicePropVariantCollection formats);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
        //return events.ToEvents();

        uint count = 0;
        err = formats.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = formats.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            //yield return (Events)GetEnumFromAttrGuid<Events>(val.ToGuid())!;
            Guid guid = val.ToGuid();
            yield return guid.FindFormatsEnum();
        }
    }

    public IEnumerable<Methods> SupportedMethods(IPortableDeviceServiceCapabilities capabilities)
        => InvokeEnumerable(() => SupportedMethodsIntern(capabilities));

    public IEnumerable<Methods> SupportedMethodsIntern(IPortableDeviceServiceCapabilities capabilities)
    {
        int err = capabilities.GetSupportedMethods(out IPortableDevicePropVariantCollection methods);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
        //return events.ToEvents();

        uint count = 0;
        err = methods.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = methods.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            //yield return (Events)GetEnumFromAttrGuid<Events>(val.ToGuid())!;
            Guid guid = val.ToGuid();
            yield return guid.FindMethodsEnum();
        }
    }
}
