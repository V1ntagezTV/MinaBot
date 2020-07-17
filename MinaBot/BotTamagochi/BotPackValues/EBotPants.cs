using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotPants
    {   
        //1st default item for all
        public static readonly Item CLEAR = new Item("empty", 0);

        public static readonly Item BRIEFS = new Item(":briefs:", 300);
        public static readonly Item SHORTS = new Item(":shorts:", 1000);
        public static readonly Item JEANS = new Item(":jeans:", 2000);
        public static List<Item> ToList()
        {
            return new List<Item>() { BRIEFS, SHORTS, JEANS };
        }
        public override string ToString()
        {
            List<Item> items = ToList();
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