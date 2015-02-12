using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
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

        public IEnumerable<Combatant> PlayerCombatants
        {
            get { return _combat.Combatants.Where(combatant => combatant.Type == CombatantType.Player); }
        }

        public IEnumerable<Combatant> MonsterCombatants
        {
            get { return _combat.Combatants.Where(combatant => combatant.Type == CombatantType.Monster); }
        }

        public IEnumerable<CombatantInitiativeViewModel> CombatantInitiativeViewModels
        {
            get { return PlayerCombatants.Select(combatant => new CombatantInitiativeViewModel(combatant, _combat.DiceRoller)); }
        }

        public IEnumerable<Combatant> Combatants
        {
            get { return _combat.Combatants; }
        }
        
        public ICommand RollPlayers
        {
            get { return MakeCommand.Do(() => Roll(PlayerCombatants)); }
        }

        public ICommand RollMonsters
        {
            get { return MakeCommand.Do(() => Roll(MonsterCombatants)); }
        }

        public ICommand MakeItSo
        {
            get { return MakeCommand.Do(StartCombat); }
        }

        public ICommand Abort
        {
            get { return MakeCommand.Do(DontStart); }
        }

        private void StartCombat()
        {
            Roll(MonsterCombatants.Where(combatant => combatant.Initiative.IsSet == false));

            foreach (var combatant in Combatants.Where(combatant => combatant.Initiative.IsSet == false))
            {
                combatant.Initiative.IsSet = true;
            }

            _combat.StartCombat();
        }

        private void DontStart()
        {
            foreach (var combatant in Combatants)
            {
                combatant.Initiative.Current = 0;
                combatant.Initiative.IsSet = false;
            }
        }

        private void Roll(IEnumerable<Combatant> combatants)
        {
            foreach (var combatant in combatants)
            {
                combatant.Initiative.Roll(_combat.DiceRoller);
            }
        }
    }
}
