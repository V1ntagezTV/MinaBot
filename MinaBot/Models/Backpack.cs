using MinaBot.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Models
{
    class Backpack
    {
        public Backpack(uint places)
        {
            this.places = places;
            this.inventory = new List<IItem>((int)places);
        }
        uint places;
        List<IItem> inventory;

        public void Add(IItem item)
        {
            inventory.Add(item);
        }

        public void Remove(IItem item)
        {
            inventory.Remove(item);
        }
    }
}
