namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void AstronautConstructorShouldWorkCorrectlyTestWithName()
        {
            Astronaut astronaut = new Astronaut("Angel", 5.20);
        
            string expectedName = "Angel";
            string actualName = astronaut.Name;
        
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void AstronautConstructorShouldWorkCorrectlyTestWithOxygen()
        {
            Astronaut astronaut = new Astronaut("Angel", 5.20);

            double expectedOxygen = 5.20;
            double actualOxygen = astronaut.OxygenInPercentage;

            Assert.AreEqual(expectedOxygen, actualOxygen);
        }

        [Test]
        public void SpaceshipConstructorWorkCorrectlyTestCount()
        {
            Spaceship spaceship = new Spaceship("Delta", 20);

            int expectedCount = 0;
            int actualCount = spaceship.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void SpaceshipConstructorWorkCorrectlyTestName()
        {
            Spaceship spaceship = new Spaceship("Delta", 20);

            string expectedName = "Delta";
            string actualName = spaceship.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void PropNameShouldThrowArgumentNullException()
        {
            Spaceship spaceship = null;

            Assert.Throws<ArgumentNullException>(() => spaceship = new Spaceship(null, 20));
        }

        [Test]
        public void SpaceshipConstructorWorkCorrectlyTestCapacity()
        {
            Spaceship spaceship = new Spaceship("Delta", 20);

            int expectedName = 20;
            int actualName = spaceship.Capacity;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void PropCapacityShouldThrowArgumentException()
        {
            Spaceship spaceship = null;

            Assert.Throws<ArgumentException>(() => spaceship = new Spaceship("Delta", -10));
        }

        [Test]
        public void MethodAddShouldThrowInvalidOperationExceptionIfAstronautsCountIsFull()
        {
            Astronaut astronaut = new Astronaut("Angel", 5.20);
            Astronaut astronaut2 = new Astronaut("Ivan", 5.20);

            Spaceship spaceship = new Spaceship("Delta", 1);
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut2));
        }

        [Test]
        public void MethodAddShouldThrowInvalidOperationExceptionIfCurrentAstronaultExist()
        {
            Astronaut astronaut = new Astronaut("Angel", 5.20);
            Astronaut astronaut2 = new Astronaut("Angel", 5.20);

            Spaceship spaceship = new Spaceship("Delta", 3);
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut2));
        }

        [Test]
        public void MethodAddShouldAddCurrentAstronaultInList()
        {
            Astronaut astronaut = new Astronaut("Angel", 5.20);
            Spaceship spaceship = new Spaceship("Delta", 3);
            spaceship.Add(astronaut);

            int expectedCount = 1;
            int actualCount = spaceship.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void MethodRemoveShouldWorkCorrectlyReturnTrue()
        {
            Astronaut astronaut = new Astronaut("Angel", 5.20);
            Spaceship spaceship = new Spaceship("Delta", 3);
            spaceship.Add(astronaut);

            bool explectedResult = true;
            bool actualResult = spaceship.Remove("Angel");

            Assert.AreEqual(explectedResult, actualResult);
        }

        [Test]
        public void MethodRemoveShouldWorkCorrectlyReturnFalse()
        {
            Astronaut astronaut = new Astronaut("Angel", 5.20);
            Spaceship spaceship = new Spaceship("Delta", 3);
            spaceship.Add(astronaut);

            bool explectedResult = false;
            bool actualResult = spaceship.Remove("Ivan");

            Assert.AreEqual(explectedResult, actualResult);
        }
    }
}