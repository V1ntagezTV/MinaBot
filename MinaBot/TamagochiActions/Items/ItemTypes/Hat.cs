using System.Collections.Generic;
using System.Linq;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Hat : Item
    {
        public Hat(string name, int price, ERarity rarity) : base(name, price, rarity) { }
    }
}