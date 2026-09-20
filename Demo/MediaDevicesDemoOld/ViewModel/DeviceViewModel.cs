namespace MediaDevicesDemo.ViewModel;

[SupportedOSPlatform("windows")]
public partial class DeviceViewModel : ObservableObject, IDisposable
{
    private readonly MediaDevice mediaDevice;

    public DeviceViewModel(MediaDevice mediaDevice)
    {
        this.mediaDevice = mediaDevice;
        this.mediaDevice.Connect();

        #region Capability

        FunctionalCategories = [.. mediaDevice.FunctionalCategories()];
        SelectedFunctionalCategory = SelectedContentCategory = FunctionalCategories.FirstOrDefault();

        #endregion

        #region Services

        ServiceTypes = [..Enum.GetValues<MediaDeviceServices>().Where(e => e != MediaDeviceServices.Unknown)];
        SelectedServiceType = MediaDeviceServices.All;
    
        #endregion
    }

    public void Dispose()
    {
        this.mediaDevice.Disconnect();
    }
}
