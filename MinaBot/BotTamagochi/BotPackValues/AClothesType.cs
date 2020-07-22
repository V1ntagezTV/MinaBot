using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.BotPackValues
{
    abstract class AClothesType
    {
        public class Hat : Item
        {
            public Hat(string name, int price) : base(name, price) { }
        }

        public class Boots : Item
        {
            public Boots(string name, int price) : base(name, price) { }
        }

        public class Jacket : Item
        {
            public Jacket(string name, int price) : base(name, price) { }
        }

        public class Pants : Item
        {
            public Pants(string name, int price) : base(name, price) { }
        }


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
                result += (ind + 1) + " " + AllClothes()[ind].Name + "\n";
            }
            return result;
        }
        public string ToStringPricesInLine()
        {
            string result = "";
            for (int ind = 0; ind < AllClothes().Count; ind++)
            {
                result += AllClothes()[ind].Price + "\n";
            }
            return result;
        }
    }
}
