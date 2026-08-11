namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("FD8878AC-D841-4D17-891C-E6829CDB6934")]
internal partial interface IPortableDeviceResources
{
    [PreserveSig]
    int GetSupportedResources(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

    [PreserveSig]
    int GetResourceAttributes(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, 
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResourceAttributes);

    [PreserveSig]
    int GetStream(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, 
        ref PropertyKey key, 
        uint dwMode, 
        ref uint pdwOptimalBufferSize,

        // TODO Test  https://github.com/dotnet/runtime/issues/100645
        //[MarshalAs(UnmanagedType.Interface)] out /*IStream*/ object ppStream);
        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] out IStream ppStream);

    [PreserveSig]
    int Delete(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys);

    [PreserveSig]
    int Cancel();

    [PreserveSig]
    int CreateResource(
        [MarshalAs(UnmanagedType.Interface)]IPortableDeviceValues pResourceAttributes,
        [MarshalAs(UnmanagedType.Interface)] out IStream ppData,
        ref uint pdwOptimalWriteBufferSize,
        [MarshalAs(UnmanagedType.LPWStr)]ref string ppszCookie);
}
