using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using OhYeah.Core.Social;
using OhYeah.Core.Social.Facebook;

namespace OhYeah.Converters
{
    public class PostTypeVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || parameter == null)
            {
                return Visibility.Collapsed;
            }

            var postType = (PostType) value;
            var requestedPostType = (PostType) Enum.Parse(typeof (PostType), parameter.ToString(), true);

            return postType == requestedPostType ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}