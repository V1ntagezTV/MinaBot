using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinaBot.BotTamagochi.BotPackValues
{
    public class ItemCollection<T> where T: Item 
    {
        public const string DEFAULT_VALUE = "Пусто!";
        public IList<T> Data;
        public ItemCollection(IList<T> list)
        {
            Data = list;
        }

        public IEnumerable<Item> ShopList()
        {
            return Data.Where(i => i.Rarity > ERarity.Legendary);
        }

        public Item GetRandomItemWithChance()
        {
            var random = new Random();
            var itemRarity = random.Next(0, 101);
            if (itemRarity <= (int)ERarity.Immortal)
            {
                return ItemMocks.ImmortalItems[random.Next(ItemMocks.ImmortalItems.Data.Count())];
            }
            else if (itemRarity <= (int)ERarity.Legendary)
            {
                return ItemMocks.LegendaryItems[random.Next(ItemMocks.LegendaryItems.Data.Count())];
            }
            else if (itemRarity <= (int)ERarity.Rare)
            {
                return ItemMocks.RareItems[random.Next(ItemMocks.RareItems.Data.Count())];
            }
            else if (itemRarity <= (int)ERarity.Common)
            {
                return ItemMocks.CommonItems[random.Next(ItemMocks.CommonItems.Data.Count())];
            }
            else return ItemMocks.defaultCleanItem;
        }

        public string ToStringWithPriceInLine()
        {
            string result = "";
            for (int ind = 0; ind < Data.Count; ind++)
            {
                result += Data[ind].Name + " " + Data[ind].Price + "\n";
            }
            if (result == "")
            {
                return DEFAULT_VALUE;
            }
            return result;
        }

        public string ToStringInLine()
        {
            string result = "";
            for (int ind = 0; ind < Data.Count; ind++)
            {
                result += Data[ind].Name + "\n";
            }
            if (result == "")
            {
                return DEFAULT_VALUE;
            }
            return result;
        }

        public string ToStringPricesInLine()
        {
            string result = "";
            for (int ind = 0; ind < Data.Count; ind++)
            {
                result += Data[ind].Price + "\n";
            }
            if (result == "")
            {
                return DEFAULT_VALUE;
            }
            return result;
        }

        public Item this[int index] => Data[index];

        public override string ToString()
        {
            string result = "";
            for (int ind = 0; ind < Data.Count; ind++)
            {
                result += Data[ind].Name + " ";
            }
            if (result == "")
            {
                return DEFAULT_VALUE;
            }
            return result;
        }
    }
}