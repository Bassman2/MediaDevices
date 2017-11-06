using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    /// <summary>
    /// Provides the base class for both MediaFileInfo and MediaDirectoryInfo objects.
    /// </summary>
    [DebuggerDisplay("{FullName}")]
    public abstract class MediaFileSystemInfo
    {
        /// <summary>
        ///corresponding MediaDevice instance
        /// </summary>
        protected MediaDevice device;

        /// <summary>
        /// MTP id 
        /// </summary>
        protected string id;

        /// <summary>
        /// parent MTP id 
        /// </summary>
        protected string parentId;

        /// <summary>
        /// full name 
        /// </summary>
        protected string fullName;

        /// <summary>
        /// Parent MediaDirectoryInfo instance
        /// </summary>
        protected MediaDirectoryInfo parent;

        internal MediaFileSystemInfo(MediaDevice device, string id)
        {
            this.device = device;
            this.id = id;
            Refresh();
        }

        /// <summary>
        /// Refreshes the state of the object.
        /// </summary>
        public virtual void Refresh()
        {
            ObjectProperties prop = this.device.GetProperties(this.id);

            Guid contentType = prop.ContentType;
            MediaFileAttributes attributes;
            string name;

            if (this.id == Item.RootId)
            {
                name = this.device.DirectorySeparatorChar.ToString();
                attributes = MediaFileAttributes.Object;
            }
            else if (contentType == WPD.CONTENT_TYPE_FUNCTIONAL_OBJECT)
            {
                name = prop.Name;
                attributes = MediaFileAttributes.Object;
            }
            else if (contentType == WPD.CONTENT_TYPE_FOLDER)
            {
                name = prop.OriginalFileName;
                attributes = MediaFileAttributes.Directory;
            }
            else
            {
                name = prop.OriginalFileName;
                attributes = MediaFileAttributes.Normal;
            }

            attributes |= prop.CanDelete ? MediaFileAttributes.CanDelete : 0;
            attributes |= prop.IsSystem ? MediaFileAttributes.System : 0;
            attributes |= prop.IsHidden ? MediaFileAttributes.Hidden : 0;
            attributes |= prop.IsDRMProtected ? MediaFileAttributes.DRMProtected : 0;

            this.Name = name;
            this.Length = prop.Size;
            this.CreationTime = prop.DateCreated;
            this.LastWriteTime = prop.DateModified;
            this.DateAuthored = prop.DateAuthored;
            this.Attributes = attributes;
            this.parentId = prop.ParentId;
            this.parent = null;     // create once if needed
            this.fullName = null;   // create once if needed
        }

        /// <summary>
        /// Gets the parent directory of a specified subdirectory.
        /// </summary>
        protected MediaDirectoryInfo GetParent()
        {
            return this.parent ?? (string.IsNullOrEmpty(this.parentId) ? null : (this.parent = new MediaDirectoryInfo(this.device, this.parentId)));
        }

        /// <summary>
        /// Gets the full path of the directory or file.
        /// </summary>
        public string FullName
        {
            get { return this.fullName ?? (this.id == Item.RootId ? this.device.DirectorySeparatorChar.ToString() : (this.fullName = this.device.GetPath(this.id))); }
        }

        /// <summary>
        /// For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the size, in bytes, of the current file.   
        /// </summary>
        public ulong Length { get; internal set; }

        /// <summary>
        /// Gets the creation time of the current file or directory.
        /// </summary>
        public DateTime? CreationTime { get; internal set; }

        /// <summary>
        /// Gets the time when the current file or directory was last written to.
        /// </summary>
        public DateTime? LastWriteTime { get; internal set; }

        /// <summary>
        /// Gets the time when the current file was authored.
        /// </summary>
        public DateTime? DateAuthored { get; internal set; }

        /// <summary>
        /// Gets the attributes for the current file, directory or object.
        /// </summary>
        public MediaFileAttributes Attributes { get; internal set; }
    }
}
