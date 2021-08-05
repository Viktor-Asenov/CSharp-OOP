using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private ICollection<IDye> dyes;

        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            } 
        }

        public int Energy
        {
            get => this.energy;
            private set
            {
                if (value >= 0)
                {
                    this.energy = value;
                }                
            }
        }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

        public void Work()
        {
            if (this.GetType().Name == "SleepyBunny")
            {
                this.Energy -= 15;
            }
            else
            {
                this.Energy -= 10;
            }
                      
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }

            foreach (var dye in this.dyes)
            {
                while (dye.IsFinished() == false)
                {
                    dye.Use();
                    if (dye.Power <= 0)
                    {
                        this.dyes.Remove(dye);
                    }

                    return;
                }                
            }
        }
    }
}
