namespace MinaBot.Models
{
    public enum ERarity
    {
        Common = 50,
        Rare = 25,
        Legendary = 5,
        Immortal = 1
    }

    public class Item
    {
        public Item(string name, int price, ERarity rarity = ERarity.Common)
        {
            this.Name = name;
            this.Price = price;
            this.Rarity = rarity;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int SoldPrice => (int)((double)Price / 100 * 75);
        /*
         * Drop chance in %.
         * Example: if generated random was bigger then drop chance you didn't get this item. 
         */
        public ERarity Rarity { get; set; }
        public override string ToString() => Name;
    }
}
