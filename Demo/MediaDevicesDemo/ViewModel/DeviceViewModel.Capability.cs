namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region Capability

    public List<string>? SupportedEvents => mediaDevice?.SupportedEvents()?.Select(i => i.ToString()).ToList();
    public List<string>? SupportedCommands => mediaDevice?.SupportedCommands()?.Select(i => i.ToString()).ToList();
    public List<string>? SupportedContents => mediaDevice?.SupportedContentTypes(FunctionalCategory.All)?.Select(i => i.ToString()).ToList();
    public List<string>? FunctionalCategories => mediaDevice?.FunctionalCategories()?.Select(i => i.ToString()).ToList();

    #endregion
}
