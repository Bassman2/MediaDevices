using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MediaDevices.WMDM
{

    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17763.0\um\mswmdm.h


    [ComImport]
    [Guid("1DCB3A00-33ED-11d3-8470-00C04F79DBC0")]    
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IWMDeviceManager
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetRevision([Out] out uint pdwRevision);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetDeviceCount([Out] out uint pdwCount);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void EnumDevices([Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);
    }
}
