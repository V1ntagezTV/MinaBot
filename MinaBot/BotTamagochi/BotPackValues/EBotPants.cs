using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotPackValues
{
    class EBotPants
    {   
        //1st default item for all
        public static readonly IItem CLEAR = new Item("empty", 0);

        public static readonly IItem BRIEFS = new Item(":briefs:", 300);
        public static readonly IItem SHORTS = new Item(":shorts:", 1000);
        public static readonly IItem JEANS = new Item(":jeans:", 2000);
        public static List<IItem> ToList()
        {
            return new List<IItem>() { BRIEFS, SHORTS, JEANS };
        }
        public override string ToString()
        {
            List<IItem> items = ToList();
            string result = "";
            for (int ind = 0; ind < items.Count; ind++)
            {
                result += items[ind].Name + " ";
                if (ind == 9)
                    result += '\n';
            }
            return result;
        }
    }
}