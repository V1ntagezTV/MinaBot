using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace MinaBot.TamagochiActions.Shop
{
    public class ShopConfig
    {
        private const string PATH = "C:/Users/Vintage/Desktop/C# Projects/MinaBot/MinaBot/TamagochiActions/Shop/shopconfig.json";
        public async Task<ShopModel> GetConfigValuesAsync()
        {
            var json = await File.ReadAllTextAsync(PATH);
            return JsonConvert.DeserializeObject<ShopModel>(json);
        }

        public async Task SaveConfigValueAsync(ShopModel shop)
        {
            var newData = JsonConvert.SerializeObject(shop, Formatting.Indented);
            await File.WriteAllTextAsync(PATH, newData);
        }
    }
}