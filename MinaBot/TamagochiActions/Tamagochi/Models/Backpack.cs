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
    public class Backpack
    {
        public const int MAXITEMSCOUNT = 10;
        public int ID { get; set; }
        public int Lenght { get; set; } = 10;
        public int ItemCount { get; set; } = 0;
        public string itemCollectionStringWithID { get; set; } = "";

        public bool isIndexInBackpackRange(int index)
        {
            var itemList = itemCollectionStringWithID.Split(',');
            return index >= 0 && index < itemList.Length;
        }

        public bool Add(string itemID)
        {
            var idList = itemCollectionStringWithID.Split(",");
            if (idList.Length >= MAXITEMSCOUNT) 
            { 
                return false;
            }
            if (itemCollectionStringWithID == "")
            {
                itemCollectionStringWithID += itemID;
                ItemCount++;
                return true;
            }
            itemCollectionStringWithID += "," + itemID;
            ItemCount++;
            return true;
        }
        
        public bool AddIdString(string idString)
        {
            if (idString == "")
            {
                return false;
            }
            var items = idString.Split(',');
            for (int ind = 0; ind < items.Length; ind++)
            {
                if (ItemCount > MAXITEMSCOUNT)
                {
                    return false;
                }
                this.Add(items[ind]);
            }
            return true;
        }

        public bool Remove(int itemID)
        {
            var idList = itemCollectionStringWithID.Split(",").ToList();
            if (idList.Count < itemID || itemCollectionStringWithID == "")
            {
                return false;
            }
            idList.Remove(idList[itemID]);
            itemCollectionStringWithID = string.Join(',', idList);
            ItemCount--;
            return true;
        }

        public bool RemoveRange(int start, int end)
        {
            var idList = itemCollectionStringWithID.Split(",").ToList();
            for ( ; start != end; end--)
            {
                idList.Remove(idList[start]);
                ItemCount--;
            }
            itemCollectionStringWithID = string.Join(',', idList);
            return true;
        }

        public ItemCollection<Item> Items 
        {
            get
            {
                var items = new ItemCollection<Item>(new List<Item>());
                if (itemCollectionStringWithID == "") return items;
                var idList = itemCollectionStringWithID.Split(",");
                for (int ind = 0; ind < idList.Length; ind++)
                {
                    var item = ItemMocks.AllItems[Convert.ToInt32(idList[ind])];
                    items.Data.Add(item);
                }
                return items;
            }
        }
        public override string ToString()
        {
            if (itemCollectionStringWithID == "") 
            {
                return "Пусто!";
            }
            return Items.ToString();
        }
    }
}
