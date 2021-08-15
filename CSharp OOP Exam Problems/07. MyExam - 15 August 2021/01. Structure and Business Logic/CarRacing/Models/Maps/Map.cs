using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            double chanceToWInFirst = 0;
            double chanceToWInSecond = 0;
            racerOne.Race();
            racerTwo.Race();

            chanceToWInFirst = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                chanceToWInFirst *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                chanceToWInFirst *= 1.1;
            }

            chanceToWInSecond = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerTwo.RacingBehavior == "strict")
            {
                chanceToWInSecond *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                chanceToWInSecond *= 1.1;
            }

            if (chanceToWInFirst > chanceToWInSecond)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
        }
    }
}
