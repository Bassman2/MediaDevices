using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [ComImport]
    [Guid("24DBD89D-413E-43E0-BD5B-197F3C56C886")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceServiceCapabilities
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetSupportedMethods([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetSupportedMethodsByFormat([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetMethodAttributes([In] ref Guid Method, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetMethodParameterAttributes([In] ref Guid Method, [In] ref PropertyKey Parameter, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetSupportedFormats([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetFormatAttributes([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetSupportedFormatProperties([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetFormatPropertyAttributes([In] ref Guid Format, [In] ref PropertyKey Property, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetSupportedEvents([MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetEventAttributes([In] ref Guid Event, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetEventParameterAttributes([In] ref Guid Event, [In] ref PropertyKey Parameter, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetInheritedServices([In] uint dwInheritanceType, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppServices);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetFormatRenderingProfiles([In] ref Guid Format, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppRenderingProfiles);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetSupportedCommands([MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void GetCommandOptions([In] ref PropertyKey Command, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

        [MethodImpl(MethodImplOptions.InternalCall)]
        void Cancel();
    }

}
