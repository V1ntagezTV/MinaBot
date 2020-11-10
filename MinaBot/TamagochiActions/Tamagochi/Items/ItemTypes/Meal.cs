using System.Collections.Generic;
using System.Linq;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Meal : Item
    {
        public static Meal[] GetAll { get; private set; } = MealList();
        public int Satiety { get; private set; }
        public Meal(string name, int price, int satiety, ERarity rarity) : base(name, price, rarity)
        {
            Satiety = satiety;
        }

        private static Meal[] MealList()
        {
            return new Meal[]
            {
                new Meal(":bone:", 0, -25, ERarity.Common),
                new Meal(":poop:", 0, -100, ERarity.Common),
                new Meal(":egg:", 5, 10, ERarity.Common),
                new Meal(":chocolate_bar:", 10, 20, ERarity.Common),
                new Meal(":apple:", 15, 30, ERarity.Common),
                new Meal(":watermelon:", 20, 40, ERarity.Common),
                new Meal(":bread:", 25, 50, ERarity.Common),
                new Meal(":crab:", 30, 60, ERarity.Common),
                new Meal(":beer:", 35, 70, ERarity.Rare),
                new Meal(":ramen:", 40, 80, ERarity.Legendary),
                new Meal(":chicken:", 45, 90, ERarity.Legendary),
                new Meal(":pizza:", 50, 100, ERarity.Immortal)
            }.OrderBy(m => m.Price).ToArray();
        }
    }
}