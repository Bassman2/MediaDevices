namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("7F6D695C-03DF-4439-A809-59266BEEE3A6")]
internal partial interface IPortableDeviceProperties
{
    [PreserveSig]
    int GetSupportedProperties(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

    [PreserveSig]
    int GetPropertyAttributes(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, 
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

    [PreserveSig]
    int GetValues(
        //[MarshalAs(UnmanagedType.LPWStr)] 
        string pszObjectID,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection? pKeys,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

    [PreserveSig]
    int SetValues(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

    [PreserveSig]
    int Delete(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys);

    [PreserveSig]
    int Cancel();
}
