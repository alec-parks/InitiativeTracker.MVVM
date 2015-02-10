using System;

namespace InitiativeTracker.MVVM.Models
{
    public static class DiceRoller
    {
        readonly static Random DiceRoll = new Random();

        public static int Roll(int die, int sides)
        {
            int min = die;
            int max = die*sides + 1;
            return DiceRoll.Next(min,max);
        }
    }
}
