using System;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class AddCombatantViewModel
    {
        private Combatant _combatant;

        public Combatant Combatant
        {
            get { return _combatant; }
        }

        public AddCombatantViewModel(Combatant combatant)
        {
            _combatant = combatant;
        }

        public string Name
        {
            get { return _combatant.Name; }
            set { _combatant.Name = value; }
        }

        public int Modifier
        {
            get { return _combatant.Initiative.Modifier; }
            set { _combatant.Initiative.Modifier = value; }
        }

        public CombatantType Type
        {
            get { return _combatant.Type; }
            set { _combatant.Type = (CombatantType) value; }
        }

        public int Counter
        {
            set { _combatant.Counter = value; }
        }
    }
}
