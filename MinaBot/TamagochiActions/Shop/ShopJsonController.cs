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
        private static Item[] items;
        public static Item[] GetItems()
        {
            if (items == null)
            {
                UpdateOnNewDays();
                var itemsId = GetConfigValuesAsync().RndItemsId;
                items = ItemMocks.AllItems.Data.Where(item => itemsId.Contains(item.Id)).ToArray();
                return items;
            }
            return items;
        }
        
        private const string PATH = @"C:\Users\Vintage\Desktop\C# Projects\MinaBot\MinaBot\TamagochiActions\Shop\shopconfig.json";
        public static ShopModel GetConfigValuesAsync()
        {
            var json = File.ReadAllText(PATH);
            return JsonConvert.DeserializeObject<ShopModel>(json);
        }
        
        public static async Task UpdateOnNewDays()
        {
            var lastShop = GetConfigValuesAsync();
            if (lastShop.UpdateDate + new TimeSpan(24, 0, 0) > DateTime.Now)
            {
                return;
            }
            lastShop.UpdateDate += new TimeSpan(24, 0,0 );
            var items = await new ItemsJsonController().GetConfigValuesAsync();
            lastShop.RndItemsId = new int[6]
            {
                GetRandomItem(GetOnlyCommonAndRare(items.Meals)).Id,
                GetRandomItem(GetOnlyCommonAndRare(items.Liquids)).Id,
                GetRandomItem(GetOnlyCommonAndRare(items.Hats)).Id,
                GetRandomItem(GetOnlyCommonAndRare(items.Jackets)).Id,
                GetRandomItem(GetOnlyCommonAndRare(items.Pants)).Id,
                GetRandomItem(GetOnlyCommonAndRare(items.Boots)).Id
            };
            var newData = JsonConvert.SerializeObject(lastShop, Formatting.Indented);
            await File.WriteAllTextAsync(PATH, newData);
        }

        private static IEnumerable<T> GetOnlyCommonAndRare<T>(this IEnumerable<T> items) where T: Item
        {
            return items.Where(it => it.Rarity >= ERarity.Rare);
        }

        private static T GetRandomItem<T>(IEnumerable<T> items)
        {
            var rndItemIndex = rnd.Next(0, items.Count());
            return items.ElementAt(rndItemIndex);
        }
    }
}