using InitiativeTracker.MVVM.Models;
using InitiativeTracker.MVVM.Tests.Mock;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests
{
    public class CombatantTests
    {
        [Theory]
        [InlineData("Kobold",1)]
        [InlineData("Brojax", 5)]
        public void CombatantShouldClone(string name, int counter)
        {
            var sut = new Combatant {Name = name, Counter = counter};

            var clone = sut.Clone();

            Assert.Equal(clone,sut);
        }

        [Fact]
        public void InitiativeShouldUnset()
        {
            var sut = new Combatant();
            var loadedDice = new FakeDice();

            sut.Initiative.Roll(loadedDice);
            sut.UnsetInitiative();

            Assert.False(sut.Initiative.IsSet);
        }

        [Fact]
        public void InitiativeShouldResetToZero()
        {
            var sut = new Combatant();
            var loadedDice = new FakeDice();

            sut.Initiative.Roll(loadedDice);
            sut.UnsetInitiative();

            Assert.Equal(0,sut.Initiative.Current);
        }
    }
}
