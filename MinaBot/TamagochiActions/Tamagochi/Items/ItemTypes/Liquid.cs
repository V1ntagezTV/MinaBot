using System.Linq;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Liquid : Item
    {
        public static Liquid[] GetAll { get; private set; } = LiquidList();
        public int Satiety { get; private set; }

        public Liquid(string name, int price, int satiety, ERarity rarity) : base(name, price, rarity)
        {
            Satiety = satiety;
        }

        private static Liquid[] LiquidList()
        {
            return new Liquid[]
            {
                new Liquid(":coffee:", 0, 20, ERarity.Common),
                new Liquid(":tea:", 0, 20, ERarity.Common),
                new Liquid(":baby_bottle:", 0, 20, ERarity.Common),
                new Liquid(":milk:", 0, 20, ERarity.Common),
                new Liquid(":tumbler_glass:", 0, 20, ERarity.Common),
                new Liquid(":mate:", 0, 20, ERarity.Rare),
                new Liquid(":bubble_tea:", 0, 20, ERarity.Rare),
                new Liquid(":beverage_box:", 0, 20, ERarity.Rare),
                new Liquid(":cup_with_straw:", 0, 20, ERarity.Rare),
                new Liquid(":cocktail:", 0, 20, ERarity.Rare),
                new Liquid(":sake:", 0, 20, ERarity.Legendary),
                new Liquid(":wine_glass:", 0, 20, ERarity.Legendary),
                new Liquid(":tropical_drink:", 0, 20, ERarity.Legendary),
                new Liquid(":champagne:", 0, 20, ERarity.Immortal),
                new Liquid(":beer:", 0, 20, ERarity.Immortal),
                new Liquid(":honey_pot:", 0, 20, ERarity.Immortal),
            }.OrderBy(m => m.Price).ToArray();
        }
    }
}