namespace MediaDevicesDemo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    private void OnApplicationStartup(object sender, StartupEventArgs e)
    {
        //try
        //{
        //    var lastVersion = VersionModel.Load("F:\\public\\bs\\version.json")!.MasterGroupManagerVersion;
        //    var currVersion = Assembly.GetEntryAssembly()!.GetName()!.Version!;

        //    if (lastVersion > currVersion)
        //    {
        //        MessageBox.Show($"Your version {currVersion} is outdated.\r\n Please update to the latest version {lastVersion}.", "Update Required", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        Environment.Exit(0);
        //    }
        //}
        //catch (Exception)
        //{ }

        AppDomain.CurrentDomain.UnhandledException += (s, a) =>
        {
            Exception ex = (Exception)a.ExceptionObject;
            Trace.TraceError(ex.ToString());
            MessageBox.Show(ex.ToString(), "Unhandled Error !!!");
        };

        //Ioc.Default.ConfigureServices
        //(
        //    new ServiceCollection()
        //        .AddSingleton<IBusinessLogic, BusinessLogic>()
        //        .AddSingleton<DialogService, DialogService>()
        //        .AddScoped<MainViewModel>()
        //        .AddScoped<UsersViewModel>()
        //        .AddScoped<GroupsViewModel>()
        //        .AddScoped<MembersViewModel>()
        //        .AddScoped<EditViewModel>()
        //        .AddScoped<SelectUsersViewModel>()
        //        .AddScoped<SelectGroupsViewModel>()
        //        .BuildServiceProvider()
        //);

        new MediaDevicesDemo.View.MainView() { DataContext = new MediaDevicesDemo.ViewModel.MainViewModel() }.Show();
    }

    //protected override void OnExit(ExitEventArgs e)
    //{
    //    Ioc.Default.GetRequiredService<IBusinessLogic>().Dispose();
    //    base.OnExit(e);
    //}
}
