using MinaBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class Item: IItem
    {
        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
            this.SoldPrice = price / 100 * 75;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int SoldPrice { get; set; }
    }
}
