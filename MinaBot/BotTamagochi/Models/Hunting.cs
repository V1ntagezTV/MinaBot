﻿using MinaBot.BotTamagochi.ItemsPack;
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
            for (int itemInd = 0; itemInd < MAXITEMCOUNT; itemInd++)
            {
                var item = ItemMocks.AllItems.GetRandomItemWithChance();
                if (item.ID == 0) { continue; } // You get nothing.
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