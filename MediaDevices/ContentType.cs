using System;

namespace MediaDevices
{
    /// <summary>
    /// Supported content.
    /// </summary>
    public enum ContentType : ulong
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [EnumGuid]
        Unknown,

        /// <summary>
        /// Indicates this object represents a functional object, not content data on the device.
        /// </summary>
        [EnumGuid(0x99ED0160, 0x17FF, 0x4C44, 0x9D, 0x98, 0x1D, 0x7A, 0x6F, 0x94, 0x19, 0x21)]
        FunctionalObject,

        /// <summary>
        /// Indicates this object is a folder.
        /// </summary>
        [EnumGuid(0x27E2E392, 0xA111, 0x48E0, 0xAB, 0x0C, 0xE1, 0x77, 0x05, 0xA0, 0x5F, 0x85)]
        Folder,

        /// <summary>
        /// Indicates this object represents image data (e.g. a JPEG file)
        /// </summary>
        [EnumGuid(0xef2107d5, 0xa52a, 0x4243, 0xa2, 0x6b, 0x62, 0xd4, 0x17, 0x6d, 0x76, 0x03)]
        Image,

        /// <summary>
        /// Indicates this object represents document data (e.g. a MS WORD file, TEXT file, etc.)
        /// </summary>
        [EnumGuid(0x680ADF52, 0x950A, 0x4041, 0x9B, 0x41, 0x65, 0xE3, 0x93, 0x64, 0x81, 0x55)]
        Document,

        /// <summary>
        /// Indicates this object represents contact data (e.g. name/number, or a VCARD file)
        /// </summary>
        [EnumGuid(0xEABA8313, 0x4525, 0x4707, 0x9F, 0x0E, 0x87, 0xC6, 0x80, 0x8E, 0x94, 0x35)]
        Contact,

        /// <summary>
        /// Indicates this object represents a group of contacts.
        /// </summary>
        [EnumGuid(0x346B8932, 0x4C36, 0x40D8, 0x94, 0x15, 0x18, 0x28, 0x29, 0x1F, 0x9D, 0xE9)]
        ContactGroup,

        /// <summary>
        /// Indicates this object represents audio data (e.g. a WMA or MP3 file)
        /// </summary>
        [EnumGuid(0x4AD2C85E, 0x5E2D, 0x45E5, 0x88, 0x64, 0x4F, 0x22, 0x9E, 0x3C, 0x6C, 0xF0)]
        Audio,

        /// <summary>
        /// Indicates this object represents video data (e.g. a WMV or AVI file)
        /// </summary>
        [EnumGuid(0x9261B03C, 0x3D78, 0x4519, 0x85, 0xE3, 0x02, 0xC5, 0xE1, 0xF5, 0x0B, 0xB9)]
        Video,

        /// <summary>
        /// Indicates this object represents a television recording.
        /// </summary>
        [EnumGuid(0x60A169CF, 0xF2AE, 0x4E21, 0x93, 0x75, 0x96, 0x77, 0xF1, 0x1C, 0x1C, 0x6E)]
        Television,

        /// <summary>
        /// Indicates this object represents a playlist.
        /// </summary>
        [EnumGuid(0x1A33F7E4, 0xAF13, 0x48F5, 0x99, 0x4E, 0x77, 0x36, 0x9D, 0xFE, 0x04, 0xA3)]
        Playlist,

        /// <summary>
        /// Indicates this object represents an album, which may contain objects of different content types (typically, MUSIC, IMAGE and VIDEO).
        /// </summary>
        [EnumGuid(0x00F0C3AC, 0xA593, 0x49AC, 0x92, 0x19, 0x24, 0xAB, 0xCA, 0x5A, 0x25, 0x63)]
        MixedContentAlbum,

        /// <summary>
        /// Indicates this object represents an audio album.
        /// </summary>
        [EnumGuid(0xAA18737E, 0x5009, 0x48FA, 0xAE, 0x21, 0x85, 0xF2, 0x43, 0x83, 0xB4, 0xE6)]
        AudioAlbum,

        /// <summary>
        /// Indicates this object represents an image album.
        /// </summary>
        [EnumGuid(0x75793148, 0x15F5, 0x4A30, 0xA8, 0x13, 0x54, 0xED, 0x8A, 0x37, 0xE2, 0x26)]
        ImageAlbum,

        /// <summary>
        /// Indicates this object represents a video album.
        /// </summary>
        [EnumGuid(0x012B0DB7, 0xD4C1, 0x45D6, 0xB0, 0x81, 0x94, 0xB8, 0x77, 0x79, 0x61, 0x4F)]
        VideoAlbum,

        /// <summary>
        /// Indicates this object represents memo data
        /// </summary>
        [EnumGuid(0x9CD20ECF, 0x3B50, 0x414F, 0xA6, 0x41, 0xE4, 0x73, 0xFF, 0xE4, 0x57, 0x51)]
        Memo,

