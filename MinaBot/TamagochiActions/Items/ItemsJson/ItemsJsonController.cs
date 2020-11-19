using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MinaBot.Models;
using MinaBot.TamagochiActions.Shop;
using Newtonsoft.Json;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes.ItemsJson
{
    public static class ItemsJsonController
    {
        private const string relativePath = @"\TamagochiActions\Items\ItemsJson\ItemsConfig.json";
        private static string directoryFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private static string fullPath = directoryFolder + relativePath;
        public static async Task<ItemsJsonModel> GetConfigValuesAsync()
        {
            var json = await File.ReadAllTextAsync(fullPath);
            return JsonConvert.DeserializeObject<ItemsJsonModel>(json);
        }

        public static async Task SaveConfigValueAsync(ItemsJsonModel items)
        {
            var newData = JsonConvert.SerializeObject(items, Formatting.Indented);
            await File.WriteAllTextAsync(fullPath, newData);
        }

        public static async Task AddItem(Item item)
        {
            var itemsData = await GetConfigValuesAsync();
            itemsData.IdCount++;
            item.Id = itemsData.IdCount;
            if (item is Boots boots) { itemsData.Boots.Add(boots); }
            else if (item is Meal meal) {itemsData.Meals.Add(meal);}
            else if (item is Hat hat) {itemsData.Hats.Add(hat);}
            else if (item is Jacket jacket) {itemsData.Jackets.Add(jacket);}
            else if (item is Liquid liquid) {itemsData.Liquids.Add(liquid);}
            else if (item is Pants pants) {itemsData.Pants.Add(pants);}
            else throw new ArgumentException("Item type was not indefinite!");
            await SaveConfigValueAsync(itemsData);
        }
    }
    
    /***
    await controller.SaveConfigValueAsync(new ItemsJsonModel() 
    {
    IdCount = ItemMocks.AllItems.Data.Count,
    Boots = Boots.GetAll.ToList(),
    Hats = Hat.GetAll.ToList(),
    Jackets = Jacket.GetAll.ToList(),
    Liquids = Liquid.GetAll.ToList(),
    Meals = Meal.GetAll.ToList(),
    Pants = Pants.GetAll.ToList()
    });
    ***/
}