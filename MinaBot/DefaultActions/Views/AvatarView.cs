using System.Linq;
using Discord;
using MinaBot.Main;
using MinaBot.Models;

namespace MinaBot.DefaultActions.Views
{
    public class AvatarView : IView
    {
        private CommandModel _command;
        public MessageResult GetView(CommandModel cmdModel)
        {
            _command = cmdModel;
            return new MessageResult.EmbedView(ConstructEmbed());
        }

        public Embed ConstructEmbed()
        {
            var content = _command.GetMessage.Content.Split();
            var embed = new EmbedBuilder();
            if (content.Length == 1)
            {
                embed.ImageUrl = _command.GetMessage.Author.GetAvatarUrl();
                embed.Title = ((IGuildUser) _command.GetMessage.Author).Nickname;
            }
            else
            {
                var user = _command.GetMessage.MentionedUsers.First();
                embed.ImageUrl = user.GetAvatarUrl();
                embed.Title = user.Username;
                embed.Description = user.Discriminator;
            }
            return embed.Build();
        }
    }
}