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
        QuoteModel _quote;
        public PastView(QuoteModel quote)
        {
            this._quote = quote;
        }

        public MessageResult GetView(CommandModel cmdModel)
        {
            return new EmbedView(GetEmbed());
        }

        public Embed GetEmbed()
        {
            var author = Program.client.GetUser((ulong) _quote.Author.DiscordId);
            var footer = new EmbedFooterBuilder() { IconUrl = author.GetAvatarUrl(), Text = $"created by {author}" };
            var embed = new EmbedBuilder()
            {
                Title = $":spaghetti: **{_quote.Prefix}**",
                Color = new Color((uint)Convert.ToInt32("f47e17", 16)),
                Footer = footer
            };
            if (_quote.isLink)
            {
                embed.ImageUrl = _quote.Text;
                embed.Description = _quote.Desc;
            }
            else
            {
                embed.Description = _quote.Text; 
            }
            return embed.Build();
        }
    }
}
