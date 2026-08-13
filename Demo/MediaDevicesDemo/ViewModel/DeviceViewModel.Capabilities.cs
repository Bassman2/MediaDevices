namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region Capability

    public List<FunctionalCategory> FunctionalCategories => [.. mediaDevice.FunctionalCategories()];


    #region Commands

    public List<Commands> Commands => [..mediaDevice.SupportedCommands()];

    [ObservableProperty]
    public partial Commands SelectedCommand { get; set; }

    partial void OnSelectedCommandChanged(Commands value)
    {
        CommandOptions = [..mediaDevice.CommandOptions(value)];
    }

    [ObservableProperty]
    public partial List<(string, string)> CommandOptions { get; set; }

    #endregion

    #region Functional



    [ObservableProperty]
    public partial FunctionalCategory SelectedFunctionalCategory { get; set; }

    partial void OnSelectedFunctionalCategoryChanged(FunctionalCategory value)
    {
        FunctionalObjects = [.. mediaDevice.FunctionalObjects(value)];
    }

    [ObservableProperty]
    public partial List<string> FunctionalObjects { get; set; }

    #endregion

    #region Content

    [ObservableProperty]
    public partial FunctionalCategory SelectedContentCategory { get; set; }

    partial void OnSelectedContentCategoryChanged(FunctionalCategory value)
    {
        ContentTypes = [.. mediaDevice.SupportedContentTypes(value)];
    }

    [ObservableProperty]
    public partial List<ContentType> ContentTypes { get; set; }

    [ObservableProperty]
    public partial ContentType SelectedContentType { get; set; }

    partial void OnSelectedContentTypeChanged(ContentType value)
    {
        Formats = [.. mediaDevice.SupportedFormats(value)];
    }

    [ObservableProperty]
    public partial List<ContentType> Formats { get; set; }

    #endregion

    //#region Format

    //[ObservableProperty]
    //public partial FunctionalCategory SelectedFormatCategory { get; set; }

    //partial void OnSelectedFormatCategoryChanged(FunctionalCategory value)
    //{
    //    ContentTypes = [.. mediaDevice.SupportedFormats(value)];
    //}

    //public List<string>? SupportedContents => mediaDevice.SupportedContentTypes(FunctionalCategory.All)?.Select(i => i.ToString()).ToList();

    //public List<string>? SupportedEvents => mediaDevice?.SupportedEvents()?.Select(i => i.ToString()).ToList();

    //#endregion

    #region Event

    public List<Events> Events => [..mediaDevice.SupportedEvents()];

    #endregion

    #endregion
}
