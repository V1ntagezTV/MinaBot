using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotBoots: AItemCollections
    {
        public static readonly Boots SOCKS = new Boots(":socks:", 50, ERarity.Common);
        public static readonly Boots ICE_SKATE = new Boots(":ice_skate:", 2000, ERarity.Rare);
        public static readonly Boots WOMANS_FLAT_SHOE = new Boots(":womans_flat_shoe:", 1000);
        public static readonly Boots HIGH_HEEL = new Boots(":high_heel:", 10000);
        public static readonly Boots SANDAL = new Boots(":sandal:", 1500);
        public static readonly Boots BOOT = new Boots(":boot:", 3000);
        public static readonly Boots BALLET_SHOES = new Boots(":ballet_shoes:", 2000);
        public static readonly Boots MANS_SHOE = new Boots(":mans_shoe:", 1400);
        public static readonly Boots ATHLETIC_SHOE = new Boots(":athletic_shoe:", 5000);
        public static readonly Boots HIKING_BOOT = new Boots(":hiking_boot:", 5000);

        public override List<Item> AllItems()
        {
            return new List<Item>() 
            {
                SOCKS, ICE_SKATE, WOMANS_FLAT_SHOE,
                HIGH_HEEL, SANDAL, BOOT, BALLET_SHOES,
                MANS_SHOE, ATHLETIC_SHOE, HIKING_BOOT
            };
        }
    }
}
