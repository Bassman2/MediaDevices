using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("C424233C-AFCE-4828-A756-7ED7A2350083")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceServiceMethodCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnComplete(
            [In, MarshalAs(UnmanagedType.Error)] int hrStatus, 
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pResults);
    }
}
