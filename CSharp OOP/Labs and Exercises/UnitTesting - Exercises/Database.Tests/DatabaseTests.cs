namespace Tests
{
    using NUnit.Framework;
    using Database;
    using System;

    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializeWhit16Elements()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            int expectedResult = 16;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldTrowInvalidOperationExceptionIsNot16Elements()
        {
            int[] array = new int[17];

            Assert.Throws<InvalidOperationException>
                (() => new Database(array));
        }

        [Test]
        public void AddMethodShouldIncreaseTheCount()
        {
            Database database = new Database();
            database.Add(1);

            int expectedCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldAddOnTheNextEmptyIndex()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database database = new Database(array);
            database.Add(6);

            int expectedResult = 6;
            int actualResult = database.Fetch()[5];


            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenIsNot16Elements()
        {
            Database database = new Database(new int[16]);

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void ShouldRemoveCorrectlyAndDecreaseCount()
        {
            Database database = new Database(new int[3]);
            database.Remove();

            int expectedCount = 2;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ShouldRemoveCorrectlyLastElement()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);
            database.Remove();

            int expectedCount = database.Count;
            int actualCount = database.Fetch().Length;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionIfCountIsZero()
        {
            Database database = new Database();


            Assert.Throws<InvalidOperationException>
                (() => database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnAllElementAssArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database database = new Database(array);

            int[] expectedValues = { 1, 2, 3, 4, 5 };
            int[] actualValues = database.Fetch();

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}