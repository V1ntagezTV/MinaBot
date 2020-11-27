﻿using System;

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
                if (value <= 0)
                {
                    score = 0;
                } 
                else if (value >= 100)
                {
                    score = 100;
                }
                else
                {
                    score = value;
                }
            }
        }

        public Happiness() 
        {
            this.Score = 100;
            LastConsume = DateTime.Now;
        }
        public override double MinusEveryMinute => 0.1;
        public override DateTime LastConsume { get; set; }
    }
}
