﻿using MinaBot.BotPackValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class Clothes
    {
        public Clothes()
        {
            Hat = EBotHats.CLEAR;
            Boots = EBotBoots.CLEAR;
            Jacket = EBotJackets.CLEAR;
            Pants = EBotPants.CLEAR;
        }

        public Item Hat { get; set; }
        public Item Jacket { get; set; }
        public Item Pants { get; set; }
        public Item Boots { get; set; }
    }
}
