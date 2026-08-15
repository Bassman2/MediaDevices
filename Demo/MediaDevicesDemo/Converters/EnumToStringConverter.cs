namespace MediaDevicesDemo.Converters;

[ValueConversion(typeof(Enum), typeof(string))]
internal class EnumToStringConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Enum val)
        {
            string name = val.ToString();
            // If the name starts with a digit, it means no matching enum name was found
            // In that case, format as hexadecimal
            if (char.IsDigit(name[0]))
            {
                name = $"0x{System.Convert.ToInt32(val):X}";
            }
            return name;
        }
        throw new Exception("The value is not an enum type!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();

}
