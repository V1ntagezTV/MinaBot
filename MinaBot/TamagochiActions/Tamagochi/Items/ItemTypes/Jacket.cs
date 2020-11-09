using System.Collections.Generic;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Jacket : Item
    {
        public static Jacket[] GetAll { get; private set; }

        public Jacket(string name, int price, ERarity rarity) : base(name, price, rarity)
        {
            GetAll = JacketsList();
        }

        private static Jacket[] JacketsList()
        {
            return new Jacket[]
            {
                new Jacket(":coat:", 4000, ERarity.Common),
                new Jacket(":lab_coat:", 1500, ERarity.Rare),
                new Jacket(":safety_vest:", 4000, ERarity.Rare),
                new Jacket(":womans_clothes:", 2500, ERarity.Common),
                new Jacket(":shirt:", 1000, ERarity.Common),
                new Jacket(":necktie:", 2000, ERarity.Legendary),
                new Jacket(":dress:", 7000, ERarity.Immortal),
                new Jacket(":bikini:", 3000, ERarity.Legendary),
                new Jacket(":one_piece_swimsuit:", 3000, ERarity.Rare),
                new Jacket(":kimono:", 2000, ERarity.Legendary),
                new Jacket(":sari:", 5000, ERarity.Rare),
                new Jacket(":running_shirt_with_sash:", 1200, ERarity.Common),
                new Jacket(":martial_arts_uniform:", 3000, ERarity.Immortal),
            };
        }
    }
}