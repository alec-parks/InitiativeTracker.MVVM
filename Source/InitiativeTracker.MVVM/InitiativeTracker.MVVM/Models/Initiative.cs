using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    public class Initiative
    {
        private  Observable<int> _current = new Observable<int>(0);
        private Observable<int> _modifier = new Observable<int>(0);
        private Observable<bool> _isSet = new Observable<bool>(false);

        public bool IsSet
        {
            get { return _isSet.Value; } 
            set { _isSet.Value = value; }
        }

        public int Current
        {
            get { return _current.Value; }
            set { _current.Value = value; }
        }

        public int Modifier
        {
            get { return _modifier; }
            set { _modifier.Value = value; }
        }

        public void Roll()
        {
            Current = DiceRoller.Roll(1,20);
            IsSet = true;
        }
    }
}
