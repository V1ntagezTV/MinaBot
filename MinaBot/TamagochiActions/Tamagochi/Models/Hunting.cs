using MinaBot.BotTamagochi.ItemsPack;
using System;

namespace MinaBot.BotTamagochi.MVC.Tamagochi
{
    public class Hunting
    {
        public int ID { get; set; }
        public int TamagochiModelID { get; set; }
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
                if (item.Id == 0) { continue; } // You get nothing.
                if (resultItemList == "")
                {
                    resultItemList += item.Id;
                    continue;
                }
                resultItemList += "," + item.Id;
            }
            return resultItemList;
        }
    }
}