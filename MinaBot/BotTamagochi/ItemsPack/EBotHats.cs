using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotHats: AItemCollections
    {
        public static readonly Hat WOMANS_HAT = new Hat(":womans_hat:", 1000, ERarity.Rare);
        public static readonly Hat TOPHAT = new Hat(":tophat:", 3000, ERarity.Common);
        public static readonly Hat BILLED_CAP = new Hat(":billed_cap:", 1500, ERarity.Common);
        public static readonly Hat MORTAR_BOARD = new Hat(":mortar_board:", 1000, ERarity.Rare);
        public static readonly Hat HELMET_WITH_CROSS = new Hat(":helmet_with_cross:", 3000, ERarity.Legendary);
        public static readonly Hat CROWN = new Hat(":crown:", 5000, ERarity.Immortal);
        public override List<Item> AllItems()
        {
            return new List<Item>() { WOMANS_HAT, TOPHAT, BILLED_CAP, MORTAR_BOARD, HELMET_WITH_CROSS, CROWN };
        }
    }
}

