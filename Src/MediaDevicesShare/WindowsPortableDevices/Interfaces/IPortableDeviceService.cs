namespace MediaDevices.WindowsPortableDevices;


[Guid("D3BD3A44-D7B5-40A9-98B7-2FA4D01DEC08")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[CLSID("EF5DB4C2-9312-422C-9152-411CD9C4DD84")]
internal interface IPortableDeviceService
{
    [PreserveSig]
    int Open(
        [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID, 
        [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

    [PreserveSig]
    int Capabilities(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceCapabilities ppCapabilities);

    [PreserveSig]
    int Content(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent2 ppContent);

    [PreserveSig]
    int Methods(
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceMethods ppMethods);

    [PreserveSig]
    int Cancel();

    [PreserveSig]
    int Close();

    [PreserveSig]
    int GetServiceObjectID(
        [MarshalAs(UnmanagedType.LPWStr)] out string ppszServiceObjectID);

    [PreserveSig]
    int GetPnPServiceID(
        [MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPServiceID);

    [PreserveSig]
    int Advise(
        [In] uint dwFlags, 
        [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback, 
        [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters,
        [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

    [PreserveSig]
    int Unadvise([In] [MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

    [PreserveSig]
    int SendCommand(
        [In] uint dwFlags, 
        [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, 
        [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);
}
