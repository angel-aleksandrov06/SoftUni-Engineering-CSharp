namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

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

            int explectedCount = 2;
            int actualCount = aquarium.Capacity;

            Assert.AreEqual(explectedCount, actualCount);
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
            Fish fish2 = new Fish("Angek");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2));
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
        public void MethodSellShouldThrowInvalidOperationException()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Ivan"));
        }

        [Test]
        public void MethodSellShouldRemoveCorrectly()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);
            aquarium.SellFish("Angel");

            bool expectedAvailable = false;
            bool actualAvailable = fish.Available;

            Assert.AreEqual(expectedAvailable, actualAvailable);
        }

        [Test]
        public void MethodSellShouldRemoveCorrectlyReturn()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);
            aquarium.SellFish("Angel");

            Fish expectedAvailable = fish;
            Fish actualAvailable = aquarium.SellFish("Angel");

            Assert.AreEqual(expectedAvailable, actualAvailable);
        }

        [Test]
        public void MethodReportShouldWorkCorrectlyReturn()
        {
            Aquarium aquarium = new Aquarium("Varna", 1);
            Fish fish = new Fish("Angel");
            aquarium.Add(fish);

            string expectedName = "Fish available at Varna: Angel";
            string actualName = aquarium.Report();

            Assert.AreEqual(expectedName, actualName);
        }
    }
}
