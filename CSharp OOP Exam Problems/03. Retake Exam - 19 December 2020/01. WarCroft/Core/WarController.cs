using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private ICollection<Character> party;
		private ICollection<Item> itemPool;

		public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			if (characterType != "Warrior" && characterType != "Priest")
            {
				throw new ArgumentException($"Invalid character type {characterType}!");
			}

			Character character = null;
			if (characterType == "Warrior")
            {
				character = new Warrior(name);
            }
			else
            {
				character = new Priest(name);
            }

			this.party.Add(character);

			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			if (itemName != "FirePotion" && itemName != "HealthPotion")
			{
				throw new ArgumentException($"Invalid item {itemName}!");
			}

			Item item = null;
			if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}
			else
			{
				item = new HealthPotion();
			}

			this.itemPool.Add(item);

			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = this.party.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}

			if (this.itemPool.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
			}

			Item item = this.itemPool.Last();
			character.Bag.AddItem(item);

			return $"{characterName} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = this.party.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return $"{character.Name} used {itemName}.";
		}

		public string GetStats()
		{
			var sorted = this.party
				.OrderByDescending(c => c.IsAlive)
				.ThenByDescending(c => c.Health)
				.ToList();

			StringBuilder sb = new StringBuilder();

            foreach (var character in sorted)
            {
				string status = character.IsAlive == true ? "Alive" : "Dead";
				sb.AppendLine
					($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
			Character attacker = this.party.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

			if (attacker.AbilityPoints == 0)
			{
				throw new ArgumentException($"{attacker.Name} cannot attack!");
			}

			if (attacker == null)
			{
				throw new ArgumentException($"Character {attackerName} not found!");
			}

			if (receiver == null)
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}

			if (attacker.IsAlive == false)
            {
				throw new ArgumentException("Invalid Operation: Must be alive to perform this action!");
			}

			if (attacker.Name == receiver.Name)
            {
				throw new ArgumentException("Cannot attack self!");
            }			

			receiver.TakeDamage(attacker.AbilityPoints);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points!" +
				$" {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

			if (receiver.IsAlive == false)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];
			Character healer = this.party.FirstOrDefault(c => c.Name == healerName);
			Character healingReceiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);

			if (healer == null || healingReceiver == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty);
			}

			if (healer.IsAlive == false || healingReceiver.IsAlive == false)
			{
				throw new ArgumentException($"{healerName} cannot heal!");
			}

            Priest priest = healer as Priest;
			priest.Heal(healingReceiver);

            StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!");

			return sb.ToString().TrimEnd();
		}
	}
}
