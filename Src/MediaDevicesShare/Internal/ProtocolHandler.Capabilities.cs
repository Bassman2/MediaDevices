namespace MediaDevices.Internal;

partial class ProtocolHandler
{
    public static IEnumerable<Commands> SupportedCommands(IPortableDeviceCapabilities capabilities)
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
            yield return key.FindCommandsEnum();
        }
    }

    

    public static IEnumerable<FunctionalCategory> FunctionalCategories(IPortableDeviceCapabilities capabilities)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        int err = capabilities.GetFunctionalCategories(out IPortableDevicePropVariantCollection categories);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalCategories));
        //return categories.ToFunctionalCategory();

        uint count = 0;
        err = categories.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = categories.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            //yield return (FunctionalCategory)GetEnumFromAttrGuid<FunctionalCategory>(val.ToGuid())!;
            Guid guid = val.ToGuid();
            yield return guid.FindFunctionalCategoryEnum();
        }
    }

    
    public static IEnumerable<string> FunctionalObjects(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Guid guid = functionalCategory.GetGuid();
        int err = capabilities.GetFunctionalObjects(ref guid!, out IPortableDevicePropVariantCollection objects);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalObjects));
        //ComTrace.WriteObject(objects);
        //return objects.ToStrings();

        uint count = 0;
        err = objects.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = objects.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            yield return val.ToString();
        }
    }

    
    public static IEnumerable<ContentType> SupportedContentTypes(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Guid guid = functionalCategory.GetGuid();
        int err = capabilities.GetSupportedContentTypes(ref guid, out IPortableDevicePropVariantCollection types);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedContentTypes));
        //return types.ToContentTypes();

        uint count = 0;
        err = types.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = types.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            //yield return (ContentType)GetEnumFromAttrGuid<ContentType>(val.ToGuid())!;
            Guid guid2 = val.ToGuid();
            yield return guid2.FindContentTypeEnum();
        }
    }

    public static IEnumerable<Events> SupportedEvents(IPortableDeviceCapabilities capabilities)
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
            yield return guid.FindEventsEnum();
        }
    }
}
