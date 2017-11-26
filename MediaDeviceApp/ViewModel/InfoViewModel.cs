using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class InfoViewModel : BaseViewModel
    {
        MediaDevice device;

        public InfoViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;
            NotifyAllPropertiesChanged();
        }

        public string DeviceId
        {
            get
            {
                return this.device?.DeviceId;
            }
        }

        public string Description
        {
            get
            {
                return this.device?.Description;
            }
        }

        public string FriendlyName
        {
            get
            {
                return this.device?.FriendlyName;
            }
            set
            {
                this.device.FriendlyName = value;
                NotifyPropertyChanged(nameof(FriendlyName));
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.device?.Manufacturer;
            }
        }

        public string SyncPartner
        {
            get
            {
                return this.device?.SyncPartner;
            }
        }

        public string FirmwareVersion
        {
            get
            {
                return this.device?.FirmwareVersion;
            }
        }

        public string PowerLevel
        {
            get
            {
                return this.device?.PowerLevel.ToString();
            }
        }

        public string PowerSource
        {
            get
            {
                return this.device?.PowerSource.ToString();
            }
        }

        public string Protocol
        {
            get
            {
                return this.device?.Protocol;
            }
        }

        public string Model
        {
            get
            {
                return this.device?.Model;
            }
        }

        public string SerialNumber
        {
            get
            {
                return this.device?.SerialNumber;
            }
        }

        public string SupportsNonConsumable
        {
            get
            {
                return this.device?.SupportsNonConsumable.ToString();
            }
        }

        public string DateTime
        {
            get
            {
                return this.device?.DateTime.ToString();
            }
        }

        public string SupportedFormatsAreOrdered
        {
            get
            {
                return this.device?.SupportedFormatsAreOrdered.ToString();
            }
        }

        public string DeviceType
        {
            get
            {
                return this.device?.DeviceType.ToString();
            }
        }

        public string NetworkIdentifier
        {
            get
            {
                return this.device?.NetworkIdentifier.ToString();
            }
        }

        public string FunctionalUniqueId
        {
            get
            {
                return this.device?.FunctionalUniqueId?.Select(b => b.ToString()).Aggregate((a, b) => $"{a},{b}");
            }
        }

        public string ModelUniqueId
        {
            get
            {
                return this.device?.ModelUniqueId?.Select(b => b.ToString()).Aggregate((a, b) => $"{a},{b}"); 
            }
        }

        public string Transport
        {
            get
            {
                return this.device?.Transport.ToString();
            }
        }

        public string UseDeviceStage
        {
            get
            {
                return this.device?.UseDeviceStage.ToString();
            }
        }

        public string PnPDeviceID
        {
            get
            {
                return this.device?.PnPDeviceID;
            }
        }
    }
}
