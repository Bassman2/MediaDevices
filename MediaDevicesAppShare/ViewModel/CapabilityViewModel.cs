using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class CapabilityViewModel : BaseViewModel
    {
        MediaDevice device;
        private List<FunctionalCategory> functionalCategories;
        private FunctionalCategory selectedFunctionalCategory;
        
        public CapabilityViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;

            this.FunctionalCategories = this.device?.FunctionalCategories()?.ToList();
            this.SelectedFunctionalCategory = this.FunctionalCategories?.FirstOrDefault() ?? FunctionalCategory.Unknown;

            NotifyAllPropertiesChanged();
        }

        public List<string> SupportedCommands
        {
            get
            {
                return this.device?.SupportedCommands()?.Select(c => c.ToString()).ToList();
            }
        }

        public List<string> SupportedEvents
        {
            get
            {
                return this.device?.SupportedEvents()?.Select(c => c.ToString()).ToList();
            }
        }
        
        public List<FunctionalCategory> FunctionalCategories
        {
            get
            {
                return this.functionalCategories;
            }
            set
            {
                this.functionalCategories = value;
                NotifyPropertyChanged(nameof(FunctionalCategories));
            }
        }

        public FunctionalCategory SelectedFunctionalCategory
        {
            get
            {
                return this.selectedFunctionalCategory;
            }
            set
            {
                this.selectedFunctionalCategory = value;
                NotifyPropertyChanged(nameof(SelectedFunctionalCategory));
                NotifyPropertyChanged(nameof(FunctionalObjects));
                NotifyPropertyChanged(nameof(SupportedContentTypes));
            }
        }

        public List<string> FunctionalObjects
        {
            get
            {
                return this.device?.FunctionalObjects(this.selectedFunctionalCategory)?.Select(c => c.ToString()).ToList();
            }
        }

        public List<string> SupportedContentTypes
        {
            get
            {
                return this.device?.SupportedContentTypes(this.selectedFunctionalCategory)?.Select(c => c.ToString()).ToList();
            }
        }
    }
}
