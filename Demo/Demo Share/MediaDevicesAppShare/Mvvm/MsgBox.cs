using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MediaDeviceApp.Mvvm
{
    public static class MsgBox
    {
        public static bool ShowQuestion(string text)
        {
            return MessageBox.Show(Application.Current.MainWindow, text, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(Application.Current.MainWindow, text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
