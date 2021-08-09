using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectlyVault()
        {
            BankVault vault = new BankVault();

            Assert.AreNotEqual(vault, null);
        }

        [Test]
        public void AddItemShouldThrowArgumentExceptionWhenCellIsNotFound()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "123");
            
            Assert.Throws<ArgumentException>(() => vault.AddItem("A6", item));
        }

        [Test]
        public void AddItemShouldThrowArgumentExceptionWhenCellIsTaken()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "123");
            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", new Item("Pesho", "456")));
        }

        [Test]
        public void AddItemShouldThrowInvalidOperationExceptionWhenCellHasItemWithSameId()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "123");
            vault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2", new Item("Pesho", "123")));
        }

        [Test]
        public void AddItemShouldAddCorrectlyAndIncreaseCount()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "123");
            vault.AddItem("A1", item);

            int expectedCount = 1;
            int actualCount = vault.VaultCells.Where(c => c.Value != null).Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveItemShouldThrowArgumentExceptionWhenCellIsNotFound()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "123");

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A6", item));
        }

        [Test]
        public void RemoveItemShouldThrowArgumentExceptionWhenItemIsNotFound()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "123");
            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", new Item("Pesho", "453")));
        }

        [Test]
        public void RemoveItemShouldRemoveCorrectlyAndDecreaseCount()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "123");
            vault.AddItem("A1", item);
            vault.RemoveItem("A1", item);

            int expectedCount = 12;
            int actualCount = vault.VaultCells.Where(c => c.Value == null).Count();

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}