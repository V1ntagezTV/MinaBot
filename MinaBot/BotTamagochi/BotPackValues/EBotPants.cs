using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotPants : AClothesType
    {   
        //1st default item for all
        public static readonly Item CLEAR = new Item("empty", 0);

        public static readonly Item BRIEFS = new Item(":briefs:", 300);
        public static readonly Item SHORTS = new Item(":shorts:", 1000);
        public static readonly Item JEANS = new Item(":jeans:", 2000);
        public override List<Item> AllClothes()
        {
            return new List<Item>() { BRIEFS, SHORTS, JEANS };
        }
    }
}