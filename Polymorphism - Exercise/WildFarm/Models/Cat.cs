namespace WildFarm.Models
{
    using System;
    using WildFarm.Enums;

    public class Cat : Feline
    {
        private const double WeightIncreasing = 0.30;

        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override double Feed(string foodType, int quantity)
        {
            if (foodType != AnimalFood.Vegetable.ToString() && foodType != AnimalFood.Meat.ToString())
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            return this.Weight += quantity * WeightIncreasing;
        }
    }
}
