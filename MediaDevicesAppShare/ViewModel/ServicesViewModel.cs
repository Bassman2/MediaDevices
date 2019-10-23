using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class ServicesViewModel : BaseViewModel
    {
        private MediaDevice device;

        public ServicesViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;
            NotifyAllPropertiesChanged();
        }

        public List<string> All
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.All)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> Contacts
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Contact)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> Calendars
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Calendar)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> Notes
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Notes)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> Tasks
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Task)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> Statuses
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Status)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> Hints
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Hints)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> DeviceMetadatas
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Metadata)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> Ringtones
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.Ringtone)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> EnumerationSynchronizations
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.EnumerationSynchronization)?.Select(s => s.ToString()).ToList();
            }
        }

        public List<string> AnchorSynchronizations
        {
            get
            {
                return this.device?.GetServices(MediaDeviceServices.AnchorSynchronization)?.Select(s => s.ToString()).ToList();
            }
        }
    }
}
