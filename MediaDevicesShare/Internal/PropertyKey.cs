using System;

namespace MediaDevices.Internal
{
    internal struct PropertyKey
    {
        public Guid fmtid;
        public uint pid;

        public static bool operator ==(PropertyKey obj1, PropertyKey obj2)
        {
            return obj1.fmtid == obj2.fmtid && obj1.pid == obj2.pid;
        }

        public static bool operator !=(PropertyKey obj1, PropertyKey obj2)
        {
            return obj1.fmtid != obj2.fmtid || obj1.pid != obj2.pid;
        }

        public override bool Equals(object obj)
        {
            PropertyKey pk = (PropertyKey)obj;
            return this.fmtid == pk.fmtid && this.pid == pk.pid;
        }
        public override int GetHashCode()
        {
            return this.fmtid.GetHashCode() ^ this.pid.GetHashCode();
        }
    }
}
