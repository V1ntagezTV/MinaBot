using System;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics
{
    public class Health : ACharacteristic
    {
        public int ID { get; set; }
        public int TamagochiModelId { get; set; }
        private double score { get; set; }
        public double Score
        {
            get => Math.Round(score, 1);
            set => score = Math.Max(value, 0);
        }
        public Health()
        {
            this.Score = 100;
            LastConsume = DateTime.Now;
        }
        public override double MinusEveryMinute => 1;
        public override DateTime LastConsume { get; set; }
    }
}
