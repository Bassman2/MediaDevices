using System;
using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;

namespace MediaDevices.Internal
{
    internal static class ComHelper
    {
        public static bool HasKeyValue(this IPortableDeviceValues values, PropertyKey findKey)
        {
            //using (new Profiler("HasKeyValue"))
            try
            {
                uint num = 0;
                values?.GetCount(ref num);
                for (uint i = 0; i < num; i++)
                {
                    PropertyKey key = new PropertyKey();
                    PROPVARIANT val = new PROPVARIANT();
                    values.GetAt(i, ref key, ref val);
                    if (key.fmtid == findKey.fmtid && key.pid == findKey.pid)
                    {
                        PropVariant pval = val;
                        return pval.variantType != VarType.VT_ERROR;
                    }

                }
                
            }
            catch { }
            return false;
        }

        public static bool IsEqual(PropertyKey a, PropertyKey b)
        {
            return a.fmtid == b.fmtid && a.pid == b.pid;
        }

        public static VarType GetVarType(this IPortableDeviceValues values, PropertyKey key)
        {
            PROPVARIANT val;
            values.GetValue(key, out val);
            return ((PropVariant)val).variantType;
        }

        internal static bool TryGetValue(this IPortableDeviceValues values, PropertyKey key, out PropVariant value)
        {
            if (values.HasKeyValue(key))
            {
                PROPVARIANT val;
                values.GetValue(key, out val);
                value = (PropVariant)val;
                return true;
            }
            value = new PropVariant();
            return false;
        }

        public static bool TryGetDateTimeValue(this IPortableDeviceValues values, PropertyKey key, out DateTime? value)
        {
            if (values.HasKeyValue(key))
            {
                PROPVARIANT val;
                values.GetValue(key, out val);
                value = ((PropVariant)val).ToDate(); 
                return true;
            }
            value = null;
            return false;
        }

        public static bool TryGetStringValue(this IPortableDeviceValues values, PropertyKey key, out string value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetStringValue(key, out value);
                return true;
            }
            value = string.Empty;
            return false;            
        }

        public static bool TryGetGuidValue(this IPortableDeviceValues values, PropertyKey key, out Guid value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetGuidValue(key, out value);
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
                values.GetBoolValue(key, out val);
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
                values.GetUnsignedIntegerValue(key, out value);
                return true;
            }
            value = 0;
            return false;
        }

        public static bool TryGetUnsignedLargeIntegerValue(this IPortableDeviceValues values, PropertyKey key, out ulong value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetUnsignedLargeIntegerValue(key, out value);
                return true;
            }
            value = 0;
            return false;
        }

        public static bool TryGetSignedIntegerValue(this IPortableDeviceValues values, PropertyKey key, out int value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetSignedIntegerValue(key, out value);
                return true;
            }
            value = 0;
            return false;
        }

        public static bool TryGetIUnknownValue(this IPortableDeviceValues values, PropertyKey key, out object value)
        {
            if (values.HasKeyValue(key))
            {
                values.GetIUnknownValue(key, out value);
                return true;
            }
            value = null;
            return false;
        }

        public static bool TryByteArrayValue(this IPortableDeviceValues values, PropertyKey key, out byte[] value)
        {
            if (values.HasKeyValue(key))
            {
                PROPVARIANT val;
                values.GetValue(key, out val);
                value = ((PropVariant)val).ToByteArray();
                return true;
            }
            value = null;
            return false;
        }
    }
}
