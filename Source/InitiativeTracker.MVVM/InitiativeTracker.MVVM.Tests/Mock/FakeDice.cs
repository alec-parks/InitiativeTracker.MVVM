using InitiativeTracker.MVVM.Models;

namespace InitiativeTracker.MVVM.Tests.Mock
{
    class FakeDice : IDice
    {
        public int Roll(int dice, int sides)
        {
            return 10;
        }
    }
}
