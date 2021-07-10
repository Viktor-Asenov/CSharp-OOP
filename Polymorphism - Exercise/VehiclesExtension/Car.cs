namespace Vehicles
{
    using System;

    public class Car : Vehicle
    {
        private const double CarConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm = fuelConsumptionPerKm += CarConsumption;
        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumptionPerKm;
            if (neededFuel > this.FuelQuantity)
            {
                throw new Exception("Car needs refueling");
            }

            this.FuelQuantity -= neededFuel;
        }

        public override void Refuel(double amountFuel)
        {
            if (amountFuel <= 0)
            {
                throw new Exception("Fuel must be a positive number");
            }

            if (this.FuelQuantity + amountFuel > this.TankCapacity)
            {
                throw new Exception($"Cannot fit {amountFuel} fuel in the tank");
            }

            this.FuelQuantity += amountFuel;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
