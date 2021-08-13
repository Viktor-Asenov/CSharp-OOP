using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (this.computers.Any(c => c.Components.Any(c => c.Id == id)))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType != "CentralProcessingUnit" && componentType != "Motherboard"
                && componentType != "PowerSupply" && componentType != "RandomAccessMemory"
                && componentType != "SolidStateDrive" && componentType != "VideoCard")
            {
                throw new ArgumentException("Component type is invalid.");
            }

            IComponent component = null;
            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            computer.AddComponent(component);
            this.components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType != "DesktopComputer" && computerType != "Laptop")
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            IComputer computer = null;
            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (this.computers.Any(c => c.Peripherals.Any(c => c.Id == id)))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            if (peripheralType != "Headset" && peripheralType != "Keyboard"
                && peripheralType != "Monitor" && peripheralType != "Mouse")
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            IPeripheral peripheral = null;
            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0 && this.computers.All(c => c.Price > budget))
            {
                throw new ArgumentException("Can't buy a computer with a budget of ${budget}.");
            }

            IComputer bestComputerForBudget = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            string boughtCoumputerInfo = bestComputerForBudget.ToString();
            this.computers.Remove(bestComputerForBudget);

            return boughtCoumputerInfo;
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            string boughtCoumputerInfo = computer.ToString();
            this.computers.Remove(computer);

            return boughtCoumputerInfo;
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent component = computer.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            computer.RemoveComponent(componentType);
            this.components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral = computer.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }
    }
}
