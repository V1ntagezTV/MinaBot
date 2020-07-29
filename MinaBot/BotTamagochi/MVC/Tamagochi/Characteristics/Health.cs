using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Health : ACharacteristic
    {
        public Health()
        {
            this.MainPoints = 100;
        }
        public override double MinusEveryMinute => 1;
        public override DateTime LastConsume { get; set; } = DateTime.Now;
    }
}
