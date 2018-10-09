using MediaDevices.Internal;
using System.IO;

namespace MediaDevices
{
    /// <summary>
    /// Provides properties for drives.
    /// </summary>
    public sealed class MediaDriveInfo
    {
        private MediaDevice device;
        private string objectId;
        private MediaStorageInfo info;

        internal MediaDriveInfo(MediaDevice device, string objectId)
        {
            this.device = device;
            this.objectId = objectId;
            this.info = device.GetStorageInfo(objectId);

            if (this.info != null)
            {
                this.TotalSize = (long)this.info.Capacity;
                this.TotalFreeSpace = this.AvailableFreeSpace = (long)this.info.FreeSpaceInBytes;

                this.DriveFormat = this.info.FileSystemType;

                switch (this.info.Type)
                {
                case StorageType.FixedRam:
                case StorageType.FixedRom:
                    this.DriveType = DriveType.Fixed;
                    break;
                case StorageType.RemovableRam:
                case StorageType.RemovableRom:
                    this.DriveType = DriveType.Removable;
                    break;
                case StorageType.Undefined:
                default:
                    this.DriveType = DriveType.Unknown;
                    break;
                }


                this.RootDirectory = new MediaDirectoryInfo(this.device, Item.Create(this.device, this.objectId));
                this.Name = this.RootDirectory.FullName;
                this.VolumeLabel = this.info.Description;
            }
        }

        /// <summary>
        /// Indicates the available space in bytes.
        /// </summary>
        public long AvailableFreeSpace { get; private set; }

        /// <summary>
        /// Format of the drive.
        /// </summary>
        public string DriveFormat { get; private set; }

        /// <summary>
        /// Type of the drive
        /// </summary>
        public DriveType DriveType { get; private set; }

        /// <summary>
        /// True is the drive is ready; false if not.
        /// </summary>
        public bool IsReady { get { return true; } }

        /// <summary>
        /// Name of the drive
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Get the root directory of the drive.
        /// </summary>
        public MediaDirectoryInfo RootDirectory { get; private set; }

        /// <summary>
        /// Gets the total free space of the device in bytes.
        /// </summary>
        public long TotalFreeSpace { get; private set; }

        /// <summary>
        /// Gets the total size of the device in bytes.
        /// </summary>
        public long TotalSize { get; private set; }

        /// <summary>
        /// Get the volume lable of the drive.
        /// </summary>
        public string VolumeLabel { get; private set; }

        /// <summary>
        /// Eject the drive.
        /// </summary>
        public void Eject()
        {
            this.device.InternalEject(this.objectId);
        }

        /// <summary>
        /// Format the drive.
        /// </summary>
        public void Format()
        {
            this.device.Format(this.objectId);
        }
    }
}
