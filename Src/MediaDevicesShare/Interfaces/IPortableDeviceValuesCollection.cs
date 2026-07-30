namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("6E3F2D79-4E07-48C4-8208-D8C2E5AF4A99")]
internal partial interface IPortableDeviceValuesCollection
{
    [PreserveSig]
    int GetCount(
        ref uint pcElems);

    [PreserveSig]
    int GetAt(
        uint dwIndex,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

    [PreserveSig]
    int Add(
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues);

    [PreserveSig]
    int Clear();

    [PreserveSig]
    int RemoveAt(
        uint dwIndex);
}