using MediaDevices;

namespace MediaDeviceApp.ViewModel
{
    public class ServiceStatusViewModel : ServiceBaseViewModel
    {
        public ServiceStatusViewModel()
        {
            this.services = MediaDeviceServices.Status;
        }

    }
}
