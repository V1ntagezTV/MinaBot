﻿using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinaBot.BotTamagochi.BotPackValues
{
    class ItemCollection<T> where T: Item 
    {
        public IList<T> Data;
        public ItemCollection(IList<T> list)
        {
            Data = list;
        }

        public IEnumerable<Item> ShopList()
        {
            return Data.Where(i => i.Rarity <= ERarity.Legendary);
        }

        public Item GetRandomItemWithChance()
        {
            var random = new Random();
            var itemRarity = random.Next(0, 101);
            if (itemRarity <= (int)ERarity.Common)
            {
                return ItemMocks.CommonItems[random.Next(ItemMocks.CommonItems.Data.Count())];
            }
            else if (itemRarity <= (int)ERarity.Rare)
            {
                return ItemMocks.RareItems[random.Next(ItemMocks.RareItems.Data.Count())];
            }
            else if (itemRarity <= (int)ERarity.Legendary)
            {
                return ItemMocks.LegendaryItems[random.Next(ItemMocks.LegendaryItems.Data.Count())];
            }
            else if (itemRarity <= (int)ERarity.Immortal)
            {
                return ItemMocks.ImmortalItems[random.Next(ItemMocks.ImmortalItems.Data.Count())];
            }
            else return ItemMocks.defaultCleanItem;

            //for (int ind = 0; ind < Data.Count(); ind++)
            //{
            //    if (random.Next(0, 101) <= (int)Data[ind].Rarity)
            //    {
            //        return Data[ind];
            //    }
            //}
            //return Item.defaultCleanItem;
        }

        public string ToStringWithPriceInLine()
        {
            string result = "";
            for (int ind = 0; ind < Data.Count; ind++)
            {
                result += Data[ind].Name + " " + Data[ind].Price + "\n";
            }
            return result;
        }

        public string ToStringInLine()
        {
            string result = "";
            for (int ind = 0; ind < Data.Count; ind++)
            {
                result += Data[ind].ID + " " + Data[ind].Name + "\n";
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
            return result;
        }

        public Item this[int index]
        {
            get { return Data[index]; }
        }

        public override string ToString()
        {
            string result = "";
            for (int ind = 0; ind < Data.Count; ind++)
            {
                result += Data[ind].Name + " ";
            }
            return result;
        }
    }
}