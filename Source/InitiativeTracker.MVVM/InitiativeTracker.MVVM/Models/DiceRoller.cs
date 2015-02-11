using System;

namespace InitiativeTracker.MVVM.Models
{
    public class DiceRoller:IDice
    {
        readonly static Random DiceRoll = new Random();

        public int Roll(int dice, int sides)
        {
            int min = dice;
            int max = dice*sides + 1;
            return DiceRoll.Next(min,max);
        }
    }
}
