using InitiativeTracker.MVVM.Models;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests
{
    public class InitiativeTests
    {
        [Fact]
        public void RollingShouldSetInitiative()
        {
            var sut = new Initiative();
            var diceRoller = new DiceRoller();

            sut.Roll(diceRoller);

            Assert.True(sut.IsSet);
        }

        [Fact]
        public void RollingShouldAssignInitiative()
        {
            var sut = new Initiative();
            var loadedDice = new FakeDice();

            sut.Roll(loadedDice);

            Assert.Equal(10,sut.Current);
        }

        [Theory]
        [InlineData(4,14)]
        [InlineData(-4,6)]
        [InlineData(0,10)]
        public void RollingShouldAddModifier(int mod, int expected)
        {
            var sut = new Initiative();
            var loadedDice = new FakeDice();

            sut.Modifier = mod;

            sut.Roll(loadedDice);

            Assert.Equal(expected,sut.Current);
        }
    }

     class FakeDice : IDice
    {
         public int Roll(int dice, int sides)
         {
            return 10;
         }
    }
}
