using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Thirsty : ACharacteristic
    {
        public Thirsty(DateTime now): base(now) { }
        public override TimeSpan MinusTimeCycle => new TimeSpan(1, 0, 0);
        public override int MinusValueInCycle => 10;
        public override int MainPoints { get; set; } = 100;
        public override DateTime LastConsume { get; set; }
    }
}
