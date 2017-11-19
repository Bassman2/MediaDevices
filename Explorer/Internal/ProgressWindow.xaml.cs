using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExplorerCtrl.Internal
{
    /// <summary>
    /// Interaction logic for ProgresshWindow.xaml
    /// </summary>
    public partial class ProgresshWindow : Window
    {
        public ProgresshWindow()
        {
            InitializeComponent();
        }

        public void Update(double percentage, string file = null)
        {
            this.progressBar.Value = percentage;
            if (file != null)
            {
                this.currentFile.Text = file;
            }
        }

        public bool IsCancelPendíng { get; private set; }
        
        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.IsCancelPendíng = true;
        }
    }
}
