using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
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

        public long AvailableFreeSpace
        { get; private set; }

        public string DriveFormat
        { get; private set; }

        public DriveType DriveType
        { get; private set; }

        public bool IsReady
        { get { return true; } }

        public string Name
        { get; private set; }

        public MediaDirectoryInfo RootDirectory
        { get; private set; }

        public long TotalFreeSpace
        { get; private set; }

        public long TotalSize
        { get; private set; }

        public string VolumeLabel
        { get; private set; }

        public void Eject()
        {
            this.device.Eject(this.objectId);
        }

        public void Format()
        {
            this.device.Format(this.objectId);
        }
    }
}
