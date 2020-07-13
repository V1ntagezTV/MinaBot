using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace MinaBot.BotPackValues
{
    class EBotBoots
    {
        //1st default item for all
        public static readonly IItem CLEAR = new Item("empty", 0);

        public static readonly IItem SOCKS = new Item(":socks:", 50);
        public static readonly IItem ICE_SKATE = new Item(":ice_skate:", 2000);
        public static readonly IItem WOMANS_FLAT_SHOE = new Item(":womans_flat_shoe:", 1000);
        public static readonly IItem HIGH_HEEL = new Item(":high_heel:", 10000);
        public static readonly IItem SANDAL = new Item(":sandal:", 1500);
        public static readonly IItem BOOT = new Item(":boot:", 3000);
        public static readonly IItem BALLET_SHOES = new Item(":ballet_shoes:", 2000);
        public static readonly IItem MANS_SHOE = new Item(":mans_shoe:", 1400);
        public static readonly IItem ATHLETIC_SHOE = new Item(":athletic_shoe:", 5000);
        public static readonly IItem HIKING_BOOT = new Item(":hiking_boot:", 5000);

        public static List<IItem> ToList()
        {
            return new List<IItem>() 
            { 
                SOCKS, ICE_SKATE, WOMANS_FLAT_SHOE,
                HIGH_HEEL, SANDAL, BOOT, BALLET_SHOES,
                MANS_SHOE, ATHLETIC_SHOE, HIKING_BOOT
            };
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
