using System;
using Windows.UI.Xaml.Data;

namespace OhYeah.Converters
{
    public class YearsAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime) value;
            var now = DateTime.Now;
            var difference = now.Year - date.Year;

            if (difference == 1)
            {
                return "1 year ago";
            }
            else
            {
                return $"{difference} years ago";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
