using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MediaDevices.Internal
{
    // to enable COM traces add "COMTRACE" to the Build Conditional compilation symbols of the MediaDevice project.

    internal static class ComTrace
    {
        private readonly static List<FieldInfo> pkeyFields;
        private readonly static List<FieldInfo> guidFields;

        static ComTrace()
        {
            pkeyFields = typeof(WPD).GetFields().Where(f => f.FieldType == typeof(PropertyKey)).ToList();
            guidFields = typeof(WPD).GetFields().Where(f => f.FieldType == typeof(Guid)).ToList();
        }

        public static FieldInfo? FindPropertyKeyField(PropertyKey key)
        {
            //return pkeyFields.SingleOrDefault(i => ((PropertyKey)i.GetValue(null)) == key);
            return pkeyFields.FirstOrDefault(i => ((PropertyKey?)i.GetValue(null)) == key);
        }

        public static FieldInfo? FindGuidField(Guid guid)
        {
            //return guidFields.SingleOrDefault(i => ((Guid)i.GetValue(null)) == guid);
            return guidFields.FirstOrDefault(i => ((Guid?)i.GetValue(null)) == guid);
        }

        [Conditional("COMTRACE")]
        public static void WriteObject(IPortableDeviceValues values, [CallerMemberName] string funcName = null)
        {
            InternalWriteObject(values, funcName);
        }

        [Conditional("COMTRACE")]
        public static void WriteObject(IPortableDeviceProperties deviceProperties, string objectId, [CallerMemberName] string funcName = null)
        {
            deviceProperties.GetSupportedProperties(objectId, out IPortableDeviceKeyCollection keys);
            deviceProperties.GetValues(objectId, keys, out IPortableDeviceValues values);

            InternalWriteObject(values, funcName);
        }

        [Conditional("COMTRACE")]
        private static void InternalWriteObject(IPortableDeviceValues values, string funcName)
        {
            Trace.WriteLine($"############################### {funcName}");   
            uint num = 0;

            values.GetCount(ref num);
            for (uint i = 0; i < num; i++)
            {
                var key = new PropertyKey();
                var val = new PropVariantFacade();
                values.GetAt(i, ref key, ref val.Value);

                string fieldName = string.Empty;
                FieldInfo propField = FindPropertyKeyField(key);
                if (propField != null)
                {
                    fieldName = propField.Name;
                }
                else
                {
                    FieldInfo guidField = FindGuidField(key.fmtid);
                    if (guidField != null)
                    {
                        fieldName = $"{guidField.Name}, {key.pid}";
                    }
                    else
                    {
                        fieldName = $"{key.fmtid}, {key.pid}";
                    }
                }

                switch (val.VariantType)
                {
                case PropVariantType.VT_CLSID:
                    Trace.WriteLine($"##### {fieldName} = {FindGuidField(val.ToGuid())?.Name ?? val.ToString()}");
                    break;
                default:
                    Trace.WriteLine($"##### {fieldName} = {val.ToDebugString()}");
                    break;
                }
            }
        }

        [Conditional("COMTRACE")]
        public static void WriteObject(IPortableDevicePropVariantCollection collection)
        {
            Trace.WriteLine("###############################");
            uint num = 0;
            collection.GetCount(ref num);
            for (uint index = 0; index < num; index++)
            {
                using (var val = new PropVariantFacade())
                {
                    collection.GetAt(index, ref val.Value);

                    Trace.WriteLine($"##### {val.ToDebugString()}");
                }
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
                var key = new PropertyKey();
                collection.GetAt(index, ref key);

                PropertyKeys propertyKey = key.GetPropertyKey();
                Trace.WriteLine($"##### {propertyKey}");
            }
        }
    }
}
