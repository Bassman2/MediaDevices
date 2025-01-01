using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ComWrappersSourceGenerationConsole;

internal class ProgramDemo2
{
    static void Mainx()
    {
        CoCreateInstance(CLSID_WICImagingFactory, 0, CLSCTX_ALL, typeof(IWICImagingFactory).GUID, out var obj);
        var factory = (IWICImagingFactory)obj;
        factory.CreateQueryWriter(GUID_MetadataFormatApp1, 0, out var writer);
    }

    static readonly Guid GUID_MetadataFormatApp1 = new("8fd3dfc3-f951-492b-817f-69c2e6d9a5b0");
    static readonly Guid CLSID_WICImagingFactory = new("cacaf262-9370-4615-a13b-9f5539da4c0a");
    const int CLSCTX_ALL = 23;

    [PreserveSig, DllImport("ole32")]
    public static extern int CoCreateInstance([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid, nint pUnkOuter, int dwClsContext, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

    [ComImport, Guid("ec5ec8a9-c395-4314-9c77-54d7a935ff70"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IWICImagingFactory
    {
        void _VtblGap1_23(); // skip 23 methods we don't need

        [PreserveSig]
        int CreateQueryWriter([MarshalAs(UnmanagedType.LPStruct)] Guid guidMetadataFormat, nint pguidVendor, out IWICMetadataQueryWriter ppIQueryWriter);
    }

    [ComImport, Guid("a721791a-0def-4d06-bd91-2118bf1db10b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public partial interface IWICMetadataQueryWriter
    {
        // undefined yet
    }
}

internal partial class ProgramDemo3
{
    static unsafe void Mainx(string[] args)
    {
        CoCreateInstance(CLSID_WICImagingFactory, 0, CLSCTX_ALL, typeof(IWICImagingFactory).GUID, out var obj);
        var factory = (IWICImagingFactory)obj;
        factory.CreateQueryWriter(GUID_MetadataFormatApp1, Unsafe.NullRef<Guid>(), out var writer);
    }

    static readonly Guid GUID_MetadataFormatApp1 = new("8fd3dfc3-f951-492b-817f-69c2e6d9a5b0");
    static readonly Guid CLSID_WICImagingFactory = new("cacaf262-9370-4615-a13b-9f5539da4c0a");
    const int CLSCTX_ALL = 23;

    [PreserveSig, LibraryImport("ole32")]
    public static partial int CoCreateInstance(in Guid rclsid, nint pUnkOuter, int dwClsContext, in Guid riid, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<object>))] out object ppv);

    [GeneratedComInterface, Guid("ec5ec8a9-c395-4314-9c77-54d7a935ff70")]
    public partial interface IWICImagingFactory
    {
        void _VTblGap1_23(); // skip 23 methods we don't need

        [PreserveSig]
        int CreateQueryWriter(in Guid guidMetadataFormat, in Guid pguidVendor, out IWICMetadataQueryWriter ppIQueryWriter);
    }

    [GeneratedComInterface, Guid("a721791a-0def-4d06-bd91-2118bf1db10b")]
    public partial interface IWICMetadataQueryWriter
    {
    }
}
