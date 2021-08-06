namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void AquariumConstructorShouldInitializeCorrectly()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);
            string expectedName = "Swamp";
            int expectedCapacity = 5;
            string actualName = aquarium.Name;
            int actualCapacity = aquarium.Capacity;

            Assert.That(expectedName, Is.EqualTo(actualName));
            Assert.That(expectedCapacity, Is.EqualTo(actualCapacity));
        }

        [TestCase(null, 1)]
        [TestCase("", 1)]
        public void ConstructorShouldThrowArgumentNullExceptionWhenNameIsNullOrEmpty
            (string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));            
        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionWhenCapacityIsBelowOrEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Swamp", -1));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenCountIsExceeded()
        {
            Aquarium aquarium = new Aquarium("Swamp", 1);
            aquarium.Add(new Fish("Nemo"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Pesho")));
        }

        [Test]
        public void AddMethodShouldAddCorrectlyAndIncreaseTheCount()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);
            aquarium.Add(new Fish("Nemo"));

            int expectedCount = 1;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionWhenFishIsNotFound()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);
            aquarium.Add(new Fish("Nemo"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Ivan"));
        }

        [Test]
        public void RemoveMethodShouldRemoveCorrectlyAndDecreaseTheCount()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);
            aquarium.Add(new Fish("Nemo"));
            aquarium.RemoveFish("Nemo");

            int expectedCount = 0;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void SellFishMethodShouldThrowInvalidOperationExceptionWhenFishIsNotFound()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Ivan"));
        }

        [Test]
        public void SellFishMethodShouldSetAvailabilityToFalse()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);
            Fish fish = new Fish("Ivan");
            aquarium.Add(fish);
            aquarium.SellFish("Ivan");

            bool expectedAvailability = false;
            bool actualAvailability = fish.Available;

            Assert.AreEqual(expectedAvailability, actualAvailability);
        }

        [Test]
        public void SellFishMethodShoulWorkCorrectly()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);
            aquarium.Add(new Fish("Ivan"));
            
            Fish soldFish = aquarium.SellFish("Ivan");

            string expectedName = "Ivan";
            string actualName = soldFish.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ReportMethodShouldReturnAllFishNamesCorrectly()
        {
            Aquarium aquarium = new Aquarium("Swamp", 5);
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Helen"));

            string expectedReport = $"Fish available at Swamp: Nemo, Helen";
            string actualReport = aquarium.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
