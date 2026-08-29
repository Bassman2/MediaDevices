namespace MediaDevices.Internal;

partial class WPD
{
    public static Guid SonyDeviceProperties = new("4D545058-8900-40b3-8F1D-DC246E1E8370");



    #region Standard Base Registers(Shared with Standard PTP)

    public static PropertyKey SonyDevicePropertyCompression = new(SonyDeviceProperties, 0x5004);
    /*
    0x5005: White Balance(Auto, Daylight, Custom presets)
    0x5007: F-Number(Aperture value scaled: e.g., 280 = f/2.8)
    0x500A: Focus Mode(AF-S, AF-C, DMF, Manual Focus)
    0x500B: Exposure Metering Mode(Multi, Center, Spot)
    0x500E: Exposure Program Mode(PASM mode configurations)
    0x5010: Exposure Bias Compensation(EV shift)
    0x5013: Still Capture Mode(Drive modes: Single, Continuous)
    */
    #endregion

    #region Proprietary Sony Custom Extension Registers(0xD200 Block)

    /*
         0xD200: Flash Compensation
        0xD201: Dynamic Range Optimizer(DRO)
        0xD203: Image Size(Output dimensions scale)
        0xD20D: Shutter Speed(Sony specific shutter lookup profile array)
        0xD20E: Battery Level Indicator
        0xD20F: Color Temperature(Direct Kelvin values, e.g., 5500)
        0xD211: Aspect Ratio(3:2, 4:3, 16:9)
        0xD213: Focus Indication(Focus acquisition verification feedback listener)
        0xD218: Battery Remaining(%) (True percentage readout status)
        0xD21B: Picture Effect(Creative profiles layout)
        0xD21D: Movie Recording State(Active movie record status checker)
        0xD21E: ISO Sensitivity(Direct sensor amplification index)
        0xD221: Live View Status(Viewfinder signal buffer state engine)
        0xD222: Still Image Save Destination(PC Only, Camera Memory Only, or PC+Camera)
    */
    #endregion

    #region Remote Programmatic Button Intercepts(Control Handshakes)

    /*
        0xD2C1: Shutter Half-Release(S1) (Simulates half-pressing button for AF)
        0xD2C2: Shutter Release(S2) (Fires capture loop sequence execution)
        0xD2C3: AEL Button Control
        0xD2C8: Movie Rec Button Toggle(Starts or stops internal recording tracks)
        0xD2D7: Focus Step Near(Programmatically shifts focus lens group forward)
        0xD2D8: Focus Step Far(Programmatically shifts focus lens group backward)
        */
    #endregion
}
