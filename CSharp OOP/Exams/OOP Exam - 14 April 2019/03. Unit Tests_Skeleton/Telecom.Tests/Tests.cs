namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorSouldWorkCorrectlyTestByPhoneBookCount()
        {
            Phone phone = new Phone("Lenovo", "P1");

            int expectedCount = 0;
            int actualCount = phone.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorSouldWorkCorrectlyTestByPropMake()
        {
            Phone phone = new Phone("Lenovo", "P1");

            string expectedMake = "Lenovo";
            string actualMake = phone.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void ConstructorSouldWorkCorrectlyTestByPropModel()
        {
            Phone phone = new Phone("Lenovo", "P1");

            string expectedModel = "P1";
            string actualModel = phone.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void PropMakeShouldThrowArgumentException()
        {
            Phone phone = null;

            Assert.Throws<ArgumentException>(() => phone = new Phone(null, "P1"));
        }

        [Test]
        public void PropModelShouldThrowArgumentException()
        {
            Phone phone = null;

            Assert.Throws<ArgumentException>(() => phone = new Phone("Lenovo", null));
        }

        [Test]
        public void MethodAddContactShouldThrowInvalidOperationException()
        {
            Phone phone = new Phone("Lenovo", "P1");
            phone.AddContact("Angel", "999");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Angel", "999"));
        }

        [Test]
        public void MethodAddContactShouldWorkCorrectly()
        {
            Phone phone = new Phone("Lenovo", "P1");
            phone.AddContact("Angel", "999");
            phone.AddContact("Ivan", "999");

            int expectedCount = 2;
            int actualCount = phone.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void MethodCallShouldThrowInvalidOperationException()
        {
            Phone phone = new Phone("Lenovo", "P1");
            phone.AddContact("Angel", "999");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Ivan"));
        }

        [Test]
        public void MethodCallShouldWorkCorrectly()
        {
            Phone phone = new Phone("Lenovo", "P1");
            phone.AddContact("Angel", "999");

            string ExplectedResult = "Calling Angel - 999...";
            string ActualResult =  phone.Call("Angel");


            Assert.AreEqual(ExplectedResult, ActualResult);
        }
    }
}