using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace MediaDevices.Internal
{
    [Guid("6A96ED84-7C73-4480-9938-BF5AF477D426")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPortableDeviceContent
    {
        void EnumObjects(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pFilter,
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppenum);

        void Properties(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceProperties ppProperties);

        void Transfer(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceResources ppResources);

        void CreateObjectWithPropertiesOnly(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

        void CreateObjectWithPropertiesAndData(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pValues,
            [Out, MarshalAs(UnmanagedType.Interface)]out IStream ppData, 
            [In, Out] ref uint pdwOptimalWriteBufferSize, 
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

        void Delete(
            [In] uint dwOptions,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        void GetObjectIDsFromPersistentUniqueIDs(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pPersistentUniqueIDs,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

        void Cancel();

        void Move(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)]string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        void Copy(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)]string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);
    }
}
