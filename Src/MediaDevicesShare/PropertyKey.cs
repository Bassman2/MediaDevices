namespace MediaDevices;

public struct PropertyKey
{
    public Guid fmtid;
    public uint pid;

    public readonly string Name => this.ToName();

    public PropertyKey()
    {
        this.fmtid = Guid.Empty;
        this.pid = 0;
    }
    public PropertyKey(string guid, uint id)
    {
        this.fmtid = Guid.Parse(guid);
        this.pid = id;
    }

    public PropertyKey(Guid guid, uint id)
    {
        this.fmtid = guid;
        this.pid = id;
    }

    public PropertyKey(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, uint id)
    {
        this.fmtid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
        this.pid = id;
    }

    public static bool operator ==(PropertyKey obj1, PropertyKey obj2)
        => obj1.fmtid == obj2.fmtid && obj1.pid == obj2.pid;
   
    public static bool operator !=(PropertyKey obj1, PropertyKey obj2)
        => obj1.fmtid != obj2.fmtid || obj1.pid != obj2.pid;

    public readonly override bool Equals(object? obj)
        => obj is PropertyKey pk && this.fmtid == pk.fmtid && this.pid == pk.pid;
    
    public readonly override int GetHashCode()
        => this.fmtid.GetHashCode() ^ this.pid.GetHashCode();

    public readonly override string ToString() => $"{this.fmtid}, {this.pid}"; 
}
