using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepositoryTests repositoryTests;

    [SetUp]
    public void Setup()
    {
        this.repositoryTests = new HeroRepositoryTests();
    }

    [Test]
    public void HeroClassConstructorWorkingCorrectlyPropertyName()
    {
        Hero hero = new Hero("angel", 2);

        string expectedName = "angel";
        string actualName = hero.Name;

        Assert.AreEqual(expectedName, actualName);
    }

    [Test]
    public void HeroClassConstructorWorkingCorrectlyPropertyLevel()
    {
        Hero hero = new Hero("angel", 2);

        int expectedName = 2;
        int actualName = hero.Level;

        Assert.AreEqual(expectedName, actualName);
    }

    [Test]
    public void RepositoryConstructorWorkingCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();

        int expectedCount = 0;
        int actualCount = heroRepository.Heroes.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void MethodCreateShouldThrowArgumentNullExceptionIfHeroIsNull()
    {
        Hero hero = null;
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void MethodCreateWorkCorrectlyTestWhitCount()
    {
        Hero hero = new Hero("angel", 4);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        int expectedCount = 1;
        int actualCount = heroRepository.Heroes.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void MethodCreateWorkCorrectlyTestWhitStringResult()
    {
        Hero hero = new Hero("angel", 4);
        HeroRepository heroRepository = new HeroRepository();

        string expectedString = "Successfully added hero angel with level 4";
        string actualString = heroRepository.Create(hero);

        Assert.AreEqual(expectedString, actualString);
    }

    [Test]
    public void MethodCreateShouldThrowInvalidOperationExceptionIfHeroWithThatNameIsAlreadyExist()
    {
        Hero hero = new Hero("angel", 4);
        Hero hero2 = new Hero("angel", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero2));
    }

    [Test]
    public void MethodRemoveShouldThrowArgumentNullExceptionIfNameIsNullOrWhiteSpace()
    {
        Hero hero = new Hero("Angel", 4);
        Hero hero2 = new Hero("Ivan", 3);
        Hero hero3 = new Hero("Georgi", 1);
        Hero hero4 = new Hero("Teo", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    [Test]
    public void MethodRemove()
    {
        Hero hero = new Hero("Angel", 4);
        Hero hero2 = new Hero("Ivan", 3);
        Hero hero3 = new Hero("Georgi", 1);
        Hero hero4 = new Hero("Teo", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);

        bool expectedResult = true;
        bool actualResult = heroRepository.Remove("Angel");

        Assert.AreEqual(expectedResult, actualResult);
        
    }

    [Test]
    public void MethodGetHeroWithHighestLevelWorkCorreclty()
    {
        Hero hero = new Hero("Angel", 4);
        Hero hero2 = new Hero("Ivan", 3);
        Hero hero3 = new Hero("Georgi", 1);
        Hero hero4 = new Hero("Teo", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);

        string expectedNameOfHeroWithHighestLevel = "Angel";
        string actualNameOfHeroWithHighestLevel = heroRepository.GetHeroWithHighestLevel().Name;

        Assert.AreEqual(expectedNameOfHeroWithHighestLevel, actualNameOfHeroWithHighestLevel);
    }

    [Test]
    public void MethodGetHeroWorkCorreclty()
    {
        Hero hero = new Hero("Angel", 4);
        Hero hero2 = new Hero("Ivan", 3);
        Hero hero3 = new Hero("Georgi", 1);
        Hero hero4 = new Hero("Teo", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);

        string expectedNameOfHeroWithHighestLevel = "Angel";
        string actualNameOfHeroWithHighestLevel = heroRepository.GetHero("Angel").Name;

        Assert.AreEqual(expectedNameOfHeroWithHighestLevel, actualNameOfHeroWithHighestLevel);
    }
}