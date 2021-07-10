namespace Vehicles
{
    using System;

    public class Bus : Vehicle
    {
        private const double BusConsumptionWithPeople = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public override void Drive(double distance)
        {
            double busFuelConsumptionPerKmWithPeople = this.FuelConsumptionPerKm += BusConsumptionWithPeople;
            double neededFuel = distance * busFuelConsumptionPerKmWithPeople;
            if (neededFuel > this.FuelQuantity)
            {
                throw new Exception("Bus needs refueling");
            }

            this.FuelQuantity -= neededFuel;
        }

        public void DriveEmpty(double distance)
        {
            double neededFuel = distance * this.FuelConsumptionPerKm;
            if (neededFuel > this.FuelQuantity)
            {
                throw new Exception("Bus needs refueling");
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
            return $"Bus: {this.FuelQuantity:f2}";
        }
    }
}
