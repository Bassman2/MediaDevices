using ExplorerCtrl;
using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MediaDeviceApp.ViewModel
{
    public class ItemViewModel : BaseViewModel, IExplorerItem
    {
        private static ImageSource imgFolder;
        private static ImageSource imgFile;

        private MediaFileSystemInfo item;

        static ItemViewModel()
        {
            imgFolder = new BitmapImage(new Uri("pack://application:,,,/Folder.png"));
            imgFile = new BitmapImage(new Uri("pack://application:,,,/File.png"));
        }

        public ItemViewModel(MediaFileSystemInfo item)
        {
            this.item = item;
            //this.Refresh += (o, a) => this.item.Refresh();
        }

        public string Name
        {
            get
            {
                return this.item.Name;
            }
            set
            { }
        }

        public string FullName { get { return this.item.FullName; } }

        public string Link { get { return null; } }

        public long Size { get { return (long)this.item.Length; } }

        public DateTime? Date { get { return this.item.LastWriteTime; } }

        public ExplorerItemType Type { get { return IsDirectory ? ExplorerItemType.Directory : ExplorerItemType.File; } }

        public ImageSource Icon { get { return IsDirectory ? imgFolder : imgFile ; } }

        public bool IsDirectory { get { return this.item.Attributes.HasFlag(MediaFileAttributes.Directory) || this.item.Attributes.HasFlag(MediaFileAttributes.Object); } }

        public bool HasChildren { get { return this.Children?.Any() ?? false; } }

        public IEnumerable<IExplorerItem> Children
        {
            get
            { 
                if (this.item.Attributes == MediaFileAttributes.Directory || this.item.Attributes == MediaFileAttributes.Object)
                {
                    MediaDirectoryInfo dir = this.item as MediaDirectoryInfo;
                    var children = dir.EnumerateFileSystemInfos().Select(i => new ItemViewModel(i)).ToList();
                    return children;
                }
                else
                {
                    return null;
                }
            }
        }

#pragma warning disable CS0067
        public event EventHandler<RefreshEventArgs> Refresh;
#pragma warning restore CS0067

        public void CreateFolder(string path)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IExplorerItem other)
        {
            return this.FullName == other.FullName;
        }

        public void Pull(string path, Stream stream)
        {
            throw new NotImplementedException();
        }

        public void Push(Stream stream, string path)
        {
            throw new NotImplementedException();
        }
    }
}
