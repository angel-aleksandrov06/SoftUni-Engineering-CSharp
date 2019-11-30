namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark park;

        [SetUp]
        public void Setup()
        {
            this.park = new SoftPark();
        }

        [Test]
        public void Try_Park_On_Invalid_Park_Spot_Should_Throw()
        {
            Assert.Throws<ArgumentException>(
                () => park.ParkCar("A0", null));
        }

        [Test]
        public void Try_Park_On_Taken_Spot_Should_Throw()
        {
            this.park.ParkCar("A1", new Car("Make", "RN"));

            Assert.Throws<ArgumentException>(
                () => park.ParkCar("A1", new Car(string.Empty, string.Empty)));
        }

        [Test]
        public void Try_Park_Same_Car_Should_Throw()
        {
            Car car = new Car("Make", "RN");

            this.park.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(
                () => park.ParkCar("A2", car));
        }

        [Test]
        public void Park_With_Valid_Car_On_Valid_Spot_Should_Return_Expected_Message()
        {
            Car car = new Car("Make", "RN");

            string actualResult = this.park.ParkCar("A1", car);

            string expectedResult = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Try_Remove_On_Invalid_Park_Spot_Should_Throw()
        {
            Assert.Throws<ArgumentException>(
                () => this.park.RemoveCar("A0", null));
        }

        [Test]
        public void Try_Remove_Non_Existing_Car_From_Parking_Spot_Should_Throw()
        {
            Assert.Throws<ArgumentException>(
                () => this.park.RemoveCar("A1", new Car(string.Empty, string.Empty)));
        }

        [Test]
        public void Remove_Valid_Car_From_Valid_Spot_Should_Return_Expected_Message()
        {
            Car car = new Car("Make", "RN");

            this.park.ParkCar("A1", car);

            string actualResult = this.park.RemoveCar("A1", car);

            string expectedResult = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Constructor_Should_Initialize_All_Parking_Spots()
        {

            int actualCount = this.park.Parking.Count;
            int expectedCount = 12;

            Assert.That(
                actualCount,
                Is.EqualTo(expectedCount));
        }
    }
}