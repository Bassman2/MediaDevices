namespace MediaDevices.Internal;

partial class ProtocolHandler
{
    public static IEnumerable<Commands> SupportedCommands(IPortableDeviceCapabilities capabilities, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        int err = capabilities.GetSupportedCommands(out IPortableDeviceKeyCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedCommands));
        return collection.Enumerate<Commands>(key => key.FindCommandsEnum());
    }

    public static IEnumerable<(string, string)> CommandOptions(IPortableDeviceCapabilities capabilities, Commands command, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        PropertyKey key = command.FindCommandsKey() ?? throw new ArgumentException("not found", nameof(command));
        int err = capabilities.GetCommandOptions(ref key, out IPortableDeviceValues values);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetCommandOptions));
        return values.Enumerate<(string, string)>(val => new (val.KeyName, val.ToString()));
    }

    public static IEnumerable<FunctionalCategory> FunctionalCategories(IPortableDeviceCapabilities capabilities, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        int err = capabilities.GetFunctionalCategories(out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalCategories));
        return collection.Enumerate<FunctionalCategory>(val => val.ToGuid().FindFunctionalCategoryEnum());
    }
    
    public static IEnumerable<string> FunctionalObjects(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        Guid guid = functionalCategory.GetGuid();
        int err = capabilities.GetFunctionalObjects(ref guid!, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFunctionalObjects));
        return collection.Enumerate<string>(val => val.ToString());
    }

    
    public static IEnumerable<ContentType> SupportedContentTypes(IPortableDeviceCapabilities capabilities, FunctionalCategory functionalCategory, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        Guid guid = functionalCategory.GetGuid();
        int err = capabilities.GetSupportedContentTypes(ref guid, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedContentTypes));
        return collection.Enumerate<ContentType>(val => val.ToGuid().FindContentTypeEnum());
    }

    public static IEnumerable<ContentType> SupportedFormats(IPortableDeviceCapabilities capabilities, ContentType functionalCategory, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        Guid guid = functionalCategory.GetGuid();
        int err = capabilities.GetSupportedFormats(ref guid, out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedFormats));
        return collection.Enumerate<ContentType>(val => val.ToGuid().FindContentTypeEnum());
    }

    public static IEnumerable<string> SupportedFormatProperties(IPortableDeviceCapabilities capabilities, Formats format, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        Guid guid = format.GetGuid();
        int err = capabilities.GetSupportedFormatProperties(ref guid, out IPortableDeviceKeyCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedFormatProperties));
        return collection.Enumerate<string>(val => val.Name);
    }

    public static IEnumerable<(string, string)> FixedPropertyAttributes(IPortableDeviceCapabilities capabilities, Formats format, PropertyKey key, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        Guid guid = format.GetGuid();
        int err = capabilities.GetFixedPropertyAttributes(ref guid, ref key, out IPortableDeviceValues collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetFixedPropertyAttributes));
        return collection.Enumerate<(string, string)>(val => new (val.KeyName, val.ToString()));
    }

    //public static void Cancel(IPortableDeviceCapabilities capabilities, CancellationToken cancellationToken = default)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    cancellationToken.Register(() => capabilities.Cancel());

    //    int err = capabilities.Cancel();
    //    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
    //}

    public static IEnumerable<Events> SupportedEvents(IPortableDeviceCapabilities capabilities, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());

        int err = capabilities.GetSupportedEvents(out IPortableDevicePropVariantCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
        return collection.Enumerate<Events>(val => val.ToGuid().FindEventsEnum());
    }

    public static IEnumerable<(string,string)> EventOptions(IPortableDeviceCapabilities capabilities, Events ev, CancellationToken cancellationToken = default)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        cancellationToken.Register(() => capabilities.Cancel());
        
        Guid guid = ev.GetGuid();
        int err = capabilities.GetEventOptions(ref guid, out IPortableDeviceValues values);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceCapabilities), nameof(IPortableDeviceCapabilities.GetSupportedEvents));
        return values.Enumerate<(string, string)>(val => new (val.KeyName, val.ToString()));
    }
}
