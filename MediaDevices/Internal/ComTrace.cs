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

namespace MediaDevices.Internal
{
    internal class ComTrace
    {

        public static void WriteObject(IPortableDeviceValues values)
        {
            uint num = 0;
            values.GetCount(ref num);
            for (uint i = 0; i < num; i++)
            {
                PropertyKey key = new PropertyKey();
                PROPVARIANT val = new PROPVARIANT();
                values.GetAt(i, ref key, ref val);

                Type twpd = typeof(WPD);
                var fields = twpd.GetFields().Where(f => f.FieldType == typeof(PropertyKey)).ToList();
                foreach (var field in fields)
                {
                    PropertyKey pk = (PropertyKey)field.GetValue(null);
                    if (pk.pid == key.pid && pk.fmtid == key.fmtid)
                    {
                        Trace.WriteLine($"##### {field.Name} = {((PropVariant)val).ToString()}");
                    }
                }
            }
        }
    }
}
