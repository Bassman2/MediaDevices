namespace MediaDevices.Internal;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("10ECE955-CF41-4728-BFA0-41EEDF1BBF19")]
internal partial interface IEnumPortableDeviceObjectIDs
{
    [PreserveSig]
    int Next(
        uint cObjects,
        [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] 
        string[] pObjIDs,
        ref uint pcFetched);

    [PreserveSig]
    int Skip(
        uint cObjects);

    [PreserveSig]
    int Reset();

    [PreserveSig]
    int Clone(
        [MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppenum);

    [PreserveSig]
    int Cancel();
}
