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

        private RelayCommand<IEnumerable<object>> _addCopyCommand;

        public event Action<object, AddCombatantEventArgs> AddCombatantEvent;

        public event Action<object, SetInitiativeEventArgs> SetInitiativeEvent;

        public event Action<object, EndCombatEventArgs> EndCombatEvent;

        public RelayCommand<IEnumerable<object>> RemoveCombatant
        {
            get 
            {
                if (_removeCombatantCommand == null)
                {
                    _removeCombatantCommand = new RelayCommand<IEnumerable<object>>(RemoveCombatantExecute
                        ,RemoveCombatantCanExecute);
                }
               
                return _removeCombatantCommand;
            }
        }

        public RelayCommand<IEnumerable<object>> AddCopy
        {
            get
            {
                if (_addCopyCommand == null)
                {
                    _addCopyCommand = new RelayCommand<IEnumerable<object>>(AddCopyExecute
                        ,AddCopyCanExecute);
                }

                return _addCopyCommand;
            }
        }

        public CombatViewModel(Combat combat)
        {
            _combat = combat;
        }

        public bool HasStarted
        {
            get { return _combat.HasStarted; }
        }

        public bool HasNotStarted
        {
            get { return !_combat.HasStarted; }
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

        public ICommand StartCombat
        {
            get { 
                return MakeCommand
                .When(() => !HasStarted)
                .Do(StartCombatControl); }
        }

        public ICommand EndCombat
        {
            get
            {
                return MakeCommand
                    .When(() => HasStarted)
                    .Do(EndCombatControl);
            }
        }

        public void StartCombatControl()
        {
            var combatantList = _combat.Combatants
                .Where(combatants => combatants.Type == CombatantType.Player).ToList();

            var args = new SetInitiativeEventArgs();

            if (SetInitiativeEvent != null)
            {
                SetInitiativeEvent(this, args);
            }

            if (args.Confirmed)
            {
                _combat.StartCombat();
                foreach (var combatant in combatantList)
                {
                    combatant.Initiative.IsSet = true;
                }
            }
        }

        public void EndCombatControl()
        {
            var args = new EndCombatEventArgs();

            if (EndCombatEvent != null)
            {
                EndCombatEvent(this, args);
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

        private void AddCopyExecute(IEnumerable<object> selectedItems)
        {
            var combatants = GetSelectedCombatants(selectedItems);
            foreach (var combatant in combatants)
            {
                _combat.AddCopy(combatant);
            }
        }

        private bool RemoveCombatantCanExecute(IEnumerable<object> selectedItems)
        {
            return selectedItems.Any();
        }

        private bool AddCopyCanExecute(IEnumerable<object> selectedItems)
        {
            var selectedCombatants = GetSelectedCombatants(selectedItems);

            if (selectedCombatants.Any(combatant => combatant.Type == CombatantType.Player) 
                || !selectedItems.Any())
            {
                return false;
            }

            return true;
        }

        private IEnumerable<Combatant> GetSelectedCombatants(IEnumerable<object> wrappedCombatants)
        {
            return wrappedCombatants
                .Select(combatant => ForView.Unwrap<CombatantViewModel>(combatant).Combatant)
                .ToList();
        }
    }
}
