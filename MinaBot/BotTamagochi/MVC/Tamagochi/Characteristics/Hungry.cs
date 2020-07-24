using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Hungry: ACharacteristic
    {
        public Hungry(DateTime start) : base(start) { }

        public override TimeSpan MinusTimeCycle { get; } = new TimeSpan(1, 0, 0);
        public override int MinusValueInCycle { get; } = 15;
        public override int MainPoints { get; set; } = 100;
        public override DateTime LastConsume { get; set; }
    }
}
