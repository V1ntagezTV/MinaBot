using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Models;
using System;

namespace MinaBot.Controllers
{
    class ShopController
    {
        ShopModel shop = new ShopModel();
        TamagochiModel tamagochi;

        AuthorModel model;
        public ShopController(AuthorModel model)
        {
            this.model = model;
        }

        public string GetTitle() => shop.Title;
        public string GetDescription() => shop.Description;
        public bool BuyItem(string itemType, int number)
        {

            Item item;
            switch (itemType)
            {
                case "hats":
                case "h":
                    item = ItemMocks.HatsCollection()[number];
                    break;
                case "jacket":
                case "j":
                    item = ItemMocks.JacketsCollection()[number];
                    break;
                case "boots":
                case "b":
                    item = ItemMocks.BootsCollection()[number];
                    break;
                case "pants":
                case "p":
                    item = ItemMocks.PantsCollection()[number];
                    break;
                default:
                    throw new ArgumentException();
            }
            if (tamagochi.Money - item.Price > 0)
            {
                tamagochi.Backpack.Add(item);
                tamagochi.Money -= item.Price;
                return true;
            }
            return false;

        }
    }

    public class AuthorModel
    {
    }
}
