using Discord;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MinaBot.MessageResult;

namespace MinaBot.BotTamagochi.MVC.Tamagochi.View
{
    class InventoryView : IView
    {
        public MessageResult GetView(TamagochiModel tamagochi, CommandModel message=null)
        {
            return new EmbedView<Embed>(ConstructMainEmbed(tamagochi, message));
        }

        private Embed ConstructMainEmbed(TamagochiModel tamagochi, CommandModel message)
        {
            var embed = new EmbedBuilder();
            embed.Color = Color.Green;
            embed.AddField(new EmbedFieldBuilder()
            {
                Name = "**Inventory:**",
                Value = ">>> " + tamagochi.Backpack.ToString()
            });
            return embed.Build();
        }
    }
}
