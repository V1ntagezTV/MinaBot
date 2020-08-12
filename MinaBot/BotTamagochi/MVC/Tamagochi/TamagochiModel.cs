using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.BotTamagochi.MVC.Tamagochi;
using MinaBot.BotTamagochi.MVC.Tamagochi.Characteristics;
using MinaBot.Main;
using System;

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
        public int HatID { get; set; }
        public Item Hat 
        { 
            get
            {
                return ItemMocks.AllItems[HatID];
            }
        }
        public int JacketID { get; set; }
        public Item Jacket
        {
            get
            {
                return ItemMocks.AllItems[JacketID];
            }
        }
        public int PantsID { get; set; }
        public Item Pants
        {
            get
            {
                return ItemMocks.AllItems[PantsID];
            }
        }
        public int BootsID { get; set; }
        public Item Boots
        {
            get
            {
                return ItemMocks.AllItems[BootsID];
            }
        }
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
