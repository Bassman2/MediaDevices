using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDeviceApp.ViewModel
{
    public class FilesViewModel : BaseViewModel
    {
        MediaDevice device;
        private string filter = "*";
        private bool useRecursive = true;
        private long numOfFiles;
        private List<MediaFileSystemInfo> files;

        public DelegateCommand EnumerateCommand { get; private set; }


        public FilesViewModel()
        {
            this.EnumerateCommand = new DelegateCommand(OnEnumerate);
        }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.Files = null;
        }

        public string Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
                NotifyPropertyChanged(nameof(Filter));
            }
        }


        public bool UseRecursive
        {
            get
            {
                return this.useRecursive;
            }
            set
            {
                this.useRecursive = value;
                NotifyPropertyChanged(nameof(UseRecursive));
            }
        }

        public long NumOfFiles
        {
            get
            {
                return this.numOfFiles;
            }
            set
            {
                this.numOfFiles = value;
                NotifyPropertyChanged(nameof(NumOfFiles));
            }
        }

        public List<MediaFileSystemInfo> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
                this.NumOfFiles = this.files?.Count ?? 0;
                NotifyPropertyChanged(nameof(Files));
            }
        }

        private void OnEnumerate()
        {
            using (new WaitCursor())
            {
                this.Files = this.device.GetRootDirectory().EnumerateFileSystemInfos(this.Filter, this.UseRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).CatchExceptions().ToList();
            }
        }
    }
}
