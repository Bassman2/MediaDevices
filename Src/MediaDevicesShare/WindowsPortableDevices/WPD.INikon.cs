namespace MediaDevices.Internal;

partial class WPD
{
    public static Guid NikonDeviceProperties = new("4D545058-4E4B-4E4D-0000-000000000000");

    //0xD108 Shooting Mode
    public static PropertyKey NikonDevicePropertyShootingBank = new(NikonDeviceProperties, 0xD010);
    public static PropertyKey NikonDevicePropertyShootingBankNameA = new(NikonDeviceProperties, 0xD011);
    public static PropertyKey NikonDevicePropertyShootingBankNameB = new(NikonDeviceProperties, 0xD012);
    public static PropertyKey NikonDevicePropertyShootingBankNameC = new(NikonDeviceProperties, 0xD013);
    public static PropertyKey NikonDevicePropertyShootingBankNameD = new(NikonDeviceProperties, 0xD014);
    public static PropertyKey NikonDevicePropertyResetBank = new(NikonDeviceProperties, 0xD015);

}
