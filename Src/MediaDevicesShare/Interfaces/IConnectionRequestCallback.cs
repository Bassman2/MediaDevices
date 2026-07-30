namespace MediaDevices.Internal;


[GeneratedComInterface(Options = ComInterfaceOptions.ComObjectWrapper, StringMarshalling = StringMarshalling.Utf16)]
[Guid("272C9AE0-7161-4AE0-91BD-9F448EE9C427")]
internal partial interface IConnectionRequestCallback
{
    [MethodImpl(MethodImplOptions.InternalCall)]
    void OnComplete([MarshalAs(UnmanagedType.Error)] int hrStatus);
}
