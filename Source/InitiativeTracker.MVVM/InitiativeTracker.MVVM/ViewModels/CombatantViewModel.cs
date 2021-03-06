﻿using System;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class CombatantViewModel
    {
        private readonly Combatant _combatant;

        public Combatant Combatant
        {
            get { return _combatant; }
        }

        public CombatantViewModel(Combatant combatant)
        {
            _combatant = combatant;
        }

        public bool IsSelected { get; set; }

        //Display name
        public string DisplayName
        {
            get{return _combatant.DisplayName;}
        }

        //Current Initiaitve
        public string Initiative
        {
            get
            {
               return _combatant.Initiative.IsSet 
                   ? _combatant.Initiative.Current.ToString() 
                   : "";
            }
        }

        //Indicate if Initiative has been set/rolled for combatant
        public bool IsSet
        {
            get { return _combatant.Initiative.IsSet; }
        }

        //Initiative Modifier
        public string Modifier
        {
            get
            {
                var mod = _combatant.Initiative.Modifier >= 0 
                    ? "+ " + _combatant.Initiative.Modifier 
                    : "- " + Math.Abs(_combatant.Initiative.Modifier);
                return mod;
            }
        }

        //Combatant Type
        public Enum Type
        {
            get { return _combatant.Type; }
        }
    }
}
