using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Threading;

namespace MediaDeviceApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private List<MediaDevice> devices;
        private MediaDevice selectedDevice;
        private bool usePrivateDevices = false;

        public DelegateCommand RefreshCommand { get; private set; }
        public DelegateCommand ResetCommand { get; private set; }

        public InfoViewModel Info { get; private set; }
        public CapabilityViewModel Capability { get; private set; }
        public ContentLocationViewModel ContentLocation { get; private set; }
        public StorageViewModel Storage { get; private set; }
        public FilesViewModel Files { get; private set; }
        public StillImageViewModel StillImage { get; private set; }
        public SmsViewModel Sms { get; private set; }
        public ExplorerViewModel Explorer { get; private set; }
        public VendorViewModel Vendor { get; private set; }

        public MainViewModel()
        {
            this.RefreshCommand = new DelegateCommand(OnRefresh);
            this.ResetCommand = new DelegateCommand(OnReset);

            this.Info = new InfoViewModel();
            this.Capability = new CapabilityViewModel();
            this.ContentLocation = new ContentLocationViewModel();
            this.Storage = new StorageViewModel();
            this.Files = new FilesViewModel();
            this.StillImage = new StillImageViewModel();
            this.Sms = new SmsViewModel();
            this.Explorer = new ExplorerViewModel();
            this.Vendor = new VendorViewModel();
            
            OnRefresh();
        }

        public bool UsePrivateDevices
        {
            get
            {
                return this.usePrivateDevices;
            }
            set
            {
                if (this.usePrivateDevices != value)
                {
                    this.usePrivateDevices = value;
                    OnRefresh();
                    NotifyPropertyChanged(nameof(UsePrivateDevices));
                }
            }
        }

        private void OnRefresh()
        {
            if (this.usePrivateDevices)
            {
                this.Devices = MediaDevice.GetPrivateDevices().ToList();
            }
            else
            {
                this.Devices = MediaDevice.GetDevices().ToList();
            }
            if (this.selectedDevice == null)
            {
                this.SelectedDevice = this.Devices.FirstOrDefault();
            }
        }

        public List<MediaDevice> Devices
        {
            get { return this.devices; }
            set { this.devices = value; NotifyPropertyChanged(nameof(Devices)); }
        }

        public MediaDevice SelectedDevice
        {
            get { return this.selectedDevice; }
            set
            {
                if (value != this.selectedDevice)
                {
                    if (this.selectedDevice != null)
                    {
                        try
                        {
                            this.selectedDevice.Disconnect();
                        }
                        catch { }
                    }
                    this.selectedDevice = value;
                    if (this.selectedDevice != null)
                    {
                        this.selectedDevice.Connect();
                    }
                    NotifyAllPropertiesChanged();
                    
                    this.Info.Update(this.selectedDevice);
                    this.Capability.Update(this.selectedDevice);
                    this.ContentLocation.Update(this.selectedDevice);
                    this.Storage.Update(this.selectedDevice);
                    this.Files.Update(this.selectedDevice);
                    this.StillImage.Update(this.selectedDevice);
                    this.Sms.Update(this.selectedDevice);
                    this.Explorer.Update(this.selectedDevice);
                    this.Vendor.Update(this.selectedDevice);

                    //if (selectedDevice.Description != "My Passport 25E2")
                    //{
                    //    var root = selectedDevice.GetRootDirectory();
                    //    var result = root.EnumerateFileSystemInfos("*", SearchOption.AllDirectories).ToList();
                    //    var files = result.OfType<MediaFileInfo>().ToList();
                    //}

                }
            }
        }
        
        private void OnReset()
        {
            if (MsgBox.ShowQuestion("Do your really want to reset your device?"))
            {
                try
                {
                    this.selectedDevice.ResetDevice();
                }
                catch (Exception ex)
                {
                    MsgBox.ShowError(ex.Message);
                }
            }
        }
    }
}
