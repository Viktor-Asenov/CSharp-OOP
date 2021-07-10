namespace Vehicles
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            Car car = 
                new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
            Truck truck = 
                new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
            Bus bus = 
                new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string vehicle = tokens[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(tokens[2]);
                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Drive(distance);
                            Console.WriteLine($"Car travelled {distance} km");
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Drive(distance);
                            Console.WriteLine($"Truck travelled {distance} km");
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Drive(distance);
                            Console.WriteLine($"Bus travelled {distance} km");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(tokens[2]);
                    try
                    {
                        bus.DriveEmpty(distance);
                        Console.WriteLine($"Bus travelled {distance} km");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    double fuelAmount = double.Parse(tokens[2]);
                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(fuelAmount);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(fuelAmount);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(fuelAmount);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
