using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerManagerConstructorShouldInitializeCorrectly()
        {
            ComputerManager cm = new ComputerManager();

            Assert.AreNotEqual(null, cm);
        }

        [Test]
        public void AddComputerShouldThrowArgumentNullExceptionWhenAddingNull()
        {
            ComputerManager cm = new ComputerManager();
            
            Assert.Throws<ArgumentNullException>(() => cm.AddComputer(null));
        }

        [Test]
        public void AddComputerShouldThrowArgumentExceptionWhenAddingAlreadyPresentedComputer()
        {
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(new Computer("Intel", "123", 1000));

            Assert.Throws<ArgumentException>(() => cm.AddComputer(new Computer("Intel", "123", 1000)));
        }

        [Test]
        public void AddComputerShouldAddCorrectlyAndIncreaseTheCount()
        {
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(new Computer("Intel", "123", 1000));

            int expectedCount = 1;
            int actualCount = cm.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(null, "123")]
        [TestCase("Intel", null)]
        public void RemoveComputerShouldThrowArgumentNullExceptionWhenTryingToRemoveComputerWithNullManufacturerOrModel
            (string manufacturer, string model)
        {
            ComputerManager cm = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => cm.RemoveComputer(manufacturer, model));
        }

        [Test]
        public void RemoveComputerShouldRemoveCorrectly()
        {
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(new Computer("Intel", "123", 1000));

            Computer removed = cm.RemoveComputer("Intel", "123");

            Assert.AreEqual("Intel", removed.Manufacturer);
            Assert.AreEqual("123", removed.Model);
        }

        [Test]
        public void RemoveComputerShouldThrowArgumentExceptionWhenRemovingUnexistedComputer()
        {
            ComputerManager cm = new ComputerManager();

            Assert.Throws<ArgumentException>(() => cm.RemoveComputer("Intel", "123"));
        }

        [Test]
        public void GetComputerByManufacturerShouldThrowArgumentNullExceptionWhenManufacturerIsNull()
        {
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(new Computer("Intel", "123", 1000));

            Assert.Throws<ArgumentNullException>(() => cm.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputerByManufacturerShouldReturnComputersByManufacturerCorrectly()
        {
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(new Computer("Intel", "123", 1000));
            cm.AddComputer(new Computer("IBM", "456", 2000));

            var collection = cm.GetComputersByManufacturer("IBM");

            int expectedCountCollection = 1;
            int actualCollectionCount = collection.Count;

            Assert.AreEqual(expectedCountCollection, actualCollectionCount);
        }
    }
}