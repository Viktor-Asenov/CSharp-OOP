namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int PowerPaladin = 100;

        public Paladin(string name) 
            : base(name)
        {
        }

        public override int Power => PowerPaladin;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
