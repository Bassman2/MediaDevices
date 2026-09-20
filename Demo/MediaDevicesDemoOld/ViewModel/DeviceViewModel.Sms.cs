namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region SMS

    public bool IsSmsSupported => mediaDevice.FunctionalCategories()?.Any(c => c == FunctionalCategory.SMS) ?? false;

    public List<string>? SmsFunctionalObjects => mediaDevice.FunctionalObjects(FunctionalCategory.SMS)?.ToList();

    [ObservableProperty]
    public partial string SelectedSmsFunctionalObject { get; set; }

    [ObservableProperty]
    public partial string SmsRecipient { get; set; }

    [ObservableProperty]
    public partial string SmsText { get; set; }

    [RelayCommand]
    private void OnSendTextSMS()
    {
        mediaDevice.SendTextSMS(SelectedSmsFunctionalObject, SmsRecipient, SmsText);
    }

    #endregion
}
