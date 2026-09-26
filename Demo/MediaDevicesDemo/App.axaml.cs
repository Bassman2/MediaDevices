using Avalonia.Markup.Xaml;
using AvaloniaToolbox.Services;
using MediaDevicesDemo.Services;
using MediaDevicesDemo.Views;

namespace MediaDevicesDemo;

public partial class App : Application
{
    public override void Initialize()
        => AvaloniaXamlLoader.Load(this);


    public override void OnFrameworkInitializationCompleted()
    {
        Ioc.Default.ConfigureServices
        (
            new ServiceCollection()
                .AddSingleton<IApplicationService, ApplicationService>()
                
                .AddSingleton<SettingsService<AppSettings>>()
                .AddSingleton<ISettingsService>(sp => sp.GetRequiredService<SettingsService<AppSettings>>())
                .AddSingleton<ISettingsService<AppSettings>>(sp => sp.GetRequiredService<SettingsService<AppSettings>>())
                
                //.AddSingleton<IBusinessLogic, BusinessLogic>()
                //.AddSingleton<DialogService, DialogService>()

                //.AddSingleton(registry)
                //.AddSingleton<IDialogService, DialogService>()

                // Dialog-Komponenten (Immer Transient!)
                //.AddTransient<GraphView>()
                //.AddTransient<GraphViewModel>()

                .AddSingleton<MainView>()
                .AddSingleton<MainViewModel>()
                //.AddSingleton<UsersViewModel>()
                //.AddSingleton<GroupsViewModel>()
                //.AddSingleton<MembersViewModel>()
                //.AddScoped<EditViewModel>()
                //.AddScoped<SelectUsersViewModel>()
                //.AddScoped<SelectGroupsViewModel>()
                .BuildServiceProvider()
        );

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainViewModel = Ioc.Default.GetRequiredService<MainViewModel>();
            var mainView = Ioc.Default.GetRequiredService<MainView>();
            mainView.DataContext = mainViewModel;
            desktop.MainWindow = mainView;
            //mainViewModel.OnStartup();
        }

        base.OnFrameworkInitializationCompleted();
    }
}