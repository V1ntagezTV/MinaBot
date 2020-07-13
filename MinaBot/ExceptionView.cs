using Discord;
using MinaBot.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Views
{
    class ExceptionView : IView
    {
        IMessage message = null;
        public ExceptionView(IMessage message)
        {
            this.message = message;
        }

        public IController GetController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Embed ConstructInfoEmbed()
        {
            throw new NotImplementedException();
        }

        public Embed ConstructMainEmbed()
        {
            var builder = new EmbedBuilder();
            builder.Title = "Unexpected command.";
            builder.Color = Color.Red;
            builder.Author = new EmbedAuthorBuilder()
            {
                Name = message.Author.Username,
                IconUrl = message.Author.GetAvatarUrl()
            };
            return builder.Build();
        }
    }
}
