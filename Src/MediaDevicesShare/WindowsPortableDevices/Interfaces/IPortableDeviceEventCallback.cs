namespace MediaDevices.Internal;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("A8792A31-F385-493C-A893-40F64EB45F6E")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal partial interface IPortableDeviceEventCallback
{
    void OnEvent(
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pEventParameters);
}
