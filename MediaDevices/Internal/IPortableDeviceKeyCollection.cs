using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("DADA2357-E0AD-492E-98DB-DD61C53BA353")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceKeyCollection
    {
        void GetCount(
            [In] ref uint pcElems);

        void GetAt(
            [In] uint dwIndex,
            [In] ref PropertyKey pKey);

        void Add(
            [In] ref PropertyKey key);

        void Clear();

        void RemoveAt(
            [In] uint dwIndex);
    }
}
