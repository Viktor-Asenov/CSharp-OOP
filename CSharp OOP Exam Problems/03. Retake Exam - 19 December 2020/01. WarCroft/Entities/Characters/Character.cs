using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
        }

        public string Name 
		{
			get => this.name;
			private set
            {
				if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				this.name = value;
            }
		}

        public double BaseHealth { get; private set; }

		public double Health { get; set; }

        public double BaseArmor { get; private set; }

		public double Armor { get; private set; }
			   
		public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
        {
			if (this.IsAlive == true)
            {
				if (this.Armor >= hitPoints)
                {
					this.Armor -= hitPoints;
				}				
				else if (hitPoints > this.Armor)
                {
					hitPoints -= this.Armor;
					this.Armor = 0;
					
					if (hitPoints > 0)
                    {
						this.Health -= hitPoints;
                    }
                }

				if (this.Health <= 0)
                {
					this.Health = 0;
					this.IsAlive = false;
                }
            }
        }

		public void UseItem(Item item)
        {
			item.AffectCharacter(this);
		}
	}
}