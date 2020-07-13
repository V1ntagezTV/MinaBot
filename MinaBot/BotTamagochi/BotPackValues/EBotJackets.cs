using MinaBot.Interfaces;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotPackValues
{
    class EBotJackets
    {
        //1st default item for all
        public static readonly IItem CLEAR = new Item("empty", 0);

        public static readonly IItem COAT = new Item(":coat:", 4000);
        public static readonly IItem LAB_COAT = new Item(":lab_coat:", 1500);
        public static readonly IItem SAFETY_VEST = new Item(":safety_vest:", 4000);
        public static readonly IItem WOMANS_CLOTHES = new Item(":womans_clothes:", 2500);
        public static readonly IItem SHIRT = new Item(":shirt:", 1000);
        public static readonly IItem NECKTIE = new Item(":necktie:", 2000);
        public static readonly IItem DRESS = new Item(":dress:", 7000);
        public static readonly IItem BIKINI = new Item(":bikini:", 3000);
        public static readonly IItem ONE_PIECE_SWIMSUIT = new Item(":one_piece_swimsuit:", 3000);
        public static readonly IItem KIMONO = new Item(":kimono:", 2000);
        public static readonly IItem SARI = new Item(":sari:", 5000);
        public static readonly IItem RUNNING_SHIRT_WITH_SASH = new Item(":running_shirt_with_sash:", 1200);
        public static readonly IItem MARTIAL_ARTS_UNIFORM = new Item(":martial_arts_uniform:", 3000);

        public static List<IItem> ToList()
        {
            return new List<IItem>() 
            {
                COAT, LAB_COAT, SAFETY_VEST, WOMANS_CLOTHES,
                SHIRT, NECKTIE, DRESS, BIKINI, ONE_PIECE_SWIMSUIT,
                KIMONO, SARI, RUNNING_SHIRT_WITH_SASH, MARTIAL_ARTS_UNIFORM
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
