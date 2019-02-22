using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{

    [Guid("D3BD3A44-D7B5-40A9-98B7-2FA4D01DEC08")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceService
    {
        void Open(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID, 
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

        void Capabilities(
            [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceCapabilities ppCapabilities);

        void Content(
            [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent2 ppContent);

        void Methods(
            [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceMethods ppMethods);

        void Cancel();

        void Close();

        void GetServiceObjectID(
            [MarshalAs(UnmanagedType.LPWStr)] out string ppszServiceObjectID);

        void GetPnPServiceID(
            [MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPServiceID);

        void Advise(
            [In] uint dwFlags, 
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback, 
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

        void Unadvise([In] [MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

        void SendCommand(
            [In] uint dwFlags, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);
    }
}
