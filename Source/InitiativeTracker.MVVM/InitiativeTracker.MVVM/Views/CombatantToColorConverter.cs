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
            return (CombatantType) parameter == CombatantType.Monster ? "#FFFF0000" : "#FF00FF00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string) parameter == "#FFFF0000" ? CombatantType.Monster : CombatantType.Player;
        }
    }
}
