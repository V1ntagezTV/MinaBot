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
        public void Remove(Item item) => inventory.Remove(item);
        public override string ToString()
        {
            string result = "";
            for (int ind = 0; ind < inventory.Count(); ind++)
            {
                result += inventory[ind].Name;
                if (ind % 10 == 0)
                    result += '\n';
            }
            return result;
        }
    }
}
