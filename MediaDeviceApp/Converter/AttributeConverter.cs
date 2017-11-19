using MediaDevices;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MediaDeviceApp.Converter
{
    [ValueConversion(typeof(MediaFileAttributes), typeof(ImageSource))]
    public class AttributeConverter : IValueConverter
    {
        private static BitmapImage fileImage;
        private static BitmapImage folderImages;

        static AttributeConverter()
        {
            fileImage = new BitmapImage(new Uri("pack://application:,,,/MediaDeviceApp;component/Images/File.png"));
            folderImages = new BitmapImage(new Uri("pack://application:,,,/MediaDeviceApp;component/Images/Folder.png"));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MediaFileAttributes attr = (MediaFileAttributes)value;
            return attr.HasFlag(MediaFileAttributes.Normal) ? fileImage : folderImages;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
