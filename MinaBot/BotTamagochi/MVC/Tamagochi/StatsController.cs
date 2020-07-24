using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using System;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi
{
    class StatsController
    {
        public int HP = 100;
        private DateTime lastCheckDate = DateTime.Now;
        public Hungry hungry = new Hungry(DateTime.Now);
        public Thirsty thirsty = new Thirsty(DateTime.Now);
        public TimeSpan MinusTimeCycle { get; } = new TimeSpan(0, 0, 5);

        public virtual bool Consume(Food food)
        {
            var calledTime = DateTime.Now;
            UpdateStats(calledTime);
            if (HP > 0)
            {

                return true;
            }
            return false;
        }

        public string UpdateStats(DateTime updateTime)
        {
            var lastTime = lastCheckDate;
            while (HP > 0)
            {
                if (HP <= 0) break;
                lastTime += MinusTimeCycle;
                if (lastTime > updateTime)
                {
                    lastCheckDate = updateTime;
                    break;
                }
                else
                {
                    hungry.MainPoints -= hungry.MinusValueInCycle;
                    thirsty.MainPoints -= hungry.MinusValueInCycle;
                    if (hungry.MainPoints + thirsty.MainPoints < 40)
                        HP -= 20;
                }
            }
            if (HP > 0)
            {
                return $"ЖИВ ЦЕЛ hg: {hungry.MainPoints}, th: {thirsty.MainPoints}, hp: {HP}";
            }
            return $"поминки: hg: {hungry.MainPoints}, th: {thirsty.MainPoints}, hp: {HP}";
        }
    }
}
