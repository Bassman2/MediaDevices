using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class ServiceStatusViewModel : BaseViewModel
    {
        private MediaDevice device;
        private MediaDeviceService selectedService;

        public ServiceStatusViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;

            this.MediaDeviceServices = this.device.GetServices(Services.Status).ToList();
            NotifyAllPropertiesChanged();
        }

        public List<MediaDeviceService> MediaDeviceServices { get; private set; }

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
                    if (this.selectedService != null)
                    {
                        this.selectedService.Close();
                    }
                    this.selectedService = value;
                    if (this.selectedService != null)
                    {
                        this.selectedService.Open();
                    }
                }
            }
        }

    }
}
