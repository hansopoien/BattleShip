using BattleShip.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BattleShip.Converters
{
    internal class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Status && value != null)
            {
                var status = (Status)value;
                return status switch
                {
                    Status.Sunk => new SolidColorBrush(Colors.Gray),
                    Status.Miss => new SolidColorBrush(Colors.Yellow),
                    Status.Untested => new SolidColorBrush(Colors.Blue),
                    Status.Hit => new SolidColorBrush(Colors.Green),
                    _ => new SolidColorBrush(Colors.White)
                };
            }
            return new SolidColorBrush(Colors.Blue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
