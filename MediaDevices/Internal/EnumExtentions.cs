using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace MediaDevices.Internal
{
    internal static class EnumExtentions
    {
        public static Guid Guid(this Enum e)
        {
            FieldInfo fi = e.GetType().GetField(e.ToString());
            EnumGuidAttribute attribute = fi.GetCustomAttribute<EnumGuidAttribute>();
            return attribute.Guid;
        }

        public static IEnumerable<TEnum> ToEnum<TEnum>(this IPortableDeviceKeyCollection col) where TEnum : struct // enum
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                PropertyKey key = new PropertyKey();
                col.GetAt(i, ref key);
                yield return GetEnumFromAttrKey<TEnum>(key);
            }
        }

        public static IEnumerable<TEnum> ToEnum<TEnum>(this IPortableDevicePropVariantCollection col) where TEnum : struct // enum
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                PropVariantFacade val = new PropVariantFacade();
                col.GetAt(i, ref val.Value);
                yield return GetEnumFromAttrGuid<TEnum>(val.ToGuid());
            }
        }

        public static T GetEnumFromAttrKey<T>(this PropertyKey key) where T : struct // enum
        {
            T en = Enum.GetValues(typeof(T)).Cast<T>().Where(e =>
            {
                KeyAttribute attr = e.GetType().GetField(e.ToString()).GetCustomAttribute<KeyAttribute>();
                return attr.Guid == key.fmtid && attr.Id == key.pid;
            }).FirstOrDefault();
            if (en.Equals(default(T)))
            {
                Trace.TraceWarning($"Unknown {typeof(T).Name} Key {key.fmtid}  {key.pid}");
            }
            return en;
        }


        public static T GetEnumFromAttrGuid<T>(this Guid guid) where T : struct // enum
        {
            T en = Enum.GetValues(typeof(T)).Cast<T>().Where(e =>
            {
                return e.GetType().GetField(e.ToString()).GetCustomAttribute<EnumGuidAttribute>().Guid == guid;
            }).FirstOrDefault();
            if (en.Equals(default(T)))
            {
                Trace.TraceWarning($"Unknown {typeof(T).Name} Guid {guid}");
            }
            return en;
        }

        public static IEnumerable<Guid> ToGuid(this IPortableDevicePropVariantCollection col) 
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    col.GetAt(i, ref val.Value);
                    yield return val.ToGuid();
                }
            }
        }

        public static IEnumerable<string> ToStrings(this IPortableDevicePropVariantCollection col)
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                using (PropVariantFacade val = new PropVariantFacade())
                {
                    col.GetAt(i, ref val.Value);
                    yield return val.ToString();
                }
            }
        }
    }
}
