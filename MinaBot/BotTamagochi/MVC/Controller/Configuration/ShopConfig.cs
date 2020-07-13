using MinaBot.BotTamagochi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Controller.Configuration
{
    class ShopConfig: IConfiguration
    {

        string[] priceInView = { "price", "p", "prices" };
        string[] soldPriceInView = { "s", "sold" };
        string[] hat = { "hat", "h", "hats"};
        string[] boot = { "boot", "b", "boots" };
        string[] jacket = { "jacket", "j", "jackets" };
        string[] pants = { "pants", "p" };
        string[] concateUses = { "sp" };

        public bool Contains(string name)
        {
            string[][] all = { priceInView, soldPriceInView, hat, boot, jacket, pants, concateUses };
            for (int ind = 0; ind < all.Length; ind++ )
            {
                if (all[ind].Contains(name))
                    return true;
            }
            return false;
        }
    }
}
