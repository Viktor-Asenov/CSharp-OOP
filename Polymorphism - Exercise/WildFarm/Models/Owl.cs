namespace WildFarm.Models
{
    using System;
    using WildFarm.Enums;

    public class Owl : Bird
    {
        private const double WeightIncreasing = 0.25;

        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }        

        public override string ProduceSound()
        {
            return "Hoot Hoot";
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
