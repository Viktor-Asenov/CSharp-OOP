namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultConsumption = 10;

        public SportCar(int horsePower, double fuel) 
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
