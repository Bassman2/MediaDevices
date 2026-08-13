namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region Drives

    public List<MediaDriveInfo> Drives => [..mediaDevice.GetDrives()];

    #endregion
}
