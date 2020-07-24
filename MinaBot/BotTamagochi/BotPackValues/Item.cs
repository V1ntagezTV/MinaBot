using Discord.Commands;

namespace MinaBot.Models
{
    class Item
    {
        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
            this.SoldPrice = price / 100 * 75;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int SoldPrice { get; set; }
        public bool Equiped { get; set; } = false;
        public override string ToString() => Name;
        
        public class Food: Item
        {
            public int Satiety { get; private set; }
            public Food(string name, int price, int satiety) : base(name, price)
            {
                Satiety = satiety;
            }
        }
    }
}
