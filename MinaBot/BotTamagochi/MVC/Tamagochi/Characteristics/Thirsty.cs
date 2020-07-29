using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Thirsty : ACharacteristic
    {
        public Thirsty()
        {
            this.MainPoints = 100;
        }
        public override double MinusEveryMinute => 0.5;
        public override DateTime LastConsume { get; set; } = DateTime.Now;
    }
}
