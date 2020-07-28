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
                    item = new EBotHats().AllItems()[number];
                    break;
                case "jacket":
                case "j":
                    item = new EBotBoots().AllItems()[number];
                    break;
                case "boots":
                case "b":
                    item = new EBotJackets().AllItems()[number];
                    break;
                case "pants":
                case "p":
                    item = new EBotPants().AllItems()[number];
                    break;
                default:
                    throw new ArgumentException();
            }
            if (model.GetTamagochi.Money - item.Price > 0)
            {
                model.GetTamagochi.Backpack.Add(item);
                model.GetTamagochi.Money -= item.Price;
                return true;
            }
            return false;

        }
    }
}