        /// <summary>
        /// Indicates this object represents e-mail data
        /// </summary> 
        [EnumGuid(0x8038044A, 0x7E51, 0x4F8F, 0x88, 0x3D, 0x1D, 0x06, 0x23, 0xD1, 0x45, 0x33)]
        EMail,

        /// <summary>
        /// Indicates this object represents an appointment in a calendar
        /// </summary>
        [EnumGuid(0x0FED060E, 0x8793, 0x4B1E, 0x90, 0xC9, 0x48, 0xAC, 0x38, 0x9A, 0xC6, 0x31)]
        Appointment,

        /// <summary>
        /// Indicates this object represents a task for tracking (e.g. a TODO list)
        /// </summary>
        [EnumGuid(0x63252F2C, 0x887F, 0x4CB6, 0xB1, 0xAC, 0xD2, 0x98, 0x55, 0xDC, 0xEF, 0x6C)]
        Task,

        /// <summary>
        /// Indicates this object represents a file that can be run. This could be a script, executable and so on.
        /// </summary>
        [EnumGuid(0xD269F96A, 0x247C, 0x4BFF, 0x98, 0xFB, 0x97, 0xF3, 0xC4, 0x92, 0x20, 0xE6)]
        Program,

        /// <summary>
        /// Indicates this object represents a file that does not fall into any of the other predefined WPD types for files.
        /// </summary>
        [EnumGuid(0x0085E0A6, 0x8D34, 0x45D7, 0xBC, 0x5C, 0x44, 0x7E, 0x59, 0xC7, 0x3D, 0x48)]
        GenericFile,

        /// <summary>
        /// Indicates this object represents a calender
        /// </summary>
        [EnumGuid(0xA1FD5967, 0x6023, 0x49A0, 0x9D, 0xF1, 0xF8, 0x06, 0x0B, 0xE7, 0x51, 0xB0)]
        Calendar,

        /// <summary>
        /// Indicates this object represents a message (e.g. SMS message, E-Mail message, etc.)
        /// </summary>
        [EnumGuid(0xE80EAAF8, 0xB2DB, 0x4133, 0xB6, 0x7E, 0x1B, 0xEF, 0x4B, 0x4A, 0x6E, 0x5F)] 
        GenericMessage,

        /// <summary>
        /// Indicates this object represents an association between a host and a device.     
        /// </summary>
        [EnumGuid(0x031DA7EE, 0x18C8, 0x4205, 0x84, 0x7E, 0x89, 0xA1, 0x12, 0x61, 0xD0, 0xF3)]     
        NetworkAssociation,

        /// <summary>
        /// Indicates this object represents certificate used for authentication.
        /// </summary>
        [EnumGuid(0xDC3876E8, 0xA948, 0x4060, 0x90, 0x50, 0xCB, 0xD7, 0x7E, 0x8A, 0x3D, 0x87)]
        Certificate,

        /// <summary>
        /// Indicates this object represents wireless network access information.
        /// </summary>
        [EnumGuid(0x0BAC070A, 0x9F5F, 0x4DA4, 0xA8, 0xF6, 0x3D, 0xE4, 0x4D, 0x68, 0xFD, 0x6C)]
        WirelessProfile,

        /// <summary>
        /// Indicates this object represents a media cast. A media cast object can be though
        /// of as a container object that groups related content, similar to how a playlist 
        /// groups songs to play. Often, a media cast object is used to group media content 
        /// originally published online.
        /// </summary>
        [EnumGuid(0x5E88B3CC, 0x3E65, 0x4E62, 0xBF, 0xFF, 0x22, 0x94, 0x95, 0x25, 0x3A, 0xB0)]
        MediaCast,

        /// <summary>
        /// Indicates this object describes a section of data contained in another object. 
        /// The WPD_OBJECT_REFERENCES property indicates which object contains the actual data.
        /// </summary>
        [EnumGuid(0x821089F5, 0x1D91, 0x4DC9, 0xBE, 0x3C, 0xBB, 0xB1, 0xB3, 0x5B, 0x18, 0xCE)]
        Section,

        /// <summary>
        /// Indicates this object doesn't fall into the predefined WPD content types
        /// </summary>
        [EnumGuid(0x28D8D31E, 0x249C, 0x454E, 0xAA, 0xBC, 0x34, 0x88, 0x31, 0x68, 0xE6, 0x34)]
        Unspecified,

        /// <summary>
        /// This content type is only valid as a parameter to API functions and driver commands. 
        /// It should not be reported as a supported content type by the driver.
        /// </summary>
        [EnumGuid(0x80E170D2, 0x1055, 0x4A3E, 0xB9, 0x52, 0x82, 0xCC, 0x4F, 0x8A, 0x86, 0x89)]
        All                      
    }
}
