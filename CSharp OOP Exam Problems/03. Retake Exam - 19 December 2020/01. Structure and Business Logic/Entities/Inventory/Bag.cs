using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private ICollection<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)this.items;

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (this.items.All(i => i.GetType().Name != name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = this.items.First(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;
        } 
    }
}
