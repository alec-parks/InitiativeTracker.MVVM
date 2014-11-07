using System.Collections.Generic;
using System.Linq;
using Assisticant.Collections;

namespace InitiativeTracker.MVVM.Models
{
    public class Combat
    {
        private ObservableList<Combatant> _combatants = new ObservableList<Combatant>();

        public bool HasStarted { get; set; }

        public IEnumerable<Combatant> Combatants
        {
            get { return _combatants; }
        }

        public void AddCombatant(Combatant combatant)
        {
            var highCombatant = FindHighestCombatant(combatant);
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

        private Combatant FindHighestCombatant(Combatant combatantToMatch)
        {
            var returnCombatant = _combatants
                .Where(combatant => combatant.Name == combatantToMatch.Name 
                                 && combatant.Type == combatantToMatch.Type)
                .OrderByDescending(combatant => combatant.Counter)
                .FirstOrDefault();
            return returnCombatant;
        }

        public void StartCombat()
        {
            foreach (var combatant in _combatants.Where(combatant => combatant.Type == CombatantType.Monster))
            {
                combatant.Initiative.Roll();
            }

            HasStarted = true;
        }

        public void EndCombat()
        {
            HasStarted = false;
        }

    }
}
