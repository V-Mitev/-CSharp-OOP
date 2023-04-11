using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        Dummy dummy;
        Dummy deadDummy;
        private int health = 10;
        private int experience = 10;
        private int attackPoints = 5;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(-5, experience);
        }

        [Test]
        public void When_DummyHealthAndExperienceProvided_ShouldBeSetCorrectly()
        {
            Assert.AreEqual(dummy.Health, health);
        }

        [Test]
        public void When_DummyTakeAttack_ShouldHealthDecrease()
        {
            dummy.TakeAttack(attackPoints);
            Assert.AreEqual(dummy.Health, health - 5);
        }

        [Test]
        public void When_DummyTakeAttack_AndLoseAllHealthPoints_ShouldThrowException()
        {
            deadDummy = new Dummy(-5, experience);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 2; i++)
                {
                    deadDummy.TakeAttack(attackPoints);
                }
            });

            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void When_DummyHealthReachZeroOrBelow()
        {
            Assert.That(dummy.IsDead(), Is.EqualTo(false));
        }

        [Test]
        public void When_DummyIsDeadGiveExperience()
        {
            Assert.That(deadDummy.GiveExperience(), Is.EqualTo(experience));
        }

        [Test]
        public void When_DummyIsAlive_ThrowInvalidOperationException()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });

            Assert.That(ioe.Message, Is.EqualTo("Target is not dead."));
        }
    }
}