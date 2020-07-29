using System;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    abstract class ACharacteristic
    {
        public abstract double MinusEveryMinute { get; }
        private double mainPoints { get; set; }
        public double MainPoints 
        { 
            get => Math.Round(mainPoints, 1);
            set => mainPoints = Math.Max(value, 0); 
        }
        public abstract DateTime LastConsume { get; set; }
    }
}
