using MinaBot.BotPackValues;
using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi
{
    class Hunting
    {
        public int ID { get; set; }
        public DateTime SavedSendTime { get; set; }
        public TimeSpan SendTimeLength { get; set; }
        public List<Item> WaitingItems { get; private set; }

        public void SendToHunting(TimeSpan timeLength)
        {
            SendTimeLength = timeLength;
            SavedSendTime = DateTime.Now;
            WaitingItems = FindItems();
        }
        private List<Item> FindItems()
        {
            const int MAXITEMCOUNT = 4;
            const int ITEMTYPESCOUNT = 6; // BOOTS, FOODS, HATS, JACKETS, PANTS, BACKPACK
            List<Item> resultItemList = new List<Item>(MAXITEMCOUNT);
            var random = new Random();
            var currentItemCount = random.Next(0, MAXITEMCOUNT);
            for (int itemInd = 0; itemInd < currentItemCount; itemInd++)
            {
                var itemTypeRnd = random.Next(0, ITEMTYPESCOUNT);
                Item rndItem = itemTypeRnd switch
                {
                    0 => new EBotBoots().GetRandomItemWithChance(),
                    1 => new EBotFoods().GetRandomItemWithChance(),
                    2 => new EBotHats().GetRandomItemWithChance(),
                    3 => new EBotJackets().GetRandomItemWithChance(),
                    4 => new EBotPants().GetRandomItemWithChance(),
                    5 => new EBotPants().GetRandomItemWithChance(),
                    //5 => throw new Exception("need create backpack class!"),
                    _ => Item.defaultCleanItem,
                };
                if (rndItem != Item.defaultCleanItem)
                {
                    resultItemList.Add(rndItem);
                }
            }
            return resultItemList;
        }
    }
}