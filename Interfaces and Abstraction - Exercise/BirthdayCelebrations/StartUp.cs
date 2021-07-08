using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Pet> pets = new List<Pet>();
            List<Robot> robots = new List<Robot>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens.Length == 5)
                {
                    string humanBirthday = tokens[4];
                    Citizen human = new Citizen(humanBirthday);
                    citizens.Add(human);
                }
                
                else if (tokens.Length == 3)
                {
                    if (tokens[0] == "Robot")
                    {
                        string robotId = tokens[2];
                        Robot robot = new Robot(robotId);
                        robots.Add(robot);
                    }
                    else
                    {
                        string petBirthday = tokens[2];
                        Pet pet = new Pet(petBirthday);
                        pets.Add(pet);
                    }                    
                }
            }

            string year = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.IsSameYearBorn(year))
                {
                    Console.WriteLine(citizen.Birthday);
                }
            }

            foreach (var pet in pets)
            {
                if (pet.IsSameYearBorn(year))
                {
                    Console.WriteLine(pet.Birthday);
                }
            }

            foreach (var robot in robots)
            {
                if (robot.GetId(year))
                {
                    Console.WriteLine(robot.Id);
                }
            }
        }
    }
}
