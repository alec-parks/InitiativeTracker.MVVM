using System.Collections.Generic;
using System.Linq;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class SetInitiativeViewModel
    {
        private readonly List<Combatant> _combatants = new List<Combatant>();

        public SetInitiativeViewModel(List<Combatant> combatants)
        {
            _combatants = combatants;
        }

        public IEnumerable<CombatantInitiativeViewModel> CombatantInitiativeViewModels
        {
            get { return _combatants.Select(combatant => new CombatantInitiativeViewModel(combatant)); }
        }
    }
}
