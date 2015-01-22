using System.Collections.Generic;
using System.Linq;
using Assisticant.Collections;
using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    public class Combat
    {
        private ObservableList<Combatant> _combatants = new ObservableList<Combatant>();
        private Observable<bool> _hasStarted = new Observable<bool>(false);

        public bool HasStarted
        {
            get { return _hasStarted.Value; } 
            set { _hasStarted.Value = value; }
        }

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
            HasStarted = true;
        }

        public void EndCombat()
        {
            HasStarted = false;

            UnsetInitiative(Combatants);
        }

        public void EndCombat(IEnumerable<Combatant> combatants)
        {
            foreach (var combatant in combatants)
            {
                RemoveCombatant(combatant);
            }
            
            UnsetInitiative(Combatants);
            
            HasStarted = false;
        }

        public void UnsetInitiative(IEnumerable<Combatant> combatants)
        {
            foreach (var combatant in combatants)
            {
                combatant.Initiative.IsSet = false;
                combatant.Initiative.Current = 0;
            }
        }

    }
}
