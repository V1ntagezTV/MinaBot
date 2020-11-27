﻿using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    public class Hungry: ACharacteristic
    {
        public Hungry()
        {
            this.Score = 100;
            LastConsume = DateTime.Now;
        }
        public int ID { get; set; }
        private double score { get; set; }
        public double Score
        {
            get => Math.Round(score, 1);
            set
            {
                if (value <= 0)
                {
                    score = 0;
                } 
                else if (value >= 100)
                {
                    score = 100;
                }
                else
                {
                    score = value;
                }
            }
        }
        public override double MinusEveryMinute => 0.05;
        public override DateTime LastConsume { get; set; }

    }
}
