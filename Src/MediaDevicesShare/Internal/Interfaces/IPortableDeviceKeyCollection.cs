namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("DADA2357-E0AD-492E-98DB-DD61C53BA353")]
[CLSID("DE2D022D-2480-43BE-97F0-D1FA2CF98F4F")]
internal partial interface IPortableDeviceKeyCollection
{
    [PreserveSig]
    int GetCount(
        ref uint pcElems);

    [PreserveSig]
    int GetAt(
        uint dwIndex,
        ref PropertyKey pKey);

    [PreserveSig]
    int Add(
        ref PropertyKey key);

    [PreserveSig]
    int Clear();

    [PreserveSig]
    int RemoveAt(
        uint dwIndex);
}
