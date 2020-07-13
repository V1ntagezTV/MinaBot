using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class ShopModel
    {
        static class ShopInfoModel
        {
            static string Title = "Mina's shop info view.";
            static string Description = "Use commands for";
        }

        public string Title = "Mina's Shop!";
        public string Description = "`Use commands for buy items.\n" +
            "-buy {itemType} {item index}\n" +
            "-sell {itemType} {item index}\n`";
    }
}
