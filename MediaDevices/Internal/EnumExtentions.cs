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

        public static TEnum[] ToArray<TEnum>(this IPortableDeviceKeyCollection col) where TEnum : struct // enum
        {
            uint count = 0;
            col.GetCount(ref count);
            var result = new TEnum[count];
            for (uint i = 0; i < count; i++)
            {
                PropertyKey key = new PropertyKey();
                col.GetAt(i, ref key);
                result[i] = GetEnumFromAttrKey<TEnum>(key);
            }
            return result;
        }

        public static TEnum[] ToArray<TEnum>(this IPortableDevicePropVariantCollection col) where TEnum : struct // enum
        {
            uint count = 0;
            col.GetCount(ref count);
            var result = new TEnum[count];
            for (uint i = 0; i < count; i++)
            {
                PROPVARIANT val = new PROPVARIANT();
                col.GetAt(i, ref val);
                result[i] = GetEnumFromAttrGuid<TEnum>(PropVariant.FromValue(val));
            }
            return result;
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
                return e.GetType().GetField(e.ToString()).GetCustomAttribute<GuidAttribute>().Guid == guid;
            }).FirstOrDefault();
            if (en.Equals(default(T)))
            {
                Trace.TraceWarning($"Unknown {typeof(T).Name} Guid {guid}");
            }
            return en;
        }
        
        public static Guid[] ToGuid(this IPortableDevicePropVariantCollection col)
        {
            uint count = 0;
            col.GetCount(ref count);
            var result = new Guid[count];
            for (uint i = 0; i < count; i++)
            {
                PROPVARIANT val = new PROPVARIANT();
                col.GetAt(i, ref val);
                result[i] = PropVariant.FromValue(val);
            }
            return result;
        }

        public static string[] ToStrings(this IPortableDevicePropVariantCollection col)
        {
            uint count = 0;
            col.GetCount(ref count);
            var result = new string[count];
            for (uint i = 0; i < count; i++)
            {
                PROPVARIANT val = new PROPVARIANT();
                col.GetAt(i, ref val);
                result[i] = PropVariant.FromValue(val);
            }
            return result;
        }
    }
}
