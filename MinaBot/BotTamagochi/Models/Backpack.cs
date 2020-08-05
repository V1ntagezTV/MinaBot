using MinaBot.BotTamagochi.BotPackValues;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinaBot.Models
{
    class Backpack: AItemCollections
    {
        public int ID { get; set; }
        public int Lenght { get; set; }
        public List<Item> inventory { get; set; } = new List<Item>();
        public void Add(Item item) => inventory.Add(item);
        public void AddRange(IList<Item> items)
        {
            for (int ind = 0; ind < items.Count; ind++)
            {
                this.Add(items[ind]);
            }
        }
        public bool Remove(Item item) => inventory.Remove(item);
        public bool Remove(int index) => inventory.Remove(inventory[index]);
        public override List<Item> AllItems() => inventory;
        public override string ToString()
        {
            if (base.ToString() == "") return "Backpack is empty.";
            return base.ToString();
        }
    }
}
