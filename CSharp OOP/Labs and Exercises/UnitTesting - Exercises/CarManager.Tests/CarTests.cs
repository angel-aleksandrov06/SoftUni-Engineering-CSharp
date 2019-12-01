namespace Tests
{
    using CarManager;
    using NUnit.Framework;
    using System;

    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorInitializeCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void ModelShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void MakeShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenIsBellowZero()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = -10;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenIsZero()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelCapacityShouldThrowArgumentExceptionWhenIsBellowZero()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = -100;

            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelCapacityShouldThrowArgumentExceptionWhenIsZero()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        //[Test]
        [TestCase(null, "Golf", 10, 20)]
        [TestCase("VW", null, 10, 20)]
        [TestCase("VW", "Golf", -10, 20)]
        [TestCase("VW", "Golf", 0, 20)]
        [TestCase("VW", "Golf", 10, -20)]
        [TestCase("VW", "Golf", 10, 0)]
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidValues(string make, string model, double fuelConsumption, double fuelCapacity)
        {

            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShoudRefuelNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(10);

            double actualFuelAmount = car.FuelAmount;
            double expectedFuelAmount = 10;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void ShoudRefuelUnitlTotalCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(150);

            double actualFuelAmount = car.FuelAmount;
            double expectedFuelAmount = 100;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldThrowArgumentExceptionWhenInputAmountIsBellowZero(double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>
                (() => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldDriveNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelAmountIsNotEnought()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);


            Assert.Throws<InvalidOperationException>
                (() => car.Drive(20));
        }
    }
}