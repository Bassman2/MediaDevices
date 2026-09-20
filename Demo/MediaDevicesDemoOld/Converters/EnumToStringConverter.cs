namespace MediaDevicesDemo.Converters;

[ValueConversion(typeof(Enum), typeof(string))]
internal class EnumToStringConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Enum val)
        {
            // Get the enum type and the numeric value
            Type enumType = val.GetType();
            object numericValue = System.Convert.ChangeType(val, Enum.GetUnderlyingType(enumType));

            // Find all enum members with the same numeric value
            var matchingNames = new HashSet<string>();
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumFieldValue = Enum.Parse(enumType, name);
                object enumNumericValue = System.Convert.ChangeType(enumFieldValue, Enum.GetUnderlyingType(enumType));
                if (numericValue.Equals(enumNumericValue))
                {
                    matchingNames.Add(name);
                }
            }

            if (matchingNames.Count > 0)
            {
                // Return all matching names separated by pipe
                return string.Join(", ", matchingNames);
            }

            // Fallback: If no names found, format as hexadecimal
            return $"0x{System.Convert.ToInt64(val):X}";
        }
        throw new Exception("The value is not an enum type!");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();

}
