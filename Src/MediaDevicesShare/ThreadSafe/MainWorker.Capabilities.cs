namespace MediaDevices;

partial class MainWorker
{
    public IEnumerable<Commands> SupportedCommands(IPortableDeviceCapabilities capabilities)
        => InvokeEnumerable(() => SupportedCommandsIntern(capabilities));

    private IEnumerable<Commands> SupportedCommandsIntern(IPortableDeviceCapabilities capabilities)
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

    public IEnumerable<FunctionalCategory> FunctionalCategories(IPortableDeviceCapabilities capabilities)
        => InvokeEnumerable(() => FunctionalCategoriesIntern(capabilities));

    private IEnumerable<FunctionalCategory> FunctionalCategoriesIntern(IPortableDeviceCapabilities capabilities)
    {
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

    public IEnumerable<string> FunctionalObjects(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory)
        => InvokeEnumerable(() => FunctionalObjectsIntern(capabilities, functionalCategory));

    private IEnumerable<string> FunctionalObjectsIntern(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory)
    {
        Guid guid = functionalCategory.GetGuid();
        int err = capabilities.GetFunctionalObjects(ref guid!, out IPortableDevicePropVariantCollection objects);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalObjects));
        //ComTrace.WriteObject(objects);
        //return objects.ToStrings();

        uint count = 0;
        int error = objects.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(error, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));
        for (uint i = 0; i < count; i++)
        {
            using PropVariantFacade val = new();
            err = objects.GetAt(i, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetAt));
            yield return val.ToString();
        }
    }

    public IEnumerable<ContentType> SupportedContentTypes(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory)
        => InvokeEnumerable(() => SupportedContentTypesIntern(capabilities, functionalCategory));

    private IEnumerable<ContentType> SupportedContentTypesIntern(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory)
    {
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

    public IEnumerable<Events> SupportedEvents(IPortableDeviceCapabilities capabilities)
        => InvokeEnumerable(() => SupportedEventsIntern(capabilities));

    public IEnumerable<Events> SupportedEventsIntern(IPortableDeviceCapabilities capabilities)
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
}
