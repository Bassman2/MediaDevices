namespace MediaDevices;

/// <summary>
/// Formats
/// </summary>
[FindFieldsGenerator(FindType.Guid)]
public enum Formats
{
    /// <summary>
    /// Unknown format
    /// </summary>
    [EnumGuid]
    Unknown,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PROPERTIES_ONLY
    /// This object has no data stream and is completely specified by properties only.
    /// Device Services FormatId: FORMAT_Association
    /// </summary>
    [EnumGuid(0x30010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    Association,

    /// <summary>
    /// WPD_OBJECT_FORMAT_UNSPECIFIED
    /// An undefined object format on the mediaDevice (e.g. objects that can not be classified by the other defined WPD format codes)
    /// Device Services FormatId: FORMAT_Undefined
    /// </summary>
    [EnumGuid(0x30000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    Undefined,

    /// <summary>
    /// WPD_OBJECT_FORMAT_SCRIPT
    /// A mediaDevice model-specific script
    /// Device Services FormatId: FORMAT_DeviceScript
    /// </summary>
    [EnumGuid(0x30020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DeviceScript,

    /// <summary>
    /// WPD_OBJECT_FORMAT_EXECUTABLE
    /// A mediaDevice model-specific binary executable
    /// Device Services FormatId: FORMAT_DeviceExecutable
    /// </summary>
    [EnumGuid(0x30030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DeviceExecutable,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TEXT
    /// A text file
    /// Device Services FormatId: FORMAT_TextDocument
    /// </summary>
    [EnumGuid(0x30040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TextDocument,

    /// <summary>
    /// WPD_OBJECT_FORMAT_HTML
    /// A HyperText Markup Language file (text)
    /// Device Services FormatId: FORMAT_HTMLDocument
    /// </summary>
    [EnumGuid(0x30050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    HTMLDocument,

    /// <summary>
    /// WPD_OBJECT_FORMAT_DPOF
    /// A Digital Print Order File (text)
    /// Device Services FormatId: FORMAT_DPOFDocument
    /// </summary>
    [EnumGuid(0x30060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DPOFDocument,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AIFF
    /// Audio file format
    /// Device Services FormatId: FORMAT_AIFFFile
    /// </summary>
    [EnumGuid(0x30070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AIFFFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WAVE
    /// Audio file format
    /// Device Services FormatId: FORMAT_WAVFile
    /// </summary>
    [EnumGuid(0x30080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WAVFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MP3
    /// Audio file format
    /// Device Services FormatId: FORMAT_MP3File
    /// </summary>
    [EnumGuid(0x30090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MP3File,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AVI
    /// Video file format
    /// Device Services FormatId: FORMAT_AVIFile
    /// </summary>
    [EnumGuid(0x300A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AVIFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MPEG
    /// Video file format
    /// Device Services FormatId: FORMAT_MPEGFile
    /// </summary>
    [EnumGuid(0x300B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPEGFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ASF
    /// Video file format (Microsoft Advanced Streaming FormatId)
    /// Device Services FormatId: FORMAT_ASFFile
    /// </summary>
    [EnumGuid(0x300C0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ASFFile,

    #region Image

    /// <summary>
    /// WPD_OBJECT_FORMAT_EXIF
    ///   Image file format (Exchangeable File FormatId), JEIDA standard
    ///   Device Services FormatId: FORMAT_EXIFImage
    /// </summary>
    [EnumGuid(0x38010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    EXIFImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TIFFEP
    /// Image file format (Tag Image File FormatId for Electronic Photography)
    /// Device Services FormatId: FORMAT_TIFFEPImage
    /// </summary>
    [EnumGuid(0x38020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TIFFEPImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_FLASHPIX
    /// Image file format (Structured Storage Image FormatId)
    /// Device Services FormatId: FORMAT_FlashPixImage
    /// </summary>
    [EnumGuid(0x38030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    FlashPixImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_BMP
    /// Image file format (Microsoft Windows Bitmap file)
    /// Device Services FormatId: FORMAT_BMPImage
    /// </summary>
    [EnumGuid(0x38040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    BMPImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_CIFF
    /// Image file format (Canon Camera Image File FormatId)
    /// Device Services FormatId: FORMAT_CIFFImage
    /// </summary>
    [EnumGuid(0x38050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    CIFFImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_GIF
    /// Image file format (Graphics Interchange FormatId)
    /// Device Services FormatId: FORMAT_GIFImage
    /// </summary>
    [EnumGuid(0x38070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    GIFImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_JFIF
    /// Image file format (JPEG Interchange FormatId)
    /// Device Services FormatId: FORMAT_JFIFImage
    /// </summary>
    [EnumGuid(0x38080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JFIFImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PCD
    /// Image file format (PhotoCD Image Pac)
    /// Device Services FormatId: FORMAT_PCDImage
    /// </summary>
    [EnumGuid(0x38090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PCDImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PICT
    /// Image file format (Quickdraw Image FormatId)
    /// Device Services FormatId: FORMAT_PICTImage
    /// </summary>
    [EnumGuid(0x380A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PICTImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PNG
    /// Image file format (Portable Network Graphics)
    /// Device Services FormatId: FORMAT_PNGImage
    /// </summary>
    [EnumGuid(0x380B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PNGImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TIFF
    /// Image file format (Tag Image File FormatId)
    /// Device Services FormatId: FORMAT_TIFFImage
    /// </summary>
    [EnumGuid(0x380D0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TIFFImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_TIFFIT
    /// Image file format (Tag Image File FormatId for Informational Technology) Graphic Arts
    /// Device Services FormatId: FORMAT_TIFFITImage
    /// </summary>
    [EnumGuid(0x380E0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    TIFFITImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_JP2
    ///   Image file format (JPEG2000 Baseline File FormatId)
    ///   Device Services FormatId: FORMAT_JP2Image
    /// </summary>
    [EnumGuid(0x380F0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JP2Image,

    /// <summary>
    /// WPD_OBJECT_FORMAT_JPX
    /// Image file format (JPEG2000 Extended File FormatId)
    /// Device Services FormatId: FORMAT_JPXImage
    /// </summary>
    [EnumGuid(0x38100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JPXImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WBMP
    /// Image file format (Wireless Application Protocol Bitmap FormatId)
    /// Device Services FormatId: FORMAT_WBMPImage
    /// </summary>
    [EnumGuid(0xB8030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WBMPImage,

    /// <summary>
    // WPD_OBJECT_FORMAT_JPEGXR
    //   Image file format (JPEG XR, also known as HD Photo)
    //   Device Services FormatId: FORMAT_JPEGXRImage
    /// </summary>
    [EnumGuid(0xB8040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    JPEGXRImage,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT
    /// Image file format
    /// Device Services FormatId: FORMAT_HDPhotoImage
    /// </summary>
    [EnumGuid(0xB8810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    HDPhotoImage,

    #endregion

    /// <summary>
    /// WPD_OBJECT_FORMAT_WMA
    /// Audio file format (Windows Media Audio)
    /// Device Services FormatId: FORMAT_WMAFile
    /// </summary>
    [EnumGuid(0xB9010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WMAFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_WMV
    /// Video file format (Windows Media Video)
    /// Device Services FormatId: FORMAT_WMVFile
    /// </summary>
    [EnumGuid(0xB9810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WMVFile,

    #region Playlist

    /// <summary>
    /// WPD_OBJECT_FORMAT_WPLPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_WPLPlaylist
    /// </summary>
    [EnumGuid(0xBA100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WPLPlaylist,

    /// <summary>
    /// WPD_OBJECT_FORMAT_M3UPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_M3UPlaylist
    /// </summary>
    [EnumGuid(0xBA110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    M3UPlaylist,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MPLPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_MPLPlaylist
    /// </summary>
    [EnumGuid(0xBA120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPLPlaylist,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ASXPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_ASXPlaylist
    /// </summary>
    [EnumGuid(0xBA130000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ASXPlaylist,

    /// <summary>
    /// WPD_OBJECT_FORMAT_PLSPLAYLIST
    /// Playlist file format
    /// Device Services FormatId: FORMAT_PSLPlaylist
    /// </summary>
    [EnumGuid(0xBA140000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PSLPlaylist,

    #endregion

    /// <summary>
    /// WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP
    /// Generic format for contact group objects
    /// Device Services FormatId: FORMAT_AbstractContactGroup
    /// </summary>
    [EnumGuid(0xBA060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractContactGroup,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST
    /// MediaCast file format
    /// Device Services FormatId: FORMAT_AbstractMediacast
    /// </summary>
    [EnumGuid(0xBA0B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractMediacast,

    /// <summary>
    /// WPD_OBJECT_FORMAT_VCALENDAR1
    /// VCALENDAR file format (VCALENDAR Version 1)
    /// Device Services FormatId: FORMAT_VCalendar1
    /// </summary>
    [EnumGuid(0xBE020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    VCalendar1,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ICALENDAR
    /// ICALENDAR file format (VCALENDAR Version 2)
    /// Device Services FormatId: FORMAT_ICalendar
    /// </summary>
    [EnumGuid(0xBE030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ICalendar,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ABSTRACT_CONTACT
    /// Abstract contact file format
    /// Device Services FormatId: FORMAT_AbstractContact
    /// </summary>
    [EnumGuid(0xBB810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AbstractContact,

    /// <summary>
    /// WPD_OBJECT_FORMAT_VCARD2
    /// VCARD file format (VCARD Version 2)
    /// Device Services FormatId: FORMAT_VCard2Contact
    /// </summary>
    [EnumGuid(0xBB820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    VCard2Contact,

    /// <summary>
    /// WPD_OBJECT_FORMAT_VCARD3
    /// VCARD file format (VCARD Version 3)
    /// Device Services FormatId: FORMAT_VCard3Contact
    /// </summary>
    [EnumGuid(0xBB830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    VCard3Contact,

    /// <summary>
    /// WPD_OBJECT_FORMAT_XML
    /// XML file format.
    /// Device Services FormatId: FORMAT_XMLDocument
    /// </summary>
    [EnumGuid(0xBA820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    XMLDocument,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AAC
    /// Audio file format
    /// Device Services FormatId: FORMAT_AACFile
    /// </summary>
    [EnumGuid(0xB9030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AACFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AUDIBLE
    /// Audio file format
    /// Device Services FormatId: FORMAT_AudibleFile
    /// </summary>
    [EnumGuid(0xB9040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AudibleFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_FLAC
    /// Audio file format
    /// Device Services FormatId: FORMAT_FLACFile
    /// </summary>
    [EnumGuid(0xB9060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    FLACFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_QCELP
    /// Audio file format (Qualcomm Code Excited Linear Prediction)
    /// Device Services FormatId: FORMAT_QCELPFile
    /// </summary>
    [EnumGuid(0xB9070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    QCELPFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AMR
    /// Audio file format (Adaptive Multi-Rate audio codec)
    /// Device Services FormatId: FORMAT_AMRFile
    /// </summary>
    [EnumGuid(0xB9080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AMRFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_OGG
    /// Audio file format
    /// Device Services FormatId: FORMAT_OGGFile
    /// </summary>
    [EnumGuid(0xB9020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    OGGFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MP4
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_MPEG4File
    /// </summary>
    [EnumGuid(0xB9820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPEG4File,

    /// <summary>
    // WPD_OBJECT_FORMAT_MP2
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_MPEG2File
    /// </summary>
    [EnumGuid(0xB9830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MPEG2File,

    #region Document

    /// <summary>
    /// WPD_OBJECT_FORMAT_MICROSOFT_WORD
    /// Microsoft Office Word Document file format.
    /// Device Services FormatId: FORMAT_WordDocument
    /// </summary>
    [EnumGuid(0xBA830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    WordDocument,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MHT_COMPILED_HTML
    /// MHT Compiled HTML Document file format.
    /// Device Services FormatId: FORMAT_MHTDocument
    /// </summary>
    [EnumGuid(0xBA840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MHTDocument,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MICROSOFT_EXCEL
    /// Microsoft Office Excel Document file format.
    /// Device Services FormatId: FORMAT_ExcelDocument
    /// </summary>
    [EnumGuid(0xBA850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ExcelDocument,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT
    /// Microsoft Office PowerPoint Document file format.
    /// Device Services FormatId: FORMAT_PowerPointDocument
    /// </summary>
    [EnumGuid(0xBA860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PowerPointDocument,

    #endregion

    /// <summary>
    /// WPD_OBJECT_FORMAT_3GP
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_3GPPFile
    /// </summary>
    [EnumGuid(0xB9840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    _3GPPFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_3G2
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_3GPP2File
    /// </summary>
    [EnumGuid(0xB9850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    _3GPP2File,

    /// <summary>
    /// WPD_OBJECT_FORMAT_AVCHD
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_AVCHDFile
    /// </summary>
    [EnumGuid(0xB9860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AVCHDFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_ATSCTS
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_ATSCTSFile
    /// </summary>
    [EnumGuid(0xB9870000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    ATSCTSFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_DVBTS
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_DVBTSFile
    /// </summary>
    [EnumGuid(0xB9880000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DVBTSFile,

    /// <summary>
    /// WPD_OBJECT_FORMAT_MKV
    /// Audio or Video file format
    /// Device Services FormatId: FORMAT_MKVFile
    /// </summary>
    [EnumGuid(0xB9900000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    MKVFile,


    #region Vendor

    // Was bedeutet 38110000-ae6c-4804-98ba-c57b46965fe7 als Format in MTP bei einem Samsung Handy

    /// <summary>
    /// Samsung (Digital Negative) 
    /// </summary>
    // 
    [EnumGuid(0x38110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    DNGFile,

    /// <summary>
    /// Samsung (High Efficiency Image File Format)
    /// </summary>
    [EnumGuid(0x38120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    HEIFFile,


    /// <summary>
    /// Abstract Audio Video Playlist (M3U- or PLS-Playlist-File)
    /// </summary>
    [EnumGuid(0xba050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    AAVPlaylist,
    
    #endregion
}