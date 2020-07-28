using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.BotTamagochi.MVC.Tamagochi
{
    class Hunting
    {
        public DateTime savedSendTime { get; set; }
        public TimeSpan sendTimeLength { get; set; }

        public List<Item> sendToHunting(TimeSpan timeLength)
        {
            sendTimeLength = timeLength;
            savedSendTime = DateTime.Now;
            return findItems();
        }
        private List<Item> findItems()
        {
            int itemCount = new Random().Next(0, 4);
            int itemTypeCount = 6;
            var result = new List<Item>(itemCount);
            for (int ind = 0; ind < itemCount; ind++)
            {
                int itemTypeChance = new Random().Next(0, 100);
                if (itemTypeChance < 20)
                {
                    //food
                }
                else if (itemTypeChance < 40)
                {
                    //boots
                }
                else if (itemTypeChance < 50)
                {
                    //pants
                }
                else if (itemTypeChance < 60)
                {
                    //jacket
                }
                else if (itemTypeChance < 70)
                {
                    //hat
                }
                else if (itemTypeChance < 50)
                {
                    //backpack
                }
            }
            return result;
        }
    }
}