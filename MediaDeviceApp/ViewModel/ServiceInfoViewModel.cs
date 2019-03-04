using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class ServiceInfoViewModel : ServiceBaseViewModel
    {
        public ServiceInfoViewModel()
        {
        }

        public List<KeyValuePair<string, string>> Properties
        {
            get
            {
                var x = this.SelectedService?.GetAllProperties()?.ToList();
                return x;
            }
        }

        public List<string> SupportedMethods
        {
            get
            {
                return this.SelectedService?.GetSupportedMethods()?.Select(c => c.ToString()).ToList();
            }
        }

        public List<string> SupportedCommands
        {
            get
            {
                return this.SelectedService?.GetSupportedCommands()?.Select(c => c.ToString()).ToList();
            }
        }

        public List<string> SupportedEvents
        {
            get
            {
                return this.SelectedService?.GetSupportedEvents()?.Select(c => c.ToString()).ToList();
            }
        }
                   
        public List<string> SupportedFormats
        {
            get
            {
                return this.SelectedService?.GetSupportedFormats()?.Select(c => c.ToString()).ToList();
            }
        }

        public List<ContentViewModel> Contents
        {
            get
            {
                return this.SelectedService?.GetContent()?.Select(c => new ContentViewModel(c)).ToList();
            }
        }

        private ContentViewModel selectedContent;
        public ContentViewModel SelectedContent
        {
            get { return this.selectedContent; }
            set { this.selectedContent = value; NotifyPropertyChanged(nameof(SelectedContent)); }
        }
    }
}
