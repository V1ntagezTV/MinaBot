using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotPackValues
{
    class EBotHats
    {
        //1st default item for all
        public static readonly IItem CLEAR = new Item("empty", 0);

        public static readonly IItem WOMANS_HAT = new Item(":womans_hat:", 1000);
        public static readonly IItem TOPHAT = new Item(":tophat:", 3000);
        public static readonly IItem BILLED_CAP = new Item(":billed_cap:", 1500);
        public static readonly IItem MORTAR_BOARD = new Item(":mortar_board:", 1000);
        public static readonly IItem HELMET_WITH_CROSS = new Item(":helmet_with_cross:", 3000);
        public static readonly IItem CROWN = new Item(":crown:", 5000);
        public static List<IItem> ToList()
        {
            return new List<IItem>() { WOMANS_HAT, TOPHAT, BILLED_CAP, MORTAR_BOARD, HELMET_WITH_CROSS, CROWN };
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

