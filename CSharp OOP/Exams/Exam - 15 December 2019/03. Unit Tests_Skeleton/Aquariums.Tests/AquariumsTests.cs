namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorFishTestWhitName()
        {
            Fish fish = new Fish("Angel");

            string expectedName = "Angel";
            string actualName = fish.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ConstructorFishTestWhitAvailable()
        {
            Fish fish = new Fish("Angel");

            bool expectedAvailable = true;
            bool actualAvailable = fish.Available;

            Assert.AreEqual(expectedAvailable, actualAvailable);
        }

        [Test]
        public void AquariumConstructorWorkCorrectlyTestWhitCount()
        {
            Aquarium aquarium = new Aquarium("Varna", 2);

            int explectedCount = 0;
            int actualCount = aquarium.Count;

            Assert.AreEqual(explectedCount, actualCount);
        }

        [Test]
        public void AquariumConstructorWorkCorrectlyTestName()
        {
            Aquarium aquarium = new Aquarium("Varna", 2);

            string expectedName = "Varna";
            string actualName = aquarium.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void AquariumPropNameShouldThrowArgumentNullException()
        {
            Aquarium aquarium = null;

            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(null, 2));
        }

        [Test]
        public void AquariumConstructorWorkCorrectlyTestCapacity()
        {
            Aquarium aquarium = new Aquarium("Varna", 2);

            int explectedCapacity = 2;
            int actualCapacity = aquarium.Capacity;

            Assert.AreEqual(explectedCapacity, actualCapacity);
        }

        [Test]
        public void AquariumPropNameShouldThrowArgumentExceptionIfIsBellowZero()
        {
            Aquarium aquarium = null;

            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Varna", -2));
        }

        [Test]
        public void MethodAddShouldThrowInvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            Fish secondFish = new Fish("Angek");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(secondFish));
        }

        [Test]
        public void MethodAddShouldAddCorrectly()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);

            int explectedCount = 1;
            int actualCount = aquarium.Count;

            Assert.AreEqual(explectedCount, actualCount);
        }

        [Test]
        public void MethodRemoveShouldThrowInvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Ivan"));
        }

        [Test]
        public void MethodRemoveShouldRemoveCorrectly()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);
            aquarium.RemoveFish("Angel");

            int explectedCount = 0;
            int actualCount = aquarium.Count;

            Assert.AreEqual(explectedCount, actualCount);
        }

        [Test]
        public void MethodSellFishShouldThrowInvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Ivan"));
        }

        [Test]
        public void MethodSellFishShouldRemoveCorrectly()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);
            aquarium.SellFish("Angel");

            bool expectedResult = false;
            bool actualResult = fish.Available;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodSellFishShouldRemoveCorrectlyAndReturnFish()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);
            aquarium.SellFish("Angel");

            Fish expectedResult = fish;
            Fish actualResult = aquarium.SellFish("Angel");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodReportShouldWorkCorrectlyAndReturnString()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);

            string expectedResult = "Fish available at Varna: Angel";
            string actualResult = aquarium.Report();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
