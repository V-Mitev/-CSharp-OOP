namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class WarriorTests
    {
        Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Pesho", 15, 45);
        }

        [TearDown]
        public void TearDown()
        {
            warrior = null;
        }

        [Test]
        public void CreateWarrior()
        {
            warrior = new Warrior("Pesho", 15, 100);

            Assert.AreEqual("Pesho", warrior.Name);
            Assert.AreEqual(15, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void WarriorShouldThrowIfNameIsEmptyOrWhiteSpace(string name)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 15, 100);
            });

            Assert.That(ae.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        public void WarriorShouldThrowIfDamageIsZeroOrLess(int damage)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Pesho", damage, 50);
            });

            Assert.That(ae.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void WarriorShouldThrowIfHPIsNegative()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Pesho", 15, -50);
            });

            Assert.That(ae.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackShouldThrowIfHPLessThan30()
        {
            Warrior attacker = new Warrior("Pesho", 15, 10);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(warrior);
            });

            Assert.That(ioe.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackShouldThrowIfDefenderHpIsLessThan30()
        {
            Warrior defender = new Warrior("Pesho", 15, 20);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            });

            Assert.That(ioe.Message, Is.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void AttackShouldThrowIfAttackerDamageIsLowerThanDefenderHp()
        {
            Warrior defender = new Warrior("Gosho", 50, 120);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            });

            Assert.That(ioe.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackShouldBeSucceed()
        {
            var defender = new Warrior("Gosho", 15, 50);

            warrior.Attack(defender);

            Assert.AreEqual(35, defender.HP);
            Assert.AreEqual(30, warrior.HP);
        }

        [Test]
        public void AttackShouldKill()
        {
            var attacker = new Warrior("Pesho", 45, 60);
            var defender = new Warrior("Gosho", 15, 35);

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
            Assert.AreEqual(45, attacker.HP);
        }
    }
}