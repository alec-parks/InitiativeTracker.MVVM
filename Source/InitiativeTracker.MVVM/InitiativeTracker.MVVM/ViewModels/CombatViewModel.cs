using System.Collections.Generic;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class CombatViewModel
    {
        private readonly Combat _combat;

        public CombatViewModel(Combat combat)
        {
            _combat = combat;
        }

        public IEnumerable<Combatant> Combatants()
        {
            return _combat.Combatants;
        }
    }
}
