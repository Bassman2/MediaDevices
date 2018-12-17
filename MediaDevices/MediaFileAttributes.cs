using System;

namespace MediaDevices
{
    /// <summary>
    /// Provides attributes for files, directories and objects.
    /// </summary>
    [Flags]
    public enum MediaFileAttributes
    {
        /// <summary>
        /// The file is a standard file.
        /// </summary>
        Normal = 0x01,

        /// <summary>
        /// The file is a directory.
        /// </summary>
        Directory = 0x02,

        /// <summary>
        /// The file is a object.
        /// </summary>
        Object = 0x04,

        /// <summary>
        /// This file can be deleted.
        /// </summary>
        CanDelete = 0x10,

        /// <summary>
        /// The file is a system file. That is, the file is part of the operating system or is used exclusively by the operating system.
        /// </summary>
        System = 0x20,

        /// <summary>
        /// The file is hidden, and thus is not included in an ordinary directory listing.
        /// </summary>
        Hidden = 0x40,

        /// <summary>
        /// The file is DRM protected.
        /// </summary>
        DRMProtected = 0x80
    }
}
