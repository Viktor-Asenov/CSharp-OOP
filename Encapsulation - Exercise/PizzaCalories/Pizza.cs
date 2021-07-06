using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough 
        {
            get => this.dough;
            set
            {
                this.dough = value;
            }
        }

        public List<Topping> Toppings 
        {
            get => this.toppings;
            private set
            {
                this.toppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.Toppings.Add(topping);
        }

        private double Calories()
        {
            return this.Dough.GetCalories() + this.Toppings.Sum(t => t.GetCalories());
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories():F2} Calories.";
        }
    }
}
