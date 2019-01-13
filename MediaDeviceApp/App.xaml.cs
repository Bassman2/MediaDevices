using MediaDeviceApp.View;
using MediaDeviceApp.ViewModel;
using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Windows;

namespace MediaDeviceApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += (s, a) =>
            {
                Exception ex = (Exception)a.ExceptionObject;
                Trace.TraceError(ex.ToString());
                MessageBox.Show(ex.ToString(), "Unhandled Error !!!");
            };

            new MainView() { DataContext = new MainViewModel() }.Show();
        }
    }
}
