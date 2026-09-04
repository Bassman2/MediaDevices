namespace MediaDevices.WindowsPortableDevices;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("89B2E422-4F1B-4316-BCEF-A44AFEA83EB3")]
[CLSID("08A99E2F-6D6D-4B80-AF5A-BAF2BCBE4CB9")]
internal partial interface IPortableDevicePropVariantCollection
{
    [PreserveSig]
    int GetCount(
        ref uint pcElems);

    [PreserveSig]
    int GetAt(
        uint dwIndex, 
        ref PropVariant pValue);

    [PreserveSig]
    int Add(
        ref PropVariant pValue);

    [PreserveSig]
    int GetType(
        out ushort pvt);

    [PreserveSig]
    int ChangeType(
        ushort vt);

    [PreserveSig]
    int Clear();

    [PreserveSig]
    int RemoveAt(
        uint dwIndex);
}
