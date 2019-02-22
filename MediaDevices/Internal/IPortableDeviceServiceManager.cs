using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("a8abc4e9-a84a-47a9-80b3-c5d9b172a961")]  
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceServiceManager
    {
        void GetDeviceServices(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In] ref Guid guidServiceCategory,
            //[Out, In, MarshalAs(UnmanagedType.LPWStr)] ref string[] pServices,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)]string[] pServices,
            [Out, In] ref uint pcServices);
        
        void GetDeviceForService(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
        
    }
}
