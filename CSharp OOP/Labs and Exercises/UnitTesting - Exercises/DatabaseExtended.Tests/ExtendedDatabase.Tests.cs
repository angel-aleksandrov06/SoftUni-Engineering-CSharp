namespace Tests
{
    using NUnit.Framework;
    //using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PersonConstructorSetIDCorrectly()
        {
            long id = 1234567891234;
            string username = "Ivan";
            Person person = new Person(id, username);

            long expectedId = id;
            long actualId = person.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void PersonConstructorSetUsernameCorrectly()
        {
            long id = 1234567891234;
            string username = "Ivan";
            Person person = new Person(id, username);

            string expectedId = username;
            string actualId = person.UserName;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void DatabaseConstructorSetCorrectly()
        {
            Person person = new Person(12343456, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            int expectedCount = 1;
            int actualCount = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void DatabaseConstructorSetCorrectlyWhenPersonIsNull()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            int expectedCount = 0;
            int actualCount = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddRangeShouldThrowArgumentExceptionIfPersonsAreOver16()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people));
        }

        [Test]
        public void AddMethodhouldThrowArgumentExceptionIfCountOfPersonsAreOver16()
        {
            Person[] people =
            {
                new Person(1, "Angel"),
                new Person(2, "Anfsfgel"),
                new Person(3, "Angefsel"),
                new Person(4, "Ansfefgel"),
                new Person(5, "sef"),
                new Person(6, "avregf"),
                new Person(7, "ewrgeg"),
                new Person(8, "ervear"),
                new Person(9, "sevesv"),
                new Person(10, "severv"),
                new Person(11, "esvevd"),
                new Person(12, "zvfv"),
                new Person(13, "zvzsfv"),
                new Person(14, "zdfgdsg"),
                new Person(15, "gtrgh"),
                new Person(16, "rtjyj")
            };

            ExtendedDatabase extendedDatabase = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(17, "Ivan")));
        }

        [Test]
        public void AddMethodhouldThrowArgumentExceptionIfThereIsAlreadyUserWhitSameUsername()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(new Person(15, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(17, "Ivan")));
        }

        [Test]
        public void AddMethodhouldThrowArgumentExceptionIfThereIsAlreadyUserWhitSameID()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(new Person(15, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(15, "Angel")));
        }

        [Test]
        public void ShouldRemoveCorrectlyAndDecreaseCount()
        {
            Person[] people =
            {
                new Person(1, "Angel"),
                new Person(2, "Anfsfgel"),
                new Person(3, "Angefsel"),
                new Person(4, "Ansfefgel"),
                new Person(5, "sef"),
                new Person(6, "avregf"),
                new Person(7, "ewrgeg"),
                new Person(8, "ervear"),
                new Person(9, "sevesv"),
                new Person(10, "severv"),
                new Person(11, "esvevd"),
                new Person(12, "zvfv"),
                new Person(13, "zvzsfv"),
                new Person(14, "zdfgdsg"),
                new Person(15, "gtrgh"),
                new Person(16, "rtjyj")
            };

            ExtendedDatabase extendeddatabase = new ExtendedDatabase(people);
            extendeddatabase.Remove();

            int expectedCount = 15;
            int actualCount = extendeddatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionIfCountIsZero()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>
                (() => extendedDatabase.Remove());
        }

        [Test]
        public void FindByUsernameShouldThrowArgumentNullExceptionIfGivenArgumentIsNullOrEmpty()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            Assert.Throws<ArgumentNullException>
                (() => extendedDatabase.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameShouldThrowInvalidOperationExceptionIfGivenNameIsInvalid()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(new Person(17, "Ivan"));

            Assert.Throws<InvalidOperationException>
                (() => extendedDatabase.FindByUsername("Angel"));
        }

        [Test]
        public void FindByUsernameReturnCorrectly()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(new Person(17, "Ivan"));

            Person expectedPerson = new Person(17, "Ivan");
            string expectedPersonUsername = expectedPerson.UserName;
            Person actualPerson = extendedDatabase.FindByUsername("Ivan");
            string actualPersonUsername = actualPerson.UserName;

            Assert.AreEqual(expectedPersonUsername, actualPersonUsername);
        }

        [Test]
        public void FindByIdShouldThrowArgumentNullExceptionIfGivenIdIsBellowZero()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            Assert.Throws<ArgumentOutOfRangeException>
                (() => extendedDatabase.FindById(-10));
        }

        [Test]
        public void FindByIdShouldThrowInvalidOperationExceptionIfGivenNameIsInvalid()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(new Person(17, "Ivan"));

            Assert.Throws<InvalidOperationException>
                (() => extendedDatabase.FindById(8));
        }

        [Test]
        public void FindByIdReturnCorrectly()
        {
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(new Person(17, "Ivan"));

            Person expectedPerson = new Person(17, "Ivan");
            long expectedPersonUsername = expectedPerson.Id;
            Person actualPerson = extendedDatabase.FindById(17);
            long actualPersonUsername = actualPerson.Id;

            Assert.AreEqual(expectedPersonUsername, actualPersonUsername);
        }
    }
}