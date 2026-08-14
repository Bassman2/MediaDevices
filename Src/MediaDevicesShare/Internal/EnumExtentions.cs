namespace MediaDevices.Internal;

internal static class EnumExtentions
{
    private static uint GetGuidId(Guid value) => unchecked((ushort)(BitConverter.ToUInt32(value.ToByteArray(), 0) >> 16));

    #region Formats

    public static Guid ToGuid(this Formats value)
    {
        int var = (((int)value) << 16);
        var g = new Guid(unchecked((int)var), unchecked((short)0xAE6C), 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        return g;
    }
    public static Formats ToFormatsEnum(this Guid value)
    {
        return (Formats)GetGuidId(value);
    }

    public static string ToFormatsName(this Guid value)
    {
        ushort val = unchecked((ushort)(BitConverter.ToUInt32(value.ToByteArray(), 0) >> 16));

        Formats formats = (Formats)val;
        return formats.ToString();
    }

    #endregion
}
