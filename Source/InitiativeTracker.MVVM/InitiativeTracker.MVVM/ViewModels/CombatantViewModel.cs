using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class CombatantViewModel
    {
        private readonly Combatant _combatant;

        public CombatantViewModel(Combatant combatant)
        {
            _combatant = combatant;
        }

        //Display name
        public string DisplayName()
        {
            return _combatant.DisplayName;
        }

        //Current Initiaitve
        public string Initiative()
        {
            return _combatant.Initiative.Current.ToString();
        }

        //Initiative Modifier
        public string Modifier()
        {
            if (_combatant.Initiative.Modifier < 0)
                return "-" + _combatant.Initiative.Modifier;
            if (_combatant.Initiative.Modifier > 0)
                return "+" + _combatant.Initiative.Modifier;
            return _combatant.Initiative.Modifier.ToString();
        }

        //Indicate if Initiative has been set/rolled for combatant
        public bool IsSet()
        {
            return _combatant.Initiative.IsSet;
        }
    }
}
