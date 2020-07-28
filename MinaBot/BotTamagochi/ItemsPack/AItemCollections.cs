using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.BotPackValues
{
    abstract class AItemCollections
    {
        public class Hat : Item
        {
            public Hat(string name, int price, ERarity rarity) : base(name, price, rarity) { }
        }

        public class Boots : Item
        {
            public Boots(string name, int price, ERarity rarity) : base(name, price, rarity) { }
        }

        public class Jacket : Item
        {
            public Jacket(string name, int price) : base(name, price) { }
        }

        public class Pants : Item
        {
            public Pants(string name, int price) : base(name, price) { }
        }

        public class Food : Item
        {
            public int Satiety { get; private set; }
            public Food(string name, int price, int satiety) : base(name, price)
            {
                Satiety = satiety;
            }
        }
        public Item GetRandomItemWithChance()
        {
            var random = new Random();
            for (int ind = 0; ind < AllItems().Count; ind++)
            {
                if (random.Next(0, 101) <= (int)AllItems()[ind].Rarity)
                {
                    return AllItems()[ind];
                }
            }
            return Item.defaultCleanItem;
        }
        public abstract List<Item> AllItems();

        public override string ToString()
        {
            string result = "";
            for (int ind = 0; ind < AllItems().Count; ind++)
            {
                result += AllItems()[ind].Name + " ";
            }
            return result;
        }

        public string ToStringWithPriceInLine()
        {
            string result = "";
            for (int ind = 0; ind < AllItems().Count; ind++)
            {
                result += AllItems()[ind].Name + " " + AllItems()[ind].Price + "\n";
            }
            return result;
        }

        public string ToStringInLine()
        {
            string result = "";
            for (int ind = 0; ind < AllItems().Count; ind++)
            {
                result += (ind + 1) + " " + AllItems()[ind].Name + "\n";
            }
            return result;
        }
        public string ToStringPricesInLine()
        {
            string result = "";
            for (int ind = 0; ind < AllItems().Count; ind++)
            {
                result += AllItems()[ind].Price + "\n";
            }
            return result;
        }
    }
}
