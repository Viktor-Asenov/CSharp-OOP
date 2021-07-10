namespace Vehicles.Core
{
    using System;
    using Vehicles.Models;

    public class Engine
    {
        public void Run()
        {
            string[] carArgs = Console.ReadLine().Split();
            string[] truckArgs = Console.ReadLine().Split();

            Vehicle car = Create(carArgs);
            Vehicle truck = Create(truckArgs);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];
                string vehicle = commandArgs[1];               

                switch (command)
                {
                    case "Drive":
                        double distance = double.Parse(commandArgs[2]);
                        if (vehicle == "Car")
                        {
                            try
                            {
                                car.Drive(distance);
                            }
                            catch (ArgumentException ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                truck.Drive(distance);
                            }
                            catch (ArgumentException ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Refuel":
                        double amountFuel = double.Parse(commandArgs[2]);
                        if (vehicle == "Car")
                        {
                            car.Refuel(amountFuel);
                        }
                        else
                        {
                            truck.Refuel(amountFuel);
                        }
                        break;                    
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private Vehicle Create(string[] args)
        {
            double fuelQuantity = double.Parse(args[1]);
            double fuelConsumption = double.Parse(args[2]);

            if (args[0] == "Car")
            {
                Car car = new Car(fuelQuantity, fuelConsumption);
                return car;
            }

            Truck truck = new Truck(fuelQuantity, fuelConsumption);
            return truck;
        }
    }
}
