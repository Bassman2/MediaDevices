using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortableDeviceApiLib;
using PortableDeviceTypesLib;
using IPortableDeviceKeyCollection = PortableDeviceApiLib.IPortableDeviceKeyCollection;
using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;
using IPortableDevicePropVariantCollection = PortableDeviceApiLib.IPortableDevicePropVariantCollection;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using System.Diagnostics;
using System.Reflection;

namespace MediaDevices.Internal
{
    // to enable COM traces add "COMTRACE" to the Build Conditional compilation symbols of the MediaDevice project.

    internal static class ComTrace
    {
        private static List<FieldInfo> fields;

        static ComTrace()
        {
            fields = typeof(WPD).GetFields().Where(f => f.FieldType == typeof(PropertyKey)).ToList();
        }

        private static FieldInfo FindField(PropertyKey key)
        {
            return fields.SingleOrDefault(i => ((PropertyKey)i.GetValue(null)).pid == key.pid && ((PropertyKey)i.GetValue(null)).fmtid == key.fmtid);
        }

        [Conditional("COMTRACE")]
        public static void WriteObject(IPortableDeviceValues values)
        {
            string func = new StackTrace().GetFrame(1).GetMethod().Name;
            Trace.WriteLine($"############################### {func}");
            uint num = 0;

            values.GetCount(ref num);
            for (uint i = 0; i < num; i++)
            {
                PropertyKey key = new PropertyKey();
                PROPVARIANT val = new PROPVARIANT();
                values.GetAt(i, ref key, ref val);

                FieldInfo field = FindField(key);
                Trace.WriteLine($"##### {field.Name} = {((PropVariant)val).ToString()}");

                //foreach (var field in fields)
                //{
                //    PropertyKey pk = (PropertyKey)field.GetValue(null);
                //    if (pk.pid == key.pid && pk.fmtid == key.fmtid)
                //    {
                //        Trace.WriteLine($"##### {field.Name} = {((PropVariant)val).ToString()}");
                //    }
                //}
            }
        }

        [Conditional("COMTRACE")]
        public static void WriteObject(IPortableDeviceProperties deviceProperties, string objectId)
        {
            IPortableDeviceKeyCollection keys;
            deviceProperties.GetSupportedProperties(objectId, out keys);

            IPortableDeviceValues values;
            deviceProperties.GetValues(objectId, keys, out values);

            WriteObject(values);
        }

        [Conditional("COMTRACE")]
        public static void WriteObject(IPortableDevicePropVariantCollection collection)
        {
            Trace.WriteLine("###############################");
            uint num = 0;
            collection.GetCount(ref num);
            for (uint index = 0; index < num; index++)
            {
                PROPVARIANT val = new PROPVARIANT();
                collection.GetAt(index, ref val);

                Trace.WriteLine($"##### {((PropVariant)val).ToString()}");
            }
        }

        [Conditional("COMTRACE")]
        public static void WriteObject(IPortableDeviceKeyCollection collection)
        {
            Trace.WriteLine("###############################");
            uint num = 0;
            collection.GetCount(ref num);
            for (uint index = 0; index < num; index++)
            {
                PropertyKey key = new PropertyKey();
                collection.GetAt(index, ref key);

                PropertyKeys propertyKey = key.GetEnumFromAttrKey<PropertyKeys>();
                Trace.WriteLine($"##### {propertyKey}");
            }
        }
    }
}
