namespace MediaDevices.WindowsPortableDevices;


/*
If your code can access the generated class: 
using MediaDevices.Internal; IPortableDeviceValues values = (IPortableDeviceValues)new PortableDeviceValues();
If the class is not visible, create by CLSID (requires the COM class to be registered on Windows): 
IPortableDeviceValues values = (IPortableDeviceValues)Activator.CreateInstance( Type.GetTypeFromCLSID(new Guid("0C15D503-D017-47CE-9016-7B3F978721CC"))); * 
*/

//[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("6848F6F2-3155-4F86-B6F5-263EEEAB3143")]
[CLSID("0C15D503-D017-47CE-9016-7B3F978721CC")]
internal partial interface IPortableDeviceValues
{
    [PreserveSig]
    int GetCount(
         ref uint pcelt);

    [PreserveSig]
    int GetAt(
        uint index,
        ref PropertyKey pKey,
        ref PropVariant pValue);

    [PreserveSig]
    int SetValue(
        ref PropertyKey key,
        ref PropVariant pValue);

    [PreserveSig]
    int GetValue(
        ref PropertyKey key,
        out PropVariant pValue);

    [PreserveSig]
    int SetStringValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.LPWStr)] string Value);

    [PreserveSig]
    int GetStringValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.LPWStr)] out string pValue);

    [PreserveSig]
    int SetUnsignedIntegerValue(
        ref PropertyKey key,
        uint Value);

    [PreserveSig]
    int GetUnsignedIntegerValue(
        ref PropertyKey key,
        out uint pValue);

    [PreserveSig]
    int SetSignedIntegerValue(
        ref PropertyKey key,
        int Value);

    [PreserveSig]
    int GetSignedIntegerValue(
        ref PropertyKey key,
        out int pValue);

    [PreserveSig]
    int SetUnsignedLargeIntegerValue(
        ref PropertyKey key,
        ulong Value);

    [PreserveSig]
    int GetUnsignedLargeIntegerValue(
        ref PropertyKey key,
        out ulong pValue);

    [PreserveSig]
    int SetSignedLargeIntegerValue(
        ref PropertyKey key,
        long Value);

    [PreserveSig]
    int GetSignedLargeIntegerValue(
        ref PropertyKey key,
        out long pValue);

    [PreserveSig]
    int SetFloatValue(
        ref PropertyKey key,
        float Value);

    [PreserveSig]
    int GetFloatValue(
        ref PropertyKey key,
        out float pValue);

    [PreserveSig]
    int SetErrorValue(
        ref PropertyKey key,
        int Value);

    [PreserveSig]
    int GetErrorValue(
        ref PropertyKey key,
        out int pValue);

    [PreserveSig]
    int SetKeyValue(
        ref PropertyKey key,
        ref PropertyKey Value);

    [PreserveSig]
    int GetKeyValue(
        ref PropertyKey key,
        out PropertyKey pValue);

    [PreserveSig]
    int SetBoolValue(
        ref PropertyKey key,
        int Value);

    [PreserveSig]
    int GetBoolValue(
        ref PropertyKey key,
        out int pValue);

    [PreserveSig]
    int SetIUnknownValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] 
        object? pValue);

    [PreserveSig]
    int GetIUnknownValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] 
        out object? ppValue);

    [PreserveSig]
    int SetGuidValue(
        ref PropertyKey key,
        ref Guid Value);

    [PreserveSig]
    int GetGuidValue(
        ref PropertyKey key,
        out Guid pValue);

    [PreserveSig]
    int SetBufferValue(
        ref PropertyKey key,
        ref byte pValue,
        uint cbValue);

    [PreserveSig]
    int GetBufferValue(
        ref PropertyKey key,
        IntPtr ppValue,
        out uint pcbValue);

    [PreserveSig]
    int SetIPortableDeviceValuesValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValue);

    [PreserveSig]
    int GetIPortableDeviceValuesValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValue);

    [PreserveSig]
    int SetIPortableDevicePropVariantCollectionValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pValue);

    [PreserveSig]
    int GetIPortableDevicePropVariantCollectionValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppValue);

    [PreserveSig]
    int SetIPortableDeviceKeyCollectionValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pValue);

    [PreserveSig]
    int GetIPortableDeviceKeyCollectionValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppValue);

    [PreserveSig]
    int SetIPortableDeviceValuesCollectionValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValuesCollection pValue);

    [PreserveSig]
    int GetIPortableDeviceValuesCollectionValue(
        ref PropertyKey key,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppValue);

    [PreserveSig]
    int RemoveValue(
        ref PropertyKey key);

    [PreserveSig]
    int CopyValuesFromPropertyStore(
        [MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

    [PreserveSig]
    int CopyValuesToPropertyStore(
        [MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

    [PreserveSig]
    int Clear();
}
