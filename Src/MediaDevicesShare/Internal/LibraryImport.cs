namespace MediaDevices.Internal;

internal partial class LibraryImport
{

    [PreserveSig, LibraryImport("ole32")]
    public static partial int CoInitialize(nint reserved);

    [PreserveSig, LibraryImport("ole32")]
    public static partial int CoCreateInstance(in Guid rclsid, nint pUnkOuter, int dwClsContext, in Guid riid, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<object>))] out object ppv);

}
