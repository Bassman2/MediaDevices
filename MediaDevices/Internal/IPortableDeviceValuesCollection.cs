using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("6E3F2D79-4E07-48C4-8208-D8C2E5AF4A99")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceValuesCollection
    {
        void GetCount(
            [In] ref uint pcElems);

        void GetAt(
            [In] uint dwIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

        void Add(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues);

        void Clear();

        void RemoveAt(
            [In] uint dwIndex);
    }
}
