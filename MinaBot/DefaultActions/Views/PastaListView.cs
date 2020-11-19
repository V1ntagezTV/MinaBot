using Discord;
using MinaBot.DefaultActions.Models;
using MinaBot.Main;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.DefaultActions.Views
{
    class PastaListView : IView
    {
        private QuoteModel[] yourQuotes;

        public PastaListView(QuoteModel[] yourQuotes)
        {
            this.yourQuotes = yourQuotes;
        }

        public MessageResult GetView(CommandModel cmdModel)
        {
            var embed = new EmbedBuilder()
            {
                Description = ":spaghetti: **Pasta list**",
                Color = new Color((uint)Convert.ToInt32("f47e17", 16))
            };
            for (int i = 0; i < yourQuotes.Length; i++)
            {
                string content;
                if (yourQuotes[i].isLink)
                {
                    content = $"[Link]({yourQuotes[i].Text})";
                } else
                {
                    content = yourQuotes[i].Text;
                }
                embed.AddField(new EmbedFieldBuilder()
                {
                    Name = yourQuotes[i].Prefix,
                    Value = content
                });
            }
            if (yourQuotes.Length == 0)
            {
                embed.AddField(new EmbedFieldBuilder()
                {
                    Name = "You dont have any pasta.",
                    Value = "Use **m!addpasta** to save in your list.\n`m!addpasta <prefix> <text>`\n`m!addpasta <prefix> <text> <image-link>`"
                });
            }
            embed.Footer = new EmbedFooterBuilder() 
            {
                IconUrl = cmdModel.GetMessage.Author.GetAvatarUrl(), 
                Text = $"pastas by {cmdModel.GetMessage.Author}"
            };
            return new MessageResult.EmbedView(embed.Build());
        }
    }
}
