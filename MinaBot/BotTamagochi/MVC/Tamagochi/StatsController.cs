using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using System;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi
{
    class StatsController
    {
        private DateTime lastCheckDate = DateTime.Now;
        public int HP { get; private set; } = 100;
        public Hungry Hungry = new Hungry(DateTime.Now);
        public Thirsty Thirsty = new Thirsty(DateTime.Now);
        public TimeSpan TickLengthTime { get; } = new TimeSpan(0, 30, 0);

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

        public void UpdateStats(DateTime updateTime)
        {
            var lastTime = lastCheckDate;
            while (HP > 0)
            {
                if (HP <= 0) break;
                lastTime += TickLengthTime;
                if (lastTime > updateTime)
                {
                    lastCheckDate = updateTime;
                    break;
                }
                else
                {
                    Hungry.MainPoints -= Hungry.MinusValueInCycle;
                    Thirsty.MainPoints -= Hungry.MinusValueInCycle;
                    if (Hungry.MainPoints + Thirsty.MainPoints < 40)
                        HP -= 20;
                }
            }
            //if (HP > 0)
            //{
            //    return $"ЖИВ ЦЕЛ hg: {hungry.MainPoints}, th: {thirsty.MainPoints}, hp: {HP}";
            //}
            //return $"поминки: hg: {hungry.MainPoints}, th: {thirsty.MainPoints}, hp: {HP}";
        }
    }
}
