namespace MediaDevices.Internal;

partial class WPD
{
    public static Guid SonyDeviceProperties = new("4D545058-4E4B-4E4D-0000-000000000000");

    // Camera Setup & Configuration

    public static PropertyKey NikonDevicePropertyShootingBank = new(NikonDeviceProperties, 0xD010);
}
