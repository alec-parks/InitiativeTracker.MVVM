using System;
using System.Globalization;
using System.Windows.Data;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.Views
{
    public class CombatantToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CombatantType combatantValue = new CombatantType();
            CombatantType combatantParameter= new CombatantType();
            Enum.TryParse(value.ToString(), out combatantValue);
            Enum.TryParse(parameter.ToString(), out combatantParameter);
            return combatantValue == combatantParameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueBool;
            bool.TryParse(value.ToString(), out valueBool);
            return valueBool ? parameter : Binding.DoNothing;
        }
    }
}