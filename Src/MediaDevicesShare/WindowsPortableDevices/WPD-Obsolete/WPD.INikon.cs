namespace MediaDevices.WindowsPortableDevices;

partial class WPD
{
    public static Guid NikonDeviceProperties = new("4D545058-4E4B-4E4D-0000-000000000000");

    // Camera Setup & Configuration

    public static PropertyKey NikonDevicePropertyShootingBank = new(NikonDeviceProperties, 0xD010);
    public static PropertyKey NikonDevicePropertyShootingBankNameA = new(NikonDeviceProperties, 0xD011);
    public static PropertyKey NikonDevicePropertyShootingBankNameB = new(NikonDeviceProperties, 0xD012);
    public static PropertyKey NikonDevicePropertyShootingBankNameC = new(NikonDeviceProperties, 0xD013);
    public static PropertyKey NikonDevicePropertyShootingBankNameD = new(NikonDeviceProperties, 0xD014);
    public static PropertyKey NikonDevicePropertyResetBank = new(NikonDeviceProperties, 0xD015);
    public static PropertyKey NikonDevicePropertyRawCompression = new(NikonDeviceProperties, 0xD016);
    public static PropertyKey NikonDevicePropertyWhiteBalanceAutoBias = new(NikonDeviceProperties, 0xD017);
    public static PropertyKey NikonDevicePropertyCompressionNL = new(NikonDeviceProperties, 0xD01E);
    public static PropertyKey NikonDevicePropertyImageSize = new(NikonDeviceProperties, 0xD01F);

    // Exposure Control

    public static PropertyKey NikonDevicePropertyFNumber = new(NikonDeviceProperties, 0xD050);
    public static PropertyKey NikonDevicePropertyFocalLength = new(NikonDeviceProperties, 0xD051);
    public static PropertyKey NikonDevicePropertyEffectMode = new(NikonDeviceProperties, 0xD052);
    public static PropertyKey NikonDevicePropertyExposureProgram = new(NikonDeviceProperties, 0xD054);
    public static PropertyKey NikonDevicePropertyExposureIndex = new(NikonDeviceProperties, 0xD056);

    // Live View & Focus Settings

    public static PropertyKey NikonDevicePropertyLiveViewStatus = new(NikonDeviceProperties, 0xD100);
    public static PropertyKey NikonDevicePropertyLiveViewDriveMode = new(NikonDeviceProperties, 0xD1001);
    public static PropertyKey NikonDevicePropertyLiveViewAFArea = new(NikonDeviceProperties, 0xD1003);
    public static PropertyKey NikonDevicePropertyFocusMode = new(NikonDeviceProperties, 0xD108);

    // Capture & Shutter

    public static PropertyKey NikonDevicePropertyRecordingMedia = new(NikonDeviceProperties, 0xD140);
    public static PropertyKey NikonDevicePropertyShutterSpeed = new(NikonDeviceProperties, 0xD1A0);
    public static PropertyKey NikonDevicePropertyBurstMode = new(NikonDeviceProperties, 0xD1A1);
}
