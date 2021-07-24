namespace Tests
{
    using NUnit.Framework;
    using System;
    using TestAxe;
        
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            // Arrange
            Dummy dummy = new Dummy(20, 10);

            // Act
            dummy.TakeAttack(5);

            // Assert
            Assert.IsTrue(dummy.Health == 15);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(2, 3);

            axe.Attack(dummy);

            var ex = Assert
                .Throws<InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(2, 2);

            axe.Attack(dummy);

            var ex = Assert
                .Throws<InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void AliveDummyCanNotGiveExperience()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(20, 20);

            axe.Attack(dummy);

            var ex = Assert
                .Throws<InvalidOperationException>(() => dummy.GiveExperience());
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}
