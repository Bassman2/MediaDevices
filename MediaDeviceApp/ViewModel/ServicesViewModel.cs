using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return this.device?.GetServices(Services.All)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> Contacts
        {
            get
            {
                return this.device?.GetServices(Services.Contact)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> Calendars
        {
            get
            {
                return this.device?.GetServices(Services.Calendar)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> Notes
        {
            get
            {
                return this.device?.GetServices(Services.Notes)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> Tasks
        {
            get
            {
                return this.device?.GetServices(Services.Task)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> Statuses
        {
            get
            {
                return this.device?.GetServices(Services.Status)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> Hints
        {
            get
            {
                return this.device?.GetServices(Services.Hints)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> DeviceMetadatas
        {
            get
            {
                return this.device?.GetServices(Services.Metadata)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> Ringtones
        {
            get
            {
                return this.device?.GetServices(Services.Ringtone)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> EnumerationSynchronizations
        {
            get
            {
                return this.device?.GetServices(Services.EnumerationSynchronization)?.Select(s => s.ServiceName).ToList();
            }
        }

        public List<string> AnchorSynchronizations
        {
            get
            {
                return this.device?.GetServices(Services.AnchorSynchronization)?.Select(s => s.ServiceName).ToList();
            }
        }
    }
}
