using MinaBot.BotTamagochi.BotPackValues;
using MinaBot.BotTamagochi.ItemsPack;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static MinaBot.BotTamagochi.BotPackValues.ItemTypes;

namespace MinaBot.Models
{
    class Backpack
    {
        public int ID { get; set; }
        public int Lenght { get; set; } = 10;
        public int ItemCount { get; set; } = 0;
        public string itemCollectionStringWithID { get; set; } = "";
        public bool Add(int itemID)
        {
            var idList = itemCollectionStringWithID.Split(",");
            if (idList.Length >= 10) 
            { 
                return false; 
            }
            itemCollectionStringWithID += itemID.ToString() + ",";
            ItemCount++;
            return true;
        }
        public bool Remove(int itemID)
        {
            var idList = itemCollectionStringWithID.Split(",").ToList();
            for (int ind = 0; ind < idList.Count; ind++)
            {
                if (idList[ind] == itemID.ToString())
                {
                    idList.Remove(idList[ind]);
                    ItemCount--;
                    return true;
                }
            }
            return false;
        }   
        public ItemCollection<Item> ItemList 
        {
            get
            {
                var result = new ItemCollection<Item>(new List<Item>());
                var idList = itemCollectionStringWithID.Split(",");
                for (int ind = 0; ind < idList.Length; ind++)
                {
                    var item = ItemMocks.AllItems[Convert.ToInt32(idList[ind])];
                    result.itemList.Add(item);
                }
                return result;
            }
        }
    }
}
