namespace MediaDevices;

public record ObjectId
{
    public static readonly ObjectId Device = new ObjectId("DEVICE", 0);
    public static readonly ObjectId Empty = new ObjectId("", 0);

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

    public string WpdObjectId = "";

    public uint MtpObjectId = 0; 
}
