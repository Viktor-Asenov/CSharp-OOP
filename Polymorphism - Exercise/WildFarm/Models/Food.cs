namespace WildFarm.Models
{
    using WildFarm.Enums;

    public abstract class Food
    {
        public Food(AnimalFood food, int quantity)
        {
            this.AnimalFood = food;
            this.Quantity = quantity;
        }

        public AnimalFood AnimalFood { get; private set; }

        public int Quantity { get; protected set; }        
    }
}
