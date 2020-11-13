using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MinaBot.Models;
using MinaBot.TamagochiActions.Shop;
using Newtonsoft.Json;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes.ItemsJson
{
    public class ItemsJsonController
    {
        private const string Path = @"C:\Users\Vintage\Desktop\C# Projects\MinaBot\MinaBot\TamagochiActions\Items\ItemTypes\ItemsJson\ItemsConfig.json";
        public async Task<ItemsJsonModel> GetConfigValuesAsync()
        {
            var json = await File.ReadAllTextAsync(Path);
            return JsonConvert.DeserializeObject<ItemsJsonModel>(json);
        }

        public async Task SaveConfigValueAsync(ItemsJsonModel items)
        {
            var newData = JsonConvert.SerializeObject(items, Formatting.Indented);
            await File.WriteAllTextAsync(Path, newData);
        }

        public async Task AddItem(Item item)
        {
            var itemsData = this.GetConfigValuesAsync().Result;
            itemsData.IdCount++;
            item.Id = itemsData.IdCount;
            if (item is Boots boots) { itemsData.Boots.Add(boots); }
            else if (item is Meal meal) {itemsData.Meals.Add(meal);}
            else if (item is Hat hat) {itemsData.Hats.Add(hat);}
            else if (item is Jacket jacket) {itemsData.Jackets.Add(jacket);}
            else if (item is Liquid liquid) {itemsData.Liquids.Add(liquid);}
            else if (item is Pants pants) {itemsData.Pants.Add(pants);}
            else throw new ArgumentException("Item type was not indefinite!");
            SaveConfigValueAsync(itemsData);
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