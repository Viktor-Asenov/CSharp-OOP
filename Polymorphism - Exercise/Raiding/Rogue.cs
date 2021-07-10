namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int PowerRogue = 80;

        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power => PowerRogue;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
