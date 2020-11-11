using Discord;
using MinaBot.DefaultActions.Models;
using MinaBot.Main;
using MinaBot.Models;
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
            var embed = new EmbedBuilder() { Title = $"**Pasta: {paste.Prefix}**",
                Description= "https://media.discordapp.net/attachments/587316273013063712/773693633698201600/unknown.png"
                ImageUrl = @"https://media.discordapp.net/attachments/587316273013063712/773693633698201600/unknown.png"
            };
            return embed.Build();
        }
    }
}
