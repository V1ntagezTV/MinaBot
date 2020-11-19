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
        private static Item[] _itemsCached;
        private static ShopModel _shopModelCache;
        private const string PATH = @"C:\Users\Vintage\Desktop\C# Projects\MinaBot\MinaBot\TamagochiActions\Shop\shopconfig.json";
        
        public static Item[] GetItems()
        {
            if (_itemsCached == null)
            {
                UpdateOnNewDays();
                var itemsId = GetConfigValues().RndItemsId;
                _itemsCached = ItemMocks.AllItems.Data.Where(item => itemsId.Contains(item.Id)).ToArray();
                return _itemsCached;
            }
            return _itemsCached;
        }
        
        public static ShopModel GetConfigValues()
        {
            if (_shopModelCache != null)
            {
                return _shopModelCache;
            }
            var json = File.ReadAllText(PATH);
            var shopModel = JsonConvert.DeserializeObject<ShopModel>(json);
            _shopModelCache = shopModel;
            return shopModel;
        }
        
        public static async Task UpdateOnNewDays()
        {
            var lastShop = GetConfigValues();
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
            _shopModelCache = lastShop;
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