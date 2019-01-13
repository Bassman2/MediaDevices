using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [Guid("2C8C6DBF-E3DC-4061-BECC-8542E810D126")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceCapabilities
    {
        void GetSupportedCommands(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

        void GetCommandOptions(
            [In] ref PropertyKey Command,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

        void GetFunctionalCategories(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppCategories);

        void GetFunctionalObjects(
            [In] ref Guid Category,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

        void GetSupportedContentTypes(
            [In] ref Guid Category,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppContentTypes);

        void GetSupportedFormats(
            [In] ref Guid ContentType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

        void GetSupportedFormatProperties(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        void GetFixedPropertyAttributes(
            [In] ref Guid Format,
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        void Cancel();

        void GetSupportedEvents(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

        void GetEventOptions(
            [In] ref Guid Event,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);
    }
}
