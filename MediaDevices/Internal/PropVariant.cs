using System;
using System.Runtime.InteropServices;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;

namespace MediaDevices.Internal
{

    [StructLayout(LayoutKind.Explicit, Size = 32)]
    internal struct PropVariant : IDisposable
    {
        [FieldOffset(0)]
        public VarType variantType;
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
            switch ((VarType)variantType)
            {
            case VarType.VT_LPWSTR:
                return Marshal.PtrToStringUni(pointerValue);

            case VarType.VT_CLSID:
                return ToGuid().ToString();

            case VarType.VT_DATE:
                return ToDate().ToString();

            case VarType.VT_BOOL:
                return ToBool().ToString();

            case VarType.VT_UI4:
                return intValue.ToString();

            case VarType.VT_UI8:
                return longValue.ToString();

            case VarType.VT_ERROR:
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

        public ulong ToUlong()
        {
            return (ulong)this.longValue;
        }

        public Byte[] ToByteArray()
        {
            // TODO

            //byte[] arr = new byte[16];
            ////Marshal.Copy(pointerValue, arr, 0, 199);
            //Marshal.Copy((IntPtr)longValue, arr, 0, 16);
            //return arr;
            
            return null;
        }

        public static PROPVARIANT StringToPropVariant(string value)
        {
            // Tried using the method suggested here:
            // http://blogs.msdn.com/b/dimeby8/archive/2007/01/08/creating-wpd-propvariants-in-c-without-using-interop.aspx
            // However, the GetValue fails (Element Not Found) even though we've just added it.
            // So, I use the alternative (and I think more "correct") approach below.

            var pvSet = new PropVariant
            {
                variantType = VarType.VT_LPWSTR,
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
                variantType = VarType.VT_UI4,
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

        public static implicit operator ulong(PropVariant val)
        {
            return val.ToUlong();
        }

        public static implicit operator Byte[](PropVariant val)
        {
            return val.ToByteArray();
        }
    }

}
