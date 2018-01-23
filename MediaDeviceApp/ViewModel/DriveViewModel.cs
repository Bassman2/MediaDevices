using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDeviceApp.ViewModel
{
    public class DriveViewModel : BaseViewModel
    {
        MediaDevice device;
        private List<MediaDriveInfo> drives;
        private MediaDriveInfo selectedDrive;
        public DelegateCommand EjectCommand { get; private set; }
        public DelegateCommand FormatCommand { get; private set; }

    public DriveViewModel()
        {
            this.EjectCommand = new DelegateCommand(OnEject, () => this.SelectedDrive != null);
            this.FormatCommand = new DelegateCommand(OnFormat, () => this.SelectedDrive != null);
        }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.Drives = device.GetDrives().ToList();
            this.SelectedDrive = this.Drives?.FirstOrDefault();
        }

        public List<MediaDriveInfo> Drives
        {
            get
            {
                return this.drives;
            }
            set
            {
                if (this.drives != value)
                {
                    this.drives = value;
                    NotifyPropertyChanged(nameof(Drives));
                }
            }
        }

        public MediaDriveInfo SelectedDrive
        {
            get
            {
                return this.selectedDrive;
            }
            set
            {
                if (this.selectedDrive != value)
                {
                    this.selectedDrive = value;
                    NotifyPropertyChanged(nameof(SelectedDrive));
                }
            }
        }

        private void OnEject()
        {
            this.SelectedDrive?.Eject();
        }

        private void OnFormat()
        {
            this.SelectedDrive?.Format();
        }
    }
}
