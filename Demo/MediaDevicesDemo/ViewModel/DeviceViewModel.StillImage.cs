

namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region StillImage

    public bool IsStillImageSupported => mediaDevice.FunctionalCategories()?.Any(c => c == FunctionalCategory.StillImageCapture) ?? false;

    public List<string>? StillImageFunctionalObjects => mediaDevice.FunctionalObjects(FunctionalCategory.StillImageCapture)?.ToList();

    [ObservableProperty]
    public partial string? SelectedStillImageFunctionalObject { get; set; }

    [ObservableProperty]
    public partial ImageSource StillImageSource { get; set; } = new BitmapImage(new Uri("pack://application:,,,/MediaDevicesDemo;component/Images/Folder.png"));


    [RelayCommand]
    public void OnStillImageCapture()
    {
        if (SelectedStillImageFunctionalObject != null)
        {
            mediaDevice.ObjectAdded += OnStillImage;
            mediaDevice.StillImageCaptureInitiate(SelectedStillImageFunctionalObject);
        }
    }

    private void OnStillImage(object? sender, ObjectAddedEventArgs e)
    {
        //mediaDevice.ObjectAdded -= OnStillImage;

        //string fullName = e.ObjectFullFileName;
        
        //using var mem = new MemoryStream();
        //e.ObjectFileStream.CopyTo(mem);
        //mem.Position = 0;
        //Application.Current.Dispatcher.Invoke(() =>
        //{
        //    BitmapImage image = new BitmapImage();
        //    image.BeginInit();
        //    image.StreamSource = mem;
        //    image.CacheOption = BitmapCacheOption.OnLoad;
        //    image.EndInit();

        //    StillImageSource = image;
        //});
    }
    #endregion
}

