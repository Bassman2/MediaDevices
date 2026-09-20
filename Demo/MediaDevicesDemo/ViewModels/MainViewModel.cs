namespace MediaDevicesDemo.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private const string appAboutUrl = "https://github.com/Bassman2/MediaDevices";
    private readonly IApplicationService applicationService;

    public MainViewModel(IApplicationService applicationService)
    {
        this.applicationService = applicationService;
    }

    [ObservableProperty]
    public partial string StatusText { get; set; } = "Ready";

    [RelayCommand]
    public void OnExit()
        => applicationService.ExitApplication();

    [RelayCommand]
    public void OnSetMode(ThemeVariants themeVariant)
        => applicationService.SetThemeVariant(themeVariant);

    [RelayCommand]
    public void OnAbout()
    => applicationService.OpenUrl(appAboutUrl);

    [RelayCommand]
    public void OnUpdateDevices()
    { }

    

    

    


}
