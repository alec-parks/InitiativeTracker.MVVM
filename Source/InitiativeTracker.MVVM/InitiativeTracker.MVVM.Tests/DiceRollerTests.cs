using InitiativeTracker.MVVM.Models;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests
{
    public class DiceRollerTests
    {
        [Theory]
        [InlineData(1, 20, 1, 20)]
        [InlineData(1, 4, 1, 4)]
        public void ShouldReturnRoll(int dice, int sides, int min, int max)
        {
            var sut = new DiceRoller();

            var result = sut.Roll(dice, sides);

            Assert.InRange(result, min, max);
        }

        [Fact]
        public void ShouldReturnRandom()
        {
            var sut = new DiceRoller();

            for (var x = 0; x < 1000000; x++)
            {
                var roll = sut.Roll(1, 20);
                Assert.InRange(roll, 1, 20);
            }
        }
    }
}
