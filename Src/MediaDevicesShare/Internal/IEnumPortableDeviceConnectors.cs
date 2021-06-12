using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [ComImport]
    [Guid("BFDEF549-9247-454F-BD82-06FE80853FAA")]
    [InterfaceType(1)]
    internal interface IEnumPortableDeviceConnectors
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void Next(
            [In] uint cRequested, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceConnector pConnectors,
            //[In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ref IPortableDeviceConnector[] pPnPDeviceIDs,
            [In, Out] ref uint pcFetched);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Skip(
            [In] uint cConnectors);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Reset();

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Clone(
            [MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceConnectors ppEnum);
    }
}
