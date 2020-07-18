using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotBoots: AClothesType
    {
        //1st default item for all
        public static readonly Item CLEAR = new Item("empty", 0);

        public static readonly Item SOCKS = new Item(":socks:", 50);
        public static readonly Item ICE_SKATE = new Item(":ice_skate:", 2000);
        public static readonly Item WOMANS_FLAT_SHOE = new Item(":womans_flat_shoe:", 1000);
        public static readonly Item HIGH_HEEL = new Item(":high_heel:", 10000);
        public static readonly Item SANDAL = new Item(":sandal:", 1500);
        public static readonly Item BOOT = new Item(":boot:", 3000);
        public static readonly Item BALLET_SHOES = new Item(":ballet_shoes:", 2000);
        public static readonly Item MANS_SHOE = new Item(":mans_shoe:", 1400);
        public static readonly Item ATHLETIC_SHOE = new Item(":athletic_shoe:", 5000);
        public static readonly Item HIKING_BOOT = new Item(":hiking_boot:", 5000);

        public override List<Item> AllClothes()
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
