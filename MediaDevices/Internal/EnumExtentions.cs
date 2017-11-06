using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PortableDeviceApiLib;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;

namespace MediaDevices.Internal
{
    internal static class EnumExtentions
    {
        public static Guid Guid(this Enum e)
        {
            FieldInfo fi = e.GetType().GetField(e.ToString());
            GuidAttribute attribute = fi.GetCustomAttribute<GuidAttribute>();
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
                PROPVARIANT val = new PROPVARIANT();
                col.GetAt(i, ref val);
                yield return GetEnumFromAttrGuid<TEnum>(PropVariant.FromValue(val));
            }
        }

        private static T GetEnumFromAttrKey<T>(this PropertyKey key) where T : struct // enum
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


        private static T GetEnumFromAttrGuid<T>(this Guid guid) where T : struct // enum
        {
            T en = Enum.GetValues(typeof(T)).Cast<T>().Where(e =>
            {
                return e.GetType().GetField(e.ToString()).GetCustomAttribute<GuidAttribute>().Guid == guid;
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
                PROPVARIANT val = new PROPVARIANT();
                col.GetAt(i, ref val);
                yield return PropVariant.FromValue(val);
            }
        }

        public static IEnumerable<string> ToStrings(this IPortableDevicePropVariantCollection col)
        {
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                PROPVARIANT val = new PROPVARIANT();
                col.GetAt(i, ref val);
                yield return PropVariant.FromValue(val);
            }
        }
    }
}
