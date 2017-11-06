using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PortableDeviceApiLib;
using PortableDeviceTypesLib;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using IPortableDevicePropVariantCollection = PortableDeviceApiLib.IPortableDevicePropVariantCollection;

namespace MediaDevices.Internal
{
    internal class Command
    {
        private IPortableDeviceValues values;
        private IPortableDeviceValues result;

        private Command(PropertyKey commandKey)
        {
            this.values = (IPortableDeviceValues)new PortableDeviceValues();
            this.values.SetGuidValue(WPD.PROPERTY_COMMON_COMMAND_CATEGORY, commandKey.fmtid);
            this.values.SetUnsignedIntegerValue(WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);
        }

        public static Command Create(PropertyKey commandKey)
        {
            return new Command(commandKey);
        }

        public void Add(PropertyKey key, Guid value)
        {
            this.values.SetGuidValue(key, value);
        }

        public void Add(PropertyKey key, int value)
        {
            this.values.SetSignedIntegerValue(key, value);
        }

        public void Add(PropertyKey key, string value)
        {
            this.values.SetStringValue(key, value);
        }

        public Guid GetGuid(PropertyKey key)
        {
            Guid value;
            this.result.GetGuidValue(key, out value);
            return value;
        }

        public int GetInt(PropertyKey key)
        {
            int value;
            this.result.GetSignedIntegerValue(key, out value);
            return value;
        }

        public string GetString(PropertyKey key)
        {
            string value;
            this.result.GetStringValue(key, out value);
            return value;
        }
        
        public IEnumerable<PropVariant> GetPropVariants(PropertyKey key) 
        {
            object obj = null;
            this.result.GetIUnknownValue(key, out obj);
            var col = obj as IPortableDevicePropVariantCollection;
        
            uint count = 0;
            col.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                PROPVARIANT val = new PROPVARIANT();
                col.GetAt(i, ref val);
                yield return PropVariant.FromValue(val);
            }
        }

        public bool Has(PropertyKey key)
        {
            uint count = 0;
            this.result.GetCount(ref count);
            for (uint i = 0; i < count; i++)
            {
                PropertyKey k = new PropertyKey();
                PROPVARIANT v = new PROPVARIANT();
                this.result.GetAt(i, ref k, ref v);
                if (key.fmtid == k.fmtid && key.pid == k.pid)
                {
                    return true;
                }
            }
            return false;
        }

        public void Send(PortableDevice device)
        {
            device.SendCommand(0, this.values, out this.result);

            int error = 0;
            result.GetErrorValue(WPD.PROPERTY_COMMON_HRESULT, out error);
            switch ((HResult)error)
            {
            case HResult.S_OK:
                return;
            case HResult.E_NOT_IMPLEMENTED:
                throw new NotSupportedException($"{new StackFrame(1, true).GetMethod().Name} not supported by device");
            default:
                throw new Exception($"Error {error:X}");
            }
        }
    }
}
