﻿using MinaBot.BotTamagochi.BotPackValues;
using System.Collections.Generic;
using System.Linq;

namespace MinaBot.Models
{
    class Backpack: AItemCollections
    {
        public int Lenght { get; }
        List<Item> inventory;

        public Backpack(int places)
        {
            this.Lenght = places;
            this.inventory = new List<Item>((int)places);
        }
        public void Add(Item item) => inventory.Add(item);
        public bool Remove(Item item) => inventory.Remove(item);
        public bool Remove(int ind) => inventory.Remove(inventory[ind]);
        public override List<Item> AllItems() => inventory;
        public override string ToString()
        {
            if (base.ToString() == "") return "Backpack is empty.";
            return base.ToString();
        }
    }
}
