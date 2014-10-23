using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    public class Initiative
    {
        private  Observable<int> _current = new Observable<int>(0);

        public int Current
        {
            get { return _current.Value; }
            set { _current.Value = value; }
        }

        public int Modifier { get; set; }

        public void Roll()
        {
            Current = DiceRoller.Roll(20, Modifier);
        }
    }
}
