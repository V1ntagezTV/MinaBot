using System.Collections.Generic;
using System.Linq;
using MinaBot.Models;

namespace MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes
{
    public class Meal : Item
    {
        public int Satiety { get; private set; }
        public Meal(string name, int price, int satiety, ERarity rarity) : base(name, price, rarity)
        {
            Satiety = satiety;
        }
    }
}