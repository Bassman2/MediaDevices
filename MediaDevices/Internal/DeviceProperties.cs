using PortableDeviceApiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    internal class DeviceProperties
    {
        private IPortableDeviceValues values;

        public DeviceProperties(IPortableDeviceProperties deviceProperties)
        {
            IPortableDeviceKeyCollection keys;
            deviceProperties.GetSupportedProperties(Item.RootId, out keys);
            deviceProperties.GetValues(Item.RootId, keys, out this.values);
        }

        public string FriendlyName
        {
            get
            {
                string value;
                this.values.GetStringValue(WPD.DEVICE_FRIENDLY_NAME, out value);
                return value;
            }
        }
    }
}
