using Discord;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Main;
using System;

namespace MinaBot.Models
{
    class TamagochiModel: IModel
    {
        public string Name { get; private set; } = "Myoui Mina";
        public string AvatarURL = @"https://i.pinimg.com/736x/16/f9/60/16f960c5ba68b8f0b88f1c571e8bf9ce--kim-taehyung-twice-cute.jpg";
        public Color Color = Color.DarkRed;
        public uint Level = 1;
        private string currentStatus = "Hello world!";
        public string CurrentStatus { 
            get => currentStatus;
            set {
                LastStatus = currentStatus;
                currentStatus = value;
            }  
        }
        public string LastStatus { get; private set; }
        public int Money = 200000;
        public uint ToUpLevelScore = 100;
        public int AgeDays { get => (DateTime.Now - Birthday).Days + 1; }
        public Clothes Clothes = new Clothes();
        public Backpack Backpack = new Backpack(10);
        public DateTime Birthday { get; } = DateTime.Now;

        // STATS
        public DateTime LastCheckDate = DateTime.Now;
        public TimeSpan TickLengthTime { get; private set; } = new TimeSpan(0, 30, 0);
        public int HP { get; set; } = 100;
        public Hungry Hungry { get; private set; } = new Hungry();
        public Thirsty Thirsty { get; private set; } = new Thirsty();
        public Happiness Happiness { get; private set; } = new Happiness();
        // HUNTING
        public Hunting Hunting { get; set; } = new Hunting();
    }
}
