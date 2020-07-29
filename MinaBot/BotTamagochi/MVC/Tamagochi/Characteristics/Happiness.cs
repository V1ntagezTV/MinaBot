﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Happiness : ACharacteristic
    {
        public Happiness() 
        {
            this.MainPoints = 100;
        }
        public override double MinusEveryMinute => 0.3;
        public override DateTime LastConsume { get; set; } = DateTime.Now;
    }
}
