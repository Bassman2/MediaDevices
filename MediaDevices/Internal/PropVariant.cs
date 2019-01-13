using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    // https://docs.microsoft.com/de-de/windows/desktop/api/propidl/ns-propidl-tagpropvariant
    // https://referencesource.microsoft.com/#PresentationCore/Core/CSharp/System/Windows/Media/Imaging/PropVariant.cs
    // https://social.msdn.microsoft.com/Forums/vstudio/en-US/e6bff306-c357-4e8c-91e7-d93306209e99/partial-implementation-of-a-managed-propvariant-class-that-works-well-with-unmanaged-apis-using?forum=clr

    [StructLayout(LayoutKind.Explicit)]
    internal struct PropVariant
    {
        [FieldOffset(0)]
        public PropVariantType vt;

        // inner data
        
        [ComConversionLoss]
        [FieldOffset(8)]
        public IntPtr ptrVal;

        [FieldOffset(8)]
        public PropVariantData dataVal;

        [FieldOffset(8)]
        public int intVal;

        [FieldOffset(8)]
        public uint uintVal;

        [FieldOffset(8)]
        public ulong ulongVal;

        [FieldOffset(8)]
        public short boolVal;

        [FieldOffset(8)]
        public double dateVal;

        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.Error)]
        public int errorCode;
    }
}
