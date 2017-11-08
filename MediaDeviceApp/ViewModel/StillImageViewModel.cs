using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MediaDeviceApp.ViewModel
{
    public class StillImageViewModel : BaseViewModel
    {
        MediaDevice device;
        private bool isStillImageSupported;
        private List<string> stillImageFunctionalObjects;
        private string selectedStillImageFunctionalObject;
        private ImageSource stillImageSource;

        private DispatcherTimer stillImageTimer;

        public DelegateCommand StillImageCommand { get; private set; }

        public StillImageViewModel()
        {
            this.StillImageCommand = new DelegateCommand(OnStillImageCapture);

            this.stillImageTimer = new DispatcherTimer();
            this.stillImageTimer.Tick += OnStillImageTimer;
            this.stillImageTimer.Interval = new TimeSpan(0, 0, 2);
        }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.IsStillImageSupported = this.device?.FunctionalCategories().Any(c => c == FunctionalCategory.StillImageCapture) ?? false;
            this.StillImageFunctionalObjects = this.device?.FunctionalObjects(FunctionalCategory.StillImageCapture).ToList();
        }
        
        public bool IsStillImageSupported
        {
            get
            {
                return this.isStillImageSupported;
            }
            set
            {
                this.isStillImageSupported = value;
                NotifyPropertyChanged(nameof(IsStillImageSupported));
            }
        }

        public List<string> StillImageFunctionalObjects
        {
            get
            {
                return this.stillImageFunctionalObjects;
            }
            set
            {
                if (this.stillImageFunctionalObjects != value)
                {
                    this.stillImageFunctionalObjects = value;
                    NotifyPropertyChanged(nameof(StillImageFunctionalObjects));
                }
            }
        }

        public string SelectedStillImageFunctionalObject
        {
            get { return this.selectedStillImageFunctionalObject; }
            set
            {
                this.selectedStillImageFunctionalObject = value;
                NotifyPropertyChanged(nameof(SelectedStillImageFunctionalObject));
            }
        }

        public ImageSource StillImageSource
        {
            get { return this.stillImageSource; }
            set { this.stillImageSource = value; NotifyPropertyChanged(nameof(StillImageSource)); }
        }

        public void OnStillImageCapture()
        {
            this.device.ObjectAdded += OnStillImage;
            this.stillImageTimer.Start();
            this.device.StillImageCaptureInitiate(this.selectedStillImageFunctionalObject);
        }

        private void OnStillImage(object sender, MediaDeviceEventArgs e)
        {
            this.stillImageTimer.Stop();
            this.device.ObjectAdded -= OnStillImage;
            FindStillImage();
        }

        private void OnStillImageTimer(object sender, EventArgs e)
        {
            this.stillImageTimer.Stop();
            this.device.ObjectAdded -= OnStillImage;
            FindStillImage();
        }

        private void FindStillImage()
        {
            List<string> files = null;
            List<string> locations = this.device.GetContentLocations(ContentType.Image).ToList();
            if (locations.Any())
            {
                files = locations.SelectMany(l => this.device.EnumerateFiles(l, "*.jpg", SearchOption.AllDirectories)).ToList();
            }
            else
            {
                string root = this.device.GetRootDirectory().FullName;
                files = this.device.EnumerateFiles(root, "*.jpg", SearchOption.AllDirectories).ToList();
            }
            string file = files.OrderByDescending(f => Path.GetFileNameWithoutExtension(f)).FirstOrDefault();

            using (MemoryStream mem = new MemoryStream())
            {
                this.device.DownloadFile(file, mem);
                mem.Position = 0;

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = mem;
                image.EndInit();

                this.StillImageSource = image;
            }
        }
    }
}
