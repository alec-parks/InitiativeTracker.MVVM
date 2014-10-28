﻿using System;
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
            set { _combatant.Name = value; }
        }

        public int Modifier
        {
            set { _combatant.Initiative.Modifier = value; }
        }

        public Enum Type
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