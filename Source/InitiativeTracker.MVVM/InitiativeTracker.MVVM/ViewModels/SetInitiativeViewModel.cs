using System.Collections.Generic;
using System.Linq;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class SetInitiativeViewModel
    {
        private readonly IEnumerable<Combatant> _combatants;

        public SetInitiativeViewModel(IEnumerable<Combatant> combatants)
        {
            _combatants = combatants;
        }

        public IEnumerable<CombatantInitiativeViewModel> CombatantInitiativeViewModels
        {
            get { return _combatants.Select(combatant => new CombatantInitiativeViewModel(combatant)); }
        }
    }
}
