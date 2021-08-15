using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            this.bakedFoods.Add(food);

            return $"Added {food.Name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            return $"Added table number {table.TableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in this.tables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {table.TableNumber} ordered {food.Name}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable tableToReserve = null;
            foreach (var table in this.tables.Where(t => t.IsReserved == false))
            {
                if (numberOfPeople <= table.Capacity)
                {
                    tableToReserve = table;
                    tableToReserve.Reserve(numberOfPeople);
                    break;
                }
            }

            if (tableToReserve == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            return $"Table {tableToReserve.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
