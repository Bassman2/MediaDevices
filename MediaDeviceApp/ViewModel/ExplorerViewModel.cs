using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class ExplorerViewModel : BaseViewModel
    {
        MediaDevice device;
        List<ItemViewModel> explorerRoot;

        public ExplorerViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;
            MediaDirectoryInfo root = null;
            try
            {
                root = this.device?.GetRootDirectory();
            }
            catch { }
            this.ExplorerRoot = root != null ? new List<ItemViewModel>() { new ItemViewModel(root) } : null;
        }

        public List<ItemViewModel> ExplorerRoot
        {
            get
            {
                return this.explorerRoot;
            }
            set
            {
                this.explorerRoot = value;
                NotifyPropertyChanged(nameof(ExplorerRoot));
            }
        }
    }
}
