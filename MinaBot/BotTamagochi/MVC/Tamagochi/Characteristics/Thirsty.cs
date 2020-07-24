using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Thirsty : ACharacteristic
    {
        public Thirsty(DateTime now): base(now) { }
        public override int MinusValueInCycle => 10;
        private int mainPoints = 100;
        public override int MainPoints
        {
            get => mainPoints;
            set
            {
                mainPoints = value > 0 ? value : 0;
            }
        }
        public override DateTime LastConsume { get; set; }
    }
}
