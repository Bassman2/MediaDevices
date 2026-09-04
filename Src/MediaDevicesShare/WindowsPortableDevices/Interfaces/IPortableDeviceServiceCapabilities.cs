namespace MediaDevices.WindowsPortableDevices;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("24DBD89D-413E-43E0-BD5B-197F3C56C886")]
internal partial interface IPortableDeviceServiceCapabilities
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetSupportedMethods(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetSupportedMethodsByFormat(
        ref Guid Format, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetMethodAttributes(
        ref Guid Method, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetMethodParameterAttributes(
        ref Guid Method, 
        ref PropertyKey Parameter, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetSupportedFormats(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetFormatAttributes(
        ref Guid Format, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetSupportedFormatProperties(
        ref Guid Format,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetFormatPropertyAttributes(
        ref Guid Format,
        ref PropertyKey Property, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetSupportedEvents(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetEventAttributes(
        ref Guid Event, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetEventParameterAttributes(
        ref Guid Event, 
        ref PropertyKey Parameter,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetInheritedServices(
        uint dwInheritanceType, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppServices);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetFormatRenderingProfiles(
        ref Guid Format, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppRenderingProfiles);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetSupportedCommands(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int GetCommandOptions(
        ref PropertyKey Command, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int Cancel();
}
