using System;
using System.Globalization;
using System.Windows.Data;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.Views
{
    public class CombatantToColorConverter: IValueConverter
    {
        public object Brush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CombatantType combatantType;

            Enum.TryParse<CombatantType>(value.ToString(), out combatantType);
            switch (combatantType)
            {
                case CombatantType.Player:
                    Brush = "#FF09660D";
                    break;
                case CombatantType.Monster:
                    Brush = "#FFFF0000";
                    break;
            }

            return Brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          throw new NotImplementedException();
        }
    }
}
