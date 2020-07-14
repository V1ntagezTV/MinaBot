using Discord;
using MinaBot.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Views
{
    class ExceptionView : IView
    {
        public IController GetController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EmbedFieldBuilder[] CommandFieldSettings(string[] commandOptions)
        {
            throw new NotImplementedException();
        }

        public Embed ConstructInfoEmbed()
        {
            throw new NotImplementedException();
        }

        public Embed ConstructMainEmbed()
        {
            var builder = new EmbedBuilder();
            builder.Title = "Unexpected command.";
            builder.Color = Color.Red;
            return builder.Build();
        }
    }
}
