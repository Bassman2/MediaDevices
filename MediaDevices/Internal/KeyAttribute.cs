using System;

namespace MediaDevices
{
    internal class KeyAttribute : Attribute
    {
        public KeyAttribute()
        {
            this.Guid = Guid.Empty;
            this.Id = 0;
        }

        public KeyAttribute(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, uint id)
        {
            this.Guid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
            this.Id = id;
        }

        public Guid Guid { get; private set; }

        public uint Id { get; private set; }
    }
}
