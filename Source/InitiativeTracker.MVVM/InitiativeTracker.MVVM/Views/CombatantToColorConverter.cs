using System;
using System.Globalization;
using System.Windows.Data;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.Views
{
    public class CombatantToColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (CombatantType)value == CombatantType.Monster 
                    ? "#FFFF0000" 
                    : "#FF00FF00";
            }
            return "#FF000000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          throw new NotImplementedException();
        }
    }
}
