using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using TPROPVARIANT = PortableDeviceTypesLib.tag_inner_PROPVARIANT;

namespace MediaDevices
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    internal struct PropVariant : IDisposable
    {
        [FieldOffset(0)]
        public short variantType;
        [FieldOffset(8)]
        public IntPtr pointerValue;
        [FieldOffset(8)]
        public byte byteValue;
        [FieldOffset(8)]
        public long intValue;
        [FieldOffset(8)]
        public long longValue;
        [FieldOffset(8)]
        public double dateValue;
        [FieldOffset(8)]
        public short boolValue;

        public const int VT_I2 = 2;
        public const int VT_I4 = 3;
        public const int VT_DATE = 7;
        public const int VT_ERROR = 10;
        public const int VT_BOOL = 11;
        public const int VT_UNKNOWN = 13;
        public const int VT_I1 = 16;
        public const int VT_UI1 = 17;
        public const int VT_UI2 = 18;
        public const int VT_UI4 = 19;
        public const int VT_I8 = 20;
        public const int VT_UI8 = 21;
        public const int VT_LPWSTR = 31;
        public const int VT_CLSID = 72;

        public const int VT_VECTOR = 0x1000;

        public static PropVariant FromValue(PROPVARIANT value)
        {
            IntPtr ptrValue = Marshal.AllocHGlobal(Marshal.SizeOf(value));
            Marshal.StructureToPtr(value, ptrValue, false);

            //
            // Marshal the pointer into our C# object
            //
            return (PropVariant)Marshal.PtrToStructure(ptrValue, typeof(PropVariant));
        }

        public override string ToString()
        {
            switch (variantType)
            {
            case VT_LPWSTR:
                return Marshal.PtrToStringUni(pointerValue);

            case VT_CLSID:
                return ToGuid().ToString();

            case VT_DATE:
                return ToDate().ToString();

            case VT_BOOL:
                return ToBool().ToString();

            case VT_UI4:
                return intValue.ToString();

            case VT_UI8:
                return longValue.ToString();

            case VT_ERROR:
                string name = Enum.GetName(typeof(HResult), longValue) ?? longValue.ToString("X");
                return $"Error: {name}";
            }

            return $"Unknown type {variantType}";
        }

        public Guid ToGuid()
        {
            return (Guid)Marshal.PtrToStructure(pointerValue, typeof(Guid));
        }

        public DateTime ToDate()
        {
            return DateTime.FromOADate(dateValue);
        }

        public bool ToBool()
        {
            return Convert.ToBoolean(boolValue);
        }

        public int ToInt()
        {
            return (int)this.intValue;
        }

        public static PROPVARIANT StringToPropVariant(string value)
        {
            // Tried using the method suggested here:
            // http://blogs.msdn.com/b/dimeby8/archive/2007/01/08/creating-wpd-propvariants-in-c-without-using-interop.aspx
            // However, the GetValue fails (Element Not Found) even though we've just added it.
            // So, I use the alternative (and I think more "correct") approach below.

            var pvSet = new PropVariant
            {
                variantType = VT_LPWSTR,
                pointerValue = Marshal.StringToCoTaskMemUni(value)
            };

            // Marshal our definition into a pointer
            var ptrValue = Marshal.AllocHGlobal(Marshal.SizeOf(pvSet));
            Marshal.StructureToPtr(pvSet, ptrValue, false);

            // Marshal pointer into the interop PROPVARIANT 
            return (PROPVARIANT)Marshal.PtrToStructure(ptrValue, typeof(PROPVARIANT));
        }

        public static PROPVARIANT IntToPropVariant(int value)
        {
            // Tried using the method suggested here:
            // http://blogs.msdn.com/b/dimeby8/archive/2007/01/08/creating-wpd-propvariants-in-c-without-using-interop.aspx
            // However, the GetValue fails (Element Not Found) even though we've just added it.
            // So, I use the alternative (and I think more "correct") approach below.

            var pvSet = new PropVariant
            {
                variantType = VT_UI4,
                intValue = value
            };

            // Marshal our definition into a pointer
            var ptrValue = Marshal.AllocHGlobal(Marshal.SizeOf(pvSet));
            Marshal.StructureToPtr(pvSet, ptrValue, false);

            // Marshal pointer into the interop PROPVARIANT 
            return (PROPVARIANT)Marshal.PtrToStructure(ptrValue, typeof(PROPVARIANT));
        }

        public void Dispose()
        {
            this.pointerValue = IntPtr.Zero;
        }

        public static implicit operator PropVariant(PROPVARIANT val)
        {
            return PropVariant.FromValue(val);
        }

        public static implicit operator string(PropVariant val)
        {
            return val.ToString();
        }

        public static implicit operator bool(PropVariant val)
        {
            return val.ToBool();
        }

        public static implicit operator DateTime(PropVariant val)
        {
            return val.ToDate();
        }

        public static implicit operator Guid(PropVariant val)
        {
            return val.ToGuid();
        }

        public static implicit operator int(PropVariant val)
        {
            return val.ToInt();
        }
    }
}
