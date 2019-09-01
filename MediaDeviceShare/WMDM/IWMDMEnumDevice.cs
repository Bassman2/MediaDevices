using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.WMDM
{
    [Guid("1DCB3A01-33ED-11d3-8470-00C04F79DBC0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IWMDMEnumDevice
    {
        void Next(
            [In]  uint celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMDevice ppDevice,
            [Out] out uint pceltFetched);
        
        void Skip(
            [In] uint celt,
            [Out] out uint pceltFetched);
        
        void Reset();
        
        void Clone([Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);
    }
}
