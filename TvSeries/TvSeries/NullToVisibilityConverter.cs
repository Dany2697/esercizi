using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Xml.Schema;
using TvSeries.ViewModel;
using Xamarin.Forms;

namespace TvSeries
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            int.TryParse(parameter.ToString(),out int index) ;
            var list = (IList)value;
            if (list.Count <= index)
                return false;
           
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
