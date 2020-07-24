using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using System;

namespace MinaBot.BotTamagochi.MVC.Tamagochi
{
    class HealthStats: ACharacteristic
    {
        public int HP = 100;
        private DateTime lastCheckDate = DateTime.Now;
        public Hungry hungry = new Hungry(DateTime.Now);
        public Thirsty thirsty = new Thirsty(DateTime.Now);

        public string UpdateStats(DateTime nowSavedTime)
        {
            var now = DateTime.Now;
            var HungryLastConsume = hungry.LastConsume;
            var ThirstyLastConsume = thirsty.LastConsume;

            var totalMinus = 
        }
    }
}
