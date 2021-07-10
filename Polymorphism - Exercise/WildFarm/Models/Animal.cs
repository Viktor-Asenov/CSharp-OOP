namespace WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; set; }
        
        public abstract string ProduceSound();

        public abstract double Feed(string foodType, int quantity);
    }
}
