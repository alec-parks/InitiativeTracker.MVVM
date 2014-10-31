using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    public class Combatant
    {
        private Observable<int> _counter = new Observable<int>(0);

        public Combatant()
        {
            Initiative = new Initiative();
        }

        public int Counter
        {
            get { return _counter.Value; }
            set { _counter.Value = value; }
        }
        
        public string DisplayName
        {
            get
            {
                var counterDisplay = (Counter > 0
                    ? " " + Counter
                    : "");
                return Name + counterDisplay;
            }
        }
        
        public Initiative Initiative{get; set; }
        
        public string Name { get; set; }
        
        public CombatantType Type {get; set;}
    }
}
