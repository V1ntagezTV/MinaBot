using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotPackValues
{
    sealed class EBotHats
    {
        //1st default item for all
        public static readonly IItem CLEAR = new Item("", 0);

        public static readonly IItem WOMANS_HAT = new Item(":womans_hat:", 1000);
        public static readonly IItem TOPHAT = new Item(":tophat:", 3000);
        public static readonly IItem BILLED_CAP = new Item(":billed_cap:", 1500);
        public static readonly IItem MORTAR_BOARD = new Item(":mortar_board:", 1000);
        public static readonly IItem HELMET_WITH_CROSS = new Item(":helmet_with_cross:", 3000);
        public static readonly IItem CROWN = new Item(":crown:", 5000);
    }
}

