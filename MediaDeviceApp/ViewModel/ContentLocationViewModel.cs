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
        private ContentType selectedContent;
        
        public ContentLocationViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;

            //var a = this.device?.SupportedCommands().ToList();
            //var b = a.Any(c => c == Commands.GetContentLocation);
            //this.IsContentLocationSupported = this.device?.SupportedCommands().Any(c => c == Commands.GetContentLocation) ?? false;



            this.SelectedContent = this.Contents.FirstOrDefault();
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
