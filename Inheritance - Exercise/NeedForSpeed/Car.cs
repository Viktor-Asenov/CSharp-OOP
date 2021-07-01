namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultConsumption = 3;

        public Car(int horsePower, double fuel) 
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
