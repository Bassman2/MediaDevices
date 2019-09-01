using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{

    [Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
    [InterfaceType(1)]
    [ComConversionLoss]
    internal interface IPortableDeviceConnector
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Connect([In] [MarshalAs(UnmanagedType.Interface)] IConnectionRequestCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Disconnect([In] [MarshalAs(UnmanagedType.Interface)] IConnectionRequestCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Cancel([In] [MarshalAs(UnmanagedType.Interface)] IConnectionRequestCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetProperty([In] ref PropertyKey pPropertyKey, out uint pPropertyType, [Out] IntPtr ppData, out uint pcbData);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void SetProperty([In] ref PropertyKey pPropertyKey, [In] uint PropertyType, [In] ref byte pData, [In] uint cbData);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetPnPID([MarshalAs(UnmanagedType.LPWStr)] out string ppwszPnPID);
    }
}
