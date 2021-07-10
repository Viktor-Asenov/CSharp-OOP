namespace Vehicles.Models
{
    using System;
    using Vehicles.Contracts;

    public abstract class Vehicle : IDriveable, IRefualable
    {
        private double fuelQuantity;
        private double fuelConspumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                if (value > 0)
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption
        {
            get => this.fuelConspumption;
            protected set
            {
                if (value > 0)
                {
                    this.fuelConspumption = value;
                }
            }
        }

        public void Drive(double distance)
        {
            double fuel = this.FuelConsumption * distance;
            if (fuel > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
