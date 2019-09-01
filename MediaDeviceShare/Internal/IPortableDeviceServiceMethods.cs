using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.Internal
{

    [Guid("E20333C9-FD34-412D-A381-CC6F2D820DF7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceServiceMethods
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Invoke([In] ref Guid Method, [In] [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, [In] [Out] [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void InvokeAsync([In] ref Guid Method, [In] [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, [In] [MarshalAs(UnmanagedType.Interface)] IPortableDeviceServiceMethodCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Cancel([In] [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);
    }
}
