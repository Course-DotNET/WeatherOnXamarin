using System;
using System.Globalization;
using Xamarin.Forms;

namespace Weather.Helpers
{
    public class DateTimeToLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var format = parameter?.ToString();
                return ((DateTime)value).ToString(format, CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException)
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}