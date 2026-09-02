namespace MediaDevices.WindowsPortableDevices;

partial class WpdDevice
{
    public IEnumerable<Commands> SupportedCommands(CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        int err = deviceCapabilities!.GetSupportedCommands(out IPortableDeviceKeyCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedCommands));
        return collection.Enumerate<Commands>(key => key.ToCommandsEnum());
    }

    public IEnumerable<MediaProperty> CommandOptions(Commands command, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        PropertyKey key = command.ToKey() ?? throw new ArgumentException("not found", nameof(command));
        int err = deviceCapabilities!.GetCommandOptions(ref key, out IPortableDeviceValues values);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetCommandOptions));
        return values.Enumerate<MediaProperty> (val => new MediaProperty(val));
    }

    public IEnumerable<FunctionalCategory> FunctionalCategories(CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        int err = deviceCapabilities!.GetFunctionalCategories(out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalCategories));
        return collection.Enumerate<FunctionalCategory>(val => val.ToGuid().ToFunctionalCategoryEnum());
    }
    
    public IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        Guid guid = functionalCategory.ToGuid();
        int err = deviceCapabilities!.GetFunctionalObjects(ref guid!, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalObjects));
        return collection.Enumerate<string>(val => val.ToString());
    }

    
    public IEnumerable<ContentType> SupportedContentTypes(FunctionalCategory functionalCategory, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        Guid guid = functionalCategory.ToGuid();
        int err = deviceCapabilities!.GetSupportedContentTypes(ref guid, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedContentTypes));
        return collection.Enumerate<ContentType>(val => val.ToGuid().ToContentTypeEnum());
    }

    public IEnumerable<Formats> SupportedFormats(ContentType functionalCategory, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        Guid guid = functionalCategory.ToGuid();
        int err = deviceCapabilities!.GetSupportedFormats(ref guid, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedFormats));

#if DEBUG
        collection.Enumerate<Guid>(val => val.ToGuid()).Where(g => g.ToFormatsEnum() == Formats.Unknown).ToList().ForEach(i =>
            Debug.WriteLine($"***Unknown Format {i}"));

#endif


        return collection.Enumerate<Formats>(val => val.ToGuid().ToFormatsEnum());
    }

    public IEnumerable<string> SupportedFormatProperties(Formats format, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        Guid guid = format.ToGuid();
        int err = deviceCapabilities!.GetSupportedFormatProperties(ref guid, out IPortableDeviceKeyCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedFormatProperties));
        return collection.Enumerate<string>(val => val.Name);
    }

    public IEnumerable<MediaProperty> FixedPropertyAttributes(Formats format, PropertyKey key, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        Guid guid = format.ToGuid();
        int err = deviceCapabilities!.GetFixedPropertyAttributes(ref guid, ref key, out IPortableDeviceValues collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFixedPropertyAttributes));
        return collection.Enumerate<MediaProperty>(val => new MediaProperty(val));
    }

    //public void Cancel(IPortableDeviceCapabilities capabilities, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    cancellationToken.Register(() => deviceCapabilities!.Cancel());

    //    int err = deviceCapabilities!.Cancel();
    //    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
    //}

    public IEnumerable<Events> SupportedEvents(CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());

        int err = deviceCapabilities!.GetSupportedEvents(out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
        return collection.Enumerate<Events>(val => val.ToGuid().ToEventsEnum());
    }

    public IEnumerable<(string,string)> EventOptions(Events ev, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => deviceCapabilities!.Cancel());
        
        Guid guid = ev.ToGuid();
        int err = deviceCapabilities!.GetEventOptions(ref guid, out IPortableDeviceValues values);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
        return values.Enumerate<(string, string)>(val => new (val.KeyName, val.ToString()));
    }
}
