using NUnit.Framework;
using System;

namespace AxeTests
{
    public class AxeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AxeConstructorTestWithAttackPoints()
        {
            Axe axe = new Axe(10, 10);

            int expectedAttackPoints = 10;
            int actualAttackPoints = axe.AttackPoints;

            Assert.AreEqual(expectedAttackPoints, actualAttackPoints);
        }

        [Test]
        public void AxeConstructorTestWithDurability()
        {
            Axe axe = new Axe(10, 10);

            int expectedDurability = 10;
            int actualDurability = axe.DurabilityPoints;

            Assert.AreEqual(expectedDurability, actualDurability);
        }

        [Test]
        public void AxeLooseDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);

            int expectedDurability = 9;
            int actualDurability = axe.DurabilityPoints;

            Assert.AreEqual(expectedDurability, actualDurability);
        }

        [Test]
        public void MethodAttackShouldThrowInvalidOperationException()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);


            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}