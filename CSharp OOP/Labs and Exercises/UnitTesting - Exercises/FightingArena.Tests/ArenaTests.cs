using NUnit.Framework;
using FightingArena;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorArenaWorkCorrectly()
        {
            Arena arena = new Arena();

            int expectedCount = 0;
            int actualCount = arena.Warriors.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConterArenaWorkCorrectly()
        {
            Arena arena = new Arena();

            int expectedCount = 0;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConterArenaWorkCorrectlydd()
        {
            Arena arena = new Arena();
            List<Warrior> list = new List<Warrior>();
            list.Add(new Warrior("Angel", 2, 5));
            list.Add(new Warrior("Ivan", 2, 5));
            list.Add(new Warrior("Georgi", 2, 5));
            list.Add(new Warrior("Tomi", 2, 5));

            foreach (Warrior warrior in list)
            {
                arena.Enroll(warrior);
            }

            List<Warrior> expectedList = list;
            List<Warrior> actualList = arena.Warriors.ToList();

            Assert.AreEqual(expectedList, actualList);
            
        }

        [Test]
        public void EnrollMethodAddCorrectly()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Angel", 2, 5);
            arena.Enroll(warrior);

            int expectedCount = 1;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollMethodShouldThrowInvalidOperationExceptionIfIsAlreadyEnrolled()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Angel", 2, 5);
            Warrior secondWarrior = new Warrior("Angel", 7, 9);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>
                (() => arena.Enroll(secondWarrior));
        }

        [Test]
        public void FightMethodWorkCorrectly()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Ivan", 40, 35);
            Warrior secondWarrior = new Warrior("Angel", 20, 35);
            arena.Enroll(warrior);
            arena.Enroll(secondWarrior);

            arena.Fight("Ivan", "Angel");

            int expectedWarriorHP = 15;
            int actualWarriorHP = warrior.HP;

            Assert.AreEqual(expectedWarriorHP, actualWarriorHP);
        }

        [Test]
        public void FightMethodShouldThrowInvalidOperationExceptionIfAttackerIsNull()
        {
            Arena arena = new Arena();
            //Warrior warrior = new Warrior("Angel", 2, 35);
            Warrior secondWarrior = new Warrior("Ivan", 6, 36);
            //arena.Enroll(warrior);
            arena.Enroll(secondWarrior);

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Angel", "Ivan"));
        }

        [Test]
        public void FightMethodShouldThrowInvalidOperationExceptionIfDefenderIsNull()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Angel", 2, 35);
            //Warrior secondWarrior = new Warrior("Ivan", 6, 36);
            arena.Enroll(warrior);
            //arena.Enroll(secondWarrior);

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Angel", "Ivan"));
        }

        [Test]
        public void FightMethodShouldThrowInvalidOperationExceptionIfTogetherАреNull()
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Angel", "Ivan"));
        }
    }
}
