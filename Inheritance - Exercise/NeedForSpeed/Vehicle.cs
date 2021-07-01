namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DefaultConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {            
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = DefaultConsumption;
        }

        public double DefaultFuelConsumption { get; protected set; }

        public virtual double FuelConsumption { get; private set; }

        public double Fuel { get; protected set; }

        public int HorsePower { get; private set; }

        public virtual void Drive(double kilometers)
        {
            double travelledDistance = kilometers * this.DefaultFuelConsumption;
            if (this.Fuel - travelledDistance >= 0)
            {
                this.Fuel -= travelledDistance;
            }
        }
    }
}
