using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("6A96ED84-7C73-4480-9938-BF5AF477D426")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceServiceManager
    {
        void GetDeviceServices(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In] ref Guid guidServiceCategory,
            [Out, In, MarshalAs(UnmanagedType.LPWStr)] string[] pServices,
            [Out, In] ref uint pcServices);
        
        void GetDeviceForService(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID,
            [Out, MarshalAs(UnmanagedType.LPWStr)] string ppszPnPDeviceID);
        
    }
}
