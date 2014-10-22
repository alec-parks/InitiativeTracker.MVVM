using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    class Combatant
    {
        private Observable<Initiative> _initiative = new Observable<Initiative>();
        private  Observable<string> _name = new Observable<string>("");

        public Initiative Initiative
        {
            get { return _initiative.Value; }
            set { _initiative.Value = value; }
        }

        public string Name
        {
            get { return _name.Value; }
            set { _name.Value = value; }
        }

        public CombatantType Type {get; set;}
    }
}
