using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitMotorcycleConstructorShoulWorkCorrectlyPropModel()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            string explectedName = "Duccato";
            string actualName = unitMotorcycle.Model;

            Assert.AreEqual(explectedName, actualName);
        }

        [Test]
        public void UnitMotorcycleConstructorShoulWorkCorrectlyPropHP()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            int explectedHP = 52;
            int actualHP = unitMotorcycle.HorsePower;

            Assert.AreEqual(explectedHP, actualHP);
        }

        [Test]
        public void UnitMotorcycleConstructorShoulWorkCorrectlyPropCubicCentimeters()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            double explectedCC = 997.20;
            double actualCC = unitMotorcycle.CubicCentimeters;

            Assert.AreEqual(explectedCC, actualCC);
        }

        [Test]
        public void UnitRiderConstructorShoulWorkCorrectlyPropName()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = new UnitRider("Angel", unitMotorcycle);

            string explectedName = "Angel";
            string actualName = unitRider.Name;

            Assert.AreEqual(explectedName, actualName);
        }

        [Test]
        public void UnitRiderConstructorShoulThrowArgumentNullException()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = null;

            Assert.Throws<ArgumentNullException>(() => unitRider = new UnitRider(null, unitMotorcycle));
        }

        [Test]
        public void UnitRiderConstructorShoulWorkCorrectlyPropUnitMotorcycle()
        {
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = new UnitRider("Angel", unitMotorcycle);

            UnitMotorcycle explectedUnitMotorcycle = unitMotorcycle;
            UnitMotorcycle actualUnitMotorcycle = unitRider.Motorcycle;

            Assert.AreEqual(explectedUnitMotorcycle, actualUnitMotorcycle);
        }

        [Test]
        public void RaceEntryConstructorShouldWorkCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            int expectedCount = 0;
            int actualCount = raceEntry.Counter;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void MethodAddRiderShouldThrowIfRiderIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null));
        }

        [Test]
        public void MethodAddRiderShouldThrowIfRiderAlreadyExist()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = new UnitRider("Angel", unitMotorcycle);
            raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider));
        }

        [Test]
        public void MethodAddRiderWorkCorrectlyTestWhitCounter()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = new UnitRider("Angel", unitMotorcycle);
            raceEntry.AddRider(unitRider);

            int expectedCount = 1;
            int actualCount = raceEntry.Counter;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void MethodAddRiderWorkCorrectlyTestWhitReturnResult()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = new UnitRider("Angel", unitMotorcycle);

            string explectedResult = "Rider Angel added in race.";
            string actualResult = raceEntry.AddRider(unitRider);

            Assert.AreEqual(explectedResult, actualResult);
        }

        [Test]
        public void MethodCalculateAverageHorsePowerShouldThrowInvalidOperationException()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = new UnitRider("Angel", unitMotorcycle);
            raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void MethodCalculateAverageHorsePowerShouldWorkCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Duccato", 52, 997.20);
            UnitRider unitRider = new UnitRider("Angel", unitMotorcycle);
            UnitRider unitRider2 = new UnitRider("Ivan", unitMotorcycle);
            UnitRider unitRider3 = new UnitRider("Georgi", unitMotorcycle);
            raceEntry.AddRider(unitRider);
            raceEntry.AddRider(unitRider2);
            raceEntry.AddRider(unitRider3);

            double explectedAverageHP = 52;
            double actualAverageHP = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(explectedAverageHP, actualAverageHP);
        }
    }
}