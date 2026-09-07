namespace MediaDevices;

public record struct PropertyCode
{
    public ushort MtpPropertyCode = 0;
    public Guid WpdFormatId = Guid.Empty;
    public uint WpdPropertyId = 0;

    //public readonly string Name => ""; // todo this.ToName();

    public PropertyCode()
    { }

    public PropertyCode(ushort mtpPropertyCode)
    {
        this.MtpPropertyCode = mtpPropertyCode;
    }

    public PropertyCode(ushort mtpPropertyCode, string wpdFormatId, uint wpdPropertyId)
    {
        this.MtpPropertyCode = mtpPropertyCode;
        this.WpdFormatId = Guid.Parse(wpdFormatId);
        this.WpdPropertyId = wpdPropertyId;
    }

    public PropertyCode(ushort mtpPropertyCode, Guid wpdFormatId, uint wpdPropertyId)
    {
        this.MtpPropertyCode = mtpPropertyCode;
        this.WpdFormatId = wpdFormatId;
        this.WpdPropertyId = wpdPropertyId;
    }

    public PropertyCode(ushort mtpPropertyCode, uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, uint wpdPropertyId)
    {
        this.MtpPropertyCode = mtpPropertyCode;
        this.WpdFormatId = new Guid(a, b, c, d, e, f, g, h, i, j, k);
        this.WpdPropertyId = wpdPropertyId;
    }

    public readonly override string ToString() => $"{this.MtpPropertyCode}, {this.WpdFormatId}, {this.WpdPropertyId}";
}
