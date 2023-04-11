namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [TearDown]
        public void TearDown()
        {
            arena = null;
        }

        [Test]
        public void ArenaShouldBeVoidOnCreate()
        {
            arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrollShouldAddWarrior()
        {
            arena.Enroll(new Warrior("Pesho", 15, 100));

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollShouldThrowIfWarriorNameIsNotUnique()
        {
            arena.Enroll(new Warrior("Pesho", 15, 100));

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Pesho", 1, 56));
            });

            Assert.That(ioe.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FightShouldThrowIfAttackerIsMissing()
        {
            arena.Enroll(new Warrior("Pesho", 10, 100));

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Kiro", "Pesho");
            });

            Assert.That(ioe.Message, Is.EqualTo("There is no fighter with name Kiro enrolled for the fights!"));
        }

        [Test]
        public void FightShouldThrowIfDefenderIsMissing()
        {
            arena.Enroll(new Warrior("Kiro", 10, 100));

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Kiro", "Pesho");
            });

            Assert.That(ioe.Message, Is.EqualTo("There is no fighter with name Pesho enrolled for the fights!"));
        }

        [Test]
        public void TestFight()
        {
            Warrior attacker = new Warrior("Pesho", 20, 100);
            Warrior defender = new Warrior("Gosho", 20, 80);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(80, attacker.HP);
            Assert.AreEqual(60, defender.HP);
        }
    }
}
