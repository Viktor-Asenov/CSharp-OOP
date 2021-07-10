namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TankCapacity = tankCapacity;

            if (this.FuelQuantity > TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double TankCapacity { get; set; }

        public abstract void Drive(double distance);

        public abstract void Refuel(double amountFuel);
        
    }
}
