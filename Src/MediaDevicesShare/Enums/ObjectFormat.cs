namespace MediaDevices;

[FindFieldsGenerator(FindType.Guid)]
public enum ObjectFormat
{
    [EnumGuid]
    Unknown,

    // WPD_OBJECT_FORMAT_PROPERTIES_ONLY
    //   This object has no data stream and is completely specified by properties only.
    //   Device Services FormatId: FORMAT_Association
    [EnumGuid(0x30010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    PropertiesOnly,


    //
    // WPD_OBJECT_FORMAT_UNSPECIFIED
    //   An undefined object format on the mediaDevice (e.g. objects that can not be classified by the other defined WPD format codes)
    //   Device Services FormatId: FORMAT_Undefined
    [EnumGuid(0x30000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7)]
    Unspecified

    /*
//
// WPD_OBJECT_FORMAT_SCRIPT
//   A mediaDevice model-specific script
//   Device Services FormatId: FORMAT_DeviceScript
public static Guid OBJECT_FORMAT_SCRIPT = new(0x30020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_EXECUTABLE
//   A mediaDevice model-specific binary executable
//   Device Services FormatId: FORMAT_DeviceExecutable
public static Guid OBJECT_FORMAT_EXECUTABLE = new(0x30030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_TEXT
//   A text file
//   Device Services FormatId: FORMAT_TextDocument
public static Guid OBJECT_FORMAT_TEXT = new(0x30040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_HTML
//   A HyperText Markup Language file (text)
//   Device Services FormatId: FORMAT_HTMLDocument
public static Guid OBJECT_FORMAT_HTML = new(0x30050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_DPOF
//   A Digital Print Order File (text)
//   Device Services FormatId: FORMAT_DPOFDocument
public static Guid OBJECT_FORMAT_DPOF = new(0x30060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_AIFF
//   Audio file format
//   Device Services FormatId: FORMAT_AIFFFile
public static Guid OBJECT_FORMAT_AIFF = new(0x30070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_WAVE
//   Audio file format
//   Device Services FormatId: FORMAT_WAVFile
public static Guid OBJECT_FORMAT_WAVE = new(0x30080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MP3
//   Audio file format
//   Device Services FormatId: FORMAT_MP3File
public static Guid OBJECT_FORMAT_MP3 = new(0x30090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_AVI
//   Video file format
//   Device Services FormatId: FORMAT_AVIFile
public static Guid OBJECT_FORMAT_AVI = new(0x300A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MPEG
//   Video file format
//   Device Services FormatId: FORMAT_MPEGFile
public static Guid OBJECT_FORMAT_MPEG = new(0x300B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_ASF
//   Video file format (Microsoft Advanced Streaming FormatId)
//   Device Services FormatId: FORMAT_ASFFile
public static Guid OBJECT_FORMAT_ASF = new(0x300C0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_EXIF
//   Image file format (Exchangeable File FormatId), JEIDA standard
//   Device Services FormatId: FORMAT_EXIFImage
public static Guid OBJECT_FORMAT_EXIF = new(0x38010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_TIFFEP
//   Image file format (Tag Image File FormatId for Electronic Photography)
//   Device Services FormatId: FORMAT_TIFFEPImage
public static Guid OBJECT_FORMAT_TIFFEP = new(0x38020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_FLASHPIX
//   Image file format (Structured Storage Image FormatId)
//   Device Services FormatId: FORMAT_FlashPixImage
public static Guid OBJECT_FORMAT_FLASHPIX = new(0x38030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_BMP
//   Image file format (Microsoft Windows Bitmap file)
//   Device Services FormatId: FORMAT_BMPImage
public static Guid OBJECT_FORMAT_BMP = new(0x38040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_CIFF
//   Image file format (Canon Camera Image File FormatId)
//   Device Services FormatId: FORMAT_CIFFImage
public static Guid OBJECT_FORMAT_CIFF = new(0x38050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_GIF
//   Image file format (Graphics Interchange FormatId)
//   Device Services FormatId: FORMAT_GIFImage
public static Guid OBJECT_FORMAT_GIF = new(0x38070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_JFIF
//   Image file format (JPEG Interchange FormatId)
//   Device Services FormatId: FORMAT_JFIFImage
public static Guid OBJECT_FORMAT_JFIF = new(0x38080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_PCD
//   Image file format (PhotoCD Image Pac)
//   Device Services FormatId: FORMAT_PCDImage
public static Guid OBJECT_FORMAT_PCD = new(0x38090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_PICT
//   Image file format (Quickdraw Image FormatId)
//   Device Services FormatId: FORMAT_PICTImage
public static Guid OBJECT_FORMAT_PICT = new(0x380A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_PNG
//   Image file format (Portable Network Graphics)
//   Device Services FormatId: FORMAT_PNGImage
public static Guid OBJECT_FORMAT_PNG = new(0x380B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_TIFF
//   Image file format (Tag Image File FormatId)
//   Device Services FormatId: FORMAT_TIFFImage
public static Guid OBJECT_FORMAT_TIFF = new(0x380D0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_TIFFIT
//   Image file format (Tag Image File FormatId for Informational Technology) Graphic Arts
//   Device Services FormatId: FORMAT_TIFFITImage
public static Guid OBJECT_FORMAT_TIFFIT = new(0x380E0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_JP2
//   Image file format (JPEG2000 Baseline File FormatId)
//   Device Services FormatId: FORMAT_JP2Image
public static Guid OBJECT_FORMAT_JP2 = new(0x380F0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_JPX
//   Image file format (JPEG2000 Extended File FormatId)
//   Device Services FormatId: FORMAT_JPXImage
public static Guid OBJECT_FORMAT_JPX = new(0x38100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_WBMP
//   Image file format (Wireless Application Protocol Bitmap FormatId)
//   Device Services FormatId: FORMAT_WBMPImage
public static Guid OBJECT_FORMAT_WBMP = new(0xB8030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_JPEGXR
//   Image file format (JPEG XR, also known as HD Photo)
//   Device Services FormatId: FORMAT_JPEGXRImage
public static Guid OBJECT_FORMAT_JPEGXR = new(0xB8040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT
//   Image file format
//   Device Services FormatId: FORMAT_HDPhotoImage
public static Guid OBJECT_FORMAT_WINDOWSIMAGEFORMAT = new(0xB8810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_WMA
//   Audio file format (Windows Media Audio)
//   Device Services FormatId: FORMAT_WMAFile
public static Guid OBJECT_FORMAT_WMA = new(0xB9010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_WMV
//   Video file format (Windows Media Video)
//   Device Services FormatId: FORMAT_WMVFile
public static Guid OBJECT_FORMAT_WMV = new(0xB9810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_WPLPLAYLIST
//   Playlist file format
//   Device Services FormatId: FORMAT_WPLPlaylist
public static Guid OBJECT_FORMAT_WPLPLAYLIST = new(0xBA100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_M3UPLAYLIST
//   Playlist file format
//   Device Services FormatId: FORMAT_M3UPlaylist
public static Guid OBJECT_FORMAT_M3UPLAYLIST = new(0xBA110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MPLPLAYLIST
//   Playlist file format
//   Device Services FormatId: FORMAT_MPLPlaylist
public static Guid OBJECT_FORMAT_MPLPLAYLIST = new(0xBA120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_ASXPLAYLIST
//   Playlist file format
//   Device Services FormatId: FORMAT_ASXPlaylist
public static Guid OBJECT_FORMAT_ASXPLAYLIST = new(0xBA130000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_PLSPLAYLIST
//   Playlist file format
//   Device Services FormatId: FORMAT_PSLPlaylist
public static Guid OBJECT_FORMAT_PLSPLAYLIST = new(0xBA140000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP
//   Generic format for contact group objects
//   Device Services FormatId: FORMAT_AbstractContactGroup
public static Guid OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP = new(0xBA060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST
//   MediaCast file format
//   Device Services FormatId: FORMAT_AbstractMediacast
public static Guid OBJECT_FORMAT_ABSTRACT_MEDIA_CAST = new(0xBA0B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_VCALENDAR1
//   VCALENDAR file format (VCALENDAR Version 1)
//   Device Services FormatId: FORMAT_VCalendar1
public static Guid OBJECT_FORMAT_VCALENDAR1 = new(0xBE020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_ICALENDAR
//   ICALENDAR file format (VCALENDAR Version 2)
//   Device Services FormatId: FORMAT_ICalendar
public static Guid OBJECT_FORMAT_ICALENDAR = new(0xBE030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_ABSTRACT_CONTACT
//   Abstract contact file format
//   Device Services FormatId: FORMAT_AbstractContact
public static Guid OBJECT_FORMAT_ABSTRACT_CONTACT = new(0xBB810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_VCARD2
//   VCARD file format (VCARD Version 2)
//   Device Services FormatId: FORMAT_VCard2Contact
public static Guid OBJECT_FORMAT_VCARD2 = new(0xBB820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_VCARD3
//   VCARD file format (VCARD Version 3)
//   Device Services FormatId: FORMAT_VCard3Contact
public static Guid OBJECT_FORMAT_VCARD3 = new(0xBB830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_XML
//   XML file format.
//   Device Services FormatId: FORMAT_XMLDocument
public static Guid OBJECT_FORMAT_XML = new(0xBA820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_AAC
//   Audio file format
//   Device Services FormatId: FORMAT_AACFile
public static Guid OBJECT_FORMAT_AAC = new(0xB9030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_AUDIBLE
//   Audio file format
//   Device Services FormatId: FORMAT_AudibleFile
public static Guid OBJECT_FORMAT_AUDIBLE = new(0xB9040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_FLAC
//   Audio file format
//   Device Services FormatId: FORMAT_FLACFile
public static Guid OBJECT_FORMAT_FLAC = new(0xB9060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_QCELP
//   Audio file format (Qualcomm Code Excited Linear Prediction)
//   Device Services FormatId: FORMAT_QCELPFile
public static Guid OBJECT_FORMAT_QCELP = new(0xB9070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_AMR
//   Audio file format (Adaptive Multi-Rate audio codec)
//   Device Services FormatId: FORMAT_AMRFile
public static Guid OBJECT_FORMAT_AMR = new(0xB9080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_OGG
//   Audio file format
//   Device Services FormatId: FORMAT_OGGFile
public static Guid OBJECT_FORMAT_OGG = new(0xB9020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MP4
//   Audio or Video file format
//   Device Services FormatId: FORMAT_MPEG4File
public static Guid OBJECT_FORMAT_MP4 = new(0xB9820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MP2
//   Audio or Video file format
//   Device Services FormatId: FORMAT_MPEG2File
public static Guid OBJECT_FORMAT_MP2 = new(0xB9830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MICROSOFT_WORD
//   Microsoft Office Word Document file format.
//   Device Services FormatId: FORMAT_WordDocument
public static Guid OBJECT_FORMAT_MICROSOFT_WORD = new(0xBA830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MHT_COMPILED_HTML
//   MHT Compiled HTML Document file format.
//   Device Services FormatId: FORMAT_MHTDocument
public static Guid OBJECT_FORMAT_MHT_COMPILED_HTML = new(0xBA840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MICROSOFT_EXCEL
//   Microsoft Office Excel Document file format.
//   Device Services FormatId: FORMAT_ExcelDocument
public static Guid OBJECT_FORMAT_MICROSOFT_EXCEL = new(0xBA850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT
//   Microsoft Office PowerPoint Document file format.
//   Device Services FormatId: FORMAT_PowerPointDocument
public static Guid OBJECT_FORMAT_MICROSOFT_POWERPOINT = new(0xBA860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_3GP
//   Audio or Video file format
//   Device Services FormatId: FORMAT_3GPPFile
public static Guid OBJECT_FORMAT_3GP = new(0xB9840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_3G2
//   Audio or Video file format
//   Device Services FormatId: FORMAT_3GPP2File
public static Guid OBJECT_FORMAT_3G2 = new(0xB9850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_AVCHD
//   Audio or Video file format
//   Device Services FormatId: FORMAT_AVCHDFile
public static Guid OBJECT_FORMAT_AVCHD = new(0xB9860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_ATSCTS
//   Audio or Video file format
//   Device Services FormatId: FORMAT_ATSCTSFile
public static Guid OBJECT_FORMAT_ATSCTS = new(0xB9870000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_DVBTS
//   Audio or Video file format
//   Device Services FormatId: FORMAT_DVBTSFile
public static Guid OBJECT_FORMAT_DVBTS = new(0xB9880000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

//
// WPD_OBJECT_FORMAT_MKV
//   Audio or Video file format
//   Device Services FormatId: FORMAT_MKVFile
public static Guid OBJECT_FORMAT_MKV = new(0xB9900000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

*/
}
