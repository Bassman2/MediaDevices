//namespace ComWrappersSourceGenerationConsole.Interfaces;

//[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
//[Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C")]
//internal partial interface IPortableDevice
//{
//    void Open(
//        string deviceID,
//        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pClientInfo);

//    void SendCommand(
//        uint dwFlags,
//        [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pParameters,
//        [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

//    void Content(
//        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

//    void Capabilities(
//        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

//    void Cancel();

//    void Close();

//    void Advise(
//        [In] uint dwFlags,
//        [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceEventCallback pCallback,
//        [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues? pParameters,
//        [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

//    void Unadvise(
//        [In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

//    void GetPnPDeviceID(
//        [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
//}
