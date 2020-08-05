using Discord;
using MinaBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinaBot.Main
{
    interface IView
    {
        public MessageResult GetView(TamagochiModel tamagochi, CommandModel message);
    }
}
