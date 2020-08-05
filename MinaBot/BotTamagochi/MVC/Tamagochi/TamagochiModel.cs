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
        public int ID { get; set; }
        public ulong DiscordId { get; set; }
        public string Name { get; set; }
        public string AvatarURL { get; set; }
        public string Color { get; set; }
        public uint Level { get; set; }
        public string currentStatus;
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
        public Health Health { get; set; }
        public Hungry Hungry { get; set; }
        public Thirsty Thirsty { get; set; }
        public Happiness Happiness { get; set; }
        public Hunting Hunting { get; set; }
    }
}
