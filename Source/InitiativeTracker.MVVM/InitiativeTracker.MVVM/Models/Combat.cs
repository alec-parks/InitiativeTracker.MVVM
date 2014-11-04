using System.Collections.Generic;
using System.Linq;
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
            var highCombatant = HighestCombatant(combatant);
            if (highCombatant != null)
            {
                if (highCombatant.Counter == 0)
                {
                    highCombatant.Counter++;
                }
                combatant.Counter = highCombatant.Counter++;
            }
            _combatants.Add(combatant);
        }

        public void AddCopy(Combatant combatant)
        {
            var copy = combatant.Clone();
            AddCombatant(copy);
        }

        public void RemoveCombatant(Combatant combatant)
        {
            _combatants.Remove(combatant);
        }

        private Combatant HighestCombatant(Combatant combatantToMatch)
        {
            var returnCombatant = _combatants
                .Where(combatant => combatant.Name == combatantToMatch.Name 
                                 && combatant.Type == combatantToMatch.Type)
                .OrderByDescending(combatant => combatant.Counter)
                .FirstOrDefault();
            return returnCombatant;
        }

    }
}
