﻿using Assisticant.Fields;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class AddCombatantViewModel
    {
        private Observable<Combatant> _combatant = new Observable<Combatant>();

        public Combatant Combatant
        {
            get { return _combatant; }
        }

        public AddCombatantViewModel(Combatant combatant)
        {
            _combatant.Value = combatant;
        }

        public string Name
        {
            get { return _combatant.Name; }
            set { _combatant.Name = value; }
        }

        public int Modifier
        {
            get { return _combatant.Value.Initiative.Modifier; }
            set { _combatant.Value.Initiative.Modifier = value; }
        }

        public CombatantType Type
        {
            get { return _combatant.Value.Type; }
            set { _combatant.Value.Type = value; }
        }

        public int Counter
        {
            set { _combatant.Value.Counter = value; }
        }
    }
}
