using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [ComImport, Guid("A8792A31-F385-493C-A893-40F64EB45F6E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceEventCallback
    {
        void OnEvent(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pEventParameters);
    }
}
