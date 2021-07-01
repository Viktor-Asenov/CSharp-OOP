namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = DefaultConsumption;
        }

        public override void Drive(double kilometers)
        {
            double travelledDistance = kilometers * this.DefaultFuelConsumption;
            if (this.Fuel - travelledDistance >= 0)
            {
                this.Fuel -= travelledDistance;
            }
        }
    }
}
