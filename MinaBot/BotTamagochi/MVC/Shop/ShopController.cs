using MinaBot.BotPackValues;
using MinaBot.Models;
using System;

namespace MinaBot.Controllers
{
    class ShopController
    {
        public ShopController(ShopModel model)
        {
            this.model = model;
        }
        ShopModel model;
        public string GetTitle() => model.Title;
        public string GetDescription() => model.Description;
        public Item BuyItem(string itemType, string itemName)
        {
            return itemType switch
            {
                ("boots") => EBotBoots.ToList().Find(item => item.Name == itemName),
                ("hat") => EBotHats.ToList().Find(item => item.Name == itemName),
                ("jacket") => EBotJackets.ToList().Find(item => item.Name == itemName),
                ("pants") => EBotPants.ToList().Find(item => item.Name == itemName),
                _ => throw new Exception(),
            };
        }
    }
}
