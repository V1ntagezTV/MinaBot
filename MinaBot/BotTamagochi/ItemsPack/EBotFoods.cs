using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotTamagochi.BotPackValues
{
    class EBotFoods : AItemCollections
    {
        //-
        public static readonly Food BONE = new Food(":bone:", 0, -25);
        public static readonly Food BRAIN = new Food(":brain:", 0, -50);
        public static readonly Food POOP = new Food(":poop:", 0, -100);
        //+
        public static readonly Food EGG = new Food(":egg:", 5, 10);
        public static readonly Food CHOCOLATE_BAR = new Food(":chocolate_bar:", 10, 20);
        public static readonly Food APPLE = new Food(":apple:", 15, 30);
        public static readonly Food WATERMELON = new Food(":watermelon:", 20, 40);
        public static readonly Food BREAD = new Food(":bread:", 25, 50);
        public static readonly Food CRAB = new Food(":crab:", 30, 60);
        public static readonly Food BEER = new Food(":beer:", 35, 70);
        public static readonly Food RAMEN = new Food(":ramen:", 40, 80);
        public static readonly Food CHICKEN = new Food(":chicken:", 45, 90);
        public static readonly Food PIZZA = new Food(":pizza:", 50, 100);

        public override List<Item> AllItems() => new List<Item>()
        {
            BONE, BRAIN, POOP,
            EGG, CHOCOLATE_BAR, APPLE, WATERMELON,
            BREAD, CRAB, BEER, RAMEN, CHICKEN, PIZZA
        };
    }
}