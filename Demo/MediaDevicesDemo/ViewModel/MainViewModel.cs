

namespace MediaDevicesDemo.ViewModel;

[SupportedOSPlatform("windows")]
public partial class MainViewModel : ObservableObject
{
    private readonly MediaDeviceManager manager;
   // private MediaDevice? device;

    public MainViewModel()
    {
        manager = MediaDeviceManager.Instance;
        Devices = manager.GetDevices()?.ToList() ?? [];
        SelectedDevice = Devices.FirstOrDefault();
        //device = Devices.FirstOrDefault();
        ////device?.Connect();
        //DeviceViewModel = device != null ? new DeviceViewModel(device) : null;
    }

    [ObservableProperty]
    public partial List<MediaDevice> Devices { get; set; }

    [ObservableProperty]
    public partial MediaDevice? SelectedDevice { get; set; }

    partial void OnSelectedDeviceChanged(MediaDevice? oldValue, MediaDevice? newValue)
    {
        if (oldValue != null && newValue != null && oldValue.Description == newValue.Description)
        {
            return;
        }
        if (oldValue != null)
        {
            DeviceViewModel = null;
        }
        if (newValue != null)
        {
            DeviceViewModel = new DeviceViewModel(newValue);
        }
    }

    [ObservableProperty]
    public partial DeviceViewModel? DeviceViewModel { get; set; }

    [RelayCommand]
    private void OnUpdateDevices()
    {
        Devices = manager.GetDevices()?.ToList() ?? [];
        SelectedDevice = Devices.FirstOrDefault(d => d.Description == SelectedDevice?.Description) ?? Devices.FirstOrDefault();
    }

    
    
}
