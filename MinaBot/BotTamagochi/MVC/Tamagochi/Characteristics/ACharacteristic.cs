using System;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    abstract class ACharacteristic
    {
        public abstract int MinusValueInCycle { get; }
        public abstract int MainPoints { get; set; }
        public abstract DateTime LastConsume { get; set; }

        public ACharacteristic(DateTime createTime)
        {
            LastConsume = createTime;
        }
    }
}
