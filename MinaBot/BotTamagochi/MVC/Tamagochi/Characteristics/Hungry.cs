﻿using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Hungry: ACharacteristic
    {
        public Hungry()
        {
            LastConsume = DateTime.Now;
        }
        private int mainPoints = 100;
        public override int MainPoints
        {
            get => mainPoints;
            set => mainPoints = value > 0 ? value : 0;
        }
        public override int MinusValueInCycle => 10;
        public override DateTime LastConsume { get; set; }
    }
}
