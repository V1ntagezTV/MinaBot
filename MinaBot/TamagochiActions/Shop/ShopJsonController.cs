using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Models;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes.ItemsJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace MinaBot.TamagochiActions.Shop
{
    public static class ShopJsonController
    {
        static Random rnd = new Random();
 
        public static Item[] items
        {
            get
            {
                var itemsId = GetConfigValuesAsync().Result.RndItemsId;
                return ItemMocks.AllItems.Data.Where(item => itemsId.Contains(item.Id)).ToArray();
            }
        }
        private const string PATH = @"C:\Users\Vintage\Desktop\C# Projects\MinaBot\MinaBot\TamagochiActions\Shop\shopconfig.json";
        public static async Task<ShopModel> GetConfigValuesAsync()
        {
            var json = await File.ReadAllTextAsync(PATH);
            return JsonConvert.DeserializeObject<ShopModel>(json);
        }
        
        public static async Task UpdateOnNewDays()
        {
            var lastShop = await GetConfigValuesAsync();
            if (lastShop.UpdateDate + new TimeSpan(24, 0, 0) > DateTime.Now)
            {
                return;
            }
            lastShop.UpdateDate = DateTime.Now;
            var items = await new ItemsJsonController().GetConfigValuesAsync();
            lastShop.RndItemsId = new int[6]
            {
                GetRandomItem(items.Meals.Where(it => it.Rarity >= ERarity.Rare)).Id,
                GetRandomItem(items.Liquids.Where(it => it.Rarity >= ERarity.Rare)).Id,
                GetRandomItem(items.Hats.Where(it => it.Rarity >= ERarity.Rare)).Id,
                GetRandomItem(items.Jackets.Where(it => it.Rarity >= ERarity.Rare)).Id,
                GetRandomItem(items.Pants.Where(it => it.Rarity >= ERarity.Rare)).Id,
                GetRandomItem(items.Boots.Where(it => it.Rarity >= ERarity.Rare)).Id
            };
            var newData = JsonConvert.SerializeObject(lastShop, Formatting.Indented);
            await File.WriteAllTextAsync(PATH, newData);
        }

        private static T GetRandomItem<T>(IEnumerable<T> items)
        {
            var rndItemIndex = rnd.Next(0, items.Count());
            return items.ElementAt(rndItemIndex);
        }
    }
}