using System.Windows.Input;
using Assisticant;
using Assisticant.Fields;
using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.ViewModels
{
    public class CombatantInitiativeViewModel
    {
        private Observable<Combatant> _combatant = new Observable<Combatant>();

        public Combatant Combatant
        {
            get { return _combatant.Value; }
        }

        public CombatantInitiativeViewModel(Combatant combatant)
        {
            _combatant.Value = combatant;
        }

        public string DisplayName
        {
            get { return _combatant.Value.DisplayName; }
        }

        public int Modifier
        {
            get { return _combatant.Value.Initiative.Modifier; }
        }

        public int Current
        {
            get { return _combatant.Value.Initiative.Current; }
            set { _combatant.Value.Initiative.Current = value; }
        }

        public ICommand RollInitiative
        {
            get
            {
                return MakeCommand
                    .Do(() => _combatant.Value.Initiative.Roll());
            }
        }
    }
}
