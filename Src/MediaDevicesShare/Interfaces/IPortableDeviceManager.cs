namespace MediaDevices.Internal;

// https://learn.microsoft.com/en-us/dotnet/standard/native-interop/comwrappers-source-generation
// https://www.youtube.com/watch?v=DZd1SGd7dSU
// https://stackoverflow.com/questions/78356359/net-8-com-class-using-generatedcominterfaceattribute-not-visible-to-vb6-vba-or
// https://stackoverflow.com/questions/79118576/how-to-rewrite-the-windows-app-sdk-widgetprovider-registration-code-using-comwra

// [LibraryImport]

[GeneratedComInterface(/*Options = ComInterfaceOptions.ComObjectWrapper, */StringMarshalling = StringMarshalling.Utf16)]
[Guid("A1567595-4C2F-4574-A6FA-ECEF917B9A40")]
internal partial interface IPortableDeviceManager
{
    [PreserveSig]
    int GetDevices(
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? deviceIDs,
        ref int deviceIDsSize);

    [PreserveSig]
    int RefreshDeviceList();

    [PreserveSig]
    int GetDeviceFriendlyName(
        string deviceID,
        nint deviceFriendlyName,
        ref int deviceFriendlyNameSize);

    [PreserveSig]
    int GetDeviceDescription(
        string deviceID,
        nint deviceDescription,
        ref int deviceDescriptionSize);

    [PreserveSig]
    int GetDeviceManufacturer(
        string deviceID,
        nint deviceManufacturer,
        ref int deviceManufacturerSize);

    [PreserveSig]
    int GetDeviceProperty(
        string deviceID,
        string devicePropertyName,
        ref byte data,
        ref uint dataSize,
        ref uint dataType);

    [PreserveSig]
    int GetPrivateDevices(
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[]? deviceIDs,
        ref int deviceIDsSize);

}
