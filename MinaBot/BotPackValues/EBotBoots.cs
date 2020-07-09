using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace MinaBot.BotPackValues
{
    sealed class EBotBoots
    {
        //1st default item for all
        public static readonly IItem CLEAR = new Item("", 0);

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


        
    }
}
