using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType 
        {
            get => this.toppingType;
            private set
            {
                string topping = value.ToLower();
                if (topping != "meat" && topping != "veggies" && topping != "cheese" && topping != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value.ToLower();
            }
        }

        public double Weight 
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    string type = char.ToUpper(this.ToppingType[0]) + this.ToppingType.Substring(1);
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double toppingModifier = 0;
            switch (this.ToppingType)
            {
                case "meat":
                    toppingModifier = 1.2;
                    break;
                case "veggies":
                    toppingModifier = 0.8;
                    break;
                case "cheese":
                    toppingModifier = 1.1;
                    break;
                case "sauce":
                    toppingModifier = 0.9;
                    break;
            }

            double totalCalories = 2 * (this.Weight * toppingModifier);
            return totalCalories;
        }
    }
}
