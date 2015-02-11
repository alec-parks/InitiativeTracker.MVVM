using InitiativeTracker.MVVM.Models;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests
{
    public class DiceRollerTests
    {
        [Theory]
        [InlineData(1, 20, 1, 20)]
        [InlineData(2, 10, 2, 20)]
        [InlineData(1, 4, 1, 4)]
        [InlineData(3, 6, 3, 18)]
        public void ShouldReturnRoll(int dice, int sides, int min, int max)
        {
            var result = DiceRoller.Roll(dice, sides);

            Assert.InRange(result, min, max);
        }

        [Fact]
        public void ShouldReturnRandom()
        {
            for (int x = 0; x < 1000000; x++)
            {
                var roll = DiceRoller.Roll(1, 20);
                Assert.InRange(roll, 1, 20);
            }
        }
    }
}
