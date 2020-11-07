using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using Microsoft.Extensions.Primitives;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    public class ShopView : IView
    {
        private EmbedBuilder _embed;

        public ShopView()
        {
            _embed = new EmbedBuilder()
            {
                Title = "**SecretShop!**",
                Description = "Buy items with `m!pet buy {itemIndex}`.",
                Color = Color.Orange
            };
        }
        public MessageResult GetView(CommandModel cmdModel)
        {
            EmbedFieldBuilder fields;
            if (cmdModel.GetArgs == null)
            {
                fields = _GetShopFields(ItemMocks.AllItems.ShopList());
            }
            else
            {
                fields = cmdModel.GetArgs[0] switch
                {
                    "foods" => _GetShopFields(ItemMocks.Foods.ShopList()),
                    "hats" => _GetShopFields(ItemMocks.Hats.ShopList()),
                    "jackets" => _GetShopFields(ItemMocks.Jackets.ShopList()),
                    "boots" => _GetShopFields(ItemMocks.Boots.ShopList()),
                    "pants" => _GetShopFields(ItemMocks.Pants.ShopList()),
                    _ => throw new NotImplementedException()
                };
            }
            _embed.AddField(fields);
            return new MessageResult.EmbedView(_embed.Build());
        }

        private EmbedFieldBuilder _GetShopFields(IEnumerable<Item> shopItems)
        {
            var itemNames = new StringBuilder();
            for (var ind = 0; ind < shopItems.Count(); ind++)
            {
                var item = shopItems.ElementAt(ind);
                var indStr = item.ID >= 10 ? $"{item.ID}" : $"0{item.ID}";
                itemNames.Append($"`{indStr}` {item.Name} — :dollar: `{item.Price}.00` —  :gem: {item.Rarity}\n");  
            }
            return new EmbedFieldBuilder() { Name = "**Item/Index:**", Value = itemNames, IsInline = true };
        }
    }
}