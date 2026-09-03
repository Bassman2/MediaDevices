namespace MediaDevices;

public record ObjectId
{
    public ObjectId(string wpdObjectId)
    {
        WpdObjectId = wpdObjectId;  
    }

    public ObjectId(uint mtpObjectId)
    {
        MtpObjectId = mtpObjectId;
    }
    public string WpdObjectId = "";

    public uint MtpObjectId = 0; 
}
