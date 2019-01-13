using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;

namespace MediaDevices.Internal
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The Facade is necessary because structs used in using are readonly and can not be filled with ref or out.
    /// </remarks>
    internal sealed class PropVariantFacade : IDisposable
    {
        // cannot be a property because it will be filled by reference
        public PropVariant Value;

        public PropVariantFacade()
        {
            this.Value = new PropVariant();
        }

        public void Dispose()
        {
            // clear only if filled
            if (this.Value.vt != 0)
            {
                try
                {
                    // clear propvariant clears also included objects like strings
                    NativeMethods.PropVariantClear(ref this.Value);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
        }

        public PropVariantType VariantType
        {
            get { return this.Value.vt; }
        }

        public override string ToString()
        {
            switch (this.Value.vt)
            {
                case PropVariantType.VT_LPSTR:
                    return Marshal.PtrToStringAnsi(this.Value.ptrVal);

                case PropVariantType.VT_LPWSTR:
                    return Marshal.PtrToStringUni(this.Value.ptrVal);

                case PropVariantType.VT_BSTR:
                    return Marshal.PtrToStringBSTR(this.Value.ptrVal);

                case PropVariantType.VT_CLSID:
                    return ToGuid().ToString();

                case PropVariantType.VT_DATE:
                    return ToDate().ToString();

                case PropVariantType.VT_BOOL:
                    return ToBool().ToString();

                case PropVariantType.VT_INT:
                case PropVariantType.VT_I4:
                    return ToInt().ToString();

                case PropVariantType.VT_UI4:
                    return ToUInt().ToString();

                case PropVariantType.VT_UI8:
                    return ToUlong().ToString();

                case PropVariantType.VT_ERROR:
                    int error = ToError();
                    string name = Enum.GetName(typeof(HResult), error) ?? error.ToString("X");
                    return $"Error: {name}";
            }

            return $"Unknown type {this.Value.vt}"; 
        }

        public int ToInt()
        {
            if (this.Value.vt == PropVariantType.VT_ERROR)
            {
                return 0;
            }

            if (this.Value.vt != PropVariantType.VT_INT && this.Value.vt != PropVariantType.VT_I4)
            {
                throw new InvalidOperationException($"ToInt does not work for value type {this.Value.vt}");
            }

            return this.Value.intVal;
        }

        public uint ToUInt()
        {
            if (this.Value.vt == PropVariantType.VT_ERROR)
            {
                return 0;
            }

            if (this.Value.vt != PropVariantType.VT_UINT && this.Value.vt != PropVariantType.VT_UI4)
            {
                throw new InvalidOperationException($"ToUInt does not work for value type {this.Value.vt}");
            }

            return this.Value.uintVal;
        }

        public ulong ToUlong()
        {
            if (this.Value.vt == PropVariantType.VT_ERROR)
            {
                return 0;
            }

            if (this.Value.vt != PropVariantType.VT_UI8)
            {
                throw new InvalidOperationException($"ToUlong does not work for value type {this.Value.vt}");
            }
            
            return this.Value.ulongVal;
        }


        public DateTime ToDate()
        {
            if (this.Value.vt == PropVariantType.VT_ERROR)
            {
                return new DateTime();
            }

            if (this.Value.vt != PropVariantType.VT_DATE)
            {
                throw new InvalidOperationException($"ToDate does not work for value type {this.Value.vt}");
            }
            
            return DateTime.FromOADate(this.Value.dateVal);
        }

        public bool ToBool()
        {
            if (this.Value.vt == PropVariantType.VT_ERROR)
            {
                return false;
            }

            if (this.Value.vt != PropVariantType.VT_BOOL)
            {
                throw new InvalidOperationException($"ToBool does not work for value type {this.Value.vt}");
            }

            return this.Value.boolVal != 0;
        }

        public Guid ToGuid()
        {
            if (this.Value.vt == PropVariantType.VT_ERROR)
            {
                return new Guid();
            }

            if (this.Value.vt != PropVariantType.VT_CLSID)
            {
                throw new InvalidOperationException($"ToGuid does not work for value type {this.Value.vt}");
            }

            return (Guid)Marshal.PtrToStructure(this.Value.ptrVal, typeof(Guid));
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public byte[] ToByteArray()
        {
            if (this.Value.vt != (PropVariantType.VT_VECTOR | PropVariantType.VT_UI1))
            {
                throw new InvalidOperationException($"ToByteArray does not work for value type {this.Value.vt}");
            }

            int size = (int)this.Value.dataVal.cData;
            byte[] managedArray = new byte[size];
            
            // bug fixed with manual COM wrapper classes
            Marshal.Copy(this.Value.dataVal.pData, managedArray, 0, size);
            return managedArray;
        }

        public int ToError()
        {
            if (this.Value.vt != PropVariantType.VT_ERROR)
            {
                return 0;
            }

            return this.Value.errorCode;
        }
            

        public static PropVariantFacade StringToPropVariant(string value)
        {
            PropVariantFacade pv = new PropVariantFacade();
            pv.Value.vt = PropVariantType.VT_LPWSTR;
            // Hack, see GetString
            pv.Value.ptrVal = Marshal.StringToCoTaskMemUni(value);
            return pv;
        }

        //public static PropVariantFacade UIntToPropVariant(uint value)
        //{
        //    PropVariantFacade pv = new PropVariantFacade();
        //    pv.Value.vt = PropVariantType.VT_UI4;
        //    pv.Value.inner.ulVal = value;
        //    return pv;
        //}

        public static PropVariantFacade IntToPropVariant(int value)
        {
            PropVariantFacade pv = new PropVariantFacade();
            pv.Value.vt = PropVariantType.VT_INT;
            pv.Value.intVal = value;
            return pv;
        }

        public static implicit operator string(PropVariantFacade val)
        {
            return val.ToString();
        }

        public static implicit operator bool(PropVariantFacade val)
        {
            return val.ToBool();
        }

        public static implicit operator DateTime(PropVariantFacade val)
        {
            return val.ToDate();
        }

        public static implicit operator Guid(PropVariantFacade val)
        {
            return val.ToGuid();
        }

        public static implicit operator int(PropVariantFacade val)
        {
            return val.ToInt();
        }

        public static implicit operator ulong(PropVariantFacade val)
        {
            return val.ToUlong();
        }

        public static implicit operator Byte[] (PropVariantFacade val)
        {
            return val.ToByteArray();
        }

        private static class NativeMethods
        {
            [DllImport("ole32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern public int PropVariantClear(ref PropVariant val);
        }
    }
}
