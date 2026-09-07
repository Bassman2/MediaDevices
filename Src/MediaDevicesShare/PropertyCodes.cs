namespace MediaDevices;

public class PropertyCodes
{
    public static Guid DEVICE_PROPERTIES_V1 = new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC);

    public static Guid WPD_PROPERTIES_INTENT_DEVICE_SINK = new("26B40315-C07F-4220-8592-5ED4E831E241");

    public static Guid WPD_PROPERTIES_STILL_IMAGE_CAPTURE_PROP_SINK = new("73C579DA-AADE-47E4-A063-00D5D1D0901E");

    public static Guid WPD_PROPERTIES_MTP_VENDOR_EXTENDED_DEVICE_PROPS = new("4D545058-8900-40B3-8F1D-DC246E1E8370");




    #region PTP

    /// <summary>
    /// The battery level of the device, expressed as a percentage (0-100).
    /// </summary>
    /// <remarks>WPD_DEVICE_POWER_LEVEL</remarks>
    public static readonly PropertyCode BatteryLevel = new PropertyCode(0x5001, DEVICE_PROPERTIES_V1, 4);

    /// <summary>
    /// The functional mode of the device, indicating its current operational state (e.g., normal, sleep, or custom modes). 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode FunctionalMode = new PropertyCode(0x5002);

    /// <summary>
    /// The size of the image to be captured, typically represented as a resolution (e.g., width x height in pixels).
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_IMAGE_SIZE</remarks>
    public static readonly PropertyCode ImageSize = new PropertyCode(0x5003, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_COMPRESSION_SETTING</remarks>
    public static readonly PropertyCode CompressionSetting = new PropertyCode(0x5004, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_WHITE_BALANCE</remarks>
    public static readonly PropertyCode WhiteBalance = new PropertyCode(0x5005, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_RGB_GAIN</remarks>
    public static readonly PropertyCode RGBGain = new PropertyCode(0x5006, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_FNUMBER</remarks>
    public static readonly PropertyCode FNumber = new PropertyCode(0x5007, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_FOCAL_LENGTH</remarks>
    public static readonly PropertyCode FocalLength = new PropertyCode(0x5008, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_FOCUS_DISTANCE</remarks>
    public static readonly PropertyCode FocusDistance = new PropertyCode(0x5009, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_FOCUS_MODE</remarks>
    public static readonly PropertyCode FocusMode = new PropertyCode(0x500A, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_EXPOSURE_METERING_MODE</remarks>
    public static readonly PropertyCode ExposureMeteringMode = new PropertyCode(0x500B, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_FLASH_MODE</remarks>
    public static readonly PropertyCode FlashMode = new PropertyCode(0x500C, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_EXPOSURE_TIME</remarks>
    public static readonly PropertyCode ExposureTime = new PropertyCode(0x500D, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_EXPOSURE_PROGRAM_MODE</remarks>
    public static readonly PropertyCode ExposureProgramMode = new PropertyCode(0x500E, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_EXPOSURE_INDEX</remarks>
    public static readonly PropertyCode ExposureIndex = new PropertyCode(0x500F, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_EXPOSURE_BIAS_COMPENSATION</remarks>
    public static readonly PropertyCode ExposureBiasCompensation = new PropertyCode(0x5010, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_DEVICE_DATETIME</remarks>
    public static readonly PropertyCode DateTime = new PropertyCode(0x5011, DEVICE_PROPERTIES_V1, 11);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_CAPTURE_DELAY</remarks>
    public static readonly PropertyCode CaptureDelay = new PropertyCode(0x5012, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_STILL_CAPTURE_MODE</remarks>
    public static readonly PropertyCode StillCaptureMode = new PropertyCode(0x5013, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_CONTRAST</remarks>
    public static readonly PropertyCode Contrast = new PropertyCode(0x5014, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_SHARPNESS</remarks>
    public static readonly PropertyCode Sharpness = new PropertyCode(0x5015, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_DIGITAL_ZOOM</remarks>
    public static readonly PropertyCode DigitalZoom = new PropertyCode(0x5016, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_EFFECT_MODE</remarks>
    public static readonly PropertyCode EffectMode = new PropertyCode(0x5017, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_BURST_NUMBER</remarks>
    public static readonly PropertyCode BurstNumber = new PropertyCode(0x5018, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_BURST_INTERVAL</remarks>
    public static readonly PropertyCode BurstInterval = new PropertyCode(0x5019, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_TIMELAPSE_NUMBER</remarks>
    public static readonly PropertyCode TimelapseNumber = new PropertyCode(0x501A, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_TIMELAPSE_INTERVAL</remarks>
    public static readonly PropertyCode TimelapseInterval = new PropertyCode(0x501B, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_STILL_IMAGE_FOCUS_METERING_MODE</remarks>
    public static readonly PropertyCode FocusMeteringMode = new PropertyCode(0x501C, "00000000-0000-0000-0000-000000000000", 0);

    #endregion

    #region MTP Extention

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode UploadURL = new PropertyCode(0x501D, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_DEVICE_ARTIST</remarks>
    public static readonly PropertyCode Artist = new PropertyCode(0x501E, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode CopyrightInfo = new PropertyCode(0x501F, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_DEVICE_SYNC_PARTNER</remarks>
    public static readonly PropertyCode SyncPartner = new PropertyCode(0xD401, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_DEVICE_FRIENDLY_NAME</remarks>
    public static readonly PropertyCode DeviceFriendlyName = new PropertyCode(0xD402, DEVICE_PROPERTIES_V1, 2);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>WPD_DEVICE_VOLUME</remarks>
    public static readonly PropertyCode Volume = new PropertyCode(0xD403, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode SupportedFormatsOrdered = new PropertyCode(0xD404, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode DeviceIcon = new PropertyCode(0xD405, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode PlaybackRate = new PropertyCode(0xD406, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode PlaybackObject = new PropertyCode(0xD407, "00000000-0000-0000-0000-000000000000", 0);

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static readonly PropertyCode PlaybackContainerIndex = new PropertyCode(0xD408, "00000000-0000-0000-0000-000000000000", 0);

    #endregion
}
