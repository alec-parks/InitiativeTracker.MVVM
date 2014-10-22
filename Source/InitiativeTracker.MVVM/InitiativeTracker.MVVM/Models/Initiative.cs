using Assisticant.Fields;

namespace InitiativeTracker.MVVM.Models
{
    class Initiative
    {
        private  Observable<int> _current = new Observable<int>(0);

        public int Current
        {
            get { return _current.Value; }
            set { _current.Value = value; }
        }

        public int Modifier { get; set; }

        public Initiative(){}
        public Initiative(int initiative, int modifier )
        {
            Current = initiative;
            Modifier = modifier;
        }

        public void RollInitiative()
        {
            Current = DiceRoller.Roll(20, Modifier);
        }
    }
}
