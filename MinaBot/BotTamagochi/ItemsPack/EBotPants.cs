using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotPants : AItemCollections
    {   
        public static readonly Pants BRIEFS = new Pants(":briefs:", 300);
        public static readonly Pants SHORTS = new Pants(":shorts:", 1000);
        public static readonly Pants JEANS = new Pants(":jeans:", 2000);
        public override List<Item> AllItems()
        {
            return new List<Item>() { BRIEFS, SHORTS, JEANS };
        }
    }
}