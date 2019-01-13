using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    internal class EnumGuidAttribute : Attribute
    {
        public EnumGuidAttribute()
        {
            this.Guid = Guid.Empty;
        }

        public EnumGuidAttribute(string v)
        {
            this.Guid = new Guid(v);
        }

        public EnumGuidAttribute(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
        {
            this.Guid = new Guid(a, b, c, d, e, f, g, h, i, j, k); 
        }

        public Guid Guid { get; private set; }
    }
}
