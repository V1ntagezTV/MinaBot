using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;

namespace MinaBot.BotTamagochi.ItemsPack
{
    static class ItemMocks
    {
        public static Item DefaultItem = new Item("-", 0, ERarity.Common);
        public static ItemCollection<Item> AllItems { get; private set; }
        public static ItemCollection<Item> CommonItems { get; private set; }
        public static ItemCollection<Item> RareItems { get; private set; }
        public static ItemCollection<Item> LegendaryItems { get; private set; }
        public static ItemCollection<Item> ImmortalItems { get; private set; }

        static ItemMocks()
        {
            AllItems = ToCollection();
            CommonItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Common).ToList());
            RareItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Rare).ToList());
            LegendaryItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Legendary).ToList());
            ImmortalItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Immortal).ToList());
        }

        private static ItemCollection<Item> ToCollection()
        {
            /* 
             * ID по возрастанию!
             * 0 = default item
            */
            var result = new List<Item>();
            result.Add(DefaultItem);
            result.AddRange(Boots.GetAll);
            result.AddRange(Meal.GetAll);
            result.AddRange(Hat.GetAll);
            result.AddRange(Jacket.GetAll);
            result.AddRange(Pants.GetAll);
            return new ItemCollection<Item>(result);
        }
    }
}
