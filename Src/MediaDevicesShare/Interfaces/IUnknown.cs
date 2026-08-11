namespace MediaDevices.Interfaces;

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("00000000-0000-0000-C000-000000000046")]
internal partial interface IUnknown
{
    [PreserveSig]
    int QueryInterface(ref Guid riid, nint ppvObject);

    [PreserveSig]
    uint AddRef();

    [PreserveSig]
    uint Release();
}

