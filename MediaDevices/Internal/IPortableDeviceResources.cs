using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace MediaDevices.Internal
{
    [Guid("FD8878AC-D841-4D17-891C-E6829CDB6934")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceResources
    {
        void GetSupportedResources(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        void GetResourceAttributes(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, 
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResourceAttributes);

        void GetStream(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, 
            [In] ref PropertyKey key, 
            [In] uint dwMode, 
            [In, Out] ref uint pdwOptimalBufferSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppStream);

        void Delete(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection pKeys);

        void Cancel();

        void CreateResource(
            [In, MarshalAs(UnmanagedType.Interface)]IPortableDeviceValues pResourceAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out IStream ppData,
            [In, Out]ref uint pdwOptimalWriteBufferSize,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)]ref string ppszCookie);
    }
}
