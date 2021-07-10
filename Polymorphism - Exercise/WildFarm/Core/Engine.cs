namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models;

    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] animalArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string[] secondInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (secondInput[0] == "End")
                {
                    break;
                }

                string typeOfFood = secondInput[0];
                int quantity = int.Parse(secondInput[1]);

                AnimalCreator animalCreator = new AnimalCreator();
                Animal animal = animalCreator.Create(animalArgs, quantity);
                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(typeOfFood, quantity);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    animal.FoodEaten = 0;
                }

                this.animals.Add(animal);
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
