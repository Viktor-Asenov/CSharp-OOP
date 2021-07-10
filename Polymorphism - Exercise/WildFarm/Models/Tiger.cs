namespace WildFarm.Models
{
    using System;
    using WildFarm.Enums;

    public class Tiger : Feline
    {
        private const double WeightIncreasing = 1.00;

        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override double Feed(string foodType, int quantity)
        {
            if (foodType != AnimalFood.Meat.ToString())
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            return this.Weight += quantity * WeightIncreasing;
        }
    }
}
