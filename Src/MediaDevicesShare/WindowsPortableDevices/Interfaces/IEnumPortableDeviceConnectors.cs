namespace MediaDevices.WindowsPortableDevices;

[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("BFDEF549-9247-454F-BD82-06FE80853FAA")]
internal partial interface IEnumPortableDeviceConnectors
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    void Next(
        uint cRequested, 
        [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceConnector pConnectors,
        //[In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ref IPortableDeviceConnector[] pPnPDeviceIDs,
        ref uint pcFetched);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void Skip(
        uint cConnectors);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void Reset();

    [MethodImpl(MethodImplOptions.InternalCall)]
    void Clone(
        [MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceConnectors ppEnum);
}
