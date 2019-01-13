using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("7F6D695C-03DF-4439-A809-59266BEEE3A6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceProperties
    {
        void GetSupportedProperties(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        void GetPropertyAttributes(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, 
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        void GetValues(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

        void SetValues(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

        void Delete(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys);

        void Cancel();
    }
}
