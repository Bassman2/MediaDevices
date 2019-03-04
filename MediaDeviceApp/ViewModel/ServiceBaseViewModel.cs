using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public abstract class ServiceBaseViewModel : BaseViewModel
    {
        protected MediaDevice device;
        protected MediaDeviceService selectedService;
        protected MediaDeviceServices services = MediaDeviceServices.All;

        public virtual void Update(MediaDevice device)
        {
            this.device = device;

            this.Services = this.device?.GetServices(this.services)?.ToList();
            NotifyAllPropertiesChanged();
        }

        public List<MediaDeviceService> Services { get; private set; }

        public MediaDeviceService SelectedService
        {
            get
            {
                return this.selectedService;
            }
            set
            {
                if (this.selectedService != value)
                {
                    //if (this.selectedService != null)
                    //{
                    //    this.selectedService.Close();
                    //}
                    this.selectedService = value;
                    //if (this.selectedService != null)
                    //{
                    //    this.selectedService.Open();
                    //}
                    NotifyAllPropertiesChanged();
                }
            }
        }
    }
}
