﻿namespace MinaBot.Models
{
    enum ERarity
    {
        Common = 50,
        Rare = 25,
        Legendary = 5,
        Immortal = 1
    }
    class Item
    {
        private static int itemCounter = -1;
        public Item(string name, int price, ERarity rarity = ERarity.Common)
        {
            this.ID = itemCounter;
            itemCounter++;
            this.Name = name;
            this.Price = price;
            this.SoldPrice = price / 100 * 75;
            this.Rarity = rarity;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int SoldPrice { get; set; }
        /*
         * Drop chance in %.
         * Example: if generated random was bigger then drop chance you didn't get this item. 
         */
        public ERarity Rarity { get; set; }
        public override string ToString() => Name;
    }
}
