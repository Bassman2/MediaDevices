namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("C424233C-AFCE-4828-A756-7ED7A2350083")]
internal partial interface IPortableDeviceServiceMethodCallback
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    void OnComplete(
        [MarshalAs(UnmanagedType.Error)] int hrStatus, 
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pResults);
}
