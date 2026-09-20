namespace MediaDevicesDemo.Converters
{
    
    [ValueConversion(typeof(long), typeof(string))]
    internal class LongToSizeStringConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long b)
            {
                double size = b;
                // output in Tera Bytes
                if (size > 10.0 * 1024 * 1024 * 1024 * 1024)
                {
                    long t = (long)Math.Ceiling(size / (1024.0 * 1024 * 1024 * 1024));
                    return $"{t:N0} TB";

                }
                // output in Giga Bytes
                if (size > 10.0 * 1024 * 1024 * 1024)
                {
                    long g = (long)Math.Ceiling(size / (1024.0 * 1024 * 1024));
                    return $"{g:N0} GB";

                }
                // output in Mega Bytes
                if (size > 10.0 * 1024 * 1024)
                {
                    long m = (long)Math.Ceiling(size / (1024.0 * 1024));
                    return $"{m:N0} MB";

                }
                // output in Kilo Bytes
                long k = (long)Math.Ceiling(size / 1024.0);
                return $"{k:N0} KB";
            }
            else
            {
                throw new Exception("LongToSizeStringConverter value has not the type long!");
            }
        }
                
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
        
    }
}
