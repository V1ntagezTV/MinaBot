﻿using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotPants : AItemCollections
    {   
        //1st default item for all
        public static readonly Pants CLEAR = new Pants("empty", 0);

        public static readonly Pants BRIEFS = new Pants(":briefs:", 300);
        public static readonly Pants SHORTS = new Pants(":shorts:", 1000);
        public static readonly Pants JEANS = new Pants(":jeans:", 2000);
        public override List<Item> AllClothes()
        {
            return new List<Item>() { BRIEFS, SHORTS, JEANS };
        }
    }
}