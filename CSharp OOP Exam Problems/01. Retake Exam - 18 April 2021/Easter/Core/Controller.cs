using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Eggs;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private int eggsDone;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();

        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny = null;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }

            this.bunnies.Add(bunny);

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (this.bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IBunny bunny = this.bunnies.FindByName(bunnyName);
            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            if (this.bunnies.Models.All(b => b.Energy < 50))
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = this.eggs.FindByName(eggName);
            ICollection<IBunny> bunniesReadyToColor = this.bunnies.Models
                                                            .Where(b => b.Energy >= 50)
                                                            .OrderByDescending(b => b.Energy)
                                                            .ToList();

            foreach (IBunny bunny in bunniesReadyToColor)
            {
                while (bunny.Energy > 0 && bunny.Dyes.Count > 0 && egg.EnergyRequired > 0)
                {
                    bunny.Work();
                    egg.GetColored();

                    if (bunny.Energy <= 0)
                    {
                        bunniesReadyToColor.Remove(bunny);
                        this.bunnies.Remove(bunny);
                        break;
                    }
                }                
                
                if (egg.EnergyRequired <= 0)
                {
                    eggsDone++;
                    return $"Egg {eggName} is done.";
                }
            }

            return $"Egg {eggName} is not done.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IBunny bunny in this.bunnies.Models)
            {
                sb.AppendLine($"{eggsDone} eggs are done!");
                sb.AppendLine($"Bunnies info:");
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }          
            
            return sb.ToString().TrimEnd();
        }
    }
}
