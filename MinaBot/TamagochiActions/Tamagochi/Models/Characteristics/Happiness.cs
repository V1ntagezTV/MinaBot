using System;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    public class Happiness : ACharacteristic
    {
        public int ID { get; set; }
        public int TamagochiModelId { get; set; }
        private double score { get; set; }
        public double Score
        {
            get => Math.Round(score, 1);
            set
            {
                score = Math.Max(value, 0);
                score = Math.Min(value, 100);
            }
        }

        public Happiness() 
        {
            this.Score = 100;
            LastConsume = DateTime.Now;
        }
        public override double MinusEveryMinute => 0.3;
        public override DateTime LastConsume { get; set; }
    }
}
