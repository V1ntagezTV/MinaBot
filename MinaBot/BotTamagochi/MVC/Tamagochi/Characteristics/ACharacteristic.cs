using System;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    abstract class ACharacteristic
    {
        public abstract double MinusEveryMinute { get; }
        private double score { get; set; }
        public double Score 
        { 
            get => Math.Round(score, 1);
            set => score = Math.Max(value, 0); 
        }
        public abstract DateTime LastConsume { get; set; }
    }
}
