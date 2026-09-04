namespace MediaDevices.WindowsPortableDevices;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
internal partial interface IPortableDeviceConnector
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    void Connect([MarshalAs(UnmanagedType.Interface)] IConnectionRequestCallback pCallback);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void Disconnect([MarshalAs(UnmanagedType.Interface)] IConnectionRequestCallback pCallback);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void Cancel([MarshalAs(UnmanagedType.Interface)] IConnectionRequestCallback pCallback);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void GetProperty(ref PropertyKey pPropertyKey, out uint pPropertyType, IntPtr ppData, out uint pcbData);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void SetProperty(ref PropertyKey pPropertyKey, uint PropertyType, ref byte pData, uint cbData);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void GetPnPID([MarshalAs(UnmanagedType.LPWStr)] out string ppwszPnPID);
}
