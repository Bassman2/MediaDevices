using System;
using System.Runtime.InteropServices;

namespace MediaDevices.WMDM
{
    [ComImport]
    [Guid("af185c41-100d-46ed-be2e-9ce8c44594ef")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IWMDeviceManager3 // : IWMDeviceManager2 // derive from IWMDeviceManager2 does not work and cause in an exception
    {
        //[MethodImpl(MethodImplOptions.InternalCall)]
        void GetRevision([Out] out uint pdwRevision);

        //[MethodImpl(MethodImplOptions.InternalCall)]
        void GetDeviceCount([Out] out uint pdwCount);

        ///[MethodImpl(MethodImplOptions.InternalCall)]
        void EnumDevices(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);

        void GetDeviceFromCanonicalName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCanonicalName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMDevice ppDevice);

        void EnumDevices2(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);

        void Reinitialize();

        void SetDeviceEnumPreference(
            [In] uint dwEnumPref);
    }
}
