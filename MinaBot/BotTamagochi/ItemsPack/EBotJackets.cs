using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotJackets: AItemCollections
    {
        //1st default item for all
        public static readonly Jacket CLEAR = new Jacket("empty", 0);

        public static readonly Jacket COAT = new Jacket(":coat:", 4000);
        public static readonly Jacket LAB_COAT = new Jacket(":lab_coat:", 1500);
        public static readonly Jacket SAFETY_VEST = new Jacket(":safety_vest:", 4000);
        public static readonly Jacket WOMANS_CLOTHES = new Jacket(":womans_clothes:", 2500);
        public static readonly Jacket SHIRT = new Jacket(":shirt:", 1000);
        public static readonly Jacket NECKTIE = new Jacket(":necktie:", 2000);
        public static readonly Jacket DRESS = new Jacket(":dress:", 7000);
        public static readonly Jacket BIKINI = new Jacket(":bikini:", 3000);
        public static readonly Jacket ONE_PIECE_SWIMSUIT = new Jacket(":one_piece_swimsuit:", 3000);
        public static readonly Jacket KIMONO = new Jacket(":kimono:", 2000);
        public static readonly Jacket SARI = new Jacket(":sari:", 5000);
        public static readonly Jacket RUNNING_SHIRT_WITH_SASH = new Jacket(":running_shirt_with_sash:", 1200);
        public static readonly Jacket MARTIAL_ARTS_UNIFORM = new Jacket(":martial_arts_uniform:", 3000);

        public override List<Item> AllItems()
        {
            return new List<Item>() 
            {
                COAT, LAB_COAT, SAFETY_VEST, WOMANS_CLOTHES,
                SHIRT, NECKTIE, DRESS, BIKINI, ONE_PIECE_SWIMSUIT,
                KIMONO, SARI, RUNNING_SHIRT_WITH_SASH, MARTIAL_ARTS_UNIFORM
            };
        }
    }
}
