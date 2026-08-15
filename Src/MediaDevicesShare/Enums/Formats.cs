namespace MediaDevices;

/// <summary>
/// Formats
/// </summary>
//[FindFieldsGenerator(FindType.Guid)]
public enum Formats : ushort
{
    /// <summary>
    /// Unknown format
    /// </summary>
    [EnumGuid]
    Unknown = 0,
    
    /// <summary>
    /// WPD_OBJECT_FORMAT_UNSPECIFIED
    /// An undefined object format on the mediaDevice (e.g. objects that can not be classified by the other defined WPD format codes)
    /// Device Services FormatId: FORMAT_Undefined
    /// </summary>
    [EnumGuid(0x30000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    Undefined = 0x3000,

    #region 0x30xx

    /// <summary>
    /// WPD_OBJECT_FORMAT_PROPERTIES_ONLY
    /// This object has no data stream and is completely specified by properties only.
    /// Device Services FormatId: FORMAT_Association
    /// </summary>
    [EnumGuid(0x30010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    Association = 0x3001,

    /// <summary>
    /// WPD_OBJECT_FORMAT_SCRIPT
    /// A mediaDevice model-specific script
    /// Device Services FormatId: FORMAT_DeviceScript
    /// </summary>
    [EnumGuid(0x30020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DeviceScript = 0x3002,

    /// <summary>
    /// WPD_OBJECT_FORMAT_EXECUTABLE
    /// A mediaDevice model-specific binary executable
    /// Device Services FormatId: FORMAT_DeviceExecutable
    /// </summary>
    [EnumGuid(0x30030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DeviceExecutable = 0x3003,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TEXT
    /// A text file
    /// Device Services FormatId: FORMAT_TextDocument
    /// </summary>
    [EnumGuid(0x30040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TextDocument = 0x3004,

    /// <summary>
    /// WPD_OBJECT_FORMAT_HTML
    /// A HyperText Markup Language file (text)
    /// Device Services FormatId: FORMAT_HTMLDocument
    /// </summary>
    [EnumGuid(0x30050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    HTMLDocument = 0x3005,

    /// <summary>
    /// WPD_OBJECT_FORMAT_DPOF
    /// A Digital Print Order File (text)
    /// Device Services FormatId: FORMAT_DPOFDocument
    /// </summary>
    [EnumGuid(0x30060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DPOFDocument = 0x3006,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AIFF
    /// Audio file format
    /// Device Services FormatId: FORMAT_AIFFFile
    /// </summary>
    [EnumGuid(0x30070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AIFFFile = 0x3007,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WAVE
    /// Audio file format
    /// Device Services FormatId: FORMAT_WAVFile
    /// </summary>
    [EnumGuid(0x30080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WAVFile = 0x3008,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MP3
    /// Audio file format
    /// Device Services FormatId: FORMAT_MP3File
    /// </summary>
    [EnumGuid(0x30090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MP3File = 0x3009,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AVI
    /// Video file format
    /// Device Services FormatId: FORMAT_AVIFile
    /// </summary>
    [EnumGuid(0x300A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AVIFile = 0x300A,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MPEG
    /// Video file format
    /// Device Services FormatId: FORMAT_MPEGFile
    /// </summary>
    [EnumGuid(0x300B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPEGFile = 0x300B,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ASF
    /// Video file format (Microsoft Advanced Streaming FormatId)
    /// Device Services FormatId: FORMAT_ASFFile
    /// </summary>
    [EnumGuid(0x300C0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ASFFile = 0x300C,

    /// <summary>
    /// (XML_DOCUMENT): Used by Apple to pass configuration files in XML format (such as .plist files) to the MTP subsystem.
    /// </summary>
    PLISTFile = 0x300D,

    #endregion

    #region Image 0x38xx

    /// <summary>
    /// Unknown image object
    /// </summary>
    [EnumGuid(0x38000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    Defined = 0x3800,

    /// <summary>
    /// WPD_OBJECT_FORMAT_EXIF
    ///   Image file format (Exchangeable File FormatId), JEIDA standard
    ///   Device Services FormatId: FORMAT_EXIFImage
    /// </summary>
    [EnumGuid(0x38010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    EXIFImage = 0x3801,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TIFFEP
    /// Image file format (Tag Image File FormatId for Electronic Photography)
    /// Device Services FormatId: FORMAT_TIFFEPImage
    /// </summary>
    [EnumGuid(0x38020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TIFFEPImage = 0x3802,

    /// <summary>
    /// WPD_OBJECT_FORMAT_FLASHPIX
    /// Image file format (Structured Storage Image FormatId)
    /// Device Services FormatId: FORMAT_FlashPixImage
    /// </summary>
    [EnumGuid(0x38030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    FlashPixImage = 0x3803,

    /// <summary>
    /// WPD_OBJECT_FORMAT_BMP
    /// Image file format (Microsoft Windows Bitmap file)
    /// Device Services FormatId: FORMAT_BMPImage
    /// </summary>
    [EnumGuid(0x38040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    BMPImage = 0x3804,

    /// <summary>
    /// WPD_OBJECT_FORMAT_CIFF
    /// Image file format (Canon Camera Image File FormatId)
    /// Device Services FormatId: FORMAT_CIFFImage
    /// </summary>
    [EnumGuid(0x38050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    CIFFImage = 0x3805,

    /// <summary>
    /// WPD_OBJECT_FORMAT_GIF
    /// Image file format (Graphics Interchange FormatId)
    /// Device Services FormatId: FORMAT_GIFImage
    /// </summary>
    [EnumGuid(0x38070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    GIFImage = 0x3807,

    /// <summary>
    /// WPD_OBJECT_FORMAT_JFIF
    /// Image file format (JPEG Interchange FormatId)
    /// Device Services FormatId: FORMAT_JFIFImage
    /// </summary>
    [EnumGuid(0x38080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JFIFImage = 0x3808,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PCD
    /// Image file format (PhotoCD Image Pac)
    /// Device Services FormatId: FORMAT_PCDImage
    /// </summary>
    [EnumGuid(0x38090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PCDImage = 0x3809,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PICT
    /// Image file format (Quickdraw Image FormatId)
    /// Device Services FormatId: FORMAT_PICTImage
    /// </summary>
    [EnumGuid(0x380A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PICTImage = 0x380A,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PNG
    /// Image file format (Portable Network Graphics)
    /// Device Services FormatId: FORMAT_PNGImage
    /// </summary>
    [EnumGuid(0x380B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PNGImage = 0x380B,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TIFF
    /// Image file format (Tag Image File FormatId)
    /// Device Services FormatId: FORMAT_TIFFImage
    /// </summary>
    [EnumGuid(0x380D0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TIFFImage = 0x380D,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TIFFIT
    /// Image file format (Tag Image File FormatId for Informational Technology) Graphic Arts
    /// Device Services FormatId: FORMAT_TIFFITImage
    /// </summary>
    [EnumGuid(0x380E0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TIFFITImage = 0x380E,

    /// <summary>
    /// WPD_OBJECT_FORMAT_JP2
    /// Image file format (JPEG2000 Baseline File FormatId)
    /// Device Services FormatId: FORMAT_JP2Image
    /// </summary>
    [EnumGuid(0x380F0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JP2Image = 0x380F,

    /// <summary>
    /// WPD_OBJECT_FORMAT_JPX
    /// Image file format (JPEG2000 Extended File FormatId)
    /// Device Services FormatId: FORMAT_JPXImage
    /// </summary>
    [EnumGuid(0x38100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JPXImage = 0x3810,

    /// <summary>
    /// Samsung (Digital Negative) 
    /// </summary>
    [EnumGuid(0x38110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DNGFile = 0x3811,

    /// <summary>
    /// Samsung (High Efficiency Image File Format)
    /// </summary>
    [EnumGuid(0x38120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    HEIFFile = 0x3812,

    #endregion

    #region Canon 0xB1xx

    /// <summary>
    /// Canon CRW Format – The legacy Canon RAW format used by older PowerShot and early EOS models. 
    /// </summary>
    CanonCRWFormat = 0xB101,

    /// <summary>
    /// Canon CR2 / CR3 Format – Modern Canon RAW image data formats. 
    /// </summary>
    CanonCR2CR3Format = 0xB103,

    /// <summary>
    /// Canon MOV/MP4 Video – Specific marker for video files recorded using Canon-proprietary codec profiles(e.g., All-I or IPB).
    /// </summary>
    CanonMOVMP4Video = 0xB104,

    #endregion

    #region Apple 0xB4xx

    /// <summary>
    /// 0xB401: Apple Media/Live Photo Link – Meaning: Identifies the primary photo object. It links the various components of a Live Photo (the .HEIC/.JPG image and the .MOV video component).
    /// </summary>
    HEICImage = 0xB401,

    /// <summary>
    /// Apple Metadata / Sidecar File – Meaning: Identifies non-destructive editing data (the typical .AAE files). They tell the system which filters or crops have been applied to the original image.
    /// </summary>
    AAEFile = 0xB402,

    /// <summary>
    /// Apple Directory / Index Configuration: Refers to internal database structures (such as fragments of Photos.sqlite). It helps the MTP driver correctly construct virtual albums and the device's native DCIM folder structure (e.g., 100APPLE).
    /// </summary>
    AppleDirectoryAndIndexConfiguration = 0xB403,

    /// <summary>
    /// Apple Burst Group Marker – Meaning: Used to logically group burst shots so that they appear on the PC as a cohesive series rather than as hundreds of loose, individual images.
    /// </summary>
    AppleBurstGroupMarker = 0xB404,

    /// <summary>
    /// Apple Device Lock &amp; Trust Status – Meaning: Reports whether the iPhone is unlocked and whether the computer has security authorization ("Trust this computer?"). If the device is locked, this property blocks access to the DCIM folder.
    /// </summary>
    AppleDeviceLockAndTrustStatus = 0xB421,

    /// <summary>
    /// Apple Host Connection Mode – Meaning: Controls export behavior. This setting determines whether photos are transferred in their original format (e.g., .HEIC) or automatically converted for the PC (as .JPG) (configurable in iOS settings under Photos → Transfer to Mac or PC).
    /// </summary>
    AppleHostConnectionMode = 0xB422,

    /// <summary>
    /// Apple Camera/Continuity Control – Meaning: Used for advanced camera interactions, such as when the iPhone acts as a webcam for a Mac (Continuity Camera) or when professional import software sends studio commands to the iPhone camera.
    /// </summary>
    AppleCameraContinuityControl = 0xB423,

    #endregion

    #region 0xB8xx

    /// <summary>
    /// Undefined firmware object format.
    /// Used for firmware files that do not match a known format.
    /// Device Services FormatId: FORMAT_UndefinedFirmware
    /// </summary>
    [EnumGuid(0xB8020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    UndefinedFirmware = 0xB802,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WBMP
    /// Image file format (Wireless Application Protocol Bitmap FormatId)
    /// Device Services FormatId: FORMAT_WBMPImage
    /// </summary>
    [EnumGuid(0xB8030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WBMPImage = 0xB803,

    /// <summary>
    /// WPD_OBJECT_FORMAT_JPEGXR
    /// Image file format (JPEG XR, also known as HD Photo)
    /// Device Services FormatId: FORMAT_JPEGXRImage
    /// </summary>
    [EnumGuid(0xB8040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JPEGXRImage = 0xB804,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT
    /// Image file format
    /// Device Services FormatId: FORMAT_HDPhotoImage
    /// </summary>
    [EnumGuid(0xB8810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    HDPhotoImage = 0xB881,

    #endregion

    #region 0xB9xx

    /// <summary>
    /// Undefined audio object format.
    /// Used when an audio file cannot be classified as a known audio format.
    /// Device Services FormatId: FORMAT_UndefinedAudio
    /// </summary>
    [EnumGuid(0xB9000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    UndefinedAudio = 0xB900,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WMA
    /// Audio file format (Windows Media Audio)
    /// Device Services FormatId: FORMAT_WMAFile
    /// </summary>
    [EnumGuid(0xB9010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WMAFile = 0xB901,

    /// <summary>
    /// WPD_OBJECT_FORMAT_OGG
    /// Audio file format
    /// Device Services FormatId: FORMAT_OGGFile
    /// </summary>
    [EnumGuid(0xB9020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    OGGFile = 0xB902,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AAC
    /// Audio file format
    /// Device Services FormatId: FORMAT_AACFile
    /// </summary>
    [EnumGuid(0xB9030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AACFile = 0xB903,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AUDIBLE
    /// Audio file format
    /// Device Services FormatId: FORMAT_AudibleFile
    /// </summary>
    [EnumGuid(0xB9040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AudibleFile = 0xB904,

    /// <summary>
    /// WPD_OBJECT_FORMAT_FLAC
    /// Audio file format
    /// Device Services FormatId: FORMAT_FLACFile
    /// </summary>
    [EnumGuid(0xB9060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    FLACFile = 0xB906,

    /// <summary>
    /// WPD_OBJECT_FORMAT_QCELP
    /// Audio file format (Qualcomm Code Excited Linear Prediction)
    /// Device Services FormatId: FORMAT_QCELPFile
    /// </summary>
    [EnumGuid(0xB9070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    QCELPFile = 0xB907,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AMR
    /// Audio file format (Adaptive Multi-Rate audio codec)
    /// Device Services FormatId: FORMAT_AMRFile
    /// </summary>
    [EnumGuid(0xB9080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AMRFile = 0xB908,

    /// <summary>
    /// Undefined video object format.
    /// Used when a video file cannot be classified as a known video format.
    /// Device Services FormatId: FORMAT_UndefinedVideo
    /// </summary>
    [EnumGuid(0xB9800000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    UndefinedVideo = 0xB980,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WMV
    /// Video file format (Windows Media Video)
    /// Device Services FormatId: FORMAT_WMVFile
    /// </summary>
    [EnumGuid(0xB9810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WMVFile = 0xB981,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MP4
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_MPEG4File
    /// ISO 14496-1
    /// </summary>
    [EnumGuid(0xB9820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPEG4File = 0xB982,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MP2
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_MPEG2File
    /// </summary>
    [EnumGuid(0xB9830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPEG2File = 0xB983,

    /// <summary>
    /// WPD_OBJECT_FORMAT_3GP
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_3GPPFile
    /// 3GPP file format. Details: http://www.3gpp.org/ftp/Specs/html-info/26244.htm (page title - \u201cTransparent end-to-end packet switched streaming service, 3GPP file format\u201d).
    /// </summary>
    [EnumGuid(0xB9840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    _3GPPFile = 0xB984,

    /// <summary>
    /// WPD_OBJECT_FORMAT_3G2
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_3GPP2File
    /// </summary>
    [EnumGuid(0xB9850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    _3GPP2File = 0xB985,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AVCHD
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_AVCHDFile
    /// </summary>
    [EnumGuid(0xB9860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AVCHDFile = 0xB986,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ATSCTS
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_ATSCTSFile
    /// </summary>
    [EnumGuid(0xB9870000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ATSCTSFile = 0xB987,

    /// <summary>
    /// WPD_OBJECT_FORMAT_DVBTS
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_DVBTSFile
    /// </summary>
    [EnumGuid(0xB9880000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DVBTSFile = 0xB988,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MKV
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_MKVFile
    /// </summary>
    [EnumGuid(0xB9900000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MKVFile = 0xB990,

    #endregion

    #region Playlist 0xBAxx

    /// <summary>
    /// Undefined collection/volume object format.
    /// Represents a collection or grouping that does not map to a known format.
    /// Device Services FormatId: FORMAT_UndefinedCollection
    /// </summary>
    [EnumGuid(0xBA000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    UndefinedVollection = 0xBA00,

    /// <summary>
    /// Abstract multimedia album container.
    /// Represents a generic album that may contain mixed media types (images, audio, video).
    /// Device Services FormatId: FORMAT_AbstractMultimediaAlbum
    /// </summary>
    [EnumGuid(0xBA010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractMultimediaAlbum = 0xBA01,

    /// <summary>
    /// Abstract image album container.
    /// Represents an album primarily containing images.
    /// Device Services FormatId: FORMAT_AbstractImageAlbum
    /// </summary>
    [EnumGuid(0xBA020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractImageAlbum = 0xBA02,

    /// <summary>
    /// Abstract audio album container.
    /// Represents an album primarily containing audio tracks.
    /// Device Services FormatId: FORMAT_AbstractAudioAlbum
    /// </summary>
    AbstractAudioAlbum = 0xBA03,

    /// <summary>
    /// Abstract video album container.
    /// Represents an album primarily containing video items.
    /// Device Services FormatId: FORMAT_AbstractVideoAlbum
    /// </summary>
    AbstractVideoAlbum = 0xBA04,

    /// <summary>
    /// Abstract Audio Video Playlist (M3U- or PLS-Playlist-File)
    /// </summary>
    [EnumGuid(0xba050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AAVPlaylist = 0xba05,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP
    /// Generic format for contact group objects
    /// Device Services FormatId: FORMAT_AbstractContactGroup
    /// </summary>
    [EnumGuid(0xBA060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractContactGroup = 0xBA06,

    /// <summary>
    /// Abstract message folder.
    /// Represents a container for message objects (e.g., SMS, MMS).
    /// Device Services FormatId: FORMAT_AbstractMessageFolder
    /// </summary>
    AbstractMessageFolder = 0xBA07,

    /// <summary>
    /// Abstract chaptered production.
    /// Represents media that is divided into chapters (e.g., audiobooks, videos with chapters).
    /// Device Services FormatId: FORMAT_AbstractChapteredProduction
    /// </summary>
    AbstractChapteredProduction = 0xBA08,

    /// <summary>
    /// Abstract audio playlist.
    /// Represents a playlist specifically for audio tracks.
    /// Device Services FormatId: FORMAT_AbstractAudioPlaylist
    /// </summary>
    AbstractAudiPlaylist = 0xBA09,

    /// <summary>
    /// Abstract video playlist.
    /// Represents a playlist specifically for video items.
    /// Device Services FormatId: FORMAT_AbstractVideoPlaylist
    /// </summary>
    AbstractVideoPlaylist = 0xBA0A,
    

    /// <summary>
    /// WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST
    /// MediaCast file format
    /// Device Services FormatId: FORMAT_AbstractMediacast
    /// </summary>
    [EnumGuid(0xBA0B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractMediacast = 0xBA0B,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WPLPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_WPLPlaylist
    /// </summary>
    [EnumGuid(0xBA100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WPLPlaylist = 0xBA10,

    /// <summary>
    /// WPD_OBJECT_FORMAT_M3UPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_M3UPlaylist
    /// </summary>
    [EnumGuid(0xBA110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    M3UPlaylist = 0xBA11,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MPLPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_MPLPlaylist
    /// </summary>
    [EnumGuid(0xBA120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPLPlaylist = 0xBA12,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ASXPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_ASXPlaylist
    /// </summary>
    [EnumGuid(0xBA130000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ASXPlaylist = 0xBA13,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PLSPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_PSLPlaylist
    /// </summary>
    [EnumGuid(0xBA140000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PLSPlaylist = 0xBA14,

    /// <summary>
    /// Undefined document object format.
    /// Used when a document cannot be classified into a known document format.
    /// Device Services FormatId: FORMAT_UndefinedDocument
    /// </summary>
    UndefinedDocument = 0xBA80,

    /// <summary>
    /// Abstract document container.
    /// Represents a generic document object or collection of documents.
    /// Device Services FormatId: FORMAT_AbstractDocument
    /// </summary>
    AbstractDocument = 0xBA81,

    /// <summary>
    /// WPD_OBJECT_FORMAT_XML
    /// XML file format.
    /// Device Services FormatId: FORMAT_XMLDocument
    /// </summary>
    [EnumGuid(0xBA820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    XMLDocument = 0xBA82,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MICROSOFT_WORD
    /// Microsoft Office Word Document file format.
    /// Device Services FormatId: FORMAT_WordDocument
    /// </summary>
    [EnumGuid(0xBA830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WordDocument = 0xBA83,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MHT_COMPILED_HTML
    /// MHT Compiled HTML Document file format.
    /// Device Services FormatId: FORMAT_MHTDocument
    /// </summary>
    [EnumGuid(0xBA840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MHTDocument = 0xBA84,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MICROSOFT_EXCEL
    /// Microsoft Office Excel Document file format.
    /// Device Services FormatId: FORMAT_ExcelDocument
    /// </summary>
    [EnumGuid(0xBA850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ExcelDocument = 0xBA85,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT
    /// Microsoft Office PowerPoint Document file format.
    /// Device Services FormatId: FORMAT_PowerPointDocument
    /// </summary>
    [EnumGuid(0xBA860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PowerPointDocument = 0xBA86,

    #endregion

    #region 0xBBxx

    /// <summary>
    /// Undefined message object format.
    /// Used when a message cannot be classified into a known message format.
    /// Device Services FormatId: FORMAT_UndefinedMessage
    /// </summary>
    UndefinedMessage = 0xBB00,

    /// <summary>
    /// Abstract message container.
    /// Represents a generic message object or collection of messages.
    /// Device Services FormatId: FORMAT_AbstractMessage
    /// </summary>
    AbstractMessage = 0xBB01,

    /// <summary>
    /// Undefined contact object format.
    /// Used when a contact object cannot be classified into a known contact format.
    /// Device Services FormatId: FORMAT_UndefinedContact
    /// </summary>
    UndefinedContact = 0xBB80,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ABSTRACT_CONTACT
    /// Abstract contact file format
    /// Device Services FormatId: FORMAT_AbstractContact
    /// </summary>
    [EnumGuid(0xBB810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractContact = 0xBB81,

    /// <summary>
    /// WPD_OBJECT_FORMAT_VCARD2
    /// VCARD file format (VCARD Version 2)
    /// Device Services FormatId: FORMAT_VCard2Contact
    /// </summary>
    [EnumGuid(0xBB820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    VCard2Contact = 0xBB82,

    /// <summary>
    /// WPD_OBJECT_FORMAT_VCARD3
    /// VCARD file format (VCARD Version 3)
    /// Device Services FormatId: FORMAT_VCard3Contact
    /// </summary>
    [EnumGuid(0xBB830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    VCard3Contact = 0xBB83,

    #endregion

    #region 0xBExx

    /// <summary>
    /// WPD_OBJECT_FORMAT_VCALENDAR1
    /// VCALENDAR file format (VCALENDAR Version 1)
    /// Device Services FormatId: FORMAT_VCalendar1
    /// </summary>
    [EnumGuid(0xBE020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    VCalendar1 = 0xBE02,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ICALENDAR
    /// ICALENDAR file format (VCALENDAR Version 2)
    /// Device Services FormatId: FORMAT_ICalendar
    /// </summary>
    [EnumGuid(0xBE030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ICalendar = 0xBE03,

    #endregion

}