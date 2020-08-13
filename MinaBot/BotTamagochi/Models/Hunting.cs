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
        public string WaitingItems { get; private set; } = "";

        public void SendToHunting(TimeSpan timeLength)
        {
            SendTimeLength = timeLength;
            SavedSendTime = DateTime.Now;
            WaitingItems = FindItems();
        }
        private string FindItems()
        {
            const int MAXITEMCOUNT = 4;
            string resultItemList = "";
            var random = new Random();
            var currentItemCount = random.Next(0, MAXITEMCOUNT);
            for (int itemInd = 0; itemInd < currentItemCount; itemInd++)
            {
                var item = ItemMocks.AllItems.GetRandomItemWithChance();
                if (resultItemList == "")
                {
                    resultItemList += item.ID;
                    continue;
                }
                resultItemList += "," + item.ID;
            }
            return resultItemList;
        }
    }
}