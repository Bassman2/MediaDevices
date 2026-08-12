namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{

    //protected MediaDevice device;
    //protected MediaDeviceService selectedService;
    //protected MediaDeviceServices services = MediaDeviceServices.All;

    public List<MediaDeviceServices> ServiceTypes => Enum.GetValues<MediaDeviceServices>().Where(e => e != MediaDeviceServices.Unknown).ToList();

    [ObservableProperty]
    public partial MediaDeviceServices SelectedServiceType { get; set; } = MediaDeviceServices.All;

    partial void OnSelectedServiceTypeChanged(MediaDeviceServices value)
    {
        Services = mediaDevice.GetServices(value).ToList();
    }

    [ObservableProperty]
    public partial List<MediaDeviceService> Services { get; set; }

    [ObservableProperty]
    public partial MediaDeviceService SelectedService { get; set; }
}
