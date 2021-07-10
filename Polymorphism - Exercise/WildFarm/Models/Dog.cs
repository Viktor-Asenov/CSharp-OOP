namespace WildFarm.Models
{
    using System;
    using WildFarm.Enums;

    public class Dog : Mammal
    {
        private const double WeightIncreasing = 0.40;

        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
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
