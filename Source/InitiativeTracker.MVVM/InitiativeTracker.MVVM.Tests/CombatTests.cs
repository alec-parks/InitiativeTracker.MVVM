using System.Linq;
using InitiativeTracker.MVVM.Models;
using InitiativeTracker.MVVM.Tests.Mock;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests
{
    public class CombatTests
    {
        [Fact]
        public void CombatShouldStart()
        {
            var sut = new Combat();
            sut.StartCombat();
            Assert.True(sut.HasStarted);
        }

        [Fact]
        public void CombatShouldEnd()
        {
            var sut = new Combat();
            sut.StartCombat();
            sut.EndCombat();
            Assert.False(sut.HasStarted);
        }

        [Theory]
        [InlineData("Brojax",0,CombatantType.Player)]
        [InlineData("Kobold",2,CombatantType.Monster)]
        [InlineData("Hans",1,CombatantType.Player)]
        [InlineData("Adult Black Dragon",0,CombatantType.Monster)]
        public void CombatantShouldBeAdded(string name, int ctr, CombatantType type)
        {
            var sut = new Combat();
            var combatant = new Combatant {Name = name, Counter = ctr, Type = type};

            sut.AddCombatant(combatant);

            Assert.Contains(combatant,sut.Combatants);
        }

        [Fact]
        public void InitiativeShouldBeReset()
        {
            var sut = new Combat();
            var combatant = new Combatant {Counter = 0, Name = "Brojax", Type = CombatantType.Player};
            var loadedDice = new FakeDice();

            sut.AddCombatant(combatant);
            combatant.Initiative.Roll(loadedDice);

            sut.UnsetInitiative(sut.Combatants);

            Assert.Equal(combatant.Initiative.Current,0);
        }

        [Fact]
        public void MonstersShouldBeRemoved()
        {
            var sut = new Combat();
            var player = new Combatant{Name="Brojax",Type=CombatantType.Player};
            var monster = new Combatant {Name = "Kobold", Type = CombatantType.Monster};

            sut.AddCombatant(player);
            sut.AddCombatant(monster);

            sut.RemoveMonsters(sut.Combatants.Where(combatant => combatant.Type == CombatantType.Monster).ToList());

            Assert.DoesNotContain(monster,sut.Combatants);
        }
    }
}
