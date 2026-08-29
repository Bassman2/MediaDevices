namespace MediaDevices.WindowsPortableDevices;

partial class WPD
{
    //Guid wpdDevicePropertiesGuid = new Guid("1f6b2299-9e76-43c8-a2ec-eeef43358afc");

    //// Canon PTP/MTP Extension Property Code for OwnerName is typically 0xD501 (or 54529)
    //int canonOwnerNameId = 0xD501;
    public static Guid CanonDeviceProperties = new Guid("1f6b2299-9e76-43c8-a2ec-eeef43358afc");

    //0xD108 Shooting Mode
    public static PropertyKey CanonDevicePropertyShootingMode = new (CanonDeviceProperties, 0xD108);


    public static PropertyKey CanonDevicePropertyOwnerName = new(CanonDeviceProperties, 0xD501);
    
    // 0xD502 (Artist/Author)
    public static PropertyKey CanonDevicePropertyArtistAuthor = new(CanonDeviceProperties, 0xD502);

    //0xD503 (Copyright)
    public static PropertyKey CanonDevicePropertyCopyright = new(CanonDeviceProperties, 0xD503);

    public static PropertyKey CanonDevicePropertySerial = new(CanonDeviceProperties, 0xD504);

    /*
     
    // Exposure & Core Camera Controls

    0xD101Aperture (F-Number)Controls/reads current lens opening value.
    0xD102Shutter Speed (Tv)Exposure duration value (e.g., 1/250, 1", Bulb).
    0xD103ISO SpeedSensor sensitivity value (e.g., 100, 800, Auto ISO).
    0xD104Exposure MeteringEvaluative, Center-Weighted, Spot, or Partial.
    0xD105Flash ModeInternal/External Speedlite state setup.
    0xD106White BalanceDaylight, Cloudy, Tungsten, Custom, Kelvin, Auto.
    0xD107Exposure Comp.Exposure Compensation adjustment steps.
    0xD108Shooting ModeCurrent position of main dial: Manual, Av, Tv, P, Auto.
    0xD109Focus ModeOne-Shot AF, AI Focus, AI Servo AF, Manual Focus.
    0xD10AWhite Balance TempPrecise Kelvin color temperature setting.
    0xD10BWhite Balance ShiftColor adjustment matrix adjustments (Amber/Blue/Magenta/Green).
    0xD10CZoom PositionLens focal lengths (Supported on specific PowerShot models).
    0xD10DFlash CompensationDirect flash intensity adjustment profile.
    0xD11CCapture DestinationDetermines if shot data writes to 1 (RAM/PC), 2 (SD Card), or 3 (Both).
    0xD11EBracket ModeExposure bracketing settings schema. 
    
    // Picture Styles & Image Quality
    0xD201Image FormatRAW, JPEG Large, JPEG Fine, RAW+JPEG combinations.
    0xD203Picture StyleStandard, Portrait, Landscape, Neutral, Faithful, Monochrome.
    0xD204Color SpaceChoice between sRGB and AdobeRGB.
    0xD205SharpnessPicture Style modification modifier parameter.
    0xD206ContrastPicture Style alteration matrix configuration.
    0xD207Color SaturationPicture Style vibrant color amplification level.
    0xD208Color ToneSkin tone tint balancing configuration adjustments.
    0xD213Auto Lighting Opt.Auto Lighting Optimizer strength index (Off, Low, Standard, High). 
    
    // Metadata & Identity Info
    0xD501Owner NameCustom name assigned to the camera body.
    0xD502Artist / AuthorPhotographer string injected directly to EXIF profiles.
    0xD503Copyright InfoLegal boilerplate metadata sequence string.
    0xD504Serial StringVendor-specific camera frame serial array structure. 
    
    // Camera Status & Physical State
     0xD402Available ShotsRemaining exposure storage space on target media storage.
    0xD405Battery StatusInternal status code (Fully charged, half, critical, AC power).
    0xD406Lens StatusDetects if a lens is currently locked onto the body mount.
    0xD407Card StatusStorage error state flag (No Card, Write Protected, Ready).
    0xD43FLive View StatusDirect boolean check reporting if mirror/sensor stream is active.
     */


    public static Guid WPD_PROPERTY_COMMON_COMMAND_CATEGORY = new Guid(0xF0422A9C, 0x5DC8, 0x44F9, 0xAA, 0x55, 0x5F, 0xA4, 0x57, 0x6F, 0x90, 0x1A);

    public static PropertyKey WPD_COMMAND_COMMON_CATEGORY = new PropertyKey(WPD_PROPERTY_COMMON_COMMAND_CATEGORY, 1);

    public static PropertyKey WPD_COMMAND_COMMON_ID = new PropertyKey(WPD_PROPERTY_COMMON_COMMAND_CATEGORY, 2);

    // MTP-Erweiterungen (Vendor-Befehle laufen über eine eigene Gruppen-GUID)
    public static Guid WPD_PROPERTY_MTP_EXT_OPERATION_CATEGORY = new Guid(0x4D545058, 0x1A2B, 0x3C4D, 0x5E, 0x6F, 0x7A, 0x8B, 0x9C, 0x0D, 0x1E, 0x2F);

    // Der Operations-Code Key verlangt typischerweise pid 2, um den Rohbefehl (z.B. 0x910C) zu fassen
    public static PropertyKey WPD_PROPERTY_MTP_EXT_OPERATION_CODE = new PropertyKey(WPD_PROPERTY_MTP_EXT_OPERATION_CATEGORY, 2);

    public static Guid WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASES = new Guid(0x95156F86, 0x1312, 0x4719, 0xBD, 0xC1, 0xDD, 0x61, 0x84, 0x36, 0x01, 0x33);

}
