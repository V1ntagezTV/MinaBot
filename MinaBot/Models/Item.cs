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
            this.name = name;

        }

        string name;
        int price;
        int soldPrice;
        
        string IItem.Name { get => name; set => name = value; }
        int IItem.Price { get => price; set => price = value; }
        int IItem.SoldPrice { get => soldPrice; set => soldPrice = value / 100 * 75; }
    }
}
