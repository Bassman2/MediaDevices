namespace MediaDevices;

public record ObjectId
{
    public static readonly ObjectId Device = new("DEVICE", 0);
    public static readonly ObjectId Empty = new("", 0);

    public ObjectId(string wpdObjectId, uint mtpObjectId)
    {
        WpdObjectId = wpdObjectId;
        MtpObjectId = mtpObjectId;
    }

    public ObjectId(string wpdObjectId)
    {
        WpdObjectId = wpdObjectId;  
    }

    public ObjectId(uint mtpObjectId)
    {
        MtpObjectId = mtpObjectId;
    }

    public bool IsDevice => this == Device;
    public bool IsEmpty => this == Empty;

    public string WpdObjectId = "";

    public uint MtpObjectId = 0; 
}
