using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{


    [Guid("272C9AE0-7161-4AE0-91BD-9F448EE9C427")]
    [InterfaceType(1)]
    internal interface IConnectionRequestCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void OnComplete([In] [MarshalAs(UnmanagedType.Error)] int hrStatus);
    }
}
