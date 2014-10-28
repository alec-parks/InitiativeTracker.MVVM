using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Assisticant;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class CombatViewModel
    {
        private readonly Combat _combat;

        public Combat Combat
        {
            get { return _combat; }
        }

        public CombatViewModel(Combat combat)
        {
            _combat = combat;
        }

        public IEnumerable<CombatantViewModel> Combatant
        {
            get { return _combat.Combatants.Select(combatant => new CombatantViewModel(combatant)); }
        }

        public ICommand AddCombatant
        {
            get
            {
                return MakeCommand.Do(()=> _combat.AddCombatant())
            }
        }
    }
}
