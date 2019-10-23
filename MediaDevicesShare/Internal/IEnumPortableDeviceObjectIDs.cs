using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("10ECE955-CF41-4728-BFA0-41EEDF1BBF19")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IEnumPortableDeviceObjectIDs
    {
        void Next(
            [In] uint cObjects,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pObjIDs,
            [In, Out]ref uint pcFetched);

        void Skip(
            [In] uint cObjects);

        void Reset();

        void Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppenum);

        void Cancel();
    }
}
