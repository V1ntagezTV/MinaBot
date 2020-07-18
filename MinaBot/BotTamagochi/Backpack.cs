using System.Collections.Generic;
using System.Linq;

namespace MinaBot.Models
{
    class Backpack
    {
        uint places;
        List<Item> inventory;

        public Backpack(uint places)
        {
            this.places = places;
            this.inventory = new List<Item>((int)places);
        }

        public void Add(Item item) => inventory.Add(item);
        public bool Remove(Item item) => inventory.Remove(item);
        public bool Remove(int ind) => inventory.Remove(inventory[ind]);
        public override string ToString()
        {
            string result = "";
            for (int ind = 0; ind < inventory.Count(); ind++)
            {
                result += inventory[ind].Name + '\n';
            }
            return result;
        }
    }
}
