using System;

namespace InitiativeTracker.MVVM.Models
{
    static class DiceRoller
    {
        readonly static Random DiceRoll = new Random();

        public static int Roll(int die, int modifier)
        {
            return DiceRoll.Next(1, die + 1) + modifier;
        }
    }
}
