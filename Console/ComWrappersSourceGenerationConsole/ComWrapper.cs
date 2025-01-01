using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

//[assembly: DisableRuntimeMarshalling]

namespace ComWrappersSourceGenerationConsole;

// https://learn.microsoft.com/en-us/dotnet/standard/native-interop/comwrappers-source-generation
// https://www.youtube.com/watch?v=DZd1SGd7dSU
// https://stackoverflow.com/questions/78356359/net-8-com-class-using-generatedcominterfaceattribute-not-visible-to-vb6-vba-or
// https://stackoverflow.com/questions/79118576/how-to-rewrite-the-windows-app-sdk-widgetprovider-registration-code-using-comwra

[GeneratedComClass]
//[ComImport] 
[Guid("0AF10CEC-2ECD-4B92-9581-34F6AE0637F3")]
internal partial class PortableDeviceManager //: IPortableDeviceManager
{ }

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("A1567595-4C2F-4574-A6FA-ECEF917B9A40")]
//[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal partial interface IPortableDeviceManager
{
    void GetDevices(
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? pPnPDeviceIDs,
        ref uint pcPnPDeviceIDs);

    void RefreshDeviceList();

    //void GetDeviceFriendlyName(
    //    [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
    //    [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName,
    //    [In, Out] ref uint pcchDeviceFriendlyName);

    void GetDeviceDescription(
        string pszPnPDeviceID,
        ref StringBuilder pDeviceDescription,
        ref uint pcchDeviceDescription);

    //void GetDeviceManufacturer(
    //    [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
    //    [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer,
    //    [In, Out] ref uint pcchDeviceManufacturer);

    //void GetDeviceProperty(
    //    [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
    //    [In, MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName,
    //    [In, Out] ref byte pData,
    //    [In, Out] ref uint pcbData,
    //    [In, Out] ref uint pdwType);

    //void GetPrivateDevices(
    //    [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? pPnPDeviceIDs,
    //    [In, Out] ref uint pcPnPDeviceIDs);
}

//[Guid("a8abc4e9-a84a-47a9-80b3-c5d9b172a961")]
//[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
//internal interface IPortableDeviceServiceManager
//{
//    void GetDeviceServices(
//        [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
//        [In] ref Guid guidServiceCategory,
//        //[Out, In, MarshalAs(UnmanagedType.LPWStr)] ref string[] pServices,
//        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? pServices,
//        [Out, In] ref uint pcServices);

//    void GetDeviceForService(
//        [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID,
//        [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);

//}