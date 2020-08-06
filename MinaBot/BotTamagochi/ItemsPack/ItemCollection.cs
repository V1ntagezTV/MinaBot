using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinaBot.BotTamagochi.BotPackValues
{
    class ItemCollection<T> where T: Item 
    {
        public IList<T> itemList;
        public ItemCollection(IList<T> list)
        {
            itemList = list;
        }

        public IEnumerable<Item> ShopList()
        {
            return itemList.Where(i => i.Rarity <= ERarity.Legendary);
        }

        public Item GetRandomItemWithChance()
        {
            var random = new Random();
            for (int ind = 0; ind < itemList.Count(); ind++)
            {
                if (random.Next(0, 101) <= (int)itemList[ind].Rarity)
                {
                    return itemList[ind];
                }
            }
            return Item.defaultCleanItem;
        }
        public string ToStringWithPriceInLine()
        {
            string result = "";
            for (int ind = 0; ind < itemList.Count; ind++)
            {
                result += itemList[ind].Name + " " + itemList[ind].Price + "\n";
            }
            return result;
        }
        public string ToStringInLine()
        {
            string result = "";
            for (int ind = 0; ind < itemList.Count; ind++)
            {
                result += itemList[ind].ID + " " + itemList[ind].Name + "\n";
            }
            return result;
        }
        public string ToStringPricesInLine()
        {
            string result = "";
            for (int ind = 0; ind < itemList.Count; ind++)
            {
                result += itemList[ind].Price + "\n";
            }
            return result;
        }
        public Item this[int index]
        {
            get { return itemList[index]; }
        }
        public override string ToString()
        {
            string result = "";
            for (int ind = 0; ind < itemList.Count; ind++)
            {
                result += itemList[ind].Name + " ";
            }
            return result;
        }
    }
}