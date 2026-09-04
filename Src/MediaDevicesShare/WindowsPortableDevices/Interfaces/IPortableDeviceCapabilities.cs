namespace MediaDevices.WindowsPortableDevices;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("2C8C6DBF-E3DC-4061-BECC-8542E810D126")]
internal partial interface IPortableDeviceCapabilities
{
    [PreserveSig]
    int GetSupportedCommands(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

    [PreserveSig]
    int GetCommandOptions(
        ref PropertyKey Command,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

    [PreserveSig]
    int GetFunctionalCategories(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppCategories);

    [PreserveSig]
    int GetFunctionalObjects(
        ref Guid Category,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

    [PreserveSig]
    int GetSupportedContentTypes(
        ref Guid Category,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppContentTypes);

    [PreserveSig]
    int GetSupportedFormats(
        ref Guid ContentType,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

    [PreserveSig]
    int GetSupportedFormatProperties(
        ref Guid Format,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

    [PreserveSig]
    int GetFixedPropertyAttributes(
        ref Guid Format,
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [PreserveSig]
    int Cancel();

    [PreserveSig]
    int GetSupportedEvents(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

    [PreserveSig]
    int GetEventOptions(
        ref Guid Event,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);
}
