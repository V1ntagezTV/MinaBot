using MinaBot.BotTamagochi.BotPackValues;
using System.Collections.Generic;
using System.Linq;

namespace MinaBot.Models
{
    class Backpack: AItemCollections
    {
        public int Lenght { get; }
        List<Item> inventory;

        public Backpack(int places)
        {
            this.Lenght = places;
            this.inventory = new List<Item>((int)places);
        }
        public void Add(Item item) => inventory.Add(item);
        public void AddRange(IList<Item> items)
        {
            for (int ind = 0; ind < items.Count; ind++)
            {
                this.Add(items[ind]);
            }
        }
        public bool Remove(Item item) => inventory.Remove(item);
        public override List<Item> AllItems() => inventory;
        public override string ToString()
        {
            if (base.ToString() == "") return "Backpack is empty.";
            return base.ToString();
        }
    }
}
