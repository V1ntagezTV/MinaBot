using Discord;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IView
    {
        EmbedBuilder ConstructMainEmbed();
        EmbedBuilder ConstructInfoEmbed();
        public MessageResult ChooseMessageResult(CommandModel command);
    }
}
