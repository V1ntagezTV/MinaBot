using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Thirsty : ACharacteristic
    {
        public int ID { get; set; }
        private double score { get; set; }
        public double Score
        {
            get => Math.Round(score, 1);
            set => score = Math.Max(value, 0);
        }
        public Thirsty()
        {
            this.Score = 100;
            LastConsume = DateTime.Now;
        }
        public override double MinusEveryMinute => 0.5;
        public override DateTime LastConsume { get; set; }
    }
}
