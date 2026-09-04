namespace MediaDevices.WindowsPortableDevices;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
[CLSID("728A21C5-3D9E-48D7-9810-864848F0F404")]
internal partial interface IPortableDevice
{
    [PreserveSig]
    int Open(
        string deviceID,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

    [PreserveSig]
    int SendCommand(
        uint dwFlags,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters,
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

    [PreserveSig]
    int Content(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);
    
    [PreserveSig]
    int Capabilities(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

    [PreserveSig]
    int Cancel();

    [PreserveSig]
    int Close();

    [PreserveSig]
    int Advise(
        uint dwFlags,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues? pParameters,
        [MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

    [PreserveSig]
    int Unadvise(
        [MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

    [PreserveSig]
    int GetPnPDeviceID(
        [MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
}
