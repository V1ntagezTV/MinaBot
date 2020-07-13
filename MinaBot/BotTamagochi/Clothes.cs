using MinaBot.BotPackValues;
using MinaBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    public class Clothes
    {
        public Clothes()
        {
            Hat = EBotHats.CLEAR;
            Boots = EBotBoots.CLEAR;
            Jacket = EBotJackets.CLEAR;
            Pants = EBotPants.CLEAR;
        }

        public IItem Hat { get; set; }
        public IItem Jacket { get; set; }
        public IItem Pants { get; set; }
        public IItem Boots { get; set; }
    }
}
