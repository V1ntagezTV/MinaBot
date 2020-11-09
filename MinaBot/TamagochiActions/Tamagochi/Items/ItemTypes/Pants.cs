using System.Collections.Generic;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Pants : Item
    {
        public static Pants[] GetAll { get; private set; }
        
        public Pants(string name, int price, ERarity rarity) : base(name, price, rarity)
        {
            GetAll = GetItemList();
        }

        private static Pants[] GetItemList()
        {
            return new Pants[]
            {
                new Pants(":briefs:", 300, ERarity.Common),
                new Pants(":shorts:", 1000, ERarity.Common),
                new Pants(":jeans:", 2000, ERarity.Rare)
            };
        }
    }
}