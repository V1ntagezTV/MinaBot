using System;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    class Health : ACharacteristic
    {
        public int ID { get; set; }
        public Health()
        {
            this.Score = 100;
            LastConsume = DateTime.Now;
        }
        public override double MinusEveryMinute => 1;
        public override DateTime LastConsume { get; set; }
    }
}
