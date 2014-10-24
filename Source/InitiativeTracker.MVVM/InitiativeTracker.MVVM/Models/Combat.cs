using System.Collections.Generic;
using Assisticant.Collections;

namespace InitiativeTracker.MVVM.Models
{
    public class Combat
    {
        private ObservableList<Combatant> _combatants = new ObservableList<Combatant>();

        public IEnumerable<Combatant> Combatants
        {
            get { return _combatants; }
        }

        public void AddCombatant(Combatant combatant)
        {
            _combatants.Add(combatant);
        }

        public void RemoveCombatant(Combatant combatant)
        {
            _combatants.Remove(combatant);
        }
    }
}
