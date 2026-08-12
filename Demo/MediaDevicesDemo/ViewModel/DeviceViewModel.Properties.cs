namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region Properties

    public string? Name => mediaDevice?.Description;
    public string? FriendlyName => mediaDevice?.FriendlyName;
    public string? Manufacturer => mediaDevice?.Manufacturer;
    public string? Model => mediaDevice?.Model;
    public string? FirmwareVersion => mediaDevice?.FirmwareVersion;
    public string? SerialNumber => mediaDevice?.SerialNumber;
    public string? SyncPartner => mediaDevice?.SyncPartner;
    public string? PowerSource => mediaDevice?.PowerSource.ToString();
    public string? PowerLevel => mediaDevice?.PowerLevel.ToString();
    public string? Protocol => mediaDevice?.Protocol;
    public string? DateTime => mediaDevice?.DateTime.ToString();
    public string? SupportedDrmSchemes => string.Concat(mediaDevice?.SupportedDrmSchemes?.Select(t => t + ", ") ?? []).TrimEnd(' ', ',');
    public string? DeviceType => mediaDevice?.DeviceType.ToString();
    public string? Transport => mediaDevice?.Transport.ToString();
    public string? UseDeviceStage => mediaDevice?.UseDeviceStage.ToString();

    public bool? SupportsNonConsumable => mediaDevice?.SupportsNonConsumable;
    public bool? SupportedFormatsAreOrdered => mediaDevice?.SupportedFormatsAreOrdered;

    #endregion

}
