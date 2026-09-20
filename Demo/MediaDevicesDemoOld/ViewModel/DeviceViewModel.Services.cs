namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    [ObservableProperty]
    public partial List<MediaDeviceServices> ServiceTypes { get; set; }

    [ObservableProperty]
    public partial MediaDeviceServices SelectedServiceType { get; set; }

    partial void OnSelectedServiceTypeChanged(MediaDeviceServices value)
    {
        Services = mediaDevice.GetServices(value).ToList();
    }

    [ObservableProperty]
    public partial List<MediaDeviceService> Services { get; set; }

    [ObservableProperty]
    public partial MediaDeviceService SelectedService { get; set; }
}
