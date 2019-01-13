using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("6848F6F2-3155-4F86-B6F5-263EEEAB3143")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceValues
    {
        void GetCount(
             [In] ref uint pcelt);

        void GetAt(
            [In] uint index,
            [In, Out] ref PropertyKey pKey,
            [In, Out] ref PropVariant pValue);

        void SetValue(
            [In] ref PropertyKey key,
            [In] ref PropVariant pValue);

        void GetValue(
            [In] ref PropertyKey key,
            [Out] out PropVariant pValue);

        void SetStringValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Value);

        void GetStringValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pValue);

        void SetUnsignedIntegerValue(
            [In] ref PropertyKey key,
            [In] uint Value);

        void GetUnsignedIntegerValue(
            [In] ref PropertyKey key, 
            [Out] out uint pValue);

        void SetSignedIntegerValue(
            [In] ref PropertyKey key,
            [In] int Value);

        void GetSignedIntegerValue(
            [In] ref PropertyKey key, 
            [Out] out int pValue);

        void SetUnsignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [In] ulong Value);

        void GetUnsignedLargeIntegerValue(
            [In] ref PropertyKey key, 
            [Out] out ulong pValue);

        void SetSignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [In] long Value);

        void GetSignedLargeIntegerValue(
            [In] ref PropertyKey key, 
            [Out] out long pValue);

        void SetFloatValue(
            [In] ref PropertyKey key,
            [In] float Value);

        void GetFloatValue(
            [In] ref PropertyKey key, 
            [Out] out float pValue);

        void SetErrorValue(
            [In] ref PropertyKey key,
            [In] int Value);

        void GetErrorValue(
            [In] ref PropertyKey key, 
            [Out] out int pValue);

        void SetKeyValue(
            [In] ref PropertyKey key,
            [In] ref PropertyKey Value);

        void GetKeyValue(
            [In] ref PropertyKey key, 
            [Out] out PropertyKey pValue);

        void SetBoolValue(
            [In] ref PropertyKey key,
            [In] int Value);

        void GetBoolValue(
            [In] ref PropertyKey key, 
            [Out] out int pValue);

        void SetIUnknownValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pValue);

        void GetIUnknownValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppValue);

        void SetGuidValue(
            [In] ref PropertyKey key,
            [In] ref Guid Value);

        void GetGuidValue(
            [In] ref PropertyKey key, 
            [Out] out Guid pValue);

        void SetBufferValue(
            [In] ref PropertyKey key,
            [In] ref byte pValue,
            [In] uint cbValue);

        void GetBufferValue(
            [In] ref PropertyKey key, 
            [Out] IntPtr ppValue, 
            [Out] out uint pcbValue);

        void SetIPortableDeviceValuesValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValue);

        void GetIPortableDeviceValuesValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValue);

        void SetIPortableDevicePropVariantCollectionValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pValue);

        void GetIPortableDevicePropVariantCollectionValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppValue);

        void SetIPortableDeviceKeyCollectionValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pValue);

        void GetIPortableDeviceKeyCollectionValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppValue);

        void SetIPortableDeviceValuesCollectionValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValuesCollection pValue);

        void GetIPortableDeviceValuesCollectionValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppValue);

        void RemoveValue(
            [In] ref PropertyKey key);

        void CopyValuesFromPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

        void CopyValuesToPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] IPropertyStore pStore);

        void Clear();
    }
}
