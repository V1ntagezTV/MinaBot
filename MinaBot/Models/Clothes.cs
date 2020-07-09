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
            hat = EBotHats.CLEAR;
            boots = EBotBoots.CLEAR;
            jacket = EBotJackets.CLEAR;
            pants = EbotPants.CLEAR;

        }

        public IItem hat;
        public IItem jacket;
        public IItem pants;
        public IItem boots;

        public IItem Hat { get => hat; set => hat = value; }
        public IItem Jacket { get => jacket; set => jacket = value; }
        public IItem Pants { get => pants; set => pants = value; }
        public IItem Boots { get => boots; set => boots = value; }
    }
}
