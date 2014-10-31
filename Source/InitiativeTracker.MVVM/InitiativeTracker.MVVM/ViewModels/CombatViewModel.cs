using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Assisticant;
using InitiativeTracker.MVVM.Models;
using InitiativeTracker.MVVM.ViewModels.EventArgs;
using InitiativeTracker.MVVM.Views.Dialogs;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class CombatViewModel
    {
        private readonly Combat _combat;

        public event Action<object, AddCombatantEventArgs> AddCombatantEvent;

        public Combat Combat
        {
            get { return _combat; }
        }

        public CombatViewModel(Combat combat)
        {
            _combat = combat;
        }

        public Combatant SelectedCombatant { get; set; }

        public IEnumerable<CombatantViewModel> Combatants
        {
            get { return _combat.Combatants.Select(combatant => new CombatantViewModel(combatant)); }
        }

        public ICommand AddCombatant
        {
            get
            {
                return MakeCommand
                    .Do(() =>
                    {
                        var args = new AddCombatantEventArgs();

                        if (AddCombatantEvent != null)
                        {
                            AddCombatantEvent(this, args);
                        }

                        if (args.Confirmed)
                        {
                            _combat.AddCombatant(args.Combatant);
                        }
                    });
            }
        }

        public ICommand RemoveCombatant
        {
            get
            {
                return MakeCommand
                    .Do(() =>
                    {
                        if(SelectedCombatant != null)
                            _combat.RemoveCombatant(SelectedCombatant);
                    });

            }
        }
    }
}
