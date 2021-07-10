namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int PowerWarrior = 100;

        public Warrior(string name) 
            : base(name)
        {
        }

        public override int Power => PowerWarrior;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
