using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("89B2E422-4F1B-4316-BCEF-A44AFEA83EB3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDevicePropVariantCollection
    {
        void GetCount(
            [In] ref uint pcElems);

        void GetAt(
            [In] uint dwIndex, 
            [In] ref PropVariant pValue);

        void Add(
            [In] ref PropVariant pValue);

        void GetType(
            [Out] out ushort pvt);

        void ChangeType(
            [In] ushort vt);
         
        void Clear();

        void RemoveAt(
            [In] uint dwIndex);
    }
}
