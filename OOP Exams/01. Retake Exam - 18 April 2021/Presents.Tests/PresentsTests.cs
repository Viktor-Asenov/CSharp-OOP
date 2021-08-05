namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void BagConstructorShouldInitializeCorrectly()
        {
            Bag bag = new Bag();

            Assert.AreNotEqual(bag, null);
        }

        [Test]
        public void CreateMethodShouldThrowArgumentNullExceptionWhenPresentIsNull()
        {
            Bag bag = new Bag();
            
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreateMethodShouldThrowInvalidOperationExceptionWhenPresentIsAlreadyCreated()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 1);
            bag.Create(present);            

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateMethodShouldAddCorrectlyAndReturnMessage()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 1);
            string message = bag.Create(present);

            Assert.AreEqual(message, $"Successfully added present {present.Name}.");
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectlyAndReturnTrue()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 1);
            bag.Create(present);
            bool isPresentRemoved = bag.Remove(present);

            Assert.AreEqual(isPresentRemoved, true);
        }

        //public void RemoveMethodShouldReturnFalseWhenPresentIsNotFound()
        //{
        //    Bag bag = new Bag();
        //    Present present = new Present("Teddy", 2);

        //    bool isPresentRemoved = bag.Remove(present);

        //    Assert.AreEqual(isPresentRemoved, false);
        //}

        [Test]
        public void GetPresentWithLeastMagicShouldReturnThePresentWithSmallestMagic()
        {
            Bag bag = new Bag();
            bag.Create(new Present("Toy", 1));
            bag.Create(new Present("Teddy", 5));

            Present presentWithLeastMagic = bag.GetPresentWithLeastMagic();
            string expectedName = "Toy";
            double expectedMagic = 1;
            string actualName = presentWithLeastMagic.Name;
            double actualMagic = presentWithLeastMagic.Magic;

            Assert.That(expectedName, Is.EqualTo(actualName));
            Assert.That(expectedMagic, Is.EqualTo(actualMagic));
        }

        [Test]
        public void GetPresentMethodShouldReturnPresentCorrectlyByGivenName()
        {
            Bag bag = new Bag();
            bag.Create(new Present("Toy", 1));
            bag.Create(new Present("Teddy", 5));

            Present present = bag.GetPresent("Teddy");
            string expectedName = "Teddy";
            double expectedMagic = 5;
            string actualName = present.Name;
            double actualMagic = present.Magic;

            Assert.That(expectedName, Is.EqualTo(actualName));
            Assert.That(expectedMagic, Is.EqualTo(actualMagic));
        }

        [Test]
        public void GetPresentsShouldReturnCollectionOfPresentsCorrectly()
        {
            Bag bag = new Bag();
            bag.Create(new Present("Toy", 1));
            bag.Create(new Present("Teddy", 5));
            IReadOnlyCollection<Present> presents = bag.GetPresents();

            int expectedCount = 2;
            int actualCount = presents.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
