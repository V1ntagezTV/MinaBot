using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using Microsoft.Extensions.Primitives;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Main;
using MinaBot.Models;
using MinaBot.TamagochiActions.Shop;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes;
using MinaBot.TamagochiActions.Tamagochi.ItemsPack.ItemTypes.ItemsJson;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    public class ShopView : IView
    {
        private EmbedBuilder _embed;

        public ShopView()
        {
            _embed = new EmbedBuilder()
            {
                Title = "**SecretShop! :convenience_store:**",
                Description = ":shopping_cart: Buy items with `m!pet buy {itemIndex}`.",
                Color = Color.Orange
            };
        }
        public MessageResult GetView(CommandModel cmdModel)
        {
            EmbedFieldBuilder fields = _GetShopFields(ShopJsonController.items);
            _embed.AddField(fields);
            return new MessageResult.EmbedView(_embed.Build());
        }

        private EmbedFieldBuilder _GetShopFields(Item[] shopItems)
        {
            var itemNames = new StringBuilder();
            for (var ind = 0; ind < shopItems.Count(); ind++)
            {
                var item = shopItems.ElementAt(ind);
                var indStr = item.Id >= 10 ? $"{item.Id}" : $"0{item.Id}";
                itemNames.Append($"`{indStr}` {item.Name} — :dollar: `{item.Price}.00` —  :gem: {item.Rarity}\n");  
            }
            return new EmbedFieldBuilder() { Name = "**Item/Index:**", Value = itemNames, IsInline = true };
        }
    }
}