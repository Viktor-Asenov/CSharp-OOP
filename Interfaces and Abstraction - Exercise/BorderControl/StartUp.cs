using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> city = new List<Citizen>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] citizenArgs = command.Split();

                if (citizenArgs.Length == 3)
                {
                    string humanId = citizenArgs[2];
                    Citizen human = new Citizen(humanId);
                    city.Add(human);
                }
                else if (citizenArgs.Length == 2)
                {
                    string robotId = citizenArgs[1];
                    Citizen robot = new Citizen(robotId);
                    city.Add(robot);
                }
            }

            string fakeDigits = Console.ReadLine();

            foreach (var citizen in city)
            {
                if (citizen.IsFake(fakeDigits))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
