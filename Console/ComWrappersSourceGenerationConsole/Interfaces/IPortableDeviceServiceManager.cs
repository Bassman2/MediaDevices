namespace ComWrappersSourceGenerationConsole.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("a8abc4e9-a84a-47a9-80b3-c5d9b172a961")]
internal partial interface IPortableDeviceServiceManager
{
    void GetDeviceServices(
        string deviceID,
        ref Guid guidServiceCategory,
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? pServices,
        ref uint pcServices);

    void GetDeviceForService(
        string pszPnPServiceID,
        out string ppszPnPDeviceID);

}
