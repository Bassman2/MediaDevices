namespace MediaDevices.WindowsPortableDevices;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("6A96ED84-7C73-4480-9938-BF5AF477D426")]
internal partial interface IPortableDeviceContent
{
    [PreserveSig]
    int EnumObjects(
        uint dwFlags,
        [MarshalAs(UnmanagedType.LPWStr)] string? pszParentObjectID,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues? pFilter,
        [MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppenum);

    [PreserveSig]
    int Properties(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceProperties ppProperties);

    [PreserveSig]
    int Transfer(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceResources ppResources);

    [PreserveSig]
    int CreateObjectWithPropertiesOnly(
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues,
        [MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

    [PreserveSig]
    int CreateObjectWithPropertiesAndData(
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues,
        //[MarshalAs(UnmanagedType.Interface)] out IStream ppData
        // UniqueComInterfaceMarshaller allows for the manual release of the COM object with ComObject.FinalRelease();.
        // Fix #417 See https://github.com/dotnet/runtime/issues/100645
        [MarshalUsing(typeof(UniqueComInterfaceMarshaller<IStream>))] out IStream ppData,
        ref uint pdwOptimalWriteBufferSize,
        [MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

    [PreserveSig]
    int Delete(
        uint dwOptions,
        [MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs,
        [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

    [PreserveSig]
    int GetObjectIDsFromPersistentUniqueIDs(
        [MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pPersistentUniqueIDs,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

    [PreserveSig]
    int Cancel();

    [PreserveSig]
    int Move(
        [MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs,
        [MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
        [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

    [PreserveSig]
    int Copy(
        [MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs,
        [MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
        [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);
}
