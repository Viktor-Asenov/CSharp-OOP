using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();                        
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public new double OverallPerformance => base.OverallPerformance + this.components.Average(c => c.OverallPerformance);

        public new decimal Price => base.Price + this.components.Sum(c => c.Price) + this.peripherals.Sum(c => c.Price);

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || this.components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IComponent component = this.components.First(c => c.GetType().Name == componentType);
            IComponent removed = component;
            this.components.Remove(component);

            return removed;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || this.peripherals.All(c => c.GetType().Name != peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IPeripheral peripheral = this.peripherals.First(c => c.GetType().Name == peripheralType);
            IPeripheral removed = peripheral;
            this.peripherals.Remove(peripheral);

            return removed;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.OverallPerformance == 0)
            {
                sb.AppendLine($"Overall Performance: {0:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            }
            else
            {
                sb.AppendLine($"Overall Performance: {Math.Abs(this.OverallPerformance):f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            }
            
            if (this.components.Count == 0)
            {
                sb.AppendLine($" Components (0):");
            }
            else
            {
                sb.AppendLine($" Components ({this.components.Count}):");
                foreach (var component in this.components)
                {
                    sb.AppendLine($"  {component.ToString()}");
                }
            }            

            if (this.peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals (0); Average Overall Performance ({0:f2}):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance):f2}):");
                foreach (var peripheral in this.peripherals)
                {
                    sb.AppendLine($"  {peripheral.ToString()}");
                }
            }            

            return sb.ToString().Trim();
        }
    }
}
