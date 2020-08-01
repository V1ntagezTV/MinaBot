using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Main;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinaBot.Models
{
    class TamagochiModel: IModel
    {
        public TamagochiModel()
        {
            Name = "#Tamagochi";
            Level = 1;
            AvatarURL = @"https://i.pinimg.com/736x/16/f9/60/16f960c5ba68b8f0b88f1c571e8bf9ce--kim-taehyung-twice-cute.jpg";
            Money = 150;
            currentStatus = "Hi!";
            ToUpLevelScore = 100;
            Clothes = new Clothes();
            Birthday = DateTime.Now;
            Backpack = new Backpack();
            LastCheckDate = DateTime.Now;
            Health = new Health();
            Thirsty = new Thirsty();
            Hungry = new Hungry();
            Happiness = new Happiness();
            Hunting = new Hunting();
        }
        public int ID { get; set; }
        public ulong DiscordId { get; set; }
        public string Name { get; set; }
        public string AvatarURL { get; set; }
        public string Color { get; set; }
        public uint Level { get; set; }
        private string currentStatus;
        public string CurrentStatus { 
            get => currentStatus;
            set {
                LastStatus = currentStatus;
                currentStatus = value;
            }  
        }
        public string LastStatus { get; private set; }
        public int Money { get; set; }
        public uint ToUpLevelScore { get; set; }
        public int AgeDays { get => (DateTime.Now - Birthday).Days + 1; }
        public Clothes Clothes { get; set; }
        public Backpack Backpack { get; set; }
        public DateTime Birthday { get; set; }
        // STATS
        public DateTime LastCheckDate { get; set; }
        public Health Health { get; private set; }
        public Hungry Hungry { get; private set; }
        public Thirsty Thirsty { get; private set; }
        public Happiness Happiness { get; private set; }
        public Hunting Hunting { get; set; }
    }
}
