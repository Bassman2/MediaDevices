using MediaDeviceApp.Mvvm;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MediaDeviceApp.ViewModel
{
    public class FilesViewModel : BaseViewModel
    {
        MediaDevice device;
        private Function selectedFunction;
        private string path = @"\";
        private string filter = "*";
        private bool useRecursive = true;
        private long numOfFiles;
        private List<Info> files;
        private string time;

        public DelegateCommand EnumerateCommand { get; private set; }

        public enum Function
        {
            MediaDevice_EnumerateDirectories,
            MediaDevice_EnumerateFiles,
            MediaDevice_EnumerateFileSystemEntries,

            MediaFileSystemInfo_EnumerateDirectories,
            MediaFileSystemInfo_EnumerateFiles,
            MediaFileSystemInfo_EnumerateFileSystemInfos,

        }

        public class Info
        {
            private static BitmapImage fileImage;
            private static BitmapImage folderImages;

            static Info()
            {
                fileImage = new BitmapImage(new Uri("pack://application:,,,/MediaDeviceApp;component/Images/File.png"));
                folderImages = new BitmapImage(new Uri("pack://application:,,,/MediaDeviceApp;component/Images/Folder.png"));
            }

            public Info(string fullName)
            {
                this.Name = System.IO.Path.GetFileName(fullName);
                this.FullName = fullName;
                this.Image = fullName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) ? folderImages : fileImage;
            }

            public Info(MediaFileSystemInfo info)
            {
                this.Id = info.Id;
                this.Name = info.Name;
                this.FullName = info.FullName;
                this.Length = info.Length;
                this.Image = info.Attributes.HasFlag(MediaFileAttributes.Normal) ? fileImage : folderImages;
            }
                        
            public string Id { get; set; }
            public string Name { get; set; }
            public string FullName { get; set; }
            public ulong Length { get; set; }
            public ImageSource Image { get; private set; } 
        }

        public FilesViewModel()
        {
            this.EnumerateCommand = new DelegateCommand(OnEnumerate);
        }

        public void Update(MediaDevice device)
        {
            this.device = device;
            this.Files = null;
        }

       

        public List<Function> Functions
        {
            get { return Enum.GetValues(typeof(Function)).Cast<Function>().ToList(); }
        }

        public Function SelectedFunction
        {
            get
            {
                return this.selectedFunction;
            }
            set
            {
                this.selectedFunction = value;
                NotifyPropertyChanged(nameof(SelectedFunction));
            }
        }

        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
                NotifyPropertyChanged(nameof(Path));
            }
        }

        public string Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
                NotifyPropertyChanged(nameof(Filter));
            }
        }


        public bool UseRecursive
        {
            get
            {
                return this.useRecursive;
            }
            set
            {
                this.useRecursive = value;
                NotifyPropertyChanged(nameof(UseRecursive));
            }
        }

        public long NumOfFiles
        {
            get
            {
                return this.numOfFiles;
            }
            set
            {
                this.numOfFiles = value;
                NotifyPropertyChanged(nameof(NumOfFiles));
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
                NotifyPropertyChanged(nameof(Time));
            }
        }

        public List<Info> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
                this.NumOfFiles = this.files?.Count ?? 0;
                NotifyPropertyChanged(nameof(Files));
            }
        }


        private void OnEnumerate()
        {
            Stopwatch stopwatch = new Stopwatch();

            using (new WaitCursor())
            {
                SearchOption searchOption = this.UseRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

                switch (this.SelectedFunction)
                {
                case Function.MediaDevice_EnumerateDirectories:
                    stopwatch.Start();
                    var list1 = this.device.EnumerateDirectories(this.Path, this.Filter, searchOption).ToList();
                    stopwatch.Stop();
                    this.Files = list1.Select(f => new Info(f)).ToList();
                    break;

                case Function.MediaDevice_EnumerateFiles:
                    stopwatch.Start();
                    var list2 = this.device.EnumerateFiles(this.Path, this.Filter, searchOption).ToList();
                    stopwatch.Stop();
                    this.Files = list2.Select(f => new Info(f)).ToList();
                    break;

                case Function.MediaDevice_EnumerateFileSystemEntries:
                    stopwatch.Start();
                    var list3 = this.device.EnumerateFileSystemEntries(this.Path, this.Filter, searchOption).ToList();
                    stopwatch.Stop();
                    this.Files = list3.Select(f => new Info(f)).ToList();
                    break;
                    
                case Function.MediaFileSystemInfo_EnumerateDirectories:
                    stopwatch.Start();
                    var list4 = this.device.GetDirectoryInfo(this.Path).EnumerateDirectories(this.Filter, searchOption).ToList();
                    stopwatch.Stop();
                    this.Files = list4.Select(f => new Info(f)).ToList();
                    break;

                case Function.MediaFileSystemInfo_EnumerateFiles:
                    stopwatch.Start();
                    var list5 = this.device.GetDirectoryInfo(this.Path).EnumerateFiles(this.Filter, searchOption).ToList();
                    stopwatch.Stop();
                    this.Files = list5.Select(f => new Info(f)).ToList();
                    break;

                case Function.MediaFileSystemInfo_EnumerateFileSystemInfos:
                    stopwatch.Start();
                    var list6 = this.device.GetDirectoryInfo(this.Path).EnumerateFileSystemInfos(this.Filter, searchOption).ToList();
                    stopwatch.Stop();
                    this.Files = list6.Select(f => new Info(f)).ToList();
                    break;
                }
                this.Time = stopwatch.Elapsed.ToString(@"mm\:ss\.fffffff");
            }
        }
    }
}
