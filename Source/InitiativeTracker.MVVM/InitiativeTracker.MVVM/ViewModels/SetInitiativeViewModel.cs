using System.Collections.Generic;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class SetInitiativeViewModel
    {
        private List<CombatantInitiativeViewModel> _combatantInitiativeViewModels = new List<CombatantInitiativeViewModel>();

        public SetInitiativeViewModel(List<CombatantInitiativeViewModel> combatantInitiativeViewModels)
        {
            _combatantInitiativeViewModels = combatantInitiativeViewModels;
        }

        public IEnumerable<CombatantInitiativeViewModel> CombatantInitiativeViewModels
        {
            get { return _combatantInitiativeViewModels; }
        }
    }
}
