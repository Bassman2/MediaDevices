using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDeviceApp.ViewModel
{
    public class StorageViewModel : BaseViewModel
    {
        MediaDevice device;
        private List<string> storages;
        private string selectedStorage;
        private MediaStorageInfo mediaStorageInfo;

        public StorageViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.Storages = this.device?.FunctionalObjects(FunctionalCategory.Storage)?.ToList();
            this.SelectedStorage = this.Storages?.FirstOrDefault();
        }
        
        public List<string> Storages
        {
            get
            {
                return this.storages;
            }
            set
            {
                if (this.storages != value)
                {
                    this.storages = value;
                    NotifyPropertyChanged(nameof(Storages));
                }
            }
        }

        public string SelectedStorage
        {
            get
            {
                return this.selectedStorage;
            }
            set
            {
                if (this.selectedStorage != value)
                {
                    this.selectedStorage = value;
                    if (!string.IsNullOrEmpty(this.selectedStorage))
                    {
                        this.mediaStorageInfo = this.device?.GetStorageInfo(this.selectedStorage);
                    }
                    else
                    {
                        this.mediaStorageInfo = null;
                    }
                    NotifyAllPropertiesChanged();
                }
            }
        }

        public MediaStorageInfo Info
        { 
            get
            {
                return this.mediaStorageInfo;
            }
        }

        public StorageType Type
        {
            get
            {
                return this.mediaStorageInfo?.Type ?? StorageType.Undefined;
            }
        }

        public string FileSystemType
        {
            get
            {
                return this.mediaStorageInfo?.FileSystemType;
            }
        }

        public ulong Capacity
        {
            get
            {
                return this.mediaStorageInfo?.Capacity ?? 0;
            }
        }

        public ulong FreeSpaceInBytes
        {
            get
            {
                return this.mediaStorageInfo?.FreeSpaceInBytes ?? 0;
            }
        }

        public ulong FreeSpaceInObjects
        {
            get
            {
                return this.mediaStorageInfo?.FreeSpaceInObjects ?? 0;
            }
        }

        public string Description
        {
            get
            {
                return this.mediaStorageInfo?.Description;
            }
        }

        public string SerialNumber
        {
            get
            {
                return this.mediaStorageInfo?.SerialNumber;
            }
        }

        public ulong MaxObjectSize
        {
            get
            {
                return this.mediaStorageInfo?.MaxObjectSize ?? 0;
            }
        }

        public ulong CapacityInObjects
        {
            get
            {
                return this.mediaStorageInfo?.CapacityInObjects ?? 0;
            }
        }

        public StorageAccessCapability AccessCapability
        {
            get
            {
                return this.mediaStorageInfo?.AccessCapability ?? 0;
            }
        }
    }
}
