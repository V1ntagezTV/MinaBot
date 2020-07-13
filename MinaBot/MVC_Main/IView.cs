using Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IView
    {
        abstract IController GetController { get; set; }
        Embed ConstructMainEmbed();
        Embed ConstructInfoEmbed();
        EmbedFieldBuilder[] CommandFieldSettings(string[] commandOptions);
    }
}
