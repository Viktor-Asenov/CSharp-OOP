namespace WildFarm.Models
{
    using System;
    using WildFarm.Enums;

    public class Mouse : Mammal
    {
        private const double WeightIncreasing = 0.10;

        public Mouse(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }        

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override double Feed(string foodType, int quantity)
        {
            if (foodType != AnimalFood.Vegetable.ToString() 
                && foodType != AnimalFood.Fruit.ToString())
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            return this.Weight += quantity * WeightIncreasing;
        }
    }
}
