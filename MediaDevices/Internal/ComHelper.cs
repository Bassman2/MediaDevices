using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;

namespace MediaDevices.Internal
{
    internal static class ComHelper
    {
        public static bool HasKeyValue(IPortableDeviceValues values, PropertyKey findKey)
        {
            uint num = 0;
            values.GetCount(ref num);
            for (uint i = 0; i < num; i++)
            {
                PropertyKey key = new PropertyKey();
                PROPVARIANT val = new PROPVARIANT();
                values.GetAt(i, ref key, ref val);
                if (key.fmtid == findKey.fmtid && key.pid == findKey.pid)
                {
                    PropVariant pval = val;
                    return pval.variantType != PropVariant.VT_ERROR;
                }
                
            }
            return false;
        }
    }
}
