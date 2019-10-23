using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MediaDevices.Internal
{
    [Guid("A1567595-4C2F-4574-A6FA-ECEF917B9A40")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceManager
    {
        void GetDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);

        void RefreshDeviceList();

        void GetDeviceFriendlyName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName,
            [In, Out] ref uint pcchDeviceFriendlyName);

        void GetDeviceDescription(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, 
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceDescription,
            [In, Out] ref uint pcchDeviceDescription);

        void GetDeviceManufacturer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer,
            [In, Out]ref uint pcchDeviceManufacturer);

        void GetDeviceProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName,
            [In, Out] ref byte pData,
            [In, Out] ref uint pcbData,
            [In, Out] ref uint pdwType);

        void GetPrivateDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)]string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);
    }
}
