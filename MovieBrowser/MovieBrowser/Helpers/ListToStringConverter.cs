using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace MovieBrowser.Helpers
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as List<string>;
            if (list != null)
            {
                return string.Join(" ",list);
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
