namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
internal partial interface IPropertyStore
{
    [PreserveSig]
    int GetCount(
        out uint cProps);

    [PreserveSig]
    int GetAt(
        uint iProp, 
        out PropertyKey pKey);

    [PreserveSig]
    int GetValue(
        ref PropertyKey key, 
        out PropVariant pv);

    [PreserveSig]
    int SetValue(
        ref PropertyKey key,
        ref PropVariant propvar);

    [PreserveSig]
    int Commit();
}
