using Discord;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class ClothesView : IView
    {
        public MessageResult GetView(TamagochiModel tamagochi, CommandModel message = null)
        {
            return new EmbedView<Embed>(ConstructMainEmbed(tamagochi, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel tamagochi, CommandModel message)
        {
            var embed = new EmbedBuilder();
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Clothes**",
                Value = ">>> " + tamagochi.Clothes.ToString(),
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Price**",
                Value = ">>> " + tamagochi.Clothes.Hat.Price + "\n" + tamagochi.Clothes.Jacket.Price + "\n" +
                    tamagochi.Clothes.Pants.Price + "\n" + tamagochi.Clothes.Boots.Price,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**SoldPrice**",
                Value = ">>> " + tamagochi.Clothes.Hat.SoldPrice + "\n" + tamagochi.Clothes.Jacket.SoldPrice + "\n" +
                    tamagochi.Clothes.Pants.SoldPrice + "\n" + tamagochi.Clothes.Boots.SoldPrice,
                IsInline = true
            });
            return embed.Build();
        }
    }
}
