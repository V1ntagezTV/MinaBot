using Discord;
using MinaBot.DefaultActions.Models;
using MinaBot.Main;
using MinaBot.Models;
using System;
using static MinaBot.MessageResult;

namespace MinaBot.DefaultActions.Views
{
    class PastView : IView
    {
        PasteModel paste;
        public PastView(PasteModel paste)
        {
            this.paste = paste;
        }

        public MessageResult GetView(CommandModel cmdModel)
        {
            return new EmbedView(GetEmbed());
        }

        public Embed GetEmbed()
        {
            //var footer = new EmbedFooterBuilder() { IconUrl = paste.Author.GetAvatarUrl(), Text = paste.Author.ToString() };
            var embed = new EmbedBuilder()
            {
                Title = $"**{paste.Prefix}**",
                Color = new Color((uint)Convert.ToInt32("f47e17", 16))
            };
            if (paste.isLink)
            {
                embed.ImageUrl = paste.Text;
                embed.Description = paste.Desc;
            }
            else
            {
                embed.Description = paste.Text;
            }
            return embed.Build();
        }
    }
}
