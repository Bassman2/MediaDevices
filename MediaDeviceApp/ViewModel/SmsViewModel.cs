using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Collections.Generic;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class SmsViewModel : BaseViewModel
    {
        MediaDevice device;
        private bool isSmsSupported;
        private List<string> smsFunctionalObjects;
        private string selectedSmsFunctionalObject;

        public DelegateCommand SendTextSMSCommand { get; private set; }


        public SmsViewModel()
        {
            this.SendTextSMSCommand = new DelegateCommand(OnSendTextSMS);
        }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.IsSmsSupported = this.device?.FunctionalCategories()?.Any(c => c == FunctionalCategory.SMS) ?? false;
            this.SmsFunctionalObjects = this.device?.FunctionalObjects(FunctionalCategory.SMS)?.ToList();
        }

        public bool IsSmsSupported
        {
            get
            {
                return this.isSmsSupported;
            }
            set
            {
                this.isSmsSupported = value;
                NotifyPropertyChanged(nameof(IsSmsSupported));
            }
        }

        public List<string> SmsFunctionalObjects
        {
            get
            {
                return this.smsFunctionalObjects;
            }
            set
            {
                this.smsFunctionalObjects = value;
                NotifyPropertyChanged(nameof(SmsFunctionalObjects));
            }
        }

        public string SelectedSmsFunctionalObject
        {
            get
            {
                return this.selectedSmsFunctionalObject;
            }
            set
            {
                this.selectedSmsFunctionalObject = value;
                NotifyPropertyChanged(nameof(SelectedSmsFunctionalObject));
            }
        }

        public string SmsRecipient { get; set; }

        public string SmsText { get; set; }

        private void OnSendTextSMS()
        {
            this.device?.SendTextSMS(this.SelectedSmsFunctionalObject, this.SmsRecipient, this.SmsText);
        }

    }
}
