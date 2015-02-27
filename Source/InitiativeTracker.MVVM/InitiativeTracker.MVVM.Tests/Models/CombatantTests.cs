using InitiativeTracker.MVVM.Models;
using InitiativeTracker.MVVM.Tests.Mock;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests.Models
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

        [Fact]
        public void ShouldNotBeEqual()
        {
            var sut = new Combatant {Name = "Brojax",Counter=1,Type = CombatantType.Player};
            var other = new Combatant{Name = "Brojax",Counter=1,Type = CombatantType.Monster};

            Assert.False(sut.Equals(other));
        }

        [Fact]
        public void ShouldNotEqualNullObject()
        {
            var sut = new Combatant { Name = "Brojax", Counter = 1, Type = CombatantType.Player };

            Assert.False(sut.Equals(null));
        }

        [Theory]
        [InlineData("Brojax", 0, "Brojax")]
        [InlineData("Brojax", 1, "Brojax 1")]
        public void ShouldGenerateDisplayName(string name, int ctr, string expected)
        {
            var sut = new Combatant {Name = name, Counter = ctr};

            Assert.Equal(expected,sut.DisplayName);
        }
    }
}
