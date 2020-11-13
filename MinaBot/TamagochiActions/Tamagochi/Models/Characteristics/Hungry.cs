using MinaBot.Models;
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
                score = Math.Max(value, 0);
                score = Math.Min(value, 100);
            }
        }
        public override double MinusEveryMinute => 0.4;
        public override DateTime LastConsume { get; set; }

    }
}
