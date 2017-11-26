using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class ContentLocationViewModel : BaseViewModel
    {
        MediaDevice device;
        private ContentType selectedContent;
        
        public ContentLocationViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.SelectedContent = this.Contents.FirstOrDefault();
        }

        public List<ContentType> Contents
        {
            get { return Enum.GetValues(typeof(ContentType)).Cast<ContentType>().ToList(); }
        }

        public ContentType SelectedContent
        {
            get
            {
                return this.selectedContent;
            }
            set
            {
                this.selectedContent = value;
                NotifyPropertyChanged(nameof(SelectedContent));
                NotifyPropertyChanged(nameof(Locations));
            }
        }

        public List<string> Locations
        {
            get
            {
                return this.device?.GetContentLocations(this.selectedContent)?.ToList();
            }
        }

    }
}
