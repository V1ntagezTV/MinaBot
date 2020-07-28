using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotTamagochi.BotPackValues
{
    class EBotFoods : AItemCollections
    {
        //-
        public static readonly Food BONE = new Food(":bone:", 0, -25, ERarity.Common);
        public static readonly Food BRAIN = new Food(":brain:", 0, -50, ERarity.Common);
        public static readonly Food POOP = new Food(":poop:", 0, -100, ERarity.Common);
        //+
        public static readonly Food EGG = new Food(":egg:", 5, 10, ERarity.Common);
        public static readonly Food CHOCOLATE_BAR = new Food(":chocolate_bar:", 10, 20, ERarity.Common);
        public static readonly Food APPLE = new Food(":apple:", 15, 30, ERarity.Rare);
        public static readonly Food WATERMELON = new Food(":watermelon:", 20, 40, ERarity.Rare);
        public static readonly Food BREAD = new Food(":bread:", 25, 50, ERarity.Rare);
        public static readonly Food CRAB = new Food(":crab:", 30, 60, ERarity.Rare);
        public static readonly Food BEER = new Food(":beer:", 35, 70, ERarity.Legendary);
        public static readonly Food RAMEN = new Food(":ramen:", 40, 80, ERarity.Legendary);
        public static readonly Food CHICKEN = new Food(":chicken:", 45, 90, ERarity.Immortal);
        public static readonly Food PIZZA = new Food(":pizza:", 50, 100, ERarity.Immortal);

        public override List<Item> AllItems() => new List<Item>()
        {
            BONE, BRAIN, POOP,
            EGG, CHOCOLATE_BAR, APPLE, WATERMELON,
            BREAD, CRAB, BEER, RAMEN, CHICKEN, PIZZA
        };
    }
}