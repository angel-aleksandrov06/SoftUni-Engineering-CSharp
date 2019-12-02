using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWarriorSetCorrectlyName()
        {
            Warrior warrior = new Warrior("Angel", 5, 35);
            string expectedName = "Angel";
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ConstructorWarriorSetCorrectlyHP()
        {
            Warrior warrior = new Warrior("Angel", 5, 35);
            int expectedName = 35;
            int actualName = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ConstructorWarriorSetCorrectlyDamage()
        {
            Warrior warrior = new Warrior("Angel", 5, 35);
            int expectedName = 5;
            int actualName = warrior.Damage;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void PropertyNameValidationSouldThrowArgumentExceptionIfValueIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 5, 35));
        }

        [Test]
        public void PropertyNameValidationSouldThrowArgumentExceptionIfValueIsWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 5, 35));
        }

        [Test]
        public void PropertyNameValidationSouldThrowArgumentExceptionIfValueIsEmptyString()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(string.Empty, 5, 35));
        }

        [Test]
        public void PropertyDamageValidationSouldThrowArgumentExceptionIfValueIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Angel", -10, 35));
        }

        [Test]
        public void PropertyDamageValidationSouldThrowArgumentExceptionIfValueIsZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Angel", 0, 35));
        }

        [Test]
        public void PropertyHPValidationSouldThrowArgumentExceptionIfValueIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Angel", 10, -10));
        }

        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfWarriorHPIsBellowMin_Attack_HP()
        {
            Warrior enemy = new Warrior("Ivan", 15, 35);
            Warrior warrior = new Warrior("Angel", 10, 20);

            Assert.Throws<InvalidOperationException>(() => enemy.Attack(warrior));
        }

        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfWarriorHPIsEqualMin_Attack_HP()
        {
            Warrior enemy = new Warrior("Ivan", 15, 35);
            Warrior warrior = new Warrior("Angel", 10, 30);

            Assert.Throws<InvalidOperationException>(() => enemy.Attack(warrior));
        }

        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfEnemyHPIsBellowMin_Attack_HP()
        {
            Warrior enemy = new Warrior("Ivan", 15, 20);
            Warrior warrior = new Warrior("Angel", 10, 35);

            Assert.Throws<InvalidOperationException>(() => enemy.Attack(warrior));
        }

        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfEnemyHPIsEqualin_Attack_HP()
        {
            Warrior enemy = new Warrior("Ivan", 15, 30);
            Warrior warrior = new Warrior("Angel", 10, 35);

            Assert.Throws<InvalidOperationException>(() => enemy.Attack(warrior));
        }

        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfEnemyHPIsBellowWarriorDamage()
        {
            Warrior enemy = new Warrior("Ivan", 15, 35);
            Warrior warrior = new Warrior("Angel", 40, 35);

            Assert.Throws<InvalidOperationException>(() => enemy.Attack(warrior));
        }

        [Test]
        public void AttackMethodShouldRemoveWarriorDamagePointsFromEnemyHP()
        {
            Warrior enemy = new Warrior("Ivan", 40, 35);
            Warrior warrior = new Warrior("Angel", 20, 35);
            enemy.Attack(warrior);

            int expectedWarriorHP = 15;
            int actualWarriorHP = enemy.HP;

            Assert.AreEqual(expectedWarriorHP, actualWarriorHP);
        }

        [Test]
        public void AttackMethodShouldMakeWarriorHPToZeroIfEnemyDamageIsBegger()
        {
            Warrior enemy = new Warrior("Ivan", 40, 35);
            Warrior warrior = new Warrior("Angel", 20, 35);
            enemy.Attack(warrior);

            int expectedWarriorHP = 0;
            int actualWarriorHP = warrior.HP;

            Assert.AreEqual(expectedWarriorHP, actualWarriorHP);
        }

        [Test]
        public void AttackMethodShouldRemoveEnemyDamagePointsFromWarriorHp()
        {
            Warrior enemy = new Warrior("Ivan", 20, 35);
            Warrior warrior = new Warrior("Angel", 20, 35);
            enemy.Attack(warrior);

            int expectedWarriorHP = 15;
            int actualWarriorHP = warrior.HP;

            Assert.AreEqual(expectedWarriorHP, actualWarriorHP);
        }
    }
}