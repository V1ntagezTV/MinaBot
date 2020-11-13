using System.Collections.Generic;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes.ItemsJson
{
    public class ItemsJsonModel
    {
        public int IdCount { get; set; }
        public List<Boots> Boots { get; set; }
        public List<Hat> Hats { get; set; }
        public List<Jacket> Jackets { get; set; }
        public List<Liquid> Liquids { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Pants> Pants { get; set; }
    }
}