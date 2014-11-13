using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Navigation;
using Assisticant;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class SetInitiativeViewModel
    {
        private readonly Combat _combat;

        public SetInitiativeViewModel(Combat combat)
        {
            _combat = combat;
        }

        public IEnumerable<Combatant> Combatants
        {
            get { return _combat.Combatants.Where(combatant => combatant.Type == CombatantType.Player); }
        }

        public IEnumerable<CombatantInitiativeViewModel> CombatantInitiativeViewModels
        {
            get { return Combatants.Select(combatant => new CombatantInitiativeViewModel(combatant)); }
        }

        public ICommand MakeItSo
        {
            get { return MakeCommand.Do(StartCombat); }
        }

        private void StartCombat()
        {
            throw new System.NotImplementedException();
        }
    }
}
