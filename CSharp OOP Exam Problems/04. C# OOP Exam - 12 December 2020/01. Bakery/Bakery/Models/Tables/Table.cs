using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private ICollection<IBakedFood> orderedFood;
        private ICollection<IDrink> orderedDrinks;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.orderedFood = new List<IBakedFood>();
            this.orderedDrinks = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.orderedFood.Clear();
            this.orderedDrinks.Clear();
            this.IsReserved = false;
            this.NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.Price + this.orderedFood.Sum(f => f.Price) + this.orderedDrinks.Sum(d => d.Price);
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            if (IsReserved == false)
            {                
                sb.AppendLine($"Table: {this.TableNumber}");
                sb.AppendLine($"Type: {this.GetType().Name}");
                sb.AppendLine($"Capacity: {this.Capacity}");
                sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            }

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.orderedDrinks.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.orderedFood.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
