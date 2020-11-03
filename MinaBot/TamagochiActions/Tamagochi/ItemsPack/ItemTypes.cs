using MinaBot.Models;

namespace MinaBot.BotTamagochi.BotPackValues
{
    sealed class ItemTypes
    {
        public class Hat : Item
        {
            public Hat(string name, int price, ERarity rarity) : base(name, price, rarity) { }
        }

        public class Boots : Item
        {
            public Boots(string name, int price, ERarity rarity) : base(name, price, rarity) { }
        }

        public class Jacket : Item
        {
            public Jacket(string name, int price, ERarity rarity) : base(name, price, rarity) { }
        }

        public class Pants : Item
        {
            public Pants(string name, int price, ERarity rarity) : base(name, price, rarity) { }
        }

        public class Food : Item
        {
            public int Satiety { get; private set; }
            public Food(string name, int price, int satiety, ERarity rarity) : base(name, price, rarity)
            {
                Satiety = satiety;
            }
        }
    }
}
