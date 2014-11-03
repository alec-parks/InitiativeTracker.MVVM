using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    public class Combatant
    {
        private Observable<int> _counter = new Observable<int>(0);

        private Observable<string> _name = new Observable<string>("");

        private Observable<CombatantType> _type = new Observable<CombatantType>(CombatantType.Player);

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

        public string Name
        {
            get { return _name; }
            set { _name.Value = value; }
        }

        public CombatantType Type
        {
            get { return _type; } 
            set { _type.Value = value; }
        }

        public override int GetHashCode()
        {
            return DisplayName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            
            var combatantObj = obj as Combatant;

            if (combatantObj == null)
                return false;

            return Counter == combatantObj.Counter && Name == combatantObj.Name && Type == combatantObj.Type;
        }
    }
}
