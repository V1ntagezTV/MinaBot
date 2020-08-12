using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Models;
using System;
using System.Collections.Generic;

namespace MinaBot.BotTamagochi.MVC.Tamagochi
{
    class Hunting
    {
        public int ID { get; set; }
        public DateTime SavedSendTime { get; set; }
        public TimeSpan SendTimeLength { get; set; }
        public List<Item> WaitingItems { get; private set; } = new List<Item>();

        public void SendToHunting(TimeSpan timeLength)
        {
            SendTimeLength = timeLength;
            SavedSendTime = DateTime.Now;
            WaitingItems = FindItems();
        }
        private List<Item> FindItems()
        {
            const int MAXITEMCOUNT = 4;
            List<Item> resultItemList = new List<Item>(MAXITEMCOUNT);
            var random = new Random();
            var currentItemCount = random.Next(0, MAXITEMCOUNT);
            for (int itemInd = 0; itemInd < currentItemCount; itemInd++)
            {
                var item = ItemMocks.AllItems.GetRandomItemWithChance();
                resultItemList.Add(item);
            }
            return resultItemList;
        }
    }
}