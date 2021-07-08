using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            City city = new City();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthday);
                    city.Citizens.Add(citizen);
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    Rebel rebel = new Rebel(name, age, group);
                    city.Rebels.Add(rebel);
                }
            }

            int sumPurchasedFood = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string name = input;

                if (city.Citizens.Any(x => x.Name == name))
                {
                    sumPurchasedFood += city.Citizens.First(x => x.Name == name).BuyFood();
                }
                else if (city.Rebels.Any(x => x.Name == name))
                {
                    sumPurchasedFood += city.Rebels.First(x => x.Name == name).BuyFood();
                }
            }

            Console.WriteLine(sumPurchasedFood);
        }
    }
}
