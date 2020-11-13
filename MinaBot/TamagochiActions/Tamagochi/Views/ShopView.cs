using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using Microsoft.Extensions.Primitives;
using MinaBot.BotTamagochi.ItemsPack;
using MinaBot.Main;
using MinaBot.Models;
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
                fields = _GetShopFields(ItemMocks.AllItems.ShopList().ToArray());
            }
            else
            {
                var contr = new ItemsJsonController().GetConfigValuesAsync().Result; 
                fields = cmdModel.GetArgs[0] switch
                {
                    "foods" => _GetShopFields(contr.Meals.ToArray()),
                    "hats" => _GetShopFields(contr.Hats.ToArray()),
                    "jackets" => _GetShopFields(contr.Jackets.ToArray()),
                    "boots" => _GetShopFields(contr.Boots.ToArray()),
                    "pants" => _GetShopFields(contr.Pants.ToArray()),
                    "liquid" => _GetShopFields(contr.Liquids.ToArray()),
                    _ => throw new ArgumentException()
                };
            }
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