using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.BotPackValues
{
    abstract class AClothesType
    {
        public abstract List<Item> AllClothes();
        public override string ToString()
        {
            string result = "";
            for (int ind = 0; ind < AllClothes().Count; ind++)
            {
                result += AllClothes()[ind].Name + " ";
            }
            return result;
        }

        public string ToStringWithPriceInLine()
        {
            string result = "";
            for (int ind = 0; ind < AllClothes().Count; ind++)
            {
                result += AllClothes()[ind].Name + " " + AllClothes()[ind].Price + "\n";
            }
            return result;
        }

        public string ToStringInLine()
        {
            string result = "";
            for (int ind = 0; ind < AllClothes().Count; ind++)
            {
                result += AllClothes()[ind].Name + "\n";
            }
            return result;
        }
    }
}
