using System.Timers;

namespace MediaDevices.Internal;

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
    
    // 0xD017: WhiteBalanceAutoBias
    // 0xD01F: ImageSize
    // 0xD01E: CompressionNL

    // Exposure Control

    // 0xD050: FNumber(Nikon-specific aperture stepping overrides)
    // 0xD051: FocalLength0xD052: EffectMode
    // 0xD054: ExposureProgram
    // 0xD056: ExposureIndex(ISO sensitivity mapping)

    // Live View & Focus Settings

    // 0xD100: LiveViewStatus(Engages/disengages live view mirrors/sensors)
    // 0xD101: LiveViewDriveMode
    // 0xD103: LiveViewAFArea
    // 0xD108: FocusMode(AF-S, AF-C, Manual)

    // Capture & Shutter

    // 0xD1A0: ShutterSpeed(Nikon extension map for bulb/timed exposures)
    // 0xD1A1: BurstMode0xD140: RecordingMedia(Directing storage to Card Slot 1, Slot 2, or SDRAM tethering)


}
