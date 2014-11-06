using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Assisticant;
using GalaSoft.MvvmLight.Command;
using InitiativeTracker.MVVM.Models;
using InitiativeTracker.MVVM.ViewModels.EventArgs;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class CombatViewModel
    {
        private readonly Combat _combat;

        private RelayCommand<IEnumerable<object>> _removeCombatantCommand;

        public event Action<object, AddCombatantEventArgs> AddCombatantEvent;

        public RelayCommand<IEnumerable<object>> RemoveCombatant
        {
            get 
            {
                if (_removeCombatantCommand == null)
                {
                    _removeCombatantCommand = new RelayCommand<IEnumerable<object>>(RemoveCombatantExecute);
                }
               
                return _removeCombatantCommand;
            }
        }

        public CombatViewModel(Combat combat)
        {
            _combat = combat;
        }

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

        private void RemoveCombatantExecute(IEnumerable<object> selectedItems)
        {
            var combatants = GetSelectedCombatants(selectedItems);
            foreach (var combatant in combatants)
            {
                _combat.RemoveCombatant(combatant);
            }
        }

        private IEnumerable<Combatant> GetSelectedCombatants(IEnumerable<object> wrappedCombatants)
        {
            return wrappedCombatants
                .Select(combatant => ForView.Unwrap<CombatantViewModel>(combatant).Combatant)
                .ToList();
        }
    }
}
