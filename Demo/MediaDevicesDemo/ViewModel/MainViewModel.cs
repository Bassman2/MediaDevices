

using System.ComponentModel.DataAnnotations;

namespace MediaDevicesDemo.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly MediaDeviceManager manager;
    //private MediaDevice? device;

    public MainViewModel()
    {
        manager = MediaDeviceManager.Instance;
        Devices = manager.GetDevices()?.ToList() ?? [];
        SelectedDevice = Devices.FirstOrDefault();
        Device = Devices.FirstOrDefault();
        Device?.Connect();
    }

    [ObservableProperty]
    public partial List<MediaDevice> Devices { get; set; }

    [ObservableProperty]
    public partial MediaDevice? SelectedDevice { get; set; }

    partial void OnSelectedDeviceChanged(MediaDevice? value)
    {
        if (Device != null && value != null && Device.Name == value.Description)
        {
            return;
        }
        if (Device != null && Device.IsConnected)
        {
            Device.Disconnect();
        }
        if (value != null)
        {
            value.Connect();
            Device = value;
            
        }
    }

    [RelayCommand]
    private void OnUpdateDevices()
    {
        Devices = manager.GetDevices()?.ToList() ?? [];
        SelectedDevice = Devices.FirstOrDefault(d => d.Description == Device!.Description) ?? Devices.FirstOrDefault();
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(
        nameof(Name), 
        nameof(FriendlyName), 
        nameof(Manufacturer), 
        nameof(Model), 
        nameof(FirmwareVersion), 
        nameof(SerialNumber), 
        nameof(SyncPartner), 
        nameof(PowerSource), 
        nameof(PowerLevel), 
        nameof(Protocol),
        nameof(DateTime),
        nameof(SupportedDrmSchemes),
        nameof(DeviceType),
        nameof(Transport),
        nameof(UseDeviceStage),
        nameof(SupportsNonConsumable),
        nameof(SupportedFormatsAreOrdered),
        nameof(SupportedEvents),
        nameof(SupportedCommands),
        nameof(SupportedContents),
        nameof(FunctionalCategories),
        nameof(VendorExtentionDescription),
        nameof(VendorOpcodes))]
    public partial MediaDevice? Device { get; set; }

    public string? Name => Device?.Description;
    public string? FriendlyName => Device?.FriendlyName;
    public string? Manufacturer => Device?.Manufacturer;
    public string? Model => Device?.Model;
    public string? FirmwareVersion => Device?.FirmwareVersion;
    public string? SerialNumber => Device?.SerialNumber;
    public string? SyncPartner => Device?.SyncPartner;
    public string? PowerSource => Device?.PowerSource.ToString();
    public string? PowerLevel => Device?.PowerLevel.ToString();
    public string? Protocol => Device?.Protocol;
    public string? DateTime => Device?.DateTime.ToString();
    public string? SupportedDrmSchemes => string.Concat(Device?.SupportedDrmSchemes?.Select(t => t + ", ") ?? []).TrimEnd(' ', ',');
    public string? DeviceType => Device?.DeviceType.ToString();
    public string? Transport => Device?.Transport.ToString();
    public string? UseDeviceStage => Device?.UseDeviceStage.ToString();

    public bool? SupportsNonConsumable => Device?.SupportsNonConsumable;
    public bool? SupportedFormatsAreOrdered => Device?.SupportedFormatsAreOrdered;

    public List<string>? SupportedEvents => Device?.SupportedEvents()?.Select(i => i.ToString()).ToList();
    public List<string>? SupportedCommands => Device?.SupportedCommands()?.Select(i => i.ToString()).ToList();
    public List<string>? SupportedContents => Device?.SupportedContentTypes(FunctionalCategory.All)?.Select(i => i.ToString()).ToList();
    public List<string>? FunctionalCategories => Device?.FunctionalCategories()?.Select(i => i.ToString()).ToList();

    public string? VendorExtentionDescription => Device?.VendorExtentionDescription();
    
    public List<string>? VendorOpcodes => Device?.VendorOpcodes().Select(i => i.ToString()).ToList();
}
