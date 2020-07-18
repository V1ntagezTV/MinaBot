using MinaBot.BotPackValues;
using MinaBot.Models;
using System;

namespace MinaBot.Controllers
{
    class ShopController
    {
        ShopModel shop = new ShopModel();
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
                    item = new EBotHats().AllClothes()[number];
                    break;
                case "jacket":
                case "j":
                    item = new EBotBoots().AllClothes()[number];
                    break;
                case "boots":
                case "b":
                    item = new EBotJackets().AllClothes()[number];
                    break;
                case "pants":
                case "p":
                    item = new EBotPants().AllClothes()[number];
                    break;
                default:
                    throw new ArgumentException();
            }
            if (model.GetTamagochi.Money - item.Price > 0)
            {
                model.GetTamagochi.backpack.Add(item);
                model.GetTamagochi.Money -= item.Price;
                return true;
            }
            return false;

        }
    }
}
