namespace WildFarm.Models
{
    using System;
    using WildFarm.Enums;

    public class Hen : Bird
    {
        private const double WeightIncreasing = 0.35;
        
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override double Feed(string foodType, int quantity)
        {
            if (foodType != AnimalFood.Vegetable.ToString() && foodType != AnimalFood.Fruit.ToString()
                && foodType != AnimalFood.Meat.ToString() && foodType != AnimalFood.Seeds.ToString())
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }

            return this.Weight += quantity * WeightIncreasing;
        }
    }
}
