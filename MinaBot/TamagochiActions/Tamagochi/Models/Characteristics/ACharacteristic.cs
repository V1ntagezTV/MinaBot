﻿using System;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    public abstract class ACharacteristic
    {
        public abstract double MinusEveryMinute { get; }
        public abstract DateTime LastConsume { get; set; }
    }
}
