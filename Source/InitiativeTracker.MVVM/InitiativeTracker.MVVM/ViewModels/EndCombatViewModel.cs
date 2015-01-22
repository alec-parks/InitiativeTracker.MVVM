using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Assisticant;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    class EndCombatViewModel
    {
        private readonly Combat _combat;

        public EndCombatViewModel(Combat combat)
        {
            _combat = combat;
        }

        public IEnumerable<Combatant> MonsterCombatants
        {
            get { return _combat.Combatants.Where(combatant => combatant.Type == CombatantType.Monster); }
        }

        public ICommand RemoveMonsterCombatants
        {
            get { return MakeCommand.Do(RemoveMonsters);}
        }

        public ICommand KeepMonsterCombatants
        {
            get { return MakeCommand.Do(KeepMonsters);}
        }

        public void RemoveMonsters()
        {
            _combat.RemoveMonsters(MonsterCombatants.ToList());
            _combat.EndCombat();
        }

        public void KeepMonsters()
        {
            _combat.EndCombat();
        }
    }
}
