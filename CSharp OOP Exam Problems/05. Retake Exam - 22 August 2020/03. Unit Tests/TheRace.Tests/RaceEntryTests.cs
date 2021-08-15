using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitDriverShouldThrowArgumentNullExceptionWhenDriverNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, new UnitCar("Audi", 300, 3)));
        }

        [Test]
        public void UnitDriverShouldInitializeCorrectly()
        {
            UnitDriver driver = new UnitDriver("Mitko", new UnitCar("Audi", 300, 3));

            Assert.AreNotEqual(null, driver);
        }        

        [Test]
        public void AddDriverShouldThrowInvalidOperationExceptionWhenDriverIsAdded()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverShouldThrowInvalidOperationExceptionWhenDriverIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Mitko", new UnitCar("Audi", 300, 3));
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver("Mitko", new UnitCar("Mercedes", 400, 4))));
        }

        [Test]
        public void AddDriverShouldAddCorrectlyDriverAndIncreaseCount()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Mitko", new UnitCar("Audi", 300, 3));
            raceEntry.AddDriver(driver);

            int expectedCount = 1;
            int actualCount = raceEntry.Counter;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowInvalidOperationExceptionWhenDriversAreLessThanTwo()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver driver = new UnitDriver("Mitko", new UnitCar("Audi", 300, 3));
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerShouldCalculateAverageCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitDriver first = new UnitDriver("Mitko", new UnitCar("Audi", 300, 3));
            UnitDriver second = new UnitDriver("Pesho", new UnitCar("BMW", 400, 4));
            raceEntry.AddDriver(first);
            raceEntry.AddDriver(second);

            double expectedAverageHorsePower = 350;
            double actualAverageHorsePower = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAverageHorsePower, actualAverageHorsePower);
        }
    }
}