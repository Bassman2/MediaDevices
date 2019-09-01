using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class ContentLocationViewModel : BaseViewModel
    {
        MediaDevice device;
        private bool isContentLocationSupported = true;
        private List<ContentType> contents;
        private ContentType selectedContent;
        
        public ContentLocationViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;

            // needed for Nicon
            try
            {
                this.Contents = Enum.GetValues(typeof(ContentType)).Cast<ContentType>().Where(c => this.device?.GetContentLocations(c)?.Any() ?? false).ToList();
            }
            catch 
            {
                this.Contents = null;
            }

            this.SelectedContent = this.Contents?.FirstOrDefault() ?? ContentType.Unknown;
        }

        public bool IsContentLocationSupported
        {
            get
            {
                return this.isContentLocationSupported;
            }
            set
            {
                this.isContentLocationSupported = value;
                NotifyPropertyChanged(nameof(IsContentLocationSupported));
            }
        }

        //public List<ContentType> Contents
        //{
        //    get { return Enum.GetValues(typeof(ContentType)).Cast<ContentType>().ToList(); }
        //}

        public List<ContentType> Contents
        {
            get
            {
                return this.contents;
            }
            set
            {
                this.contents = value;
                NotifyPropertyChanged(nameof(Contents));
            }
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
                // needed for Nicon
                try
                {
                    return this.device?.GetContentLocations(this.selectedContent)?.ToList();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
                return null;
            }
        }

    }
}
