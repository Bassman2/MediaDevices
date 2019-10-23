using MediaDeviceApp.Mvvm;
using MediaDevices;
using System.Linq;

namespace MediaDeviceApp.ViewModel
{
    public class RootViewModel : BaseViewModel
    {
        MediaDevice device;
        MediaDirectoryInfo root;

        public RootViewModel()
        {
            
        }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.root = this.device?.GetRootDirectory();
            NotifyAllPropertiesChanged();
        }

        public string Id
        {
            get
            {
                return this.root?.Id;
            }
        }

        public string Name
        {
            get
            {
                return this.root?.Name;
            }
        }

        public string FullName
        {
            get
            {
                return this.root?.FullName;
            }
        }

        public ulong Length
        {
            get
            {
                return this.root?.Length ?? 0;
            }
        }

        public string Attributes
        {
            get
            {
                return this.root?.Attributes.ToString();
            }
        }

    }
}
