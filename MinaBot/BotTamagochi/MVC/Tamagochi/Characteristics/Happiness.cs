using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Happiness : ACharacteristic
    {
        private int mainPoints = 100;
        public Happiness() 
        {
            LastConsume = DateTime.Now;
        }
        public override int MinusValueInCycle => 3;
        public override int MainPoints 
        {
            get => mainPoints; 
            set => mainPoints = value > 0 ? value : 0;
        }
        public override DateTime LastConsume { get; set; }
    }
}
