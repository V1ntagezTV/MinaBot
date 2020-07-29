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
        public Hungry()
        {
            this.MainPoints = 100;
        }
        public override double MinusEveryMinute => 0.4;
        public override DateTime LastConsume { get; set; } = DateTime.Now;

    }
}
