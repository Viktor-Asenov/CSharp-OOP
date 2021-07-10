namespace Vehicles
{
    using System;

    public class Truck : Vehicle
    {
        private const double TruckConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm = fuelConsumptionPerKm += TruckConsumption;
        }

        public override void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumptionPerKm;
            if (neededFuel > this.FuelQuantity)
            {
                throw new Exception("Truck needs refueling");
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

            amountFuel *= 0.95;
            this.FuelQuantity += amountFuel;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
