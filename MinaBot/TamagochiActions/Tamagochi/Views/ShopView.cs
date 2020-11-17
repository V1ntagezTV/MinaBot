using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MessageResult GetView(CommandModel cmdModel)
        {
            var embed = new EmbedBuilder()
            {
                Title = "SecretShop! :convenience_store:",
                Description = ":shopping_cart: Buy items with `m!pet buy {itemIndex}`\n" +
                              $"**Update time:** {ShopJsonController.GetConfigValuesAsync().UpdateDate.ToShortTimeString()}",
                Color = Color.Orange
            };
            var embedFields = _GetShopFields(ShopJsonController.GetItems());
            foreach (var field in embedFields)
            {
                embed.AddField(field);
            }
            return new MessageResult.EmbedView(embed.Build());
        }

        private EmbedFieldBuilder _GetShopField(Item[] shopItems)
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

        private EmbedFieldBuilder[] _GetShopFields(Item[] shopItems)
        {
            var fields = new EmbedFieldBuilder[6];
            for (var ind = 0; ind < shopItems.Length; ind++)
            {
                var item = shopItems[ind];
                fields[ind] = new EmbedFieldBuilder()
                {
                    Name = item.Name,
                    Value = $"————\n:id: {item.Id} \n :dollar: {item.Price} \n :gem: {item.Rarity}",
                    IsInline = true
                };
            }
            return fields;
        }
    }
}