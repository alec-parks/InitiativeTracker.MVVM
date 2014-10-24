using Assisticant;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        //Private RO Combatant Field
        private readonly Combatant _combatant;
        //Default Constructor
        public ViewModelLocator ()
        {
            if (DesignMode)
            {
                 _combatant = new Combatant
                 {
                     Name = "Test Combatant",
                     Type = CombatantType.Player,
                     Counter = 1,
                     Initiative = new Initiative {Modifier = 5, Current = 13, IsSet = true}
                 };
            }
        }

        //CombatantViewModel Property

        public object CombatantViewModel 
        {
            get
            {
                return ViewModel(() => new CombatantViewModel(_combatant));
            }
        }
    }
}
