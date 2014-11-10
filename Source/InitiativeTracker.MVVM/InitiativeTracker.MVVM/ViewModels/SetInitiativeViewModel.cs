using System.Collections.Generic;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class SetInitiativeViewModel
    {
        private List<CombatantInitiativeViewModel> _combatants = new List<CombatantInitiativeViewModel>();

        public SetInitiativeViewModel(List<CombatantInitiativeViewModel> combatants)
        {
            _combatants = combatants;
        }

        public IEnumerable<CombatantInitiativeViewModel> CombatantInitiativeViewModels
        {
            get { return _combatants; }
        }
    }
}
