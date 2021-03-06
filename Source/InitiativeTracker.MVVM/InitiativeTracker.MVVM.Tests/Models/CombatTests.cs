﻿using System.Linq;
using InitiativeTracker.MVVM.Models;
using InitiativeTracker.MVVM.Tests.Mock;
using Xunit;
using Xunit.Extensions;

namespace InitiativeTracker.MVVM.Tests.Models
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
        public void CombatantShouldBeRemoved()
        {
            var sut = new Combat();
            var combatant = new Combatant {Name = "Brojax", Counter = 0};
            var monster = new Combatant {Name = "Kobold", Counter = 0};

            sut.AddCombatant(combatant);
            sut.AddCombatant(monster);

            sut.RemoveCombatant(combatant);

            Assert.DoesNotContain(combatant,sut.Combatants);
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

        [Theory]
        [InlineData("Kobold",CombatantType.Monster,0)]
        [InlineData("Kobold",CombatantType.Monster,10)]
        [InlineData("Brojax",CombatantType.Player,10)]
        public void CopyShouldIncrementCounter(string name, CombatantType type, int ctr)
        {
            var sut = new Combat();
            var combatant = new Combatant { Name = name, Type = type, Counter = ctr};
            var expected = new Combatant {Name = name, Type = type, Counter = ctr+1};

            sut.AddCombatant(combatant);
            sut.AddCopy(combatant);

            Assert.Contains(expected,sut.Combatants);
        }
    }
}
