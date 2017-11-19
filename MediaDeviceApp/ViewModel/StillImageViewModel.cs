using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
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
        
        public DelegateCommand StillImageCommand { get; private set; }

        public StillImageViewModel()
        {
            //this.stillImageSource = new BitmapImage(new Uri("pack://application:,,,/MediaDeviceApp;component/Images/Folder.png"));
            this.StillImageCommand = new DelegateCommand(OnStillImageCapture);
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
            set
            {
                this.stillImageSource = value;
                NotifyPropertyChanged(nameof(StillImageSource));
            }
        }

        public void OnStillImageCapture()
        {
            this.device.ObjectAdded += OnStillImage;
            
            this.device.StillImageCaptureInitiate(this.selectedStillImageFunctionalObject);
        }

        private void OnStillImage(object sender, ObjectAddedEventArgs e)
        {
            this.device.ObjectAdded -= OnStillImage;

            string fullName = e.ObjectFullFileName;
            using (MemoryStream mem = new MemoryStream())
            {
                e.ObjectFileStream.CopyTo(mem);
                mem.Position = 0;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = mem;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();

                    this.StillImageSource = image;
                });
            }
        }
    }
}
