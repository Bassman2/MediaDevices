using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDevice
    {
        void Open(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

        void SendCommand(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

        void Content(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

        void Capabilities(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

        void Cancel();

        void Close();

        void Advise(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

        void Unadvise(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

        void GetPnPDeviceID(
            [Out, MarshalAs(UnmanagedType.LPWStr)]out string ppszPnPDeviceID);
    }
}
