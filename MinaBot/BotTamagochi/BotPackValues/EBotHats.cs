using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotHats: AClothesType
    {
        //1st default item for all
        public static readonly Item CLEAR = new Item("empty", 0);

        public static readonly Item WOMANS_HAT = new Item(":womans_hat:", 1000);
        public static readonly Item TOPHAT = new Item(":tophat:", 3000);
        public static readonly Item BILLED_CAP = new Item(":billed_cap:", 1500);
        public static readonly Item MORTAR_BOARD = new Item(":mortar_board:", 1000);
        public static readonly Item HELMET_WITH_CROSS = new Item(":helmet_with_cross:", 3000);
        public static readonly Item CROWN = new Item(":crown:", 5000);
        public override List<Item> AllClothes()
        {
            return new List<Item>() { WOMANS_HAT, TOPHAT, BILLED_CAP, MORTAR_BOARD, HELMET_WITH_CROSS, CROWN };
        }
    }
}

