using System;
using System.Runtime.InteropServices;


namespace MediaDevices.Internal
{
    internal static class ComHelper
    {
        public static bool HasKeyValue(this IPortableDeviceValues values, PropertyKey findKey)
        {
            uint num = 0;
            values?.GetCount(ref num);
            for (uint i = 0; i < num; i++)
            {
                PropertyKey key = new PropertyKey();
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    values.GetAt(i, ref key, ref val.Value);
                    if (key.fmtid == findKey.fmtid && key.pid == findKey.pid)
                    {
                        
                        return val.VariantType != PropVariantType.VT_ERROR;
                    }
                }
            }
            
            return false;
        }

        public static bool IsEqual(PropertyKey a, PropertyKey b)
        {
            return a.fmtid == b.fmtid && a.pid == b.pid;
        }

        public static PropVariantType GetVarType(this IPortableDeviceValues values, PropertyKey key)
        {
            using (PropVariantFacade val = new PropVariantFacade())
            {
                values.GetValue(ref key, out val.Value);
                return val.VariantType;
            }
        }

        internal static bool TryGetValue(this IPortableDeviceValues values, PropertyKey key, out PropVariantFacade value)
        {
            if (values.HasKeyValue(key))
            {
                PropVariantFacade val = new PropVariantFacade();
                values.GetValue(ref key, out val.Value);
                value = val;
                return true;
            }
            value = null;
            return false;
        }

        public static bool TryGetDateTimeValue(this IPortableDeviceValues values, PropertyKey key, out DateTime? value)
        {
            if (values.HasKeyValue(key))
            {
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    values.GetValue(ref key, out val.Value);
                    value = val.ToDate();
                }
                return true;
            }
            value = null;
            return false;
        }

        public static bool TryGetStringValue(this IPortableDeviceValues values, PropertyKey key, out string value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetStringValue(ref key, out value);
                return true;
            }
            value = string.Empty;
            return false;            
        }

        public static bool TryGetGuidValue(this IPortableDeviceValues values, PropertyKey key, out Guid value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetGuidValue(ref key, out value);
                return true;
            }
            value = Guid.Empty;
            return false;
        }

        public static bool TryGetBoolValue(this IPortableDeviceValues values, PropertyKey key, out bool value)
        {
            if (values.HasKeyValue(key))
            {
                int val;
                values.GetBoolValue(ref key, out val);
                value = val != 0;
                return true;
            }
            value = false;
            return false;
        }

        public static bool TryGetUnsignedIntegerValue(this IPortableDeviceValues values, PropertyKey key, out uint value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetUnsignedIntegerValue(ref key, out value);
                return true;
            }
            value = 0;
            return false;
        }

        public static bool TryGetUnsignedLargeIntegerValue(this IPortableDeviceValues values, PropertyKey key, out ulong value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetUnsignedLargeIntegerValue(ref key, out value);
                return true;
            }
            value = 0;
            return false;
        }

        public static bool TryGetSignedIntegerValue(this IPortableDeviceValues values, PropertyKey key, out int value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetSignedIntegerValue(ref key, out value);
                return true;
            }
            value = 0;
            return false;
        }

        public static bool TryGetIUnknownValue(this IPortableDeviceValues values, PropertyKey key, out object value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetIUnknownValue(ref key, out value);
                return true;
            }
            value = null;
            return false;
        }

        public static bool TryByteArrayValue(this IPortableDeviceValues values, PropertyKey key, out byte[] value)
        {
            if (values.HasKeyValue(key))
            {
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    values.GetValue(ref key, out val.Value);
                    value = val.ToByteArray();
                }
                return true;
            }
            value = null;
            return false;
        }

        private static class NativeMethods
        {
            // http://www.pinvoke.net/default.aspx/iprop/PropVariantClear.html
            // https://social.msdn.microsoft.com/Forums/windowsserver/en-US/ec242718-8738-4468-ae9d-9734113d2dea/quotipropdllquot-seems-to-be-missing-in-windows-server-2008-and-x64-systems?forum=winserver2008appcompatabilityandcertification
            [DllImport("ole32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern public int PropVariantClear(ref PropVariant val);
        }
    }
}
