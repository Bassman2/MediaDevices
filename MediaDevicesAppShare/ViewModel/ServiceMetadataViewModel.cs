using MediaDevices;

namespace MediaDeviceApp.ViewModel
{
    public class ServiceMetadataViewModel : ServiceBaseViewModel
    {
        public ServiceMetadataViewModel()
        {
            this.services = MediaDeviceServices.Metadata;
        }
    }
}
