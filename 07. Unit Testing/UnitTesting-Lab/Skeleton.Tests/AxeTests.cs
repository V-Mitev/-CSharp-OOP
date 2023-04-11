using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private int attack = 5;
        private int durability = 6;
        private Dummy dummy;
        private int health = 100;
        private int experience = 100;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attack, durability);    
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void When_AxeAttackAndDurabilityProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(axe.AttackPoints, attack);
            Assert.AreEqual(axe.DurabilityPoints, durability);
        }

        [Test]
        public void When_AttackLoseDurability()
        {
            axe.Attack(dummy);

            Assert.AreEqual(durability - 1, axe.DurabilityPoints);
        }

        [Test]
        public void When_AxeIsBroken()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                axe.Attack(null);
            });
        }

        [Test]
        public void When_AxeAttackWithDurabilityPointsZero_ShouldThrowException()
        {
            dummy = new Dummy(5000, 5000);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 7; i++)
                {
                    axe.Attack(dummy);
                }
            });

            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}