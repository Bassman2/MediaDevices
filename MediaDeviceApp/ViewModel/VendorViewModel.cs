using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class VendorViewModel : BaseViewModel
    {
        MediaDevice device;
        private string description;
        private List<int> opCodes;



        public VendorViewModel()
        { }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.OpCodes = this.device.VendorOpcodes().ToList();
            this.Description = this.device.VendorExtentionDescription();
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    NotifyPropertyChanged(nameof(Description));
                }
            }
        }

        public List<int> OpCodes
        {
            get
            {
                return this.opCodes;
            }
            set
            {
                if (this.opCodes != value)
                {
                    this.opCodes = value;
                    NotifyPropertyChanged(nameof(OpCodes));
                }
            }
        }

    }
}
