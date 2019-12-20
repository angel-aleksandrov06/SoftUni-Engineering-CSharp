using NUnit.Framework;
using System;

namespace Tests
{
    class DummyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DummyConstructorTestWithHealth()
        {
            Dummy dummy = new Dummy(10, 10);

            int expectedHealth = 10;
            int actualHealth = dummy.Health;

            Assert.AreEqual(expectedHealth, actualHealth);
        }

        [Test]
        public void DummyConstructorTestWithExperiance()
        {
            Dummy dummy = new Dummy(0, 10);

            int expectedExperiance = 10;
            int actualExperiance = dummy.GiveExperience();

            Assert.AreEqual(expectedExperiance, actualExperiance);
        }

        [Test]
        public void MethodIsDeadShouldReturnfalse()
        {
            Dummy dummy = new Dummy(5, 10);

            bool expectedResult = false;
            bool actualResult = dummy.IsDead();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodGiveExperianceShouldThrowInvalidOperationException()
        {
            Dummy dummy = new Dummy(5, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

        [Test]
        public void MethodTakeAttackShouldThrowInvalidOperationException()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
        }

        [Test]
        public void MethodTakeAttackShouldLooseHealth()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(2);

            int expectedHealth = 8;
            int actualHealth = dummy.Health;

            Assert.AreEqual(expectedHealth, actualHealth);

        }
    }
}
