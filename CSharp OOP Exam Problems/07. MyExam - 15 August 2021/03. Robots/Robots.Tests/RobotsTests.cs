namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        [Test]
        public void RobotManagerConstructorShouldThrowArgumentExceptionWhenCapacityIsBelow0()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void RobotManagerConstructorShouldInitializeCorrectly()
        {
            RobotManager rm = new RobotManager(3);
            int expectedCapacity = 3;
            int actualCapacity = rm.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenRobotIsPresented()
        {
            RobotManager rm = new RobotManager(3);
            rm.Add(new Robot("Pesho", 100));

            Assert.Throws<InvalidOperationException>(() => rm.Add(new Robot("Pesho", 100)));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenNotEnoughCapacity()
        {
            RobotManager rm = new RobotManager(1);
            rm.Add(new Robot("Pesho", 100));

            Assert.Throws<InvalidOperationException>(() => rm.Add(new Robot("Gosho", 50)));
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionWhenRobotDoesntExist()
        {
            RobotManager rm = new RobotManager(1);
            rm.Add(new Robot("Pesho", 100));

            Assert.Throws<InvalidOperationException>(() => rm.Remove("Gosho"));
        }

        [Test]
        public void RemoveShouldRemoveCorrectlyAndDecreaseCount()
        {
            RobotManager rm = new RobotManager(1);
            Robot robot = new Robot("Pesho", 100);

            rm.Add(robot);
            rm.Remove("Pesho");

            int expectedCount = 0;
            int actualCount = rm.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void WorkShouldThrowInvalidOperationExceptionWhenRobotDoesntExist()
        {
            RobotManager rm = new RobotManager(1);
            rm.Add(new Robot("Pesho", 100));

            Assert.Throws<InvalidOperationException>(() => rm.Work("Gosho", "Worker", 30));
        }

        [Test]
        public void WorkShouldThrowInvalidOperationExceptionWhenRobotBatteryIsNotEnough()
        {
            RobotManager rm = new RobotManager(1);
            rm.Add(new Robot("Pesho", 10));

            Assert.Throws<InvalidOperationException>(() => rm.Work("Pesho", "Worker", 30));
        }

        [Test]
        public void WorkShouldReduceRobotBatteryCorrectly()
        {
            RobotManager rm = new RobotManager(1);
            Robot robot = new Robot("Pesho", 100);
            rm.Add(robot);
            rm.Work("Pesho", "Worker", 30);

            int expectedBattery = 70;
            int actualBattery = robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void ChargeShouldThrowInvalidOperationExceptionWhenRobotDoesntExist()
        {
            RobotManager rm = new RobotManager(1);
            rm.Add(new Robot("Pesho", 100));

            Assert.Throws<InvalidOperationException>(() => rm.Charge("Gosho"));
        }

        [Test]
        public void ChargeShouldRechargeRobotBatteryCorrectly()
        {
            RobotManager rm = new RobotManager(1);
            Robot robot = new Robot("Pesho", 100);
            rm.Add(robot);
            rm.Work("Pesho", "Worker", 30);
            rm.Charge("Pesho");

            int expectedBattery = 100;
            int actualBattery = robot.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }
    }
}
