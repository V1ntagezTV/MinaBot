using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Interfaces
{
    public interface IItem
    {
        abstract public string Name { get; set; }
        abstract public int Price { get; set; }
        abstract public int SoldPrice { get; set; }
    }
}
