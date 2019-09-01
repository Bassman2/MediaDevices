using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPropertyStore
    {
        void GetCount(
            [Out] out uint cProps);

        void GetAt(
            [In] uint iProp, 
            [Out] out PropertyKey pKey);

        void GetValue(
            [In] ref PropertyKey key, 
            [Out] out PropVariant pv);

        void SetValue(
            [In] ref PropertyKey key,
            [In] ref PropVariant propvar);

        void Commit();
    }
}
