using MinaBot.Models;
using System.Collections.Generic;

namespace MinaBot.BotPackValues
{
    class EBotJackets
    {
        //1st default item for all
        public static readonly Item CLEAR = new Item("empty", 0);

        public static readonly Item COAT = new Item(":coat:", 4000);
        public static readonly Item LAB_COAT = new Item(":lab_coat:", 1500);
        public static readonly Item SAFETY_VEST = new Item(":safety_vest:", 4000);
        public static readonly Item WOMANS_CLOTHES = new Item(":womans_clothes:", 2500);
        public static readonly Item SHIRT = new Item(":shirt:", 1000);
        public static readonly Item NECKTIE = new Item(":necktie:", 2000);
        public static readonly Item DRESS = new Item(":dress:", 7000);
        public static readonly Item BIKINI = new Item(":bikini:", 3000);
        public static readonly Item ONE_PIECE_SWIMSUIT = new Item(":one_piece_swimsuit:", 3000);
        public static readonly Item KIMONO = new Item(":kimono:", 2000);
        public static readonly Item SARI = new Item(":sari:", 5000);
        public static readonly Item RUNNING_SHIRT_WITH_SASH = new Item(":running_shirt_with_sash:", 1200);
        public static readonly Item MARTIAL_ARTS_UNIFORM = new Item(":martial_arts_uniform:", 3000);

        public static List<Item> ToList()
        {
            return new List<Item>() 
            {
                COAT, LAB_COAT, SAFETY_VEST, WOMANS_CLOTHES,
                SHIRT, NECKTIE, DRESS, BIKINI, ONE_PIECE_SWIMSUIT,
                KIMONO, SARI, RUNNING_SHIRT_WITH_SASH, MARTIAL_ARTS_UNIFORM
            };
        }
        public override string ToString()
        {
            List<Item> items = ToList();
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
