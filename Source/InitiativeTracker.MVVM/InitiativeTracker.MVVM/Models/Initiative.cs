using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    public class Initiative
    {
        private  Observable<int> _current = new Observable<int>(0);
        private Observable<int> _modifier = new Observable<int>(0);

        public bool IsSet { get; set; }

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
            Current = DiceRoller.Roll(20, Modifier);
            IsSet = true;
        }
    }
}
