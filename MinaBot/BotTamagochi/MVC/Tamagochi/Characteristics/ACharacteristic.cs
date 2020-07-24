using System;
using static MinaBot.Models.Item;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    abstract class ACharacteristic
    {
        public abstract TimeSpan MinusTimeCycle { get; }
        public abstract int MinusValueInCycle { get; }
        public abstract int MainPoints { get; set; }
        public abstract DateTime LastConsume { get; set; }

        public ACharacteristic(DateTime createTime)
        {
            LastConsume = createTime;
        }

        public virtual bool Consume(Food food)
        {
            var calledTime = DateTime.Now;
            UpdateStats(calledTime);
            if (MainPoints > 0)
            {
                MainPoints = Math.Min(food.Satiety, 100);
                LastConsume = calledTime;
                return true;
            }
            return false;
        }

        public virtual void UpdateStats(DateTime nowSavedTime)
        {
            var lastTime = LastConsume;
            while (MainPoints > 0)
            {
                if (MainPoints <= 0) break;
                lastTime += MinusTimeCycle;
                if (lastTime > nowSavedTime)
                {
                    break;
                }
                else
                { 
                    MainPoints -= MinusValueInCycle; 
                }
            }
        }
    }
}
