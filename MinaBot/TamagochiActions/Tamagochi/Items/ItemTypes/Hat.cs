using System.Collections.Generic;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Hat : Item
    {
        public static Hat[] GetAll { get; private set; }

        public Hat(string name, int price, ERarity rarity) : base(name, price, rarity)
        {
            GetAll = HatsList();
        }

        private static Hat[] HatsList()
        {
            return new Hat[]
            {
                new Hat(":womans_hat:", 1000, ERarity.Legendary),
                new Hat(":tophat:", 3000, ERarity.Common),
                new Hat(":billed_cap:", 1500, ERarity.Common),
                new Hat(":mortar_board:", 1000, ERarity.Rare),
                new Hat(":helmet_with_cross:", 3000, ERarity.Legendary),
                new Hat(":crown:", 5000, ERarity.Immortal)
            };
        }
    }
}