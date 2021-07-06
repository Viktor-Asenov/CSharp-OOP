using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputPerson = Console.ReadLine();
            string inputProduct = Console.ReadLine();

            List<Person> people = new List<Person>();

            if (inputPerson.Contains(';'))
            {
                string[] peopleData = inputPerson.Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < peopleData.Length; i++)
                {
                    string[] currentPersonData = peopleData[i]
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = currentPersonData[0];
                    decimal money = decimal.Parse(currentPersonData[1]);

                    try
                    {
                        Person person = new Person(name, money);
                        people.Add(person);
                    }
                    catch (ArgumentException exception)
                    {

                        Console.WriteLine(exception.Message);
                        return;
                    }
                }
            }
            else
            {
                string[] personData = inputPerson.Split('=');
                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException exception)
                {

                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            List<Product> products = new List<Product>();

            if (inputProduct.Contains(';'))
            {
                string[] productData = inputProduct.Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productData.Length; i++)
                {
                    string[] currentProductData = productData[i]
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = currentProductData[0];
                    decimal cost = decimal.Parse(currentProductData[1]);

                    try
                    {
                        Product product = new Product(name, cost);
                        products.Add(product);
                    }
                    catch (ArgumentException exception)
                    {

                        Console.WriteLine(exception.Message);
                        return;
                    }
                }
            }
            else
            {
                string[] productData = inputProduct.Split('=');
                string name = productData[0];
                decimal cost = decimal.Parse(productData[1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException exception)
                {

                    Console.WriteLine(exception.Message);
                    return;
                }
            }            

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] commandArgs = command.Split();
                string personName = commandArgs[0];
                string productToBuy = commandArgs[1];

                Product product = products.FirstOrDefault(p => p.Name == productToBuy);
                people.FirstOrDefault(p => p.Name == personName).AddProduct(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
