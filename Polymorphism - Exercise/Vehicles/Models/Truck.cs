namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += fuelConsumptionModifier;
        }

        public override void Refuel(double fuel)
        {            
            base.Refuel(fuel * 0.95);
        }
    }
}
