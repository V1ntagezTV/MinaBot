using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotTamagochi.BotPackValues
{
    class EBotFoods : AItemCollections
    {
        public static readonly Food BRAIN = new Food(":brain:", 0, -10);
        public static readonly Food BONE = new Food(":bone:", 0, -15);
        public static readonly Food POOP = new Food(":poop:", 0, -30);

        public static readonly Food CHICKEN = new Food(":chicken:", 0, 10);
        public static readonly Food CRAB = new Food(":crab:", 0, 10);
        public static readonly Food APPLE = new Food(":apple:", 0, 10);
        public static readonly Food WATERMELON = new Food(":watermelon:", 0, 10);
        public static readonly Food POULTRY_LEG = new Food(":poultry_leg:", 0, 10);
        public static readonly Food CUT_OF_MEAT = new Food(":cut_of_meat:", 0, 10);
        public static readonly Food BREAD = new Food(":bread:", 0, 10);
        public static readonly Food CHOCOLATE_BAR = new Food(":chocolate_bar:", 0, 10);
        public static readonly Food BEER = new Food(":beer:", 0, 10);
        public static readonly Food PIE = new Food(":pie:", 0, 10);
        public static readonly Food RAMEN = new Food(":ramen:", 0, 10);
        public static readonly Food BURRITO = new Food(":burrito:", 0, 10);
        public static readonly Food TACO = new Food(":taco:", 0, 10);
        public static readonly Food HAMBURGER = new Food(":hamburger:", 0, 10);
        public static readonly Food HOTDOG = new Food(":hotdog:", 0, 10);
        public static readonly Food PIZZA = new Food(":pizza:", 0, 10);
        public static readonly Food SANDWICH = new Food(":sandwich:", 0, 10);
        public static readonly Food EGG = new Food(":egg:", 0, 10);
        public static readonly Food SUSHI = new Food(":sushi:", 0, 10);
        public override List<Item> AllClothes() => new List<Item>()
        {
            BRAIN, BONE, POOP,
            CHICKEN, CRAB, APPLE, WATERMELON, POULTRY_LEG, CUT_OF_MEAT,
            BREAD, CHOCOLATE_BAR, BEER, PIE, RAMEN, BURRITO, TACO,
            HAMBURGER, HOTDOG, PIZZA, SANDWICH, EGG, SUSHI
        };
    }
}