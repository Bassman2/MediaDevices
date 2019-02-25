using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDeviceApp.ViewModel
{
    public class ServiceMetadataViewModel : BaseViewModel
    {
        private MediaDevice device;
        private MediaDeviceService selectedService;

        public ServiceMetadataViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;

            this.MediaDeviceServices = this.device.GetServices(Services.Metadata)?.ToList();
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
