

using System.ComponentModel.DataAnnotations;

namespace MediaDevicesDemo.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private readonly MediaDeviceManager manager;
    private MediaDevice? device;

    public MainViewModel()
    {
        manager = MediaDeviceManager.Instance;
        device = manager.GetDevices()!.FirstOrDefault();
        device?.Connect();
    }


    public string? Name => device?.Name;
    public string? FriendlyName => device?.FriendlyName;
    public string? Manufacturer => device?.Manufacturer;
    public string? Model => device?.Model;
    public string? FirmwareVersion => device?.FirmwareVersion;
    public string? SerialNumber => device?.SerialNumber;
    public string? SyncPartner => device?.SyncPartner;
    public string? PowerSource => device?.PowerSource.ToString();
    public string? PowerLevel => device?.PowerLevel.ToString();
    public string? Protocol => device?.Protocol;
    public string? DateTime => device?.DateTime.ToString();
    public string? SupportedDrmSchemes => string.Concat(device?.SupportedDrmSchemes?.Select(t => t + ", ") ?? []).TrimEnd(' ', ',');
    public string? DeviceType => device?.DeviceType.ToString();
    public string? Transport => device?.Transport.ToString();
    public string? UseDeviceStage => device?.UseDeviceStage.ToString();

    public bool? SupportsNonConsumable => device?.SupportsNonConsumable;
    public bool? SupportedFormatsAreOrdered => device?.SupportedFormatsAreOrdered;

    public List<string>? SupportedEvents => device?.SupportedEvents()?.Select(i => i.ToString()).ToList();
    public List<string>? SupportedCommands => device?.SupportedCommands()?.Select(i => i.ToString()).ToList();
    public List<string>? SupportedContents => device?.SupportedContentTypes(FunctionalCategory.All)?.Select(i => i.ToString()).ToList();
    public List<string>? FunctionalCategories => device?.FunctionalCategories()?.Select(i => i.ToString()).ToList();
}
