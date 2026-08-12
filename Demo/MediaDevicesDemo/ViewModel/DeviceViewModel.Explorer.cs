namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region Explorer

    [ObservableProperty]
    public partial string? SelectedDirectory { get; set; }

    [RelayCommand]
    public void OnDirectorySelected(object? selectedItem)
    {
        if (selectedItem is string directory)
        {
            SelectedDirectory = directory;
        }
    }

    #endregion
}
