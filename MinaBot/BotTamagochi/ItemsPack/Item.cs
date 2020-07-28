using Discord.Commands;

namespace MinaBot.Models
{
    abstract class Item
    {
        public Item(string name, int price, int dropChance = 0)
        {
            this.Name = name;
            this.Price = price;
            this.SoldPrice = price / 100 * 75;
            this.DropChance = dropChance;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int SoldPrice { get; set; }
        /**
         * Drop chance in %.
         * Example: if generated random was bigger then drop chance you didn't get this item. 
         **/
        public int DropChance { get; set; }
        public bool Equiped { get; set; } = false;
        public override string ToString() => Name;
    }
}
