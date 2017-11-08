using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;

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

        public string DeviceId { get { return this.device?.DeviceId; } }

        public string Description { get { return this.device?.Description; } }

        public string FriendlyName
        {
            get
            {
                try
                {
                    return this.device?.FriendlyName;
                }
                catch { }
                return String.Empty;
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
                try
                {
                    return this.device?.Manufacturer;
                }
                catch { }
                return String.Empty;
            }
        }

        public string SyncPartner
        {
            get
            {
                try
                {
                    return this.device?.SyncPartner;
                }
                catch { }
                return String.Empty;
            }
        }

        public string FirmwareVersion
        {
            get
            {
                try
                {
                    return this.device?.FirmwareVersion;
                }
                catch { }
                return String.Empty;
            }
        }

        public string PowerLevel
        {
            get
            {
                try
                {
                    return this.device?.PowerLevel.ToString();
                }
                catch { }
                return String.Empty;
            }
        }

        public string PowerSource
        {
            get
            {
                try
                {
                    return this.device?.PowerSource.ToString();
                }
                catch { }
                return String.Empty;
            }
        }

        public string Protocol
        {
            get
            {
                try
                {
                    return this.device?.Protocol;
                }
                catch { }
                return String.Empty;
            }
        }

        public string Model
        {
            get
            {
                try
                {
                    return this.device?.Model;
                }
                catch { }
                return String.Empty;
            }
        }

        public string SerialNumber
        {
            get
            {
                try
                {
                    return this.device?.SerialNumber;
                }
                catch { }
                return String.Empty;
            }
        }

        public string SupportsNonConsumable
        {
            get
            {
                try
                {
                    return this.device?.SupportsNonConsumable.ToString();
                }
                catch { }
                return String.Empty;
            }
        }

        public string SupportedFormatsAreOrdered
        {
            get
            {
                try
                {
                    return this.device?.SupportedFormatsAreOrdered.ToString();
                }
                catch { }
                return String.Empty;
            }
        }

        public string DeviceType
        {
            get
            {
                try
                {
                    return this.device?.DeviceType.ToString();
                }
                catch { }
                return String.Empty;
            }
        }

        public string Transport
        {
            get
            {
                try
                {
                    return this.device?.Transport.ToString();
                }
                catch { }
                return String.Empty;
            }
        }

        public string PnPDeviceID
        {
            get
            {
                try
                {
                    return this.device?.PnPDeviceID;
                }
                catch { }
                return String.Empty;
            }
        }
    }
}
