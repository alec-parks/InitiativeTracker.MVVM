﻿using Assisticant;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        //Private RO Combatant Field
        private readonly Combatant _combatant;
        private readonly Combat _combat;
        //Default Constructor
        public ViewModelLocator()
        {
            if (DesignMode)
            {
                _combatant = new Combatant
                {
                    Name = "Test Combatant",
                    Type = CombatantType.Monster,
                    Counter = 1,
                    Initiative = new Initiative {Modifier = -5, Current = 13, IsSet = true}
                };

                _combat= new Combat();
                for (int x = 0; x <= 10; x++)
                {
                    _combat.AddCombatant(_combatant);
                }

            }
            else
            {
                _combat = new Combat();    
            }
            
            
        }

        //ViewModel Properties

        public object CombatantViewModel
        {
            get { return ViewModel(() => new CombatantViewModel(_combatant)); }
        }

        public object AddCombatantViewModel
        {
            get { return ViewModel(() => new AddCombatantViewModel(_combatant)); }
        }

        public object CombatViewModel
        {
            get { return ViewModel(() => new CombatViewModel(_combat)); }
        }
    }
}