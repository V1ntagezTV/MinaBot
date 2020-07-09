using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotPackValues
{
    sealed class EBotPants
    {   
        //1st default item for all
        public static readonly IItem CLEAR = new Item("", 0);

        public static readonly IItem BRIEFS = new Item(":briefs:", 300);
        public static readonly IItem SHORTS = new Item(":shorts:", 1000);
        public static readonly IItem JEANS = new Item(":jeans:", 2000);
    }
}