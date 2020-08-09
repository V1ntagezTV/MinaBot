using Discord;
using MinaBot.BotTamagochi.ItemsPack;
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
            var hat = ItemMocks.AllItems[tamagochi.HatID];
            var jacket = ItemMocks.AllItems[tamagochi.JacketID];
            var pants = ItemMocks.AllItems[tamagochi.PantsID];
            var boots = ItemMocks.AllItems[tamagochi.BootsID];
            var embed = new EmbedBuilder();
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Clothes**",
                Value = ">>> " + hat.Name +"\n"+ jacket.Name + "\n"
                + pants.Name + "\n" + boots.Name,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Price**",
                Value = ">>> " + hat.Price + "\n" + jacket.Price + "\n" +
                    pants.Price + "\n" + boots.Price,
                IsInline = true
            });
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**SoldPrice**",
                Value = ">>> " + hat.SoldPrice + "\n" + jacket.SoldPrice + "\n" +
                    pants.SoldPrice + "\n" + boots.SoldPrice,
                IsInline = true
            });
            return embed.Build();
        }
    }
}
