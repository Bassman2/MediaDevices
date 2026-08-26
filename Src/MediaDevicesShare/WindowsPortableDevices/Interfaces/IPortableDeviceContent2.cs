namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("9B4ADD96-F6BF-4034-8708-ECA72BF10554")]
internal partial interface IPortableDeviceContent2 : IPortableDeviceContent
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    void UpdateObjectWithPropertiesAndData(
        [MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
        [MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pProperties, 
        [MarshalAs(UnmanagedType.Interface)] out IStream ppData,  
        ref uint pdwOptimalWriteBufferSize);
}
