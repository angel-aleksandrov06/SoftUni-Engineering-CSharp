using NUnit.Framework;

namespace Tests
{
    public class HeroTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HeroConstructorShouldWorkCorrectlyTestWithName()
        {
            Axe axe = new Axe(10, 10);
            Hero hero = new Hero("Angel", axe);

            string expectedName = "Angel";
            string actualName = hero.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void HeroConstructorShouldWorkCorrectlyTestWithExperiance()
        {
            Axe axe = new Axe(10, 10);
            Hero hero = new Hero("Angel", axe);

            int expectedExperiance = 0;
            int actualExperiance = hero.Experience;

            Assert.AreEqual(expectedExperiance, actualExperiance);
        }

        [Test]
        public void HeroConstructorShouldWorkCorrectlyTestWithWapon()
        {
            Axe axe = new Axe(10, 10);
            Hero hero = new Hero("Angel", axe);


            Axe expectedWapon = axe;
            Axe actualWapon = hero.Weapon;

            Assert.AreEqual(expectedWapon, actualWapon);
        }

        [Test]
        public void MethodAttackShouldWorkCorrectly()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            Hero hero = new Hero("Angel", axe);

            hero.Attack(dummy);

            int expectedExperiance = 10;
            int actualExperiance = hero.Experience;

            Assert.AreEqual(expectedExperiance, actualExperiance);
        }
    }
}
