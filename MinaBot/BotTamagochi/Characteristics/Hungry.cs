using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Hungry: ACharacteristic
    {
        public int ID { get; set; }
        private double score { get; set; }
        public double Score
        {
            get => Math.Round(score, 1);
            set => score = Math.Max(value, 0);
        }
        public Hungry()
        {
            this.Score = 100;
            LastConsume = DateTime.Now;
        }
        public override double MinusEveryMinute => 0.4;
        public override DateTime LastConsume { get; set; }

    }
}
