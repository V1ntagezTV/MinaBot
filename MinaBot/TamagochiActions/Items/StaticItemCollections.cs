using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes.ItemsJson;

namespace MinaBot.BotTamagochi.ItemsPack
{
    static class ItemMocks
    {
        public static Item DefaultItem = new Item("-", 0, ERarity.Common) {Id = 0};
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
            var jsonItems = Task.Run(() => new ItemsJsonController().GetConfigValuesAsync()).Result;
            var result = new List<Item>();
            result.Add(DefaultItem);
            result.AddRange(jsonItems.Boots);
            result.AddRange(jsonItems.Meals);
            result.AddRange(jsonItems.Hats);
            result.AddRange(jsonItems.Jackets);
            result.AddRange(jsonItems.Pants);
            result.AddRange(jsonItems.Liquids);
            return new ItemCollection<Item>(result);
        }
    }
}
