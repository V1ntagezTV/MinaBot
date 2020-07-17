using Discord;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IView
    {
        MessageResult ConstructMainEmbed();
        MessageResult ConstructInfoEmbed();
        public MessageResult ChooseMessageResult(CommandModel command);
    }
}
