using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static MinaBot.BotTamagochi.BotPackValues.ItemTypes;

namespace MinaBot.BotTamagochi.ItemsPack
{
    static class ItemMocks
    {
        public static Item defaultCleanItem = new Item("Empty", 0, 0);
        public static ItemCollection<Item> AllItems { get; private set; }
        public static ItemCollection<Item> CommonItems { get; private set; }
        public static ItemCollection<Item> RareItems { get; private set; }
        public static ItemCollection<Item> LegendaryItems { get; private set; }
        public static ItemCollection<Item> ImmortalItems { get; private set; }
        public static ItemCollection<Boots> Boots { get; private set; }
        public static ItemCollection<Hat> Hats { get; private set; }
        public static ItemCollection<Jacket> Jackets { get; private set; }
        public static ItemCollection<Pants> Pants { get; private set; }
        public static ItemCollection<Food> Foods { get; private set; }

        static ItemMocks()
        {
            AllItems = ToCollection();
            CommonItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Common).ToList());
            RareItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Rare).ToList());
            LegendaryItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Legendary).ToList());
            ImmortalItems = new ItemCollection<Item>(AllItems.Data.Where(it => it.Rarity == ERarity.Immortal).ToList());
            Boots = new ItemCollection<Boots>(BootsList());
            Hats = new ItemCollection<Hat>(HatsList());
            Jackets = new ItemCollection<Jacket>(JacketsList());
            Pants = new ItemCollection<Pants>(PantsList());
            Foods = new ItemCollection<Food>(FoodsList());
        }

        public static readonly Boots SOCKS = new Boots(":socks:", 50, ERarity.Common);
        public static readonly Boots ICE_SKATE = new Boots(":ice_skate:", 2000, ERarity.Rare);
        public static readonly Boots WOMANS_FLAT_SHOE = new Boots(":womans_flat_shoe:", 1000, ERarity.Common);
        public static readonly Boots HIGH_HEEL = new Boots(":high_heel:", 10000, ERarity.Legendary);
        public static readonly Boots SANDAL = new Boots(":sandal:", 1500, ERarity.Common);
        public static readonly Boots BOOT = new Boots(":boot:", 3000, ERarity.Rare);
        public static readonly Boots BALLET_SHOES = new Boots(":ballet_shoes:", 2000, ERarity.Legendary);
        public static readonly Boots MANS_SHOE = new Boots(":mans_shoe:", 1400, ERarity.Rare);
        public static readonly Boots ATHLETIC_SHOE = new Boots(":athletic_shoe:", 5000, ERarity.Rare);
        public static readonly Boots HIKING_BOOT = new Boots(":hiking_boot:", 5000, ERarity.Rare);
        static private IList<Boots> BootsList()
        {
            return new List<Boots>()
            {
                SOCKS, ICE_SKATE, WOMANS_FLAT_SHOE,
                HIGH_HEEL, SANDAL, BOOT, BALLET_SHOES,
                MANS_SHOE, ATHLETIC_SHOE, HIKING_BOOT
            };
        }

        //-
        public static readonly Food BONE = new Food(":bone:", 0, -25, ERarity.Common);
        public static readonly Food BRAIN = new Food(":brain:", 0, -50, ERarity.Common);
        public static readonly Food POOP = new Food(":poop:", 0, -100, ERarity.Common);
        //+
        public static readonly Food EGG = new Food(":egg:", 5, 10, ERarity.Common);
        public static readonly Food CHOCOLATE_BAR = new Food(":chocolate_bar:", 10, 20, ERarity.Common);
        public static readonly Food APPLE = new Food(":apple:", 15, 30, ERarity.Rare);
        public static readonly Food WATERMELON = new Food(":watermelon:", 20, 40, ERarity.Rare);
        public static readonly Food BREAD = new Food(":bread:", 25, 50, ERarity.Rare);
        public static readonly Food CRAB = new Food(":crab:", 30, 60, ERarity.Rare);
        public static readonly Food BEER = new Food(":beer:", 35, 70, ERarity.Legendary);
        public static readonly Food RAMEN = new Food(":ramen:", 40, 80, ERarity.Legendary);
        public static readonly Food CHICKEN = new Food(":chicken:", 45, 90, ERarity.Immortal);
        public static readonly Food PIZZA = new Food(":pizza:", 50, 100, ERarity.Immortal);
        static private IList<Food> FoodsList()
        {
            return new List<Food>() 
            {
                BONE, BRAIN, POOP,
                EGG, CHOCOLATE_BAR, APPLE, WATERMELON,
                BREAD, CRAB, BEER, RAMEN, CHICKEN, PIZZA
            };
        }


        public static readonly Hat WOMANS_HAT = new Hat(":womans_hat:", 1000, ERarity.Legendary);
        public static readonly Hat TOPHAT = new Hat(":tophat:", 3000, ERarity.Common);
        public static readonly Hat BILLED_CAP = new Hat(":billed_cap:", 1500, ERarity.Common);
        public static readonly Hat MORTAR_BOARD = new Hat(":mortar_board:", 1000, ERarity.Rare);
        public static readonly Hat HELMET_WITH_CROSS = new Hat(":helmet_with_cross:", 3000, ERarity.Legendary);
        public static readonly Hat CROWN = new Hat(":crown:", 5000, ERarity.Immortal);
        static private IList<Hat> HatsList()
        {
            return new List<Hat> { WOMANS_HAT, TOPHAT, BILLED_CAP, MORTAR_BOARD, HELMET_WITH_CROSS, CROWN };
        }

        public static readonly Jacket COAT = new Jacket(":coat:", 4000, ERarity.Common);
        public static readonly Jacket LAB_COAT = new Jacket(":lab_coat:", 1500, ERarity.Rare);
        public static readonly Jacket SAFETY_VEST = new Jacket(":safety_vest:", 4000, ERarity.Rare);
        public static readonly Jacket WOMANS_CLOTHES = new Jacket(":womans_clothes:", 2500, ERarity.Common);
        public static readonly Jacket SHIRT = new Jacket(":shirt:", 1000, ERarity.Common);
        public static readonly Jacket NECKTIE = new Jacket(":necktie:", 2000, ERarity.Legendary);
        public static readonly Jacket DRESS = new Jacket(":dress:", 7000, ERarity.Immortal);
        public static readonly Jacket BIKINI = new Jacket(":bikini:", 3000, ERarity.Legendary);
        public static readonly Jacket ONE_PIECE_SWIMSUIT = new Jacket(":one_piece_swimsuit:", 3000, ERarity.Rare);
        public static readonly Jacket KIMONO = new Jacket(":kimono:", 2000, ERarity.Legendary);
        public static readonly Jacket SARI = new Jacket(":sari:", 5000, ERarity.Rare);
        public static readonly Jacket RUNNING_SHIRT_WITH_SASH = new Jacket(":running_shirt_with_sash:", 1200, ERarity.Common);
        public static readonly Jacket MARTIAL_ARTS_UNIFORM = new Jacket(":martial_arts_uniform:", 3000, ERarity.Immortal);
        static private IList<Jacket> JacketsList()
        {
            return new List<Jacket>()
            {
                COAT, LAB_COAT, SAFETY_VEST, WOMANS_CLOTHES,
                SHIRT, NECKTIE, DRESS, BIKINI, ONE_PIECE_SWIMSUIT,
                KIMONO, SARI, RUNNING_SHIRT_WITH_SASH, MARTIAL_ARTS_UNIFORM
            };
        }

        public static readonly Pants BRIEFS = new Pants(":briefs:", 300, ERarity.Common);
        public static readonly Pants SHORTS = new Pants(":shorts:", 1000, ERarity.Common);
        public static readonly Pants JEANS = new Pants(":jeans:", 2000, ERarity.Rare);
        static private IList<Pants> PantsList()
        {
            return new List<Pants>() { BRIEFS, SHORTS, JEANS };
        }
        static private ItemCollection<Item> ToCollection()
        {
            /* 
             * ID по возрастанию!
             * 0 = default item
            */
            var result = new List<Item>();
            result.Add(defaultCleanItem);
            result.AddRange(BootsList());
            result.AddRange(FoodsList());
            result.AddRange(HatsList());
            result.AddRange(JacketsList());
            result.AddRange(PantsList());
            return new ItemCollection<Item>(result);
        }
    }
}
