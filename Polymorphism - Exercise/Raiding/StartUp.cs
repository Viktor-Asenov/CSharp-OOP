namespace Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidingParty = new List<BaseHero>();
            int countCreated = 0;

            while (countCreated < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    BaseHero hero = CreateHero(heroType, heroName);
                    raidingParty.Add(hero);
                    countCreated++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            int bossPower = int.Parse(Console.ReadLine());
            if (raidingParty.Count > 0)
            {
                foreach (var hero in raidingParty)
                {
                    Console.WriteLine(hero.CastAbility());
                }
            }

            int sumPower = raidingParty.Sum(h => h.Power);
            if (sumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        public static BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero hero = null;
            switch (heroType)
            {
                case "Druid":
                    hero = new Druid(heroName);
                    break;
                case "Paladin":
                    hero = new Paladin(heroName);
                    break;
                case "Rogue":
                    hero = new Rogue(heroName);
                    break;
                case "Warrior":
                    hero = new Warrior(heroName);
                    break;
                default:
                    throw new Exception("Invalid hero!");
            }

            return hero;
        }
    }
}
