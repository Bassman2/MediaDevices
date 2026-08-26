namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("E20333C9-FD34-412D-A381-CC6F2D820DF7")]
internal partial interface IPortableDeviceServiceMethods
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int Invoke(
        ref Guid Method, 
        [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, 
        [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int InvokeAsync(
        ref Guid Method, 
        [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, 
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceServiceMethodCallback pCallback);

    [MethodImpl(MethodImplOptions.InternalCall)]
    [PreserveSig]
    int Cancel(
        [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);
}
