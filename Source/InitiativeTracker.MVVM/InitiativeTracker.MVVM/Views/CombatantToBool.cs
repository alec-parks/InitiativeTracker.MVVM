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
            CombatantType combatantValue;
            CombatantType combatantParameter;
            Enum.TryParse(value.ToString(), out combatantValue);
            Enum.TryParse(parameter.ToString(), out combatantParameter);
            if (combatantValue == combatantParameter)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueBool;
            bool.TryParse(value.ToString(), out valueBool);
            if (valueBool)
                return parameter;
            return Binding.DoNothing;
        }
    }
}