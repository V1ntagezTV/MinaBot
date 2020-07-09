using Microsoft.VisualBasic;
using MinaBot.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinaBot.Models
{
    public class Backpack
    {
        uint places;
        List<IItem> inventory;

        public Backpack(uint places)
        {
            this.places = places;
            this.inventory = new List<IItem>((int)places);
        }

        public void Add(IItem item) => inventory.Add(item);
        public void Remove(IItem item) => inventory.Remove(item);

        public override string ToString()
        {
            string result = "";
            for (int ind=0; ind < inventory.Count(); ind++)
            {
                result += inventory[ind];
                if (ind % 10 == 10)
                    result += '\n';
            }
            return result;
        }
    }
}
