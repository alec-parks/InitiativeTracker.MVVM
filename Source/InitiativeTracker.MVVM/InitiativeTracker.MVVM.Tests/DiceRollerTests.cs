using InitiativeTracker.MVVM.Models;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests
{
    public class DiceRollerTests
    {
        [Theory]
        [InlineData(20, -1, 0, 19)]
        [InlineData(20,-5,-4,15)]
        [InlineData(20,5,6,25)]
        public void ShouldReturnInitiative(int sides, int modifier, int min, int max)
        {
            var result = DiceRoller.Roll(sides, modifier);

            Assert.InRange(result, min, max);
        }
    }
}
