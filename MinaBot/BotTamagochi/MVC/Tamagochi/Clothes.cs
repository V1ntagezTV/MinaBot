using MinaBot.BotPackValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class Clothes
    {
        public Clothes()
        {
            Hat = Item.defaultCleanItem;
            Boots = Item.defaultCleanItem;
            Jacket = Item.defaultCleanItem;
            Pants = Item.defaultCleanItem;
        }

        public Item Hat { get; set; }
        public Item Jacket { get; set; }
        public Item Pants { get; set; }
        public Item Boots { get; set; }
        public override string ToString()
        {
            return Hat.ToString() + "\n" + Jacket.ToString() + "\n" +
                Pants.ToString() + "\n" + Boots.ToString();
        }
    }
}
