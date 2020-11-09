using System;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Boots : Item
    {
        public static Boots[] GetAll { get; private set; }

        public Boots(string name, int price, ERarity rarity) : base(name, price, rarity)
        {
            GetAll = BootsList();
        }
        
        private static Boots[] BootsList()
        {
            return new Boots[]
            {
                new Boots(":socks:", 50, ERarity.Common),
                new Boots(":ice_skate:", 2000, ERarity.Rare),
                new Boots(":womans_flat_shoe:", 1000, ERarity.Common),
                new Boots(":high_heel:", 10000, ERarity.Legendary),
                new Boots(":sandal:", 1500, ERarity.Common),
                new Boots(":boot:", 3000, ERarity.Rare),
                new Boots(":ballet_shoes:", 2000, ERarity.Legendary),
                new Boots(":mans_shoe:", 1400, ERarity.Rare),
                new Boots(":athletic_shoe:", 5000, ERarity.Rare),
                new Boots(":hiking_boot:", 5000, ERarity.Rare),
            };
        }
    }
}