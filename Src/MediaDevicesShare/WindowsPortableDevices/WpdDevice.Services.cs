namespace MediaDevices.WindowsPortableDevices;

partial class WpdDevice
{

    public IEnumerable<MediaDeviceService> GetServices(MediaDeviceServices serviceTypes)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Guid serviceGuid = serviceTypes.ToGuid();
        uint num = 0;
        int err = serviceManager.GetDeviceServices(usbDevice, ref serviceGuid, null, ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceServiceManager), nameof(IPortableDeviceServiceManager.GetDeviceServices));

        if (num == 0)
        {
            yield break;
        }
        string[] services = new string[num];
        err = serviceManager.GetDeviceServices(usbDevice, ref serviceGuid, services, ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceServiceManager), nameof(IPortableDeviceServiceManager.GetDeviceServices));

        foreach (var service in services)
        {
            yield return new MediaDeviceService(this, service);
        }
    }


    public static IEnumerable<Commands> SupportedCommands(IPortableDeviceServiceCapabilities capabilities)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

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
            yield return key.ToCommandsEnum();
        }
    }

    public static IEnumerable<Events> SupportedEvents(IPortableDeviceServiceCapabilities capabilities)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

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
            yield return guid.ToEventsEnum();
        }
    }


    public static IEnumerable<Formats> SupportedFormats(IPortableDeviceServiceCapabilities capabilities)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

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
            yield return guid.ToFormatsEnum();
        }
    }



    public static IEnumerable<Methods> SupportedMethods(IPortableDeviceServiceCapabilities capabilities)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

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
            yield return guid.ToMethodsEnum();
        }
    }
}
