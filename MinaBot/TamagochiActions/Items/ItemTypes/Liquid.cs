﻿using System.Linq;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Liquid : Item
    {
        public int Satiety { get; private set; }

        public Liquid(string name, int price, int satiety, ERarity rarity) : base(name, price, rarity)
        {
            Satiety = satiety;
        }
    }
}